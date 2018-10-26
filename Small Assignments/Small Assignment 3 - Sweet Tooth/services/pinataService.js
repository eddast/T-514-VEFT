const pinatasWithSurpise = require('../data/data').pinatas;
const NOT_FOUND = require('../resources/common').NOT_FOUND_INDICATOR;

/**
 * Manipulates candy data souces in system
 */
const pinataService = () => {

    /**
     * Gets all pinatas in system and excludes their suprise property
     * @returns all pinatas in system excluding their surprise property
     */
    const getAllPinatas = () => {
        let pinatas = [];
        pinatasWithSurpise.forEach(pinata => {
            // Show current hits as 0 if no hits have been issued
            pinata.currentHits == undefined ? pinata.currentHits = 0 : null;
            pinatas.push(hideSurpriseForPinata(pinata));
        });
        return pinatas;
    };

    /**
     * Gets a specific pinata by id from data and excludes their suprise property
     * @param {*} id id of pinata to get
     * @return -1 if pinata was not found, otherwise the pinata object by id excluding surprise property
     */
    const getPinataById = id => {
        const pinataWithSurprise = getPinataByIdWithSurprise(id);
        if (pinataWithSurprise == NOT_FOUND) return NOT_FOUND;
        // Show current hits as 0 if no hits have been issued
        pinataWithSurprise.currentHits == undefined ? pinataWithSurprise.currentHits = 0 : null;
        return hideSurpriseForPinata(pinataWithSurprise);
    };

    /**
     * Gets a specific pinata by id from data
     * @param {*} id id of pinata to get
     * @return -1 if pinata was not found, otherwise the pinata object
     */
    const getPinataByIdWithSurprise = id => {
        const pinataWithSurprise = pinatasWithSurpise.filter(p => p.id == id);
        if (pinataWithSurprise.length === 0) return NOT_FOUND;
        return pinataWithSurprise[0];
    };

    /**
     * Returns a pinata object excluding the surprise property
     * @param {*} pinata to remove surprise property from
     */
    const hideSurpriseForPinata = pinata => {
        const {['surprise']: deletedKey, ...otherKeys} = pinata;
        return otherKeys;
    }

    /**
     * Adds a new pinata into the system
     * @param {*} pinata json object to add to system as pinata resource
     */
    const createPinata = pinata => {
        let highestId = 0;
        pinatasWithSurpise.forEach(c => { if (c.id > highestId) { highestId = c.id; }});
        const id = highestId + 1; const { name, surprise, maximumHits } = pinata;
        const newPinata = { id, name, surprise, maximumHits };
        pinatasWithSurpise.push(newPinata);
        return newPinata;
    };

    /**
     * Increment the hits for a pinata in the system by it's pinata id if hits have not reached maximum
     * @param {*} id id of pinata to hit
     * @returns surprise property of pinata if hit was last blow towards maximum hits
     * @returns true if hit was successful (but didn't reach maximum hits yet)
     * @returns false if hit was not done due to maximum hit for given pinata having exceeded
     * @returns NOT_FOUND_INDICATOR (-1) if pinata was not found for given id
     */
    const hitPinataById = id => {

        // check if pinata exists
        let pinata = getPinataByIdWithSurprise(id);
        if(pinata == NOT_FOUND) return NOT_FOUND;

        // check if maximum hits have been reached for pinata
        const { currentHits, maximumHits } = pinata;
        if( currentHits >= maximumHits ) return false;

        // if maximum hits not reached, issue a hit to pinata
        if(currentHits == undefined) pinata.currentHits = 1;
        else pinata.currentHits = pinata.currentHits+1;

        // check if maximum hit were just reached by current hit
        // if so, return pinata's surprise property
        if( pinata.currentHits < maximumHits ) return true;
        else return { surprise: pinata.surprise };
    }

    return {
        getAllPinatas,
        getPinataById,
        createPinata,
        hitPinataById
    };
};

module.exports = pinataService();
