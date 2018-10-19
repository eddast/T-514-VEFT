
/*========================================*
 * SC-T-514-VEFT Web Services Fall 2018
 * Assignment:  Large Assignment II
 *              Mansion de Subastas
 * Due: 12th of October 2018
 * Web API index.js file
 * Author: Edda Steinunn Rúnarsdóttir
 *========================================*/
const express = require('express');
const bodyParser = require('body-parser');
const artService = require('./services/artService');
const artistService = require('./services/artistService');
const auctionService = require('./services/auctionService');
const customerService = require('./services/customerService');
const { checkError, raiseError } = require('./utils/errorResponses');
const router = express.Router();
const app = express();
const port = 3000;


/***************************************
 * ROUTES FOR ART RESOURCES IN SYSTEM *
 ***************************************/
/**
 * [GET] /api/arts
 * Gets all arts in system
 * Returns HTTP status 200 (OK) along with all arts
 */
router.get('/arts', (req, res) =>
    artService.getAllArts(
        arts => res.json(arts),
        err => raiseError.internalServerError(res, err)
    )
);
/**
 * [GET] /api/arts/:id
 * Gets a specified art in system by art id
 * Returns HTTP status 200 (OK) if art is found along with that art
 * Returns HTTP status 404 (not found) if art is not found
 * Returns HTTP status 400 (bad request) if id is improperly formatted
 */
router.get('/arts/:id', (req, res) => {
    const { id } = req.params;
    artService.getArtById(id,
        art => res.json(art),
        err => {
            if(checkError.isNotFoundError(err)) return raiseError.notFound(res, err);  
            if(checkError.isFormatError(err))   return raiseError.badRequest(res, err);
            else                                return raiseError.internalServerError(res, err);
        }
    );
});
/**
 * [POST] /api/arts
 * Creates a new art resource in system
 * New art object passed as request body
 * Returns HTTP status 201 (created)
 * Returns HTTP status 412 (precondition failed) if model is invalid
 * Returns HTTP status 400 (bad request) if external id (artist id) is invalid
 */
router.post('/arts', (req, res) => {
    const { body } = req;
    artService.createArt(body,
        success => res.status(201).send(),
        err => {
            if(checkError.isValidationError(err))       return raiseError.preconditionFailed(res, err);
            if(checkError.isFormatError(err))           return raiseError.badRequest(res, err);
            if(checkError.isBadExternalIdError(err))    return raiseError.notFoundExternalId(res, err);
            else                                        return raiseError.internalServerError(res, err);
        }
    );
});


/*****************************************
 * ROUTES FOR ARTIST RESOURCES IN SYSTEM *
 *****************************************/
/**
 * [GET] /api/artists
 * Gets all artists in system
 * Returns HTTP status 200 (OK) along with all arts
 */
router.get('/artists', (req, res) =>
    artistService.getAllArtists(
        arts => res.json(arts),
        err => raiseError.internalServerError(res, err)
    )
);
/**
 * [GET] /api/artists/:id
 * Gets a specified artist in system by artist id
 * Returns HTTP status 200 (OK) if artist is found along with that artist
 * Returns HTTP status 404 (not found) if artist is not found
 * Returns HTTP status 400 (bad request) if id is improperly formatted
 */
router.get('/artists/:id', (req, res) => {
    const { id } = req.params;
    artistService.getArtistById(id,
        artist => res.json(artist),
        err => {
            if(checkError.isNotFoundError(err)) return raiseError.notFound(res, err);
            if(checkError.isFormatError(err))   return raiseError.badRequest(res, err);
            else                                return raiseError.internalServerError(res, err);
        }
    );
});
/**
 * [POST] /api/artist
 * Creates a new artist resource in system
 * New artist object passed as request body
 * Returns HTTP status 201 (created)
 * Returns HTTP status 412 (precondition failed) if model is invalid
 */
