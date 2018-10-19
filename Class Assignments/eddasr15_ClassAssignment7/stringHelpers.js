
/**
 * Functionality of string helpers with all member functions
 * Encapsulated in function e.g. to preserve block scoping
 * @returns all member functions, i.e. all modules to be exported
 */
const stringHelpers = () => {
    /**
     * Returns true if string is a palindrome (case insensitive)
     * @param {*} str string to check whether is a palindrome
     */
    const isPalindrome = str => str.toLowerCase() == str.split('').reverse().join('').toLowerCase();

    return { isPalindrome }
}

module.exports = stringHelpers();