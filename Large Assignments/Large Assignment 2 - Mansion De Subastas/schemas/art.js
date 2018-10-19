const Schema = require('mongoose').Schema;
/**
 * The schema of an art resource
 */
module.exports = new Schema({
    /* Art title */
    title: { type: String, required: true },

    /* Id of artist for art */
    artistId: { type: Schema.Types.ObjectId, required: true },

    /* Date of art creation */
    date: { type: Date, required: true, default: new Date() },

    /* Array of URLs to embedded images for art */
    images: Array,

    /* Description for art */
    description: String,

    /* True if art is an auction item, false otherwise */
    isAuctionItem: { type: Boolean, default: false },
}, { collection: 'arts' });