router.post('/artists', (req, res) => {
    const { body } = req;
    artistService.createArtist(body,
      success => res.status(201).send(),
      err => {
          if (checkError.isValidationError(err))    return raiseError.preconditionFailed(res, err);
          else                                      return raiseError.internalServerError(res, err);
      }
    );
});


/*******************************************
 * ROUTES FOR CUSTOMER RESOURCES IN SYSTEM *
 *******************************************/
/**
 * [GET] /api/customers
 * Gets all customers in system
 * Returns HTTP status 200 (OK) along with all customers
 */
router.get('/customers', (req, res) =>
    customerService.getAllCustomers(
        customers => res.json(customers),
        err => raiseError.internalServerError(res, err)
    )
);
/**
 * [GET] /api/customers/:id
 * Gets a specified customer in system by customer id
 * Returns HTTP status 200 (OK) if customer is found along with that customer
 * Returns HTTP status 404 (not found) if customer is not found
 * Returns HTTP status 400 (bad request) if id is improperly formatted
 */
router.get('/customers/:id', (req, res) => {
    const { id } = req.params;
    customerService.getCustomerById(id,
        customer => res.json(customer),
        err => {
            if(checkError.isNotFoundError(err)) return raiseError.notFound(res, err);
            if(checkError.isFormatError(err))   return raiseError.badRequest(res, err);
            else                                return raiseError.internalServerError(res, err);
        }
    );
});
/**
 * [POST] /api/customers
 * Creates a new customer resource in system
 * New customer object passed as request body
 * Returns HTTP status 201 (created)
 * Returns HTTP status 412 (precondition failed) if model is invalid
 */
router.post('/customers', (req, res) => {
    const { body } = req;
    customerService.createCustomer(body,
        success => res.status(201).send(),
        err => {
            if (checkError.isValidationError(err))  return raiseError.preconditionFailed(res, err);
            else                                    return raiseError.internalServerError(res, err);
        }
    );
});
/**
 * [GET] /api/customers/:id/auction-bids
 * Gets all auction bids associated with a customer by customer id
 * Returns HTTP status 200 (OK) if customer is found along with all his or her embedded auction bids
 * Returns HTTP status 404 (not found) if customer is not found
 * Returns HTTP status 400 (bad request) if id is improperly formatted
 */
router.get('/customers/:id/auction-bids', (req, res) => {
    const { id } = req.params;
    customerService.getCustomerAuctionBids(id,
        bids => res.json(bids),
        err => {
            if (checkError.isFormatError(err))          return raiseError.badRequest(res, err);
            else if (checkError.isNotFoundError(err))   return raiseError.notFound(res, err);
            else                                        return raiseError.internalServerError(res, err);
        }
    )
});


/*****************************************
 * ROUTES FOR ARTIST RESOURCES IN SYSTEM *
 *****************************************/
/**
 * [GET] /api/auctions
 * Gets all auctions in system
 * Returns HTTP status 200 (OK) along with all auctions
 */
router.get('/auctions', (req, res) =>
    auctionService.getAllAuctions(
        auctions => res.json(auctions),
        err => checkError.internalServerError(res, err)
    )
);
/**
 * [GET] /api/auctions/:id
 * Gets a specified auction in system by auction id
 * Returns HTTP status 200 (OK) if auction is found along with that auction
 * Returns HTTP status 404 (not found) if auction is not found
 */
router.get('/auctions/:id', (req, res) => {
    const { id } = req.params;
    auctionService.getAuctionById(id,
        auction => res.json(auction),
        err => {
            if(checkError.isNotFoundError(err)) return raiseError.notFound(res, err);
            if(checkError.isFormatError(err))   return raiseError.badRequest(res, err);
            else                                return raiseError.internalServerError(res, err);
        }
    );
});
/**
 * 
 * [GET] /api/auctions/:id/winner
 * Gets the winner of the auction by auction id
 * Returns HTTP status 200 (OK) along with message if auction had no bids
 * Returns HTTP status 200 (OK) along with customer which holds the highest bid
 * Returns HTTP status 409 (Conflict) if the auction is not finished
 * Returns HTTP status 404 (not found) if auction is not found
 */
