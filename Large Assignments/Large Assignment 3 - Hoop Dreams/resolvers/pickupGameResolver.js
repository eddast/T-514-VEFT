const { PickupGames, Players } = require('../data/db');
const { getBasketballFieldById } = require('../services/basketballFieldService');
const {
  NotFoundError,
  InternalServerError,
  BadRequest,
  PickupGameOverlapError,
  BasketballFieldClosedError,
  PickupGameAlreadyPassedError,
  ValidationError,
  PickupGameExceedMaximumError
} = require('../errors');

/****   Common Functions   ****/
const throwPickUpGameError = (game, error, pickupGameId, err) => {
  if(game === null) err(new NotFoundError(`Pickup game with id ${ pickupGameId } not found in system`));
  else if(error.name === "CastError") err(new BadRequest(`Parameter pickupGameId ${ pickupGameId } was not properly formatted as ObjectId (must be a string of 24 characters)`));
  else err(new InternalServerError(false));
}

const throwPlayerError = (player, error, playerId, err) => {
    if(player === null) err(new NotFoundError(`Player with id ${ playerId } not found in system and cannot be set as host for game`));
    else if(error.name === "CastError") err(new BadRequest(`Id ${ playerId } is not properly formatted as ObjectId (must be a string of 24 characters)`));
    else err(new InternalServerError(false));
}

/****   Helper Functions   ****/
const resolveBasketballField = (field, hostId, basketballFieldId, start, end, res, err) => {
    if(field.status === "CLOSED") err(new BasketballFieldClosedError());
    // Validate that host for host id provided exists and that id is on valid form
    Players.findById(hostId, (error, player) => {
        if(error || player === null) {
            throwPlayerError(player, error, hostId, err);
        } else {
            // For each game held on same field, check for overlap.
            // Throw error if new entry causes overlap
            PickupGames.find({ fieldLocationId: basketballFieldId}, (error, games) => {
                if(error) err(new InternalServerError(false));
                else if(games === null) err(new InternalServerError(false));
                else {
                    resolveGames(games, start, end, basketballFieldId, hostId, error, res, err)
                }
            });
        }
    });
}

const resolveGames = (games, start, end, basketballFieldId, hostId, error, res, err) => {
    games.map(g => {
        if( (new Date(g.start).getTime() <= new Date(end).getTime()) &&
            (new Date(start).getTime() <= new Date(g.end).getTime()) ) {
            err(new PickupGameOverlapError());
        }
    });
    // Attempt to create new pickup game if both field and host is validated OK
    new PickupGames({ start: start, end: end, fieldLocationId: basketballFieldId, registeredPlayersIds: [], hostId: hostId }).save((error, game) => {
        if (error) {
            if(error.name === "ValidationError") err(new ValidationError(error));
            else err(new InternalServerError(false));
        } else res(game);
    });
}

const deletePickupGame = (id, game, res, err) => {
    PickupGames.deleteOne({ _id: id }, (deleteError) => {
        if(deleteError) err(new InternalServerError(false));

        // After deleting game, delete all embedded resources as cascading effect
        // e.g. remove deleted game from playedGames for players
        // Then return true for delete success
        else {
            Players.find({ playedGamesIds: game._id}, (cascadeError, players) => {
            if(cascadeError) err(new InternalServerError(false))
            else { players.map(p => { p.playedGamesIds.splice(p.playedGamesIds.indexOf(game.id), 1); p.save();}); res(true); }
            });
        }
    });
}

const resolvePickupGameAddPlayers = (playerId, pickupGameId, game, res, err) => {
    // Validate that player is valid and that player exists with that id
    Players.findById(playerId, (perror, player) => {
        // Validate that id is valid and that game exists with that id
        if(perror || player === null) {
            throwPlayerError(player, perror, playerId, err)
        // If player and game is valid check if game has passed, max capacity is reached
        // Or player is already in game and throw appropriate errors, otherwise add player to game
        } else {
            resolveAddPlayers(playerId, pickupGameId, game, player, res, err);
        }
    })
}

