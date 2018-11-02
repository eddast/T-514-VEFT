using System.Linq;

namespace CleanThatCode.Community.Common
{
    // Your job is to implement this class
    public static class StringHelpers
    {
        // Instead of spaces it should be separated with dots, e.g. Hello World -> Hello.World
        public static string ToDotSeparatedString(this string str)
        {
            return str.Replace(' ', '.');;
        }
        
        // All words in the string should be capitalized, e.g. teenage mutant ninja turtles -> Teenage Mutant Ninja Turtles
        public static string CapitalizeAllWords(this string str)
        {
            /* split string into array of words on space */
            string[] words = str.Split(' ');

            /* capitalize first letter in each word */
            for(int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                word = char.ToUpper(word[0]).ToString() + word.Substring(1);
                words[i] = word;
            }

            /* puzzle sentence back together, words seperated by spaces */
            return string.Join(" ", words);
        }

        // The words should be reversed in the string, e.g. Hi Ho Silver Away! -> Away! Silver Ho Hi
        public static string ReverseWords(this string str)
        {
            /* split string into array of words on space */
            string[] words = str.Split(' ');

            /* reverse array of words */
            for(int i = 0; i < words.Length/2; i++)
            {
                string tmp = words[i];
                words[i] = words[words.Length-i-1];
                words[words.Length-i-1] = tmp;
            }

            /* puzzle sentence back together, words now reversed */
            return string.Join(" ", words);
        }
    }
}