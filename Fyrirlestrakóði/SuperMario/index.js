const { ApolloServer } = require('apollo-server');
const typeDefs = require('./schema');

const server = new ApolloServer({
  typeDefs
  /* resolvers */
});
console.log(typeDefs);
server.listen()
  .then(({ url }) => console.log(`GraphQL API running on ${url}`));