router.get('/auctions/:id/winner', (req, res) => {
    const { id } = req.params;
    auctionService.getAuctionWinner(id,
        auction => res.send(auction),
        err => {
            if(checkError.isNotFoundError(err))     return raiseError.notFound(res, err);
            if(checkError.isCustomError(err))       return raiseError.customError(res, err);
            if(checkError.isFormatError(err))       return raiseError.badRequest(res, err);
            if(checkError.isValidationError(err))   return raiseError.preconditionFailed(res, err);
            else                                    return raiseError.internalServerError(res, err);
        }
    );
});
/**
 * [POST] /api/auctions
 * Creates a new auction resource in system
 * New auction object passed as request body
 * Returns HTTP status 201 (created)
 * Returns HTTP status 412 (precondition failed) if model is invalid
 */
router.post('/auctions', (req, res) => {
    const { body } = req;
    auctionService.createAuction(body,
        success => res.status(201).send(),
        err => {
            if(checkError.isCustomError(err))           return raiseError.customError(res, err);
            if(checkError.isFormatError(err))           return raiseError.badRequest(res, err);
            if(checkError.isBadExternalIdError(err))    return raiseError.notFoundExternalId(res, err);
            if(checkError.isValidationError(err))       return raiseError.preconditionFailed(res, err);
            else                                        return raiseError.internalServerError(res, err);
        }
    );
});
/**
 * [GET] /api/auctions/:id/bids
 * Gets all auction bids associated with an auction
 * Returns HTTP status 200 (OK) if auction is found along with bids associated with it
 * Returns HTTP status 404 (not found) if auction is not found
 * Returns HTTP status 400 (bad request) if auction id is improperly formatted
 */
router.get('/auctions/:id/bids', (req, res) => {
    const { id } = req.params;
    auctionService.getAuctionBidsWithinAuction(id,
        bids => res.json(bids),
        err => {
            if(checkError.isCustomError(err))   return raiseError.isCustomError(res, err);
            if(checkError.isNotFoundError(err)) return raiseError.notFound(res, err);
            if(checkError.isFormatError(err))   return raiseError.badRequest(res, err);
            else                                return raiseError.internalServerError(res, err);
        }
    );
});
/**
 * [POST] /api/auctions/:id/bids
 * Creates a new auction bid resource in system
 * New customer object passed as request body
 * auction winner is also updated to the highest bidder
 * Returns HTTP status 201 (created)
 * Returns HTTP status 404 (not found) if auction is not found by id
 * Returns HTTP status 412 (precondition failed) if model is invalid
 * Returns HTTP status 400 (bad request) if id is improperly formatted
 * Returns HTTP status 403 (forbidden) if the auction has already passed its end date
 */
router.post('/auctions/:id/bids', (req, res) => {
    const { body } = req;
    const { id } = req.params;
    auctionService.placeNewBid(id, body.customerId, body.price,
        newAuction => res.status(201).send(),
        err => {
            if(checkError.isNotFoundError(err))         return raiseError.notFound(res, err);
            if(checkError.isCustomError(err))           return raiseError.customError(res, err);
            if(checkError.isFormatError(err))           return raiseError.badRequest(res, err);
            if(checkError.isValidationError(err))       return raiseError.preconditionFailed(res, err);
            if(checkError.isBadExternalIdError(err))    return raiseError.notFoundExternalId(res, err);
            else                                        return raiseError.internalServerError(res, err);
        }
    );
});


/************************
 * SETUP SERVER ON PORT *
 ************************/
app.use(bodyParser.json());
app.use((err, req, res, next) => {
    if (err) {
      res.status(400).send('Invalid request data');
    } else {
      next()
    }
});
app.use('/api', router);
app.listen(port || process.env.PORT, () => console.log(`Server listening on port ${port}`));