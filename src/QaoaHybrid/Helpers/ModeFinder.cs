﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT License.

namespace Microsoft.Quantum.Qaoa.QaoaHybrid.Helpers
{
    using System.Collections.Generic;
    using System.Linq;

    public class ModeFinder
    {
        /// <summary>
        /// Return the most common boolean string from a list of boolean values.
        /// </summary>
        /// <param name="list">
        /// List of boolean values.
        /// </param>
        /// <returns>
        /// The most common boolean string.
        /// </returns>
        public static bool[] FindModeInBoolList(List<bool[]> list)
        {
            var counter = new Dictionary<string, int>();
            foreach (var boolString in list.Select(ArrayToStringConverter.ConvertBoolArrayToString))
            {
                if (counter.ContainsKey(boolString))
                {
                    counter[boolString] += 1;
                }
                else
                {
                    counter[boolString] = 1;
                }
            }

            var result = counter.Aggregate((x, y) => x.Value > y.Value ? x : y).Key;

            return result.Select(chr => chr == '1').ToArray();
        }
    }
}