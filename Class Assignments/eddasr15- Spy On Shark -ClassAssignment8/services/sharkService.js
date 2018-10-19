
const { Shark } = require('../data/db');

/**
 * Manages queries for shark data sources in system
 */
const sharkService = () => {
    /**
     * Gets all sharks in system
     * Calls callback function with sharks when all sharks are found
     * @param {function} cb callback to call when all sharks are found with sharks as parameter
     * @param {function} err callback to call if error occurred finding sharks with that error as parameter
     */
    const getAllSharks = (res, err) =>
        Shark.find({}, (error, sharks) => {
            if(error)   err(error);
            else        res(sharks);
        });
    /**
     * Gets list of sharks in system by list of ids
     * Calls callback function with sharks when all sharks are found
     * @param {function} cb callback to call when all sharks are found with sharks as parameter
     * @param {function} err callback to call if error occurred finding sharks with that error as parameter
     */
    const getSharksByIds = (idList, res, err) =>
        Shark.find ( { _id: { $in: idList } }, (error, sharks) => {
            if(error)   err(error);
            else        res(sharks);
        });
    /**
     * Gets all sharks in system by specific species
     * Calls callback function with sharks of the species when found
     * @param {string[]} speciesList list of all species of which to include all sharks of
     * @param {function} cb callback to call when all sharks of the species are found with those sharks as parameter
     * @param {function} err callback to call if error occurred finding sharks of the species with that error as parameter
     */
    const getAllSharksBySpecies = (speciesList, res, err) =>
        Shark.find ( { species: { $in: speciesList } }, (error, sharks) => {
            if(error)   err(error);
            else        res(sharks);
        });
    /**
     * Gets all sharks in system exluding specific species
     * Calls callback function with all sharks excluding those of the species when found
     * @param {string[]} speciesList list of all species to which to filter out sharks by
     * @param {function} cb callback to call when all sharks excluding those of species from species list are found with sharks as parameter
     * @param {function} err callback to call if error occurred finding sharks with that error as parameter
     */
    const getSharksExcludingSpecies = (speciesList, res, err) =>
        Shark.find ( { species: { $nin: speciesList } }, (error, sharks) => {
            if(error)   err(error);
            else        res(sharks);
        });

    return {
        getAllSharks,
        getSharksByIds,
        getAllSharksBySpecies,
        getSharksExcludingSpecies
    };
};

module.exports = sharkService();