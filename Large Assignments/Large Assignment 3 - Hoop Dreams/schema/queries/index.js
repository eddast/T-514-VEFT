const basketballFieldQueries = require('./basketballFieldQueries');
const pickupGameQueries = require('./pickupGameQueries');
const playerQueries = require('./playerQueries');

module.exports = `
  type Query {
    ${basketballFieldQueries}
    ${pickupGameQueries}
    ${playerQueries}
  }
`;
