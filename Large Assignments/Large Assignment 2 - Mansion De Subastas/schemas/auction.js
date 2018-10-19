const Schema = require('mongoose').Schema;
/**
 * The schema of an auction resource
 */
module.exports = new Schema({
    /* Id of art being auctioned */
    artId: { type: Schema.Types.ObjectId, required: true },

    /* Minimum bid price for auction */
    minimumPrice: { type: Number, default: 1000 },

    /* Date when auction ends */
    endDate: { type: Date, required: true },

    /* Id of a customer holding highest bid of auction */
    auctionWinner: Schema.Types.ObjectId
}, { collection: 'auctions' });