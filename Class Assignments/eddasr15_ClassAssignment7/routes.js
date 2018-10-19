const express = require('express');
const myEmitter = require('./myEmitter');
const router = express.Router();
const app = express();
const port = 3000;

/**
 * Checks whether string is a palindrome by calling function
 */
router.get('/ispalindrome/', (req, res) => {

    // Extract query parameter
    const { palindrome } = req.query;
    if(palindrome == undefined) return res.status(400).send('must provide query parameter "palindrome"');

    // Register listeners for a palindromes responses
    // Will return response with appropriate status to client on event
    var emitter = new myEmitter();
    emitter.on(emitter.PALINDROME_EVT, msg => res.status(200).send(msg));
    emitter.on(emitter.NOT_PALINDROME_EVT, msg => res.status(400).send(msg));

    // Check for palindrome
    // Listeners will return HTTP response based on emit
    emitter.checkPalindrome(palindrome);
});

/**
 * Set up API on port
 * Prefix routes with /api
 */
app.use('/api', router);
app.listen(port || process.env.PORT, () => console.log(`Listening on port ${port}`) );