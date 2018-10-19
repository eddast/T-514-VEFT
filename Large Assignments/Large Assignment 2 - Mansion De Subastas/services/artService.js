/*========================================*
 * SC-T-514-VEFT Web Services Fall 2018
 * Assignment:  Large Assignment II
 *              Mansion de Subastas
 * Due: 12th of October 2018
 * Art Service File
 * Author: Edda Steinunn Rúnarsdóttir
 *========================================*/
const { Art, Artist } = require('../data/db');
const {
    getNotFoundError,
    getExternalIdNotFoundError
  } = require('../utils/errorResponses').constructError;


/**
 * Manipulates art data sources in system
 */
const artService = () => {
    /**
     * Gets all arts in system
     * Calls callback function with arts when found
     * @param {function} cb callback to call when all arts are found with arts as parameter
     * @param {function} err callback to call if error occurred finding arts with error as parameter
     */
    const getAllArts = (cb, err) =>
        Art.find({}, (error, arts) => {
            if(error)   err(error);
            else        cb(arts);
        });
    /**
     * Gets a specific art by id from data 
     * Calls callback function with art as parameter when found
     * @param {number} id id of art to get
     * @param {function} cb callback to call when art is found by id with art as parameter
     * @param {function} err callback to call if error occurred finding art with error as parameter
     */
    const getArtById = (id, cb, err) =>
       Art.findById(id, (error, art) => {
           if(error)                err(error);
           else if(art === null)    err(getNotFoundError('art', 'id', id));
           else                     cb(art);
        });
    /**
     * Adds a new art resource into the system
     * @param {Art} art json object to add to system as art resource
     * @param {function} cb callback to call if art is added
     * @param {function} err callback to call if error occurred adding art with error as parameter
     */
    const createArt = (art, cb, err) => {
        // Check if external id exists
        Artist.findById(art.artistId, (error, artist) => {
            if(error) err(error);
            else {
                // Set error if external id is not found
                if(artist === null) err(getExternalIdNotFoundError('artistId', art.artistId));
                // Otherwise attempt to create model
                else {
                    Art.create({
                        title: art.title,
                        artistId: art.artistId,
                        date: art.date,
                        images: art.images,
                        description: art.description,
                        isAuctionItem: art.isAuctionItem
                        }, error => { if(error) err(error); else cb(true); }
                    );
                }
            }
        });
    };

    return {
        getAllArts,
        getArtById,
        createArt
    };
};

module.exports = artService();
