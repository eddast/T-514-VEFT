/*========================================*
 * SC-T-514-VEFT Web Services Fall 2018
 * Assignment:  Large Assignment II
 *              Mansion de Subastas
 * Due: 12th of October 2018
 * API Errors Helper Functions File
 * Author: Edda Steinunn Rúnarsdóttir
 *========================================*/


 /**
  * Constructs API error helper functionalities
  * i.e. error checkers, error raisers and error constructors
  */
 const errorHelpers = () => {

    /**
     * Constants denoting various error types in system
     */
    const FORMAT_ERROR = 'CastError';
    const VALIDATION_ERROR = 'ValidationError';
    const EXTERNAL_ID_NOT_FOUND = 'ExternalIdNotFound';
    const RESOURCE_NOT_FOUND = 'ResourceNotFound';
    const CUSTOM_ERROR = 'CustomError';

    /**
     * Functions that check which type of error is set
     * @param {*} error error present in request
     */
    const isFormatError = (error) => error.name == FORMAT_ERROR;
    const isValidationError = (error) => error.name == VALIDATION_ERROR;
    const isBadExternalIdError = (error) => error.name == EXTERNAL_ID_NOT_FOUND;
    const isNotFoundError = (error) => error.name == RESOURCE_NOT_FOUND;
    const isCustomError = (error) => error.name === CUSTOM_ERROR;

    /**
     * Functions that raise given errors
     * @param {*} res the HTTP result
     * @param {*} err error associated with error
     */
    const internalServerError = (res, err) => res.status(500).send(`Internal server error occurred.\n message: \n${err.message}`);
    const badRequest = (res, err) => res.status(400).send(`Request was not correctly formatted\n message: ${err.message}`);
    const notFound = (res, err) => res.status(404).send(`${err.resource} was not found by the ${err.parameter} ${err.parameterValue}.`);
    const customError = (res, err) => res.status(err.status).send(err.message);
    const notFoundExternalId = (res, err) => {
        if(err.value !== undefined) return res.status(404).send(`External id provided (${err.param}: ${err.value}) not found in database.`);
        else return res.status(404).send(`External id ${err.param} must be provided`);
    };
    const preconditionFailed = (res, err) => {
        errorMessage = "Request model was not properly formatted. \n";
        const { errors } = err;
        for(let e in errors) if(errors.hasOwnProperty(e)) errorMessage += `  - ${e} : ${errors[e].message}\n`;
        return res.status(412).send(errorMessage);
    };
    
    /**
     * Functions that construct errors by parameters
     * @param {*} ... parameters to use to give information on error
     */
    const getNotFoundError = (resourceName, parameterName, parameterValue) => {
        return {
            name: RESOURCE_NOT_FOUND,
            resource: resourceName,
            parameter: parameterName,
            parameterValue: parameterValue
        }
    };
    const getExternalIdNotFoundError = (param, value) => {
        return {
          name: EXTERNAL_ID_NOT_FOUND,
          param: param,
          value: value, 
        }
    };
    const getCustomError = (code, message) => {
        return {
          name: CUSTOM_ERROR,
          status: code,
          message: message, 
        }
    };

    return {
        /* nature of error checks */
        checkError: {
            isFormatError,
            isValidationError,
            isBadExternalIdError,
            isNotFoundError,
            isCustomError
        },
        /* raise/return errors properly */
        raiseError: {
            internalServerError,
            badRequest,
            notFoundExternalId,
            preconditionFailed,
            notFound,
            customError
        },
        /* create errors */
        constructError: {
            getNotFoundError,
            getExternalIdNotFoundError,
            getCustomError
        }
    }
};

module.exports = errorHelpers();