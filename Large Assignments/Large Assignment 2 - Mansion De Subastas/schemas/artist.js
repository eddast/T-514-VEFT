const Schema = require('mongoose').Schema;
/**
 * The schema of an artist resource
 */
module.exports = new Schema({
    /* Artist name */
    name: { type: String, required: true },

    /* Artist nick name */
    nickname: { type: String, required: true },

    /* Address of artist */
    address: { type: String, required: true },

    /* Date when artist became auction member */
    memberSince: { type: Date, required: true, default: new Date() },
}, { collection: 'artists' });