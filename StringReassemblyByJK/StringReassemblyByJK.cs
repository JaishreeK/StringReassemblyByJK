using System;
using System.Collections.Generic;
using System.Text;

namespace StringReassemblyByJK
{
    //Author: Jaishree Kulkarni 
    //Date: 22nd July 2019
    //Version 0.0.1

    //Class library StringReassembly to process a set of strings to check for overlaps and merge them.
    public class StringReassembly
    {
        // Calculates maximum overlap in two given strings, Returns the distance and overlapping string
        private Tuple<int, StringBuilder> FindOverlaps(string str1, string str2)
        {
            StringBuilder sb = new StringBuilder();
            int max = int.MinValue;

            if ((str1 != null) && (str2 != null))
            {                
                int len1 = str1.Length;
                int len2 = str2.Length;

                // start with minimum length
                int n;

                if (len1 < len2)
                {
                    n = len1;
                    //if str1 is substring of str2 return str2
                    if (str2.Contains(str1))
                        return new Tuple<int, StringBuilder>(len1, new StringBuilder(str2));

                }
                else
                {
                    n = len2;
                    //if str2 is substring of str1 return str1
                    if (str1.Contains(str2))
                        return new Tuple<int, StringBuilder>(len2, new StringBuilder(str1));

                }

                

                // check suffix of str1 matches with prefix of str2
                for (var i = 1; i <= n; i++)
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
                for (var i = 1; i <= n; i++)
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
            }
            return new Tuple<int, StringBuilder>(max, sb);
        }

        //Assembles the given strings into one by checking the overlaps and substrings in them. Uses Greedy Match and Merge algorithm. Returns the final result string 
        public string AssembleStrings(List<string> listStr)
        {
            if (listStr != null)
            {
                int n = listStr.Count;

                if (n < 1)
                    return "";

                if (n == 1)
                    return listStr[0];


                // run n-1 times to consider every pair
                while (n != 1)
                {
                    // check for maximum overlap
                    int max = int.MinValue;
                    int str1Index = -1, str2Index = -1;

                    String resultStr = "";

                    for (var i = 0; i < n; i++)
                    {
                        for (var j = i + 1; j < n; j++)
                        {
                            // resultOverlap stores maximum length of the matching prefix and suffix. sb stores
                            // the resultant string after maximum overlap of str1 and str2                       
                            Tuple<int, StringBuilder> resultOverlap = FindOverlaps(listStr[i], listStr[j]);

                            // check for maximum overlap
                            if (max < resultOverlap.Item1)
                            {
                                max = resultOverlap.Item1;
                                resultStr = resultOverlap.Item2.ToString();
                                str1Index = i;
                                str2Index = j;
                            }
                        }
                    }
                    // ignore last element in next cycle
                    n--;

                    // if no overlap, append listStr(n) to listStr(0)
                    if (max == int.MinValue)                    
                        listStr[0] += listStr[n];                   
                    else
                    {
                        listStr[str1Index] = resultStr;
                        listStr[str2Index] = listStr[n];
                    }
                }
                return listStr[0];
            }
            return "";
        }
    }
}
