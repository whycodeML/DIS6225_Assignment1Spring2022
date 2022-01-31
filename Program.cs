/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE FUNCTION BLOCK

*/
using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;

namespace DIS_Assignmnet1_SPRING_2022
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1
            Console.WriteLine("Q1: Enter the string:");
            string s = Console.ReadLine();
            string final_string = RemoveVowels(s);
            Console.WriteLine("Final string after removing the Vowels: {0}", final_string);
            Console.WriteLine();
            
            //Question 2:
            string[] bulls_string1 = new string[] { "Marshall", "Student", "Center" };
            string[] bulls_string2 = new string[] { "MarshallStudent", "Center" };
            bool flag = ArrayStringsAreEqual(bulls_string1, bulls_string2);
            Console.WriteLine("Q2");
            if (flag)
            {
                Console.WriteLine("Yes, Both the array’s represent the same string");
            }
            else
            {
                Console.WriteLine("No, Both the array’s don’t represent the same string ");
            }
            Console.WriteLine();
            
            //Question 3:
            int[] bull_bucks = new int[] { 1, 2, 3, 2 };
            int unique_sum = SumOfUnique(bull_bucks);
            Console.WriteLine("Q3:");
            Console.WriteLine("Sum of Unique Elements in the array are :{0}", unique_sum);
            Console.WriteLine();
            
            
            //Question 4:
            int[,] bulls_grid = new int[,] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 } };
            Console.WriteLine("Q4:");
            int diagSum = DiagonalSum(bulls_grid);
            Console.WriteLine("The sum of diagonal elements in the bulls grid is {0}:", diagSum);
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Q5:");
            String bulls_string = "aiohn";
            int[] indices = { 3, 1, 4, 2, 0 };
            String rotated_string = RestoreString(bulls_string, indices);
            Console.WriteLine("The  Final string after rotation is {0} ", rotated_string);
            Console.WriteLine();
            
            //Quesiton 6:
            string bulls_string6 = "mumacollegeofbusiness";
            char ch = 'c';
            string reversed_string = ReversePrefix(bulls_string6, ch);
            Console.WriteLine("Q6:");
            Console.WriteLine("Resultant string are reversing the prefix:{0}", reversed_string);
            Console.WriteLine();

        }

        /* 
        <summary>
        Given a string s, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.

        Example 1:
        Input: s = "MumaCollegeofBusiness"
        Output: "MmCllgfBsnss"

        Example 2:
        Input: s = "aeiou"
        Output: ""

        Constraints:
        •	0 <= s.length <= 10000
        s consists of uppercase and lowercase letters
        </summary>
        */

        private static string RemoveVowels(string s)
        {
            String final_string = "";
            Char[] v = new Char[5] { 'a', 'e', 'i', 'o', 'u' }; // creating vovels to check
            bool flag;

            try
            {
                if (s.Length >= 0 && s.Length <= 10000) //constraint checking
                {


                    // write your code here
                    for (int x = 0; x < s.Length; x++)
                    {
                        flag = false;
                        char c = char.ToLower(s[x]); //lowering case before checking as it is case sensetive

                        for (int y = 0; y < v.Length; y++)
                        {
                            if (c == v[y]) //checking vovels
                            {
                                flag = true; //setting flag to true if matched
                            }
                        }

                        if (flag == false)
                        {
                            final_string += s[x]; //appending all the characters that are not vovel in their original form.
                        }
                    }
                    return final_string;
                }
                else
                {
                    return null;
                }
            }

            catch (Exception)
            {
                throw;
            }

        }

        /* Q1 - Self Reflection
         * Time - 15 minsThis problem took around 15 mins of time
         * Learning and Self reflection - We should carefully check the output, I was ignoring the case senstivness in the output.
         */

        /* 
        <summary>
       Given two string arrays word1 and word2, return true if the two arrays represent the same string, and false otherwise.
       A string is represented by an array if the array elements concatenated in order forms the string.
       Example 1:
       Input: : bulls_string1 = ["Marshall", "Student",”Center”], : bulls_string2 = ["MarshallStudent ", "Center"]
       Output: true
       Explanation:
       word1 represents string "marshall" + "student" + “center” -> "MarshallStudentCenter "
       word2 represents string "MarshallStudent" + "Center" -> "MarshallStudentCenter"
       The strings are the same, so return true.
       Example 2:
       Input: word1 = ["Zimmerman", "School", ”of Advertising”, ”and Mass Communications”], word2 = ["Muma", “College”,"of”, “Business"]
       Output: false

       Example 3:
       Input: word1  = ["University", "of", "SouthFlorida"], word2 = ["UniversityofSouthFlorida"]
       Output: true
       </summary>
       */

        private static bool ArrayStringsAreEqual(string[] bulls_string1, string[] bulls_string2)
        {
            try
            {
                
                bool areEqual = String.Equals(string.Join("",bulls_string1), string.Join("", bulls_string2), StringComparison.OrdinalIgnoreCase); //comparing two string by joining them and storing in a vasriable
                if (areEqual)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        /* Q2 - Self Reflection
         * Time - This problem took around 5 mins of time
         * Learning and Self reflection - There is always easy way to do things.
         */

        /*
        <summary> 
       You are given an integer array bull_bucks. The unique elements of an array are the elements that appear exactly once in the array.
       Return the sum of all the unique elements of es.
       Example 1:
       Input: bull_bucks = [1,2,3,2]
       Output: 4
       Explanation: The unique elements are [1,3], and the sum is 4.
       Example 2:
       Input: bull_bucks = [1,1,1,1,1]
       Output: 0
       Explanation: There are no unique elements, and the sum is 0.
       Example 3:
       Input: bull_bucks = [1,2,3,4,5]
       Output: 15
       Explanation: The unique elements are [1,2,3,4,5], and the sum is 15.
       </summary>
        */

        private static int SumOfUnique(int[] bull_bucks)
        {
            int sum = 0; // Declaring var for returning sum
            try
            {
                if (bull_bucks.Length >= 1 && bull_bucks.Length <= 100) // checking constraints mentioned
                {

                    Dictionary<int, int> d = new Dictionary<int, int>(); // Using dictionary for the main logic
                    foreach (int e in bull_bucks)
                    {
                        if (e >= 1 && e <= 100) //checking another constraint for the each element
                        {


                            if (d.ContainsKey(e))
                            {
                                d[e]++; // incresing value count if element is already in the dictionary
                            }
                            else
                            {
                                d.Add(e, 1);
                            }
                        }
                        else
                        {
                            return 0;
                        }

                    }
                    foreach (var kv in d)
                    {
                        if (kv.Value == 1) // checking elements where value is 1, then adding them up
                        {
                            sum += kv.Key; // increasing sum for each element with value 1
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }

            return sum;
        }

        /* Q3 - Self Reflection
         * Time - This problem took around 20 mins of time
         * Learning and Self reflection - Disctionaries can be very useful and time efficient.
         */

        /*

        <summary>
       Given a square matrix bulls_grid, return the sum of the matrix diagonals.
       Only include the sum of all the elements on the primary diagonal and all the elements on the secondary diagonal that are not part of the primary diagonal.

       Example 1:
       Input: bulls_grid = [[1,2,3],[4,5,6], [7,8,9]]
       Output: 25
       Explanation: Diagonals sum: 1 + 5 + 9 + 3 + 7 = 25
       Notice that element mat[1][1] = 5 is counted only once.
       Example 2:
       Input: bulls_grid = [[1,1,1,1], [1,1,1,1],[1,1,1,1], [1,1,1,1]]
       Output: 8
       Example 3:
       Input: bulls_grid = [[5]]
       Output: 5
       </summary>

        */

        private static int DiagonalSum(int[,] bulls_grid)
        {
            try
            {
                int r = bulls_grid.GetLength(0); //getting rows and columns of matrix
                int c = bulls_grid.GetLength(1);
                int sum1 = 0;
                int j = 0;

                for (int i = 0; i < r; i++) //loop to get sum of left to right diagonal
                {
                    j = i;
                    sum1 += bulls_grid[i, j];

                }
                j = r - 1;

                for (int i = 0; i < r; i++) //loop to get sum of right to left diagonal
                {
                    sum1 += bulls_grid[i, j];
                    j--;
                }
                int rem;
                int quo = 0;
                if (r % 2 != 0) //checking if middle element is added twice
                {
                    quo += Math.DivRem(r, 2, out rem); //finding the middle element
                    sum1 = sum1 - bulls_grid[quo, quo];
                }
                return sum1;
            }
            catch (Exception e)
            {

                Console.WriteLine("An error occured: " + e.Message);
                throw;
            }

        }

        /* Q4 - Self Reflection
         * Time - This problem took around 20 mins of time
         * Learning and Self reflection - Handling dictionaries in c can be challenging sometimes, need to do more handson.
         */


        /*
         
        <summary>
        Given a string bulls_string  and an integer array indices of the same length.
        The string bulls_string  will be shuffled such that the character at the ith position moves to indices[i] in the shuffled string.
        Return the shuffled string.

        Example 3:
        Input: bulls_string  = "aiohn", indices = [3,1,4,2,0]
        Output: "nihao"

        */

        private static string RestoreString(string bulls_string, int[] indices)
        {
            try
            {
                int strLen = bulls_string.Length;
                int indLen = indices.Length;

                if (strLen == indLen && strLen >= 1 && strLen <= 100) //checking constraints
                {
                    var regexp = new Regex("^[a-z]+$"); //creating regular expression with a-z small letters no other letters could be a part of this
                    if (regexp.IsMatch(bulls_string) == true) // this condition is true when input string has all the small case letters, else it would be false
                    {

                        string[] output = new string[strLen];
                        for (int i = 0; i < strLen; i++)
                        {
                            int val = indices[i];
                            if(val>=0 && val < indLen) //checking constraint
                            {
                                output[val] = char.ToString(bulls_string[i]); //main logic where index is used to place the character in the restored string
                            }
                            else
                            {
                                return null;
                            }
                        }
                        string s1 = string.Join("", output); //concatinating the arrsy to generate string
                        return s1;
                    }
                    else
                    {
                        return null; //regex return
                    }
                }
                else
                {
                    return null; //constraint return
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

        }
        /* Q5 - Self Reflection
         * Time - This problem took around 30 mins of time
         * Learning and Self reflection - Learned new technique of Regex in C, rest other things were easy to implement.
         */

        /*
         <summary>
        Given a 0-indexed string bulls_string   and a character ch, reverse the segment of word that starts at index 0 and ends at the index of the first occurrence of ch (inclusive). If the character ch does not exist in word, do nothing.
        For example, if word = "abcdefd" and ch = "d", then you should reverse the segment that starts at 0 and ends at 3 (inclusive). The resulting string will be "dcbaefd".
        Return the resulting string.

        Example 1:
        Input: bulls_string   = "mumacollegeofbusiness", ch = "c"
        Output: "camumollegeofbusiness"
        Explanation: The first occurrence of "c" is at index 4. 
        Reverse the part of word from 0 to 4 (inclusive), the resulting string is "camumollegeofbusiness".

        Example 2:
        Input: bulls_string   = "xyxzxe", ch = "z"
        Output: "zxyxxe"
        Explanation: The first and only occurrence of "z" is at index 3.
        Reverse the part of word from 0 to 3 (inclusive), the resulting string is "zxyxxe".

        Example 3:
        Input: bulls_string   = "zimmermanschoolofadvertising", ch = "x"
        Output: "zimmermanschoolofadvertising"
        Explanation: "x" does not exist in word.
        You should not do any reverse operation, the resulting string is "zimmermanschoolofadvertising".
        */

        private static string ReversePrefix(string bulls_string6, char ch)
        {
            try
            {
                String prefix_string = "";
                int ind = bulls_string6.IndexOf(ch);
                
                var regexp = new Regex("^[a-z]+$");

                if (bulls_string6.Length >= 1 && bulls_string6.Length <= 250 && regexp.IsMatch(char.ToString(ch)) == true) //checking all the constraints 
                {

                    if (ind >= 0) // if a values is found the the index would be > = 0 else it would be -1
                    {

                        string[] s1 = new string[bulls_string6.Length]; // creating array with same elements as the input string lenght
                        int j = 0;
                        for (int i = ind; i >= 0; i--)
                        {
                            s1[j] = char.ToString(bulls_string6[i]); //loop is used to reverse the string from begining till index location found
                            j++;
                        }
                        s1[j] = bulls_string6.Substring(j, bulls_string6.Length - j); //adding remaining string 
                        string op = string.Join("", s1); //concatinating array to string
                        return op;
                    }
                    else
                    {
                        return bulls_string6; //incase character is not found in the string
                    }
                }
                else
                {
                    return prefix_string;
                }

            }
            catch (Exception)
            {

                throw;
            }

        }
        /* Q6 - Self Reflection
         * Time - This problem took around 30 mins of time
         * Learning and Self reflection - Again used Regex here which was helpful as I learned this in Q5, rest other things were easy to implement.
         */
    }
}