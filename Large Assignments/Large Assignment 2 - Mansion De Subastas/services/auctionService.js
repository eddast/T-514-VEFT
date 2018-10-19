const { Auction, AuctionBid, Customer, Art } = require('../data/db');
const {
  getNotFoundError,
  getExternalIdNotFoundError,
  getCustomError
} = require('../utils/errorResponses').constructError;

/**
 * Manipulates auction data sources in system
 */
const auctionService = () => {
    /**
     * Gets all auctions in system
     * Calls callback function with auctions when found
     * @param {function} cb callback to call when all auctions are found with auctions as parameter
     * @param {function} err callback to call if error occurred finding auctions with error as parameter
     */
    const getAllAuctions = (cb, err) =>
        Auction.find({}, (error, auctions) => { if (error) err(error); else cb(auctions); });
    /**
     * Gets a specific auction by id from data 
     * Calls callback function with auction as parameter when found
     * @param {number} id id of auction to get
     * @param {function} cb callback to call when auction is found by id with auction as parameter
     * @param {function} err callback to call if error occurred finding auction with error as parameter
     */
    const getAuctionById = (id, cb, err) =>
        Auction.findById(id, (error, auction) => {
            if (error)                  err(error);
            else if (auction === null)  err(getNotFoundError('auction', 'id', id));
            else                        cb(auction);
        });
    /**
     * Adds a new auction resource into the system
     * @param {Auction} auction json object to add to system as auction resource
     * @param {function} cb callback to call if auction is added
     * @param {function} err callback to call if error occurred adding auction with error as parameter
     */
    const createAuction = (auction, cb, err) => {
        // check if external id exists
        Art.findById(auction.artId, (error, art) => {
            if(error)                       err(error);
            else if(!art)                   err(getExternalIdNotFoundError('artId', auction.artId));
            else if (!art.isAuctionItem)    err(getCustomError(412, 'The art being put up for auction is not an auction item'));
            else                            createNewAuction(auction, cb, err);
        });
    };
    /**
     * Creates a new auction from model
     * @param {*} auction auction to create model from
     * @param {*} cb callback function to call to let know that the auction was created successfully
     * @param {*} err callback function to call if an error occurred
     */
    const createNewAuction = (auction, cb, err) => {
        Auction.create({
            artId: auction.artId,
            minimumPrice: auction.minimumPrice,
            endDate: auction.endDate
            }, error => { if(error) err(error); else cb(true); }
        );
    }
    /**
     * Gets the winner for an auction by auction id 
     * @param {number} id id of auction to get winner of
     * @param {function} cb callback to call if auction winner is successfully retrieved
     * @param {function} err callback to call if error occurred finding auction winner
     */
    const getAuctionWinner = (auctionId, cb, err) => {
        Auction.findById(auctionId, (error, auction) => {
            if(error)                       err(error);
            else if(auction === null)       err(getNotFoundError('auction', 'id', auctionId));
            else if(auction.endDate >
                    new Date())             err(getCustomError(409, 'Auction has not finished'));
            else if(!auction.auctionWinner) cb('This auction had no bids.');
            else {
                Customer.findById(auction.auctionWinner, (customerError, customer) => {
                    if (customerError) err(customerError); else cb(customer);
                })
            }
        });
    };
    /**
     * Gets the auction bids for an auction by auction id 
     * @param {number} id id of auction to get bids of
     * @param {function} cb callback to call if bids for auction are successfully retrieved
     * @param {function} err callback to call if error occurred finding bids for auction
     */
    const getAuctionBidsWithinAuction = (auctionId, cb, err) =>
        /* check if auction id provided is correct */
        Auction.findById(auctionId, (auctionError, auction) => {
            if(auctionError)            err(auctionError);
            else if(auction === null)   err(getNotFoundError('auction', 'id', auctionId));
            else {
                AuctionBid.find({ auctionId }, (error, bids) => {
                    if(error)   err(error);
                    else        cb(bids);
                });
            }
        })
    /**
     * Places new bid for auction
     * @param {number} id id of auction to place bid for
     * @param {number} customerId id of customer placing bid
     * @param {number} price price of bid
     * @param {function} cb callback to call if new bid was successfully placed
     * @param {function} err callback to call if error occurred placing new bid
     */
    const placeNewBid = (auctionId, customerId, price, cb, err) => {
        Auction.findById(auctionId, (error, auction) => {
            if(error)                       err(error);
            else if(auction === null)       err(getNotFoundError('Auction', '_id', auctionId));
            else if(auction.endDate <
                    new Date())             err(getCustomError(403, 'Auction has reached end date' ));
            else if(auction.minimumPrice >
                    price)                  err(getCustomError(412, 'Bid price cannot be less than minimum asking price'));
            else                            validateCustomerAndPlaceBid(auctionId, customerId, price, auction, cb, err);
        });
    };
    /**
     * calls the customer database and checks if the customer exists, 
     * if the customer is valid a bid is placed
     * @param {number} auctionId the auction the bid was placed to
     * @param {number} customerId the customer placing the bid
     * @param {number} price the amount the customer bid
     * @param {Auction} auction information about the auction
     * @param {function} cb callback to call if new bid was successfully placed
     * @param {function} err callback to call if error occurred placing new bid
     */
    const validateCustomerAndPlaceBid = (auctionId, customerId, price, auction, cb, err) => {
        Customer.findById(customerId, (error, customer) => {
            if(error) err(error);
            else {
                // If the customer does not exist an error is thrown, if not the bid is validated 
                if(customer == null)            err(getExternalIdNotFoundError('customerId', customerId));
                else if(auction.auctionWinner)  findHighestAuctionBid(auctionId, customerId, price, auction, cb, err);
                else                            createNewAuctionBid(auctionId, customerId, price, auction, cb, err);
            }
        });
    }
    /**
     * Finds the highest auction bid for a given auction
     * and creates a new bid if the current bid is higher
     * @param {number} auctionId auction to find highest bid for
     * @param {number} customerId customer placing new bid
     * @param {number} price amount that the customer bid
     * @param {Auction} auction auction information
     * @param {function} cb callback to call if new bid was successfully placed
     * @param {function} err callback to call if error occurred placing new bid
     */
    const findHighestAuctionBid = (auctionId, customerId, price, auction, cb, err) => {
        AuctionBid.find({ auctionId, customerId: auction.auctionWinner }, (bidError, bids) => {
            if (bidError)   err(bidError);
            else {
                // Find the highest bid
                const maxBid = Math.max(...bids.map(bid => bid.price), 0);
                if (price <= maxBid)    err(getCustomError(412, 'Bid cannot be less than the highest bid of auction'));
                else                    createNewAuctionBid(auctionId, customerId, price, auction, cb, err);
            }
        });
    }
    /**
     * Creates a new auction bid and updates the 
     * property auctionWinner in auction accordingly
     * @param {number} auctionId auction that the customer is placing the bid to
     * @param {number} customerId customer that placed bid
     * @param {number} price price that the customer bid
     * @param {Auction} auction information about the auction to create
     * @param {function} cb callback to call if new auction was successfully created
     * @param {function} err callback to call if error occurred creating new auction
     */
    const createNewAuctionBid = (auctionId, customerId, price, auction, cb, err) => {
        AuctionBid.create({
            auctionId: auctionId,
            customerId: customerId,
            price: price
        }, error => { 
            if(error)   err(error);
            else {
                auction.auctionWinner = customerId;
                // Updates the auction with the auctionWinner property
                Auction.findOneAndUpdate({_id: auctionId}, auction, (error, res) => {
                    if (error) err(error); else cb(true);
                });
            }
        });
    }

    return {
        getAllAuctions,
        getAuctionById,
        getAuctionWinner,
        createAuction,
        getAuctionBidsWithinAuction,
        placeNewBid
    };
};

module.exports = auctionService();
