/*========================================*
 * SC-T-514-VEFT Web Services Fall 2018
 * Assignment:  Large Assignment II
 *              Mansion de Subastas
 * Due: 12th of October 2018
 * Artist Service File
 * Author: Edda Steinunn Rúnarsdóttir
 *========================================*/

const { Artist } = require('../data/db');
const { getNotFoundError } = require('../utils/errorResponses').constructError;


/**
 * Manipulates artist data sources in system
 */
const artistService = () => {
    /**
     * Gets all artist in system
     * Calls callback function with artists when found
     * @param {function} cb callback to call when all artists are found with artists as parameter
     * @param {function} err callback to call if error occurred finding artists with error as parameter
     */
    const getAllArtists = (cb, err) =>
        Artist.find({}, (error, artists) => {
            if(error)   err(error);
            else        cb(artists);
        });
    /**
     * Gets a specific artist by id from data 
     * Calls callback function with artist as parameter when found
     * @param {number} id id of art to get
     * @param {function} cb callback to call when artist is found by id with artist as parameter
     * @param {function} err callback to call if error occurred finding artist with error as parameter
     */
    const getArtistById = (id, cb, err) =>
       Artist.findById(id, (error, artist) => {
           if(error)                    err(error);
           else if (artist === null)    err(getNotFoundError('artist', 'id', id));
           else                         cb(artist);
        });
    /**
     * Adds a new artist resource into the system
     * @param {Artist} artist json object to add to system as artist resource
     * @param {function} cb callback to call if artist is added
     * @param {function} err callback to call if error occurred adding artist with error as parameter
     */
    const createArtist = (artist, cb, err) => {
        Artist.create({
            name: artist.name,
            nickname: artist.nickname,
            address: artist.address,
            memberSince: artist.memberSince,
            }, error => { 
                if(error)   err(error);
                else        cb(true);
            }
        );
    };

    return {
        getAllArtists,
        getArtistById,
        createArtist
    };
};

module.exports = artistService();
