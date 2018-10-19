
const { Attack } = require('../data/db');
const { getSharksByIds, getAllSharksBySpecies } = require('./sharkService');
const { getAreasByIds } = require('./areaService');

/**
 * Manages queries for attack data sources in system
 */
const attackService = () => {
    /**
     * Gets all sharks that have been known to attack
     * Calls callback function with sharks that have been known to attack are found
     * @param {function} cb callback to call when all attacking sharks are found with those sharks as parameter
     * @param {function} err callback to call if error occurred finding attacking sharks with that error as parameter
     */
    const getAllAttackingSharks = (res, err) =>
        // Group together IDs of sharks that have been registered to an attack
        Attack.aggregate( [ { $group : {  _id : "$sharkId" } } ], (error, sharkIds) => {
            if(error)   err(error);
            else        {
                // After retrieving IDs, retrive sharks by IDs
                getSharksByIds(sharkIds,
                    sharks =>   res(sharks),
                    error =>    err(error)
                );
            }
        });
    /**
     * Gets all areas in system that have been attacked by a shark
     * Calls callback function with areas that have been attacked
     * @param {function} cb callback to call when all areas that have been attacked are found with those areas as parameter
     * @param {function} err callback to call if error occurred finding areas that have been attacked with that error as parameter
     */
    const getAllAttackedAreas = (res, err) =>
        // Group together IDs of areas that have been attacked
        Attack.aggregate([{ $group : {  _id : "$areaId" } }], (error, areaIDs) => {
            if(error)   err(error);
            else {
                // After retrieving IDs, retrive areas by IDs
                getAreasByIds(areaIDs,
                    areas =>    res(areas),
                    error =>    err(error)
                );
            }
        });
    /**
     * Gets all areas in system that have been attacked by a shark over n times
     * Calls callback function with areas that have been attacked over n times
     * @param {number} n n+1 is how many times area has to have been attacked to be included in list
     * @param {function} cb callback to call when all areas are found that have been attacked over n times with those areas as parameter
     * @param {function} err callback to call if error occurred finding areas that have been attacked over n times with that error as parameter
     */
    const getAllAreasAttackedAtLeastNTimes = (n, res, err) =>
        // Group together IDs of areas that have been attacked and strip out those with less than n occurrences
        Attack.aggregate([
            { $group :      { _id : "$areaId", count: { $sum: 1 } } },
            { $match :      { count : { $gt: n } } },
            { $project :    { _id: "$_id" } }
        ], (error, areaIDs) => {
            if(error)   err(error);
            else {
                // After retrieving IDs, retrive areas by IDs
                getAreasByIds(areaIDs,
                    areas =>    res(areas),
                    error =>    err(error)
                );
            }
        });
    /**
     * Gets an area in system that is most frequently attacked by sharks
     * Calls callback function with most frequently attacked area
     * @param {function} cb callback to call when most frequently attacked area is found with that area as parameter
     * @param {function} err callback to call if error occurred finding most frequently attacked area with that error as parameter
     */
    const getMostFrequentlyAttackedArea = (res, err) =>
        // Group together IDs of areas and count their occurrences
        // Then sort by descending and take the top entry i.e. area with the most frequent occurences (most attacked)
        Attack.aggregate([
            { $group:   { _id : "$areaId", count: { $sum: 1 }}},
            { $sort:    { count: -1}},
            { $limit:   1}
        ], (error, areaID) => {
            if(error)   err(error);
            else {
                // After retrieving ID of most frequently attacked area, retrive areas by ID
                getAreasByIds(areaID,
                    area =>     res(area),
                    error =>    err(error)
                );
            }
        });
    /**
     * Gets total count of attacks by list of shark species
     * Calls callback function with count of attacks by species
     * @param {string[]} speciesList list of all species to which to include and count shark attacks by
     * @param {function} cb callback to call when count for species attacks is found with that area as parameter
     * @param {function} err callback to call if error occurred finding count for species attacks with that error as parameter
     */
    const getTotalAttackBySharkSpecies = (speciesList, res, err) =>
        // Get sharks for species specified
        getAllSharksBySpecies(speciesList,
            sharks => {
                // Stip shark data to only show shark ids
                const sharkIDs = sharks.map(s => s._id);
                // Group sharks together by their specified species id and count attacks for each shark
                Attack.aggregate([
                    { $match :  { sharkId : { $in: sharkIDs } }},
                    { $group:   { _id : "$sharkId", count: { $sum: 1 }}}
                ], (error, sharkAttacks) => {
                    if(error)   err(error);
                    else {
                        // Count total attacks for each shark attck (one for each species)
                        let countAttacks = 0; sharkAttacks.forEach( attack => countAttacks += attack.count);
                        res('Total attacks: ' + countAttacks);
                    }
                });
            },
            error =>    err(error)
        );

    return {
        getAllAttackingSharks,
        getAllAttackedAreas,
        getAllAreasAttackedAtLeastNTimes,
        getMostFrequentlyAttackedArea,
        getTotalAttackBySharkSpecies
    };
};

module.exports = attackService();