using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StringReassemblyByJK
{
    //Author: Jaishree Kulkarni 
    //Date: 22nd July 2019
    //Version 1.0.0

    //Class library StringReassembly to process a set of strings to check for overlaps and merge them.

    public class StringReassembly
    {
        // Function to calculate maximum overlap in two given strings 
        public Tuple<int, StringBuilder> FindOverlaps(string str1, string str2)
        {
            // maximum overlap length of the matching prefix and suffix
            int max = int.MinValue;
            int len1 = str1.Length;
            int len2 = str2.Length;
            StringBuilder sb = new StringBuilder();

            // start with minimum length      
            int n = Math.Min(len1, len2);

            if (len1 < len2)
            {
                //if x is substring of y return y
                if (str2.Contains(str1))
                {
                    sb.Clear();
                    sb.Append(str2);
                    return new Tuple<int, StringBuilder>(len1, sb);
                }
            }
            else
            {
                //if x is substring of y return y
                if (str1.Contains(str2))
                {
                    sb.Clear();
                    sb.Append(str1);
                    return new Tuple<int, StringBuilder>(len2, sb);
                }

            }

            // check suffix of str1 matches with prefix of str2
            for (int i = 1; i <= n; i++)
            {
                if (str1.Substring(len1 - i).Equals(str2.Substring(0, i)))
                {
                    if (max < i)
                    {
                        max = i;
                        sb.Clear();
                        sb.Append(str1).Append(str2.Substring(i));
                    }
                }
            }

            // check prefix of str1 matches with suffix of str2
            for (int i = 1; i <= n; i++)
            {
                // compare first i characters in str1 with last i characters in str2
                if (str1.Substring(0, i).Equals(str2.Substring(len2 - i)))
                {
                    if (max < i)
                    {
                        max = i;
                        sb.Clear();
                        sb.Append(str2).Append(str1.Substring(i));
                    }
                }
            }
            return new Tuple<int, StringBuilder>(max, sb);
        }

        //Calculate smallest string that contains each string in the given set as substring. 
        public string AssembleStrings(List<string> listStr)
        {
            int n = listStr.Count;

            if(n<1)           
                return "";
            
             if (n == 1)
                return listStr[0];
           

            // run n-1 times to consider every pair
            while (n != 1)
            {
                // check for maximum overlap
                int max = int.MinValue;
                // stores index of strings involved in maximum overlap
                int str1Index = -1, str2Index = -1;

                // to store resultant string after maximum overlap
                String resStr = "";

                for (int i = 0; i < n; i++)
                {
                    for (int j = i + 1; j < n; j++)
                    {

                        // r will store maximum length of the matching prefix and suffix. sb stores
                        // the resultant string after maximum overlap of str1 and str2                       
                        Tuple<int, StringBuilder> r = FindOverlaps(listStr[i], listStr[j]);

                        // check for maximum overlap
                        if (max < r.Item1)
                        {
                            max = r.Item1;
                            resStr = r.Item2.ToString();
                            str1Index = i;
                            str2Index = j;
                        }
                    }
                }
                // ignore last element in next cycle
                n--;

                // if no overlap, append listStr(n) to listStr(0)
                if (max == int.MinValue)
                {
                    listStr[0] += listStr[n];
                }
                else
                {
                    // copy resultant string
                    listStr[str1Index] = resStr;
                    listStr[str2Index] = listStr[n];
                }
            }
            return listStr[0];
        }
    }
}
