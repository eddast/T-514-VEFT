const offers = require('../data/data').offers;
const candyService = require('./candyService');

/**
 * Manipulates candy data souces in system
 */
const offerService = () => {

    /**
     * Gets all offers in system
     * Gets embedded candies by the candy ids embedded
     * @returns all offers in system with embedded candies
     */
    const getAllOffers = () => {
        // Get embedded candies in embedded candy id array via candy service
        offers.forEach((offer) => {
            offer.candies.forEach((candyId, index, embeddedCandies) => 
                embeddedCandies[index] = candyService.getCandyById(candyId));
        });
        return offers;
    }

    return { getAllOffers };
};

module.exports = offerService();
