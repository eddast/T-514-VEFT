const { PickupGames, Players } = require('../data/db');
const { getBasketballFieldById } = require('../services/basketballFieldService');
const { ValidationError } = require('../errors');   // custom errors
const { NotFoundError, InternalServerError, BadRequest } = require('../errors'); // general errors
const { PickupGameOverlapError, BasketballFieldClosedError, PickupGameAlreadyPassedError, PickupGameExceedMaximumError } = require('../errors'); // system specific errors



/****************************************
 *                                      *
 *      RESOLVERS FOR PICKUP GAMES      *
 *                                      *
 ****************************************/


module.exports = {

    queries: {

        /**
         * Gets collection of all pickup games in system
         * Throws internal server error if fetch cannot be conducted
         * @return (promise of) collection of all games in system when fetched from MongoDB
         */
        allPickupGames: () =>
            new Promise((res, err) =>
                PickupGames.find({}, (error, games) => error ? err(new InternalServerError(false)) : res(games)))
                .then(games => games)
                .catch(error => { throw error; }),

        /**
         * Gets basketball field by ID
         * Throws not found error if no game is found by ID
         * Throws bad request error if id is improperly formatted
         * Throws internal server error if fetch cannot be conducted
         * @param parent pointer to root i.e. result of the previous call (unused)
         * @param args query argument, should contain required id parameter for pickup game
         * @return (promise of) a single game by id when fetched from MongoDB
         */
        pickupGame: (parent, args) =>
            new Promise((res, err) => {
                const { id } = args;
                PickupGames.findById(id, (error, game) => {
                    // Validate that id is valid and that game exists with that id
                    if (error || game === null) {
                        analyseMongoDBFetchError(game, error, id, err, 'PickupGame');
                    } else res(game);
                })
            }).then(game => game).catch(error => { throw error }),

    },

    mutations: {

        /**
         * Creates new pickup game into the system
         * Throws error if any errors occur adding to system
         * GraphQL does input model validation automatically
         * @param parent pointer to root i.e. result of the previous call (unused)
         * @param args query argument, should contain required input model for pickup game
         * @return (promise of) the new player that was added to MongoDB database
         */
        createPickupGame: (parent, args) =>
            new Promise((res, err) => {
                const { basketballFieldId, hostId } = args.input;
                const start = args.input.start.value;
                const end = args.input.end.value;
                getBasketballFieldById(basketballFieldId).then(field => {
                    resolveBasketballField(field, hostId, start, end, res, err);
                }).catch(fieldErr => err(fieldErr))
            }).then(game => game).catch(error => { throw error; }),

        /**
         * Removes pickup game from the system by id
         * Throws error if any errors occur deleting from system
         * @param parent pointer to root i.e. result of the previous call (unused)
         * @param args query argument, should contain required id parameter for pickup game
         * @return (promise of) a boolean indicating success for operation
         */
        removePickupGame: (parent, args) =>
            new Promise((res, err) => {
                const { id } = args;
                PickupGames.findById(id, (error, game) => {
                    if (error || game === null) analyseMongoDBFetchError(game, error, id, err, 'PickupGame');
                    else deletePickupGame(id, res, err);
                });
            }).then(success => success).catch(error => { throw error; }),

        /**
         * Adds existing player to existing pickup game within the system
         * Does so by registering player to the pickup game's registered players
         * and the pickup game to the player's playedGames
         * Throws error if either game or player is not found by their ids
         * Throws error if game is passed in which case player cannot be added to it
         * Throws error if game has reached it maximum player capacity
         * @param parent pointer to root i.e. result of the previous call (unused)
         * @param args query argument, should contain required id parameter for pickup game
         * @return (promise of) the pickup game player is being added to
         */
        addPlayerToPickupGame: (parent, args) =>
            new Promise((res, err) => {
                const { playerId, pickupGameId } = args.input;
                PickupGames.findById(pickupGameId, (error, game) => {
                    if (error || game === null) analyseMongoDBFetchError(game, error, pickupGameId, err, 'PickupGame');
                    else resolvePickupGameAddPlayers(playerId, pickupGameId, game, res, err);
                })
            }).then(game => game).catch(error => { throw error }),

        /**
         * Removes existing player to existing pickup game within the system if player is in that game
         * Does so by removing the player from the pickup game's registered players
         * and removing the pickup game from the player's playedGames
         * Throws error if either game or player is not found by their ids
         * Throws error if game is passed in which case player cannot be removed from it
         * @param parent pointer to root i.e. result of the previous call (unused)
         * @param args query argument, should contain required id parameter for pickup game
         * @return (promise of) the pickup game player is being removed from
         */
        removePlayerFromPickupGame: (parent, args) =>
            new Promise((res, err) => {
                const { playerId, pickupGameId } = args.input;
                PickupGames.findById(pickupGameId, (error, game) => {
                    if (error || game === null) analyseMongoDBFetchError(game, error, pickupGameId, err, 'PickupGame');
                    else resolveRemovePlayerFromPickupGame(playerId, game, res, err);
                })
            }).then(game => game).catch(error => { throw error }),

    },

    types: {

        PickupGame: {

            /* Fetch basketball field by id for obtaining location using database model's fieldlocationId  */
            location: (parent) =>
                getBasketballFieldById(parent.fieldLocationId).then(field => field).catch(err => { throw err; }),

            /* Fetch registered players of game by fetching all players whose ids are in database model's registeredPlayersIds */
            registeredPlayers: (parent) =>
                new Promise((res, err) =>
                    Players.find({ _id: { $in: parent.registeredPlayersIds } }, (error, players) => error ? err(new InternalServerError(false)) : res(players)))
                    .then(players => players)
                    .catch(error => { throw error; }),

            /* Fetch host as player by database model's hostId */
            host: (parent) =>
                new Promise((res, err) =>
                    Players.findById(parent.hostId,
                        (error, host) => error ? err(new InternalServerError(false)) : res(host)))
                    .then(host => host)
                    .catch(error => { throw error; }),
        }
    }
}



