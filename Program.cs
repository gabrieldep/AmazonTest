using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;

namespace AmazonTest
{
    public class Result
    {
        internal static List<int> MinimalHeaviestSetA(List<int> arr)
        {
            arr = arr.OrderByDescending(a => a).ToList();
            var subsetA = new List<int>();
            var totalSum = arr.Sum();
            var subsetSum = 0;
            while (true)
            {
                var aux = arr[0];
                totalSum -= aux;
                arr.Remove(aux);
                subsetA.Add(aux);
                subsetSum += aux;
                if (subsetSum > totalSum)
                    break;
            }
            subsetA.Reverse();
            return subsetA;
        }

        public static int CountGroups(List<string> related)
        {
            var connections = new List<Tuple<int, int>>();
            for (int i = 0; i < related.Count; i++)
            {
                for (int j = 0; j < related[0].Count(); j++)
                {
                    if (i == j)
                        continue;
                    if (related[i][j] == 1)
                    {
                        if (connections.Contains(new(j, i)))
                            continue;
                        else
                            connections.Add(new(j, i));
                    }
                }
            }
            return GetGroupCount(ref connections, 0);
        }

        internal static int GetGroupCount(ref List<Tuple<int, int>> groups, int index)
        {
            if (index == groups.Count)
                return 0;
            var tuple = groups.FirstOrDefault(g => g.Item1 == index);
            if (tuple == null)
                return 1;
            else
                groups.Remove(tuple);
            var rtrn = GetGroupCount(ref groups, tuple.Item2);
            return rtrn;
        }
    }
}