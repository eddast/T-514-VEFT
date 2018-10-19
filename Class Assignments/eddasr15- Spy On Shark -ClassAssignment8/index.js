/********************************************
 *                                          *
 *  SC-T-514-VEFT Web Services Fall 2018    *
 *  Assignment:     Class Assignment VIII   *
 *                  Spy On Shark            *
 *  Due: 9th of October 2018                *
 *  Author: Edda Steinunn Rúnarsdóttir      *
 *                                          *
 ********************************************/

var async = require('async');
const { connection } = require('./data/db');
const { TIGER_SHARK, HAMMERHEAD_SHARK, GREAT_WHITE_SHARK, BULL_SHARK } = require('./constants');
const { getAllSharks, getAllSharksBySpecies, getSharksExcludingSpecies } = require('./services/sharkService');
const {
    getAllAttackingSharks,
    getAllAttackedAreas,
    getAllAreasAttackedAtLeastNTimes,
    getMostFrequentlyAttackedArea,
    getTotalAttackBySharkSpecies
} = require('./services/attackService');


/*****************************************
 *                                       *
 * SET UP QUERIES TESTS HELPER FUNCTIONS *
 *                                       *
 *****************************************/
/**
 * Test functionality for class assignment requirements
 * All take in callbacks to explicitly notify that test has run
 */
const tests = [
    // 1.1. Get all sharks
    (callback) => {
        console.log('\n===================');
        console.log('1.1 Get all sharks:');
        console.log('===================\n');
        getAllSharks (
            sharks =>   { console.log(sharks);  callback(); },
            error =>    { console.log(error);   callback(); }
        );
    },
    // 1.2. Get all tiger sharks
    (callback) => {
        console.log('\n========================');
        console.log('1.2 Get all tiger sharks');
        console.log('========================\n');
        getAllSharksBySpecies([TIGER_SHARK],
            sharks =>   { console.log(sharks);  callback(); },
            error =>    { console.log(error);   callback(); }
        );
    },
    // 1.3. Get all tiger and bull sharks
    (callback) => {
        console.log('\n=================================');
        console.log('1.3 Get all tiger and bull sharks');
        console.log('=================================\n');
        getAllSharksBySpecies([TIGER_SHARK, BULL_SHARK],
            sharks =>   { console.log(sharks);  callback(); },
            error =>    { console.log(error);   callback(); }
        );
    },
    // 1.4. Get all sharks except great white sharks
    (callback) => {
        console.log('\n============================================');
        console.log('1.4 Get all sharks except great white sharks');
        console.log('============================================\n');
        getSharksExcludingSpecies([GREAT_WHITE_SHARK],
            sharks =>   { console.log(sharks);  callback(); },
            error =>    { console.log(error);   callback(); }
        );
    },
    // 1.5. Get all sharks that have been known to attack
    (callback) => {
        console.log('\n=================================================');
        console.log('1.5 Get all sharks that have been known to attack');
        console.log('=================================================\n');
        getAllAttackingSharks(
            sharks =>   { console.log(sharks);  callback(); },
            error =>    { console.log(error);   callback(); }
        );
    },
    // 1.6. Get all areas with registered attacks
    (callback) => {
        console.log('\n=========================================');
        console.log('1.6 Get all areas with registered attacks');
        console.log('=========================================\n');
        getAllAttackedAreas(
            sharks =>   { console.log(sharks);  callback(); },
            error =>    { console.log(error);   callback(); }
        );
    },
    // 1.7. Get all areas with more than 5 registered attacks
    (callback) => {
        console.log('\n=====================================================');
        console.log('1.7 Get all areas with more than 5 registered attacks');
        console.log('=====================================================\n');
        getAllAreasAttackedAtLeastNTimes(5,
            attacks =>   { console.log(attacks);    callback(); },
            error =>    { console.log(error);       callback(); }
        );
    },
    // 1.8. Get the area with the most registered shark attacks
    (callback) => {
        console.log('\n=======================================================');
        console.log('1.8 Get the area with the most registered shark attacks');
        console.log('=======================================================\n');
        getMostFrequentlyAttackedArea(
            area =>     { console.log(area);    callback(); },
            error =>    { console.log(error);   callback(); }
        );
    },
    // 1.9. Get the total count of great white shark attacks
    (callback) => {
        console.log('\n====================================================');
        console.log('1.9 Get the total count of great white shark attacks');
        console.log('====================================================\n');
        getTotalAttackBySharkSpecies([GREAT_WHITE_SHARK],
            attacks =>  { console.log(attacks); callback(); },
            error =>    { console.log(error);   callback(); }
        );
    },
    // 1.10. Get the total count of hammerhead and tiger shark attacks
    (callback) => {
        console.log('\n==============================================================');
        console.log('1.10 Get the total count of hammerhead and tiger shark attacks');
        console.log('==============================================================\n');
        getTotalAttackBySharkSpecies([HAMMERHEAD_SHARK, TIGER_SHARK],
            attacks =>  { console.log(attacks); callback(); },
            error =>    { console.log(error);   callback(); }
        );
    }
];



/************************************
 *                                  *
 *      EXECUTE QUERIES/TESTS       *
 *                                  *
 ************************************/
/**
 * Executes all tests in system in order asynchronously
 * Once execution finishes for all tests we close connection
 */
async.series(tests, onFinish => connection.close());