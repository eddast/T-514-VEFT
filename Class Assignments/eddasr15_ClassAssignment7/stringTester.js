const stringHelpers = require('./stringHelpers');

// Testing isPalindrome
const results = [
    stringHelpers.isPalindrome('XOX'),
    !stringHelpers.isPalindrome('Lion-O'),
    !stringHelpers.isPalindrome('Grayskull'),
    stringHelpers.isPalindrome('Madam'),
    stringHelpers.isPalindrome('Noon'),
    stringHelpers.isPalindrome('Racecar')
];
if (results.every(r => r)) { console.log('All is well!'); }
