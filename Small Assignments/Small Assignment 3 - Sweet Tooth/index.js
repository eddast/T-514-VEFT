const express = require('express');
const bodyParser = require('body-parser');
const router = express.Router();
const app = express();
const port = 3000;
const NOT_FOUND = require('./resources/common').NOT_FOUND_INDICATOR;
const candyService = require('./services/candyService');
const offerService = require('./services/offerService');
const pinataService = require('./services/pinataService');

/****************************************
 * ROUTES FOR CANDY RESOURCES IN SYSTEM *
 ****************************************/

/**
 * [GET] /api/candies
 * Gets all candies in system
 * Returns HTTP status 200 (OK) along with all candies
 */
router.get('/candies', (req, res) => res.json(candyService.getAllCandies()));

/**
 * [GET] /api/candies/:id
 * Gets a specified candy in system by candy id
 * Returns HTTP status 200 (OK) if candy is found along with that candy
 * Returns HTTP status 404 (not found) if candy is not found
 */
router.get('/candies/:id', (req, res) => {
    const { id } = req.params;
    const candy = candyService.getCandyById(id);
    if (candy === NOT_FOUND) return res.status(404).send('Candy with id ' + id + ' not found');
    return res.json(candy);
});

/**
 * [POST] /api/candies
 * Creates a new candy resource in system
 * New candy object passed as request body, no model validation
 * Returns HTTP status 201 (created)
 */
router.post('/candies', (req, res) => {
    const { body } = req;
    const newCandy = candyService.createCandy(body);
    return res.status(201).send(newCandy);
});

/****************************************
 * ROUTES FOR OFFER RESOURCES IN SYSTEM *
 ****************************************/

 /**
 * [GET] /api/offers
 * Gets all offers in system with embedded candies
 * Returns HTTP status code of 200 (OK) along with all offers
 */
router.get('/offers', (req, res) => res.json(offerService.getAllOffers()));

/*****************************************
 * ROUTES FOR PINATA RESOURCES IN SYSTEM *
 *****************************************/

/**
 * [GET] /api/pinatas
 * Gets all pinatas in system (without revealing their surprise feature)
 * Returns HTTP status code of 200 (OK) along with all pinatas
 */
router.get('/pinatas', (req, res) => res.json(pinataService.getAllPinatas()));

/**
 * [GET] /api/pinatas/:id
 * Gets specific pinata in system by it's pinata id (without revealing it's surprise feature)
 * Returns HTTP status 200 (OK) if pinata is found along with that pinata
 * Returns HTTP status 404 (not found) if pinata is not found
 */
router.get('/pinatas/:id', (req, res) => {
    const { id } = req.params;
    const pinata = pinataService.getPinataById(id);
    if (pinata === NOT_FOUND) return res.status(404).send('Pinata with id ' + id + ' not found');
    return res.json(pinata);
});

/**
 * [POST] /api/pinatas
 * Creates a new pinata resource in system
 * New pinata object passed as request body, no model validation
 * Returns HTTP status 201 (created)
 */
router.post('/pinatas', (req, res) => {
    const { body } = req;
    const newPinata = pinataService.createPinata(body);
    return res.status(201).send(newPinata);
});

/**
 * [PATCH] /api/pinatas/:id/hit
 * Adds to hits for a pinata resource by it's id if maximum hits for pinata is not reached
 * Returns HTTP status 204 (no content) on successful hit if maximum hits is not reached
 * Returns HTTP status 200 (OK) on successful hit that reaches maximum hits along with pinata's surprise
 * Returns HTTP status 423 (locked) if maximum hits have already been reached
 * Returns HTTP status 404 (not found) if pinata is not found by id
 */
router.patch('/pinatas/:id/hit', (req, res) => {
    const { id } = req.params;
    const success = pinataService.hitPinataById(id);
    // not found
    if (success === NOT_FOUND) return res.status(404).send('Pinata with id ' + id + ' not found');
    // reached maximum hits - show surprise
    if (success.surprise !== undefined) return res.status(200).send(success);
    // hit successful
    if (success) return res.status(204).send();
    // hit unsuccessful - pinata over maximum hits
    return res.status(423).send();
});


/************************
 * SETUP SERVER ON PORT *
 ************************/

app.use(bodyParser.json());
app.use('/api', router);
app.listen(port || process.env.PORT, () => console.log(`Listening on port ${port}`));
