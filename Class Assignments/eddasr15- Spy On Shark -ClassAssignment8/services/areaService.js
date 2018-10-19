
const { Area } = require('../data/db');

/**
 * Manages queries for area data sources in system
 */
const areaService = () => {
   /**
     * Gets list of areas in system by list of ids
     * Calls callback function with areas when all areas are found
     * @param {function} cb callback to call when all areas are found with areas as parameter
     * @param {function} err callback to call if error occurred finding areas with that error as parameter
     */
    const getAreasByIds = (idList, res, err) =>
        Area.find ( { _id: { $in: idList } }, (error, areas) => {
            if(error)   err(error);
            else        res(areas);
        });

    return {
        getAreasByIds
    };
};

module.exports = areaService();