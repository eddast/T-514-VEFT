const Schema = require('mongoose').Schema;

module.exports = new Schema({
    name: { type: String, required: true },
    region: { type: String, required: true }
});
