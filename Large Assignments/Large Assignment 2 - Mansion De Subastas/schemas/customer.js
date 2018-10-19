const Schema = require('mongoose').Schema;
/**
 * The schema of an customer resource
 */
module.exports = new Schema({
    /* Customer name */
    name: { type: String, required: true },

    /* Customer username to auction */
    username: { type: String, required: true },

    /* Customer email */
    email: { type: String, required: true },

    /* Customer address */
    address: { type: String, required: true },
}, { collection: 'customers' });
