using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodeKata {
    public class StringCalculator {
        public int Add(string numbers) {
            var delimeter = GetDelimeters(numbers);
            var intNumbers = SplitStringToInts(numbers, delimeter);
            return intNumbers.Sum();
        }

        public string[] GetDelimeters(string toCheck) {
            List<string> finalValue = new List<string>();

            if (toCheck.Length > 2 && toCheck[0] == '\\' && !CheckIfCharIsNumber(toCheck[1])) {
                    finalValue.AddRange(FindAdvancedDelimeters(toCheck));
            }

            if (finalValue.Count == 0) {
                finalValue.Add(",");
            }

            return finalValue.ToArray();
        }

        private static List<string> FindAdvancedDelimeters(string toCheck) {
            List<string> delimeters = new List<string>();

            //simple one char delimeter
            if (toCheck[1] != '[') {
                delimeters.Add(toCheck[1].ToString());
                // advanced multiple char delimeter
            } else {
                int i = 1;
                while (i < toCheck.Length - 1 && toCheck[i] == '[') {
                    i++;
                    delimeters.Add(GetSingleAdvancedDelimeter(toCheck, ref i));
                }
            }

            return delimeters;
        }

        private static string GetSingleAdvancedDelimeter(string toCheck, ref int i) {
            string delimeter = "";
            while (i < toCheck.Length - 1 && toCheck[i] != ']') {
                delimeter += toCheck[i];
                i++;
            }
            i++;
            return delimeter;
        }

        public int[] SplitStringToInts(string toSplit, string[] delimeters) {
            var splited = toSplit.Split(delimeters, StringSplitOptions.None);
            int[] result = new int[splited.Length];

            for (int i = 0; i < splited.Length; i++) {
                if (!CheckIfPositive(splited[i])) {
                    throw new ArgumentOutOfRangeException("Negatives not allowed: {1} is negative number.", splited[i]);
                }

                string cleanSegment = RemoveNonNumericChars(splited[i]);
                cleanSegment = RemoveBigNumbers(cleanSegment);
                result[i] = cleanSegment.Length > 0 ? Convert.ToInt32(cleanSegment) : 0;

            }
            return result;
        }

        public static bool CheckIfPositive(string number) {
            if (number.Length > 0 && number[0] == '-') {
                return false;
            }
            return true;
        }

        public static string RemoveNonNumericChars(string toClean) {
            string cleanSegment = "";
            for (int j = 0; j < toClean.Length; j++) {
                if (CheckIfCharIsNumber(toClean[j])) {
                    cleanSegment += ConvertCharToInt(toClean[j]).ToString();
                }
            }
            return cleanSegment;
        }

        public static string RemoveBigNumbers(string toChange) {
            if (toChange.Length > 3) {
                return "";
            }
            return toChange;
        }

        public static int ConvertCharToInt(char c) {
            int value = Convert.ToInt32(c);
            value -= 48;

            if (value < 0 || value > 9) {
                throw new ArgumentOutOfRangeException();
            }

            return value;
        }

        public static bool CheckIfCharIsNumber(char c) {
            try {
                ConvertCharToInt(c);
                return true;
            } catch (ArgumentOutOfRangeException) {
            }
            return false;
        }
    }
}
