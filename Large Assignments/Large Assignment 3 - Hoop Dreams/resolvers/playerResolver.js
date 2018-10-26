const { NotFoundError, InternalServerError, BadRequest } = require('../errors');
const { Players, PickupGames } = require('../data/db');

module.exports = {

  queries: {

    /**
     * Gets a collection of all players in system
     * Throws internal server error if fetch cannot be conducted
     * @return (promise of) collection of all players when fetched from MongoDB
     */
    allPlayers: () => 
      new Promise((res, err) => 
        Players.find({}, (error, players) => error ? err(new InternalServerError(false)) : res(players)))
        .then(players => players)
        .catch(error => { throw error; }),

    /**
     * Gets player by ID
     * Throws not found error if no player is found by ID
     * Throws bad request error if id is improperly formatted
     * Throws internal server error if fetch cannot be conducted
     * @param parent pointer to root i.e. result of the previous call (unused)
     * @param args query argument, should contain required id parameter for pickup game
     * @return (promise of) a single player by id when fetched from MongoDB
     */
    player: (parent, args) =>
      new Promise((res, err) => {
        const { id } = args;
        Players.findById(id, (error, player) => {
          // Validate that id is valid and that player exists with that id
          if(error || player === null) {
            if(player === null) err(new NotFoundError(`Player with id ${ id } not found in system`));
            else if(error.name === "CastError") err(new BadRequest(`Id ${ id } is not properly formatted as ObjectId (must be a string of 24 characters)`))
            else err(new InternalServerError(false))
          } else res(player);
        })
      }).then(player => player).catch(error => { throw error; }),

  },

  mutations: {

    /**
     * Creates new player into the system
     * GraphQL does input model validation automatically
     * Throws internal server error if any errors occur adding to system
     * @param parent pointer to root i.e. result of the previous call (unused)
     * @param args query argument, should contain required id parameter for pickup game
     * @return (promise of) the new player that was added to MongoDB database
     */
    createPlayer: (parent, args) => 
      new Promise((res, err) => {
        const { name } = args.input;
        var newPlayer = new Players({ name: name });
        newPlayer.save((error, player) => {
          if(error) {
            if(error.name === "ValidationError") err(new ValidationError(error));
            else err(new InternalServerError(false));
          } else res(player);
        });
      }).then(player => player).catch(error => { throw error; }),

    /**
     * Updates existing player in the system
     * GraphQL does input model validation automatically
     * Throws not found error if no player is found by ID
     * Throws bad request error if id is improperly formatted
     * Throws internal server error if fetch cannot be conducted
     * @param parent pointer to root i.e. result of the previous call (unused)
     * @param args query argument, should contain required id parameter for pickup game
     * @return (promise of) the updated player that was just updated to MongoDB database
     */
    updatePlayer: (parent, args) => 
      new Promise((res, err) => {
        const { id, input } = args;
        Players.findById(id, (error, playerToUpdate) => {
          // Validate that id is valid and that player exists with that id
          if(error || playerToUpdate === null) {
            if(playerToUpdate === null) err(new NotFoundError(`Player with id ${ id } not found in system`));
            else if(error.name === "CastError") err(new BadRequest(`Parameter id ${ id } was not properly formatted as ObjectId (must be a string of 24 characters)`))
            else err(new InternalServerError(false));
          } else {
            // If id was valid and corresponded to player in system,
            // Attempt to update player's fields in system
            playerToUpdate.name = input.name;
            playerToUpdate.save((error, player) => {
              if(error) err(new InternalServerError(false)); else res(player);
            });
          }
        });
      }).then(player => player).catch(error => { throw error; }),

    /**
     * Deletes existing player in the system
     * Throws not found error if no player is found by ID
     * Throws bad request error if id is improperly formatted
     * Throws internal server error if fetch cannot be conducted
     * @param parent pointer to root i.e. result of the previous call (unused)
     * @param args query argument, should contain required id parameter for pickup game
     * @return (promise of) a boolean indicating whether operation was successful or not
     */
    removePlayer: (parent, args) =>
      new Promise((res, err) => {
        const { id } = args;
        Players.findById(id, (error, player) => {
          if(error || player === null) {
            if (player == null) err(new NotFoundError(`Player with id ${ id } not found in system`))
            else if (error.name === "CastError") err(new BadRequest(`Parameter id ${ id } was not properly formatted as ObjectId (must be a string of 24 characters)`))
            else err(new InternalServerError(false));
          } else Players.deleteOne({ _id: id }, (deleteError) => deleteError ? err(new InternalServerError(false)) : res(player))
        });
      })
        // Delete embedded resources
        .then(player => {
          // Delete games that had deleted player as host and their embedded resources
          PickupGames.deleteMany({ hostId: player.id }, (deleteError) => {
            if(deleteError) throw new InternalServerError(false);
            // Delete players from registered players array of all pickup games
            PickupGames.find({ registeredPlayersIds: player._id}, (error, games) => {
              if(deleteError) { throw new InternalServerError(false); }
              games.map(g => { g.registeredPlayersIds.splice( g.registeredPlayersIds.indexOf(player.id), 1 ); g.save(); })
            });
          });
          return true;
        })
        .catch(error => { throw error; }),

  },
  
  types : {

    Player : {

    /* Fetch all played games for player by fetching the games by id using database model's playedGamesIds  */
    playedGames : (parent) => 
      new Promise((res, err) =>
          PickupGames.find({ _id: { $in: parent.playedGamesIds } },
            (error, games) => error ? err(new InternalServerError(false)) : res(games)))
          .then(games => games)
          .catch(error => { throw error; }),
    }
  }

}