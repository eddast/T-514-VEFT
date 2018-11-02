const { Area, Shark, Attack, connection } = require('./db');
const { TIGER_SHARK, HAMMERHEAD_SHARK, GREAT_WHITE_SHARK, BULL_SHARK, WHALE_SHARK, NORTH_AMERICA, AUSTRALIA, EUROPE, MEXICO_BEACH, MALIBU_BEACH, GOLD_COAST, BONDI_BEACH, REYKJANES_BEACH } = require('../constants');
const cliProgress = require('cli-progress');

const getResourceIdByName = (resources, prop, value) => resources.find(elem => elem[prop] === value);
const bar = new cliProgress.Bar({}, cliProgress.Presets.rect);
bar.start(100, 0);

// Drop all collections before execution
Object.keys(connection.collections).forEach(collection => {
    if (collection === 'areas') { Area.collection.drop(); }
    if (collection === 'sharks') { Shark.collection.drop(); }
    if (collection === 'attacks') { Attack.collection.drop(); }
});

// CHRISTMAS TREE!!
//           *
//          /.\
//         /..'\
//         /'.'\
//        /.''.'\
//        /.'.'.\
// "'""""/'.''.'.\""'"'"
//       ^^^[_]^^^
Shark.insertMany([
    { species: TIGER_SHARK },
    { species: HAMMERHEAD_SHARK },
    { species: GREAT_WHITE_SHARK },
    { species: BULL_SHARK },
    { species: WHALE_SHARK }
], err => {
    if (err) { throw new Error(err); }
    bar.update(25);
    Shark.find({}, (err, sharks) => {
        if (err) { throw new Error(err); }
        bar.update(35);
        Area.insertMany([
            {
                name: MEXICO_BEACH,
                region: NORTH_AMERICA
            },
            {
                name: MALIBU_BEACH,
                region: NORTH_AMERICA
            },
            {
                name: GOLD_COAST,
                region: AUSTRALIA
            },
            {
                name: BONDI_BEACH,
                region: AUSTRALIA
            },
            {
                name: REYKJANES_BEACH,
                region: EUROPE
            }
        ], err => {
            if (err) { throw new Error(err); }
            bar.update(65);
            Area.find({}, (err, areas) => {
                if (err) { throw new Error(err); }
                bar.update(80);
                Attack.insertMany([
                    // Beginning of mexico beach
                    {
                        sharkId: getResourceIdByName(sharks, 'species', TIGER_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MEXICO_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', TIGER_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MEXICO_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', TIGER_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MEXICO_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', TIGER_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MEXICO_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', BULL_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MEXICO_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', BULL_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MEXICO_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', GREAT_WHITE_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MEXICO_BEACH)
                    },
                    // End of mexico beach
                    // Start of malibu beach
                    {
                        sharkId: getResourceIdByName(sharks, 'species', GREAT_WHITE_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MALIBU_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', GREAT_WHITE_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MALIBU_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', GREAT_WHITE_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MALIBU_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', HAMMERHEAD_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MALIBU_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', HAMMERHEAD_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MALIBU_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', TIGER_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MALIBU_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', TIGER_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MALIBU_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', TIGER_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MALIBU_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', TIGER_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MALIBU_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', TIGER_SHARK),
                        areaId: getResourceIdByName(areas, 'name', MALIBU_BEACH)
                    },
                    // End of malibu beach
                    // Start of gold coast
                    {
                        sharkId: getResourceIdByName(sharks, 'species', GREAT_WHITE_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', GREAT_WHITE_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', GREAT_WHITE_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', GREAT_WHITE_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', GREAT_WHITE_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', GREAT_WHITE_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', BULL_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', BULL_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', BULL_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', BULL_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', BULL_SHARK),
                        areaId: getResourceIdByName(areas, 'name', GOLD_COAST)
                    },
                    // End of gold coast
                    // Beginning of bondi beach
                    {
                        sharkId: getResourceIdByName(sharks, 'species', HAMMERHEAD_SHARK),
                        areaId: getResourceIdByName(areas, 'name', BONDI_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', HAMMERHEAD_SHARK),
                        areaId: getResourceIdByName(areas, 'name', BONDI_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', HAMMERHEAD_SHARK),
                        areaId: getResourceIdByName(areas, 'name', BONDI_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', HAMMERHEAD_SHARK),
                        areaId: getResourceIdByName(areas, 'name', BONDI_BEACH)
                    },
                    {
                        sharkId: getResourceIdByName(sharks, 'species', HAMMERHEAD_SHARK),
                        areaId: getResourceIdByName(areas, 'name', BONDI_BEACH)
                    }
                    // End of bondi beach
                ], err => {
                    if (err) { throw new Error(err); }
                    bar.update(100);
                    bar.stop();
                    connection.close();
                });
            });
        });
    });
});