/********************************
 *                              *
 *      HELPER FUNCTIONS        *
 *                              *
 ********************************/


/**
 * Analyses the sort of error that has occured when fetching from MongoDB
 * Callbacks err function when analysis is complete
 * @param {any} resource the resource returned from search
 * @param {any} error error present in system
 * @param {string} id parameter id passed in to search for game
 * @param {function} err promise callback error function from parent function 
 * @param {string} resourceName name of resource that was queried
 */
const analyseMongoDBFetchError = (resource, error, id, err, resourceName) => {
    if (resource === null) err(new NotFoundError(`${resourceName} with id ${id} not found in system`));
    else if (error.name === "CastError") err(new BadRequest(`Id ${id} was not properly formatted as ObjectId for ${resourceName} (must be a string of 24 characters)`));
    else err(new InternalServerError(false));
}

/**
 * Checks if a given basketball field is closed
 * If not, check if host specified actually exists
 * If so, check for game overlap on field
 * @param {any} field the basketball field
 * @param {number} hostId id of player to be host
 * @param {Date} start start date of new game
 * @param {Date} end end date of new game
 * @param {function} res parent promise resolver function called on success
 * @param {function} err parent promise error function called on error
 */
const resolveBasketballField = (field, hostId, start, end, res, err) => {
    if (field.status === "CLOSED") err(new BasketballFieldClosedError());
    else {
        // Validate that host for host id provided exists and that id is on valid form
        Players.findById(hostId, (error, player) => {
            if (error || player === null) {
                analyseMongoDBFetchError(player, error, hostId, err, 'Player (host)');
            } else {
                // For each game held on same field, check for overlap.
                // Throw error if new entry causes overlap
                PickupGames.find({ fieldLocationId: field.id }, (error, games) => {
                    if (error) err(new InternalServerError(false));
                    else if (games === null) err(new InternalServerError(false));
                    else {
                        resolveGames(games, start, end, field.id, hostId, res, err)
                    }
                });
            }
        });
    }
}

/**
 * Checks for date overlap in games given all games for a field
 * If no overlap, add new pickup game to system
 * @param {any} games all games on a given field
 * @param {Date} start start date of new game
 * @param {Date} end end date of new game
 * @param {number} basketballFieldId field id on which new game is to be held
 * @param {number} hostId id of player to host new game
 * @param {function} res parent promise resolver function called on success
 * @param {function} err parent promise error function called on error
 */
