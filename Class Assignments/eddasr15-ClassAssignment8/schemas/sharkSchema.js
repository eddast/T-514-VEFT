const Schema = require('mongoose').Schema;

module.exports = new Schema({
    species: { type: String, required: true }
});
