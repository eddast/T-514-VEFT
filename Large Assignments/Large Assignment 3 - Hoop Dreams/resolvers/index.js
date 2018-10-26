const moment = require('moment');
const basketballFieldResolver = require('./basketballFieldResolver');
const pickupGameResolver = require('./pickupGameResolver');
const playerResolver = require('./playerResolver');
const { GraphQLScalarType } = require('graphql')

module.exports = {

    /* Custom scalar resolver for date time to icelandic llll format */
    Moment: new GraphQLScalarType ({
        name: 'Moment',
        parseValue: value => value,
        parseLiteral: value => value,
        serialize: value => moment(new Date(value)).locale('is-IS').format('llll')
    }),

    /* Queries resolvers extracted from subset resolvers */
    Query: {
        ...basketballFieldResolver.queries,
        ...pickupGameResolver.queries,
        ...playerResolver.queries
    },

    /* Mutation resolvers extracted from subset resolvers */
    Mutation: {
        ...pickupGameResolver.mutations,
        ...playerResolver.mutations
    },

    /* Types resolvers */
    ...basketballFieldResolver.types,
    ...pickupGameResolver.types,
    ...playerResolver.types
};