const resolveGames = (games, start, end, basketballFieldId, hostId, res, err) => {
    let hasOverlap = false;
    games.map(g => {
        if ((new Date(g.start).getTime() <= new Date(end).getTime()) &&
            (new Date(start).getTime() <= new Date(g.end).getTime())) {
            err(new PickupGameOverlapError()); hasOverlap = true; return;
        }
    });
    if(!hasOverlap) {
        new PickupGames({ start: start, end: end, fieldLocationId: basketballFieldId, registeredPlayersIds: [], hostId: hostId }).save((error, game) => {
            if (error) {
                if (error.name === "ValidationError") err(new ValidationError(error));
                else err(new InternalServerError(false));
            } else res(game);
        });
    }
}

/**
 * Deletes game and all embedded resources as cascading effect
 * e.g. remove the deleted game from playedGames for all players
 * Then solve true for delete success
 * @param {number} id id of pick up game to delete
 * @param {function} res parent promise resolver function called on success
 * @param {function} err parent promise error function called on error
 */
const deletePickupGame = (id, res, err) =>
    PickupGames.deleteOne({ _id: id }, (deleteError) => {
        if (deleteError) err(new InternalServerError(false));
        else {
            Players.find({ playedGamesIds: id }, (cascadeError, players) => {
                if (cascadeError) err(new InternalServerError(false))
                else { players.map(p => { p.playedGamesIds.splice(p.playedGamesIds.indexOf(id), 1); p.save(); }); res(true); }
            });
        }
    });

/**
 * Checks if player being added to game exists
 * Then attempt to add player to game 
 * Throws not found error if player is not found by id
 * @param {number} playerId id of player to add to game
 * @param {number} pickupGameId id of game to add player to
 * @param {any} game 
 * @param {function} res parent promise resolver function called on success
 * @param {function} err parent promise error function called on error
 */
const resolvePickupGameAddPlayers = (playerId, pickupGameId, game, res, err) =>
    Players.findById(playerId, (perror, player) => {
        if (perror || player === null) analyseMongoDBFetchError(player, perror, playerId, err, 'Player');
        else resolveAddPlayers(game, player, res, err);
    });

/**
 * Checks if max capacity is reached for field before adding player to game and if game has passed
 * Then check player is already in game they're attempted to get added to
 * Throws exceed maximum error if max capacity is exceeded for field
 * Throws already passed error if game has already passed
 * Throws bad request error if player is already in game
 * @param {any} game game to add player to
 * @param {any} player player to add to game 
 * @param {function} res parent promise resolver function called on success
 * @param {function} err parent promise error function called on error
 */
const resolveAddPlayers = (game, player, res, err) => {
    if (new Date(game.end).getTime() < new Date().getTime()) err(new PickupGameAlreadyPassedError())
    else if (game.registeredPlayersIds.indexOf(player._id) > -1) err(new BadRequest('Player is already signed up for pickup game'));
    else {
        getBasketballFieldById(game.fieldLocationId).then(field => {
            if (field.capacity <= game.registeredPlayersIds.length) err(new PickupGameExceedMaximumError());
            else {
                game.registeredPlayersIds.push(player._id); game.save();
                player.playedGamesIds.push(game._id); player.save();
                res(game);
            }
        }).catch(err => { throw err; })
    }
}

/**
 * Validates that player exists and is not already signed up for game and that pickup game has not passed
 * If none applies, removes player from a given pickup game
 * Throws not found error if player is not found by id
 * Throws already passed error if game has already passed
 * Throws bad request error if player is already signed up for game
 * @param {number} playerId id of player to remove from pickup game
 * @param {any} game game to remove player from
 * @param {function} res parent promise resolver function called on success
 * @param {function} err parent promise error function called on error
 */
const resolveRemovePlayerFromPickupGame = (playerId, game, res, err) =>
    Players.findById(playerId, (perror, player) => {
        if (perror || player === null) analyseMongoDBFetchError(player, perror, playerId, err, 'Player');
        else {
            if (new Date(game.end).getTime() < new Date().getTime()) err(new PickupGameAlreadyPassedError());
            else if (game.registeredPlayersIds.indexOf(playerId) === -1) err(new BadRequest('Cannot remove: Player is not signed up for this pickup game'));
            else {
                game.registeredPlayersIds.splice(game.registeredPlayersIds.indexOf(playerId), 1); game.save();
                player.playedGamesIds.splice(player.playedGamesIds.indexOf(game._id), 1); player.save();
                res(game);
            }
        }
    });