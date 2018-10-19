const enums = require('./enums');
const inputs = require('./inputs');
const interfaces = require('./interfaces');
const mutations = require('./mutations');
const queries = require('./queries');
const types = require('./types');

module.exports = `
  ${enums}
  ${inputs}
  ${interfaces}
  ${mutations}
  ${queries}
  ${types}
`;
