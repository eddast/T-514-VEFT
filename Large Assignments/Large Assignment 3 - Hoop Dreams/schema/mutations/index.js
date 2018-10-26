const pickupGameMutations = require('./pickupGameMutations');
const playerMutations = require('./playerMutations');

module.exports = `
  type Mutation {
    ${pickupGameMutations}
    ${playerMutations}
  }
`;
