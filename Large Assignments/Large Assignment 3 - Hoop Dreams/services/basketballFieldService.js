const request = require('request');
const { NotFoundError, InternalServerError, BadRequest } = require('../errors');

/**
 * Contains logic to connect and use the basketball field web service
 * Returns data from web service using callback functions
 */
const basketballFieldService = () => {
    /**
     * Base URL to web service
     */
    const webAPIBaseURL = "https://basketball-fields.herokuapp.com/api/basketball-fields"
    /**
     * Gets all basketball fields from web service, may filter by status if provided
     * Callbacks appropriate error on error, otherwise callbacks with proper payload
     * @param status optional parameter used to filter collection basketball fields by if provided
     * @return (a promise of) a collection of basketball fields from web service
     */
    const getAllBasketballFields = status => {
        const requestRoute = status === undefined ? webAPIBaseURL : `${ webAPIBaseURL }?status=${ status }`;
        return new Promise((res, err) => {
            request (requestRoute, (error, response, body) => {
                if( error || ( response && response.statusCode !== 200 ) ) {
                    err(new InternalServerError(true));
                } else {
                    res(JSON.parse(body));
                }
            });
        });
    }
    /**
     * Fetches single basketball field by basketball field id
     * Callbacks appropriate error on error, otherwise callbacks with proper payload
     * @param id id of basketball field to fetch from web service
     * @return (a promise of) a single basketball field from web service
     */
    const getBasketballFieldById = id => {
        const requestRoute = `${ webAPIBaseURL }/${ id }`;
        return new Promise( (res, err) => {
            if (id === "" || id === undefined || id === null) err(new BadRequest(`Basketball field id is required`)); 
            request (requestRoute, (error, response, body) => {
                if( error || response && response.statusCode !== 200 || body === null ) {
                    if( response && response.statusCode === 404 || body === null ) {
                        err(new NotFoundError(`Basketball field with id ${ id } not found in system`)); 
                    } else {
                        err(new InternalServerError(true)) ;
                    }
                } else res(JSON.parse(body));
            });
        });
    }
    /**
     * Returns functionalities of service
     */
    return {
        getAllBasketballFields,
        getBasketballFieldById
    }
}

module.exports = basketballFieldService();