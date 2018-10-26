class PickupGameExceedMaximumError extends Error {
    constructor(message = 'Pickup game has exceeded the maximum of players.') {
        super(message);
        this.name = 'PickupGameExceedMaximumError';
        this.code = 409;
    }
};

class BasketballFieldClosedError extends Error {
    constructor(message = 'Cannot add a pickup game to a closed basketball field') {
        super(message);
        this.name = 'BasketballFieldClosedError';
        this.code = 400;
    }
};

class PickupGameOverlapError extends Error {
    constructor(message = 'Pickup games cannot overlap') {
        super(message);
        this.name = 'PickupGameOverlapError';
        this.code = 400;
    }
};

class PickupGameAlreadyPassedError extends Error {
    constructor(message = 'Pickup game has already passed') {
        super(message);
        this.name = 'PickupGameAlreadyPassedError';
        this.code = 400;
    }
}

class NotFoundError extends Error {
    constructor(message = 'Id was not found') {
        super(message);
        this.name = 'NotFoundError';
        this.code = 404;
    }
}

class BadRequest extends Error {
    constructor(message = 'Field arguments were not setup correctly') {
        super(message);
        this.name = 'BadRequest';
        this.code = 400;
    }
}
class InternalServerError extends Error {
    constructor(fromWebService, message = 'Internal server error occurred') {
        const messageExplicit = fromWebService !== undefined ? `Unable to fetch data from ${fromWebService ? "web service" : "MongoDB data source"}.` : message;
        super(messageExplicit);
        this.name = 'InternalServerError';
        this.code = 500;
    }
}

class ValidationError extends Error {
    constructor(err) {
        let errorMessage = "Input model was not properly formatted.\n";
        const { errors } = err;
        for(let e in errors) if(errors.hasOwnProperty(e))
            errorMessage += `${errors[e].value} is an invalid value for '${e}' (should be a valid ${errors[e].kind})\n`;
        super(errorMessage);
        this.name = 'PreconditionFailed';
        this.code = 412;
    }
}

module.exports = {
    PickupGameExceedMaximumError,
    BasketballFieldClosedError,
    PickupGameOverlapError,
    PickupGameAlreadyPassedError,
    NotFoundError,
    BadRequest,
    InternalServerError,
    ValidationError
};
