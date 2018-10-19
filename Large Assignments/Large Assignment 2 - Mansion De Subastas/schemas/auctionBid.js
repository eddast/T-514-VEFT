const Schema = require('mongoose').Schema;
/**
 * The schema of an auction bid resource
 */
module.exports = new Schema({

    /* Id of auction for bid */
    auctionId: { type: Schema.Types.ObjectId, required: true },

    /* Id of customer that placed the bid */
    customerId: { type: Schema.Types.ObjectId, required: true },

    /* Bid price */
    price: { type: Number, required: true }
}, { collection: 'auctionBids' });