const resolveAddPlayers = (playerId, pickupGameId, game, player, res, err) => {
    if(new Date(game.end).getTime() < new Date().getTime()) err(new PickupGameAlreadyPassedError())
    else if (game.registeredPlayersIds.indexOf(playerId) > -1) err(new BadRequest('Player is already signed up for pickup game'));
    else {
        getBasketballFieldById(game.fieldLocationId).then(field => {
            if(field.capacity <= game.registeredPlayersIds.length) err(new PickupGameExceedMaximumError());
            else {
                game.registeredPlayersIds.push(playerId); game.save();
                player.playedGamesIds.push(pickupGameId); player.save();
                res(game);
            }
        }).catch(err => { throw err; })
    }
}

const resolveRemovePlayerFromPickupGame = (playerId, pickupGameId, game, res, err) => {
    // Validate that player is valid and that player exists with that id
    Players.findById(playerId, (perror, player) => {
        if(perror || player === null) {
            throwPlayerError(player, perror, playerId, err)
        // If both ids are valid and match resources from database, check if game is passed 
        // And whether user is part of the game, then delete user from game
        } else {
            if(new Date(game.end).getTime() < new Date().getTime()) err(new PickupGameAlreadyPassedError());
            else if (game.registeredPlayersIds.indexOf(playerId) === -1) err(new BadRequest('Cannot remove: Player is not signed up for this pickup game'));
            else {
                game.registeredPlayersIds.splice(game.registeredPlayersIds.indexOf(playerId), 1); game.save();
                player.playedGamesIds.splice(player.playedGamesIds.indexOf(pickupGameId), 1); player.save();
                res(game);
            }
        }
    })
}

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
        const { id } = args;
        PickupGames.findById(id, (error, game) => {
          // Validate that id is valid and that game exists with that id
          if(error || game === null) {
            throwPickUpGameError(game, error, id, err);
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

        // Validate that basketball field provided exists and is open
        getBasketballFieldById(basketballFieldId).then(field => {
            resolveBasketballField(field, hostId, basketballFieldId, start, end, res, err);
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
        // Validate that a player with the id provided exists and that id is valid
        if(error || game === null) {
          throwPickUpGameError(game, error, id, err);
        // if player was found by id, delete player
        } else {
            deletePickupGame(id, game, res, err);
          }
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
    // tekur inn signuplayerinput og skilar PickupGame!
    addPlayerToPickupGame: (parent, args) => 
      new Promise((res, err) => {
        const { playerId, pickupGameId } = args.input;
        PickupGames.findById(pickupGameId, (error, game) => {
          // Validate that id is valid and that game exists with that id
          if(error || game === null) {
            throwPickUpGameError(game, error, pickupGameId, err);
          } else {
            resolvePickupGameAddPlayers(playerId, pickupGameId, game, res, err);
          }
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
    // tekur inn signuplayerinput og skilar PickupGame!
    removePlayerFromPickupGame: (parent, args) =>
      new Promise((res, err) => {
        const { playerId, pickupGameId } = args.input;
        // Validate that id is valid and that game exists with that id
        PickupGames.findById(pickupGameId, (error, game) => {
          if(error || game === null) {
            throwPickUpGameError(game, error, pickupGameId, err);
          } else {
            resolveRemovePlayerFromPickupGame(playerId, pickupGameId, game, res, err);
          }
        })
      }).then(game => game).catch(error => { throw error }),

  },

  types : {

    PickupGame : {

      /* Fetch basketball field by id for obtaining location using database model's fieldlocationId  */
      location : (parent) =>
        getBasketballFieldById(parent.fieldLocationId).then(field => field).catch(err => { throw err; }),
      
      /* Fetch registered players of game by fetching all players whose ids are in database model's registeredPlayersIds */
      registeredPlayers : (parent) =>
        new Promise((res, err) =>
          Players.find({ _id: { $in: parent.registeredPlayersIds } },(error, players) => error ? err(new InternalServerError(false)) : res(players)))
          .then(players => players)
          .catch(error => { throw error; }),
      
      /* Fetch host as player by database model's hostId */
      host : (parent) =>
        new Promise((res, err) =>
          Players.findById(parent.hostId,
            (error, host) => error ? err(new InternalServerError(false)) : res(host)))
          .then(host => host)
          .catch(error => { throw error; }),
    }
  }
}