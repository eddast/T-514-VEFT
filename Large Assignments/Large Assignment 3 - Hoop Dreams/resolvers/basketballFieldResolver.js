const {
  getAllBasketballFields,
  getBasketballFieldById
} = require('../services/basketballFieldService');
const { PickupGames } = require('../data/db');

module.exports = {

  queries : {

    /**
     * Gets a collection of all basketball fields from service or throws error on error
     * @param parent pointer to root i.e. result of the previous call (unused)
     * @param args query argument, may contain status for filtering list of fields by their status
     * @return (promise of) collection of all basketball fields when fetched from web service
     */
    allBasketballFields: (parent, args) =>
      getAllBasketballFields(args.status).then(fields => fields).catch(err => { throw err; }),

    /**
     * Gets basketball field by ID from service or throws error on error
     * @param parent pointer to root i.e. result of the previous call (unused)
     * @param args query argument, should contain required id parameter for basketball field
     * @return (promise of) a basketball field when fetched from web service
     */
    basketballField: (parent, args) =>
      getBasketballFieldById(args.id).then(field => field).catch(err => { throw err; })
      
  },

  types : {

    BasketballField : {

      /* Fetch games for field by obtaining games that have their locationId set to this basketball field  */
      pickupGames: (parent) =>
        new Promise((res, err) =>
          PickupGames.find({ fieldLocationId: parent.id }, (error, games) => error ? err(new InternalServerError(false)) : res(games)))
          .then(games => games)
          .catch(error => { throw error; }),
      }

  }
}
