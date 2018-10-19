/*========================================*
 * SC-T-514-VEFT Web Services Fall 2018
 * Assignment:  Large Assignment II
 *              Mansion de Subastas
 * Due: 12th of October 2018
 * Customer Service File
 * Author: Edda Steinunn Rúnarsdóttir
 *========================================*/
const { Customer, AuctionBid } = require('../data/db');
const { getNotFoundError } = require('../utils/errorResponses').constructError;


/**
 * Manipulates customer data sources in system
 */
const customerService = () => {
    /**
     * Gets all customers in system
     * Calls callback function with customers when found
     * @param {function} cb callback to call when all customers are found with customers as parameter
     * @param {function} err callback to call if error occurred finding customers with error as parameter
     */
    const getAllCustomers = (cb, err) =>
        Customer.find({}, (error, customers) => {
            if(error)   err(error);
            else        cb(customers);
        });
    /**
     * Gets a specific customer by id from data 
     * Calls callback function with customer as parameter when found
     * @param {number} id id of customer to get
     * @param {function} cb callback to call when customer is found by id with customer as parameter
     * @param {function} err callback to call if error occurred finding customer with error as parameter
     */
    const getCustomerById = (id, cb, err) =>
       Customer.findById(id, (error, customer) => {
           if(error)                    err(error);
           else if (customer === null)  err(getNotFoundError('customer', 'id', id));
           else                         cb(customer);
        });
    /**
     * Adds a new customer resource into the system
     * @param {Customer} customer json object to add to system as customer resource
     * @param {function} cb callback to call if customer is added
     * @param {function} err callback to call if error occurred adding customer with error as parameter
     */
    const createCustomer = (customer, cb, err) => {
        Customer.create({
            name: customer.name,
            username: customer.username,
            email: customer.email,
            address: customer.address
            }, error => {
                if(error)   err(error);
                else        cb(true);
            }
        );
    };
    /**
     * Gets all bids by a given customer by id in system
     * Calls helper function when customer id has been validated
     * @param {function} cb callback to call when all bids by customer are found with bids as parameter
     * @param {function} err callback to call if error occurred finding bids with error as parameter
     */
    const getCustomerAuctionBids = (customerId, cb, err) =>
        Customer.findById(customerId, (error, customer) => {
            if(error)                   err(error);
            else if(customer !== null)  findBidsByCustomer(customerId, cb, err);
            else                        err(getNotFoundError('Customer', 'id', customerId));
        });
    /**
     * Finds bids for any given customer by id
     * Calls callback function when found
     * @param {*} customerId customerId to search bids for
     * @param {*} cb callback to call with bids when found
     * @param {*} err callback to call if error occured finding bids
     */
    const findBidsByCustomer = (customerId, cb, err) => {
        AuctionBid.find( { customerId }, (error, bids) => {
            if(error)   err(error);
            else        cb(bids);
        });
    }

    return {
        getAllCustomers,
        getCustomerById,
        createCustomer,
        getCustomerAuctionBids
    };
};

module.exports = customerService();
