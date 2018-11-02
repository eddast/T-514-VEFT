const isPalindrome = require('./stringHelpers').isPalindrome;
const EventEmitter = require('events');

/**
 * Custom event emitter class
 * Checks for palindromes in string
 */
class MyEmitter extends EventEmitter {
    /**
     * Initializes emitter
     * Defines constant values for event variables used by emitter
     */
    constructor() {
        super();
        this.NOT_PALINDROME_EVT = 'not-palindrome';
        this.PALINDROME_EVT = 'palindrome'
    }
    /**
     * Palindrome check that emits event according to whether parameter string is palindrome
     * @param {*} str string to check whether is a palindrome
     */
    checkPalindrome(str) {
        if(isPalindrome(str))   this.emit(this.PALINDROME_EVT, 'This was a palindrome!') 
        else                    this.emit(this.NOT_PALINDROME_EVT, 'This was not a palindrome!')
    }
}

module.exports = MyEmitter;