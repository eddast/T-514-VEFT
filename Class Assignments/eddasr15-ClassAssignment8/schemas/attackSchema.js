const Schema = require('mongoose').Schema;

module.exports = new Schema({
    areaId: { type: Schema.Types.ObjectId, required: true, ref: 'Area' },
    sharkId: { type: Schema.Types.ObjectId, required: true, ref: 'Shark' }
});
