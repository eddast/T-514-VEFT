const bossEnemy = require('./bossEnemy');
const character = require('./character');
const commonEnemy = require('./commonEnemy');
const level = require('./level');

module.exports = `
  ${bossEnemy}
  ${character}
  ${commonEnemy}
  ${level}
`;
