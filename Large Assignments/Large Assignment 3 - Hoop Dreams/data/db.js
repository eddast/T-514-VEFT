const mongoose = require('mongoose');
const Schema = require('mongoose').Schema;
/**
 * Initialize mongoDB Connection
 */
const mongoDBString = "mongodb://root:Root123@ds235833.mlab.com:35833/hoopdreams"
const connection = mongoose.createConnection( mongoDBString, { useNewUrlParser: true } );
/**
 * Player schema for MongoDB schema
 */
const playersSchema = new Schema({
    name: { type: String, required: true },
    playedGamesIds: { type: [Schema.Types.ObjectId], required: true },
}, { collection: 'players' });
/**
 * Pickup game schema for MongoDB schema
 */
const pickupGamesSchema = new Schema({
    start: { type: Date, required: true },
    end: { type: Date, required: true },
    fieldLocationId: { type: String, required: true },
    registeredPlayersIds: { type: [Schema.Types.ObjectId], required: true },
    hostId: { type: Schema.Types.ObjectId, required: true },
}, { collection: 'pickupGames' });
/**
 * Connect database schemas to mongoDB collection
 */
module.exports = {
    PickupGames: connection.model('PickupGames', pickupGamesSchema),
    Players: connection.model('PlayersSchema', playersSchema)
};