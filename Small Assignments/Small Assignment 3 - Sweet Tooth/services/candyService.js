const candies = require('../data/data').candies;
const NOT_FOUND = require('../resources/common').NOT_FOUND_INDICATOR;

/**
 * Manipulates candy data souces in system
 */
const candyService = () => {

    /**
     * Gets all candies in system
     * @returns all candies in system
     */
    const getAllCandies = () => candies;

    /**
     * Adds a new candy into the system
     * @param {*} candy json object to add to system as candy resource
     */
    const createCandy = candy => {
        let highestId = 0;
        candies.forEach(c => { if (c.id > highestId) { highestId = c.id; }});
        const id = highestId + 1; const { name, description } = candy;
        const newCandy = { id, name, description, };
        candies.push(newCandy);
        return newCandy;
    };

    /**
     * Gets a specific candy by id from data 
     * @param {*} id id of candy to get
     * @return NOT_FOUND_INDICATOR (-1) if candy was not found, otherwise the candy object by id
     */
    const getCandyById = id => {
        const candy = candies.filter(c => c.id == id);
        if (candy.length === 0) { return NOT_FOUND; }
        return candy[0];
    };

    return {
        getAllCandies,
        getCandyById,
        createCandy
    };
};

module.exports = candyService();
