using System;
using System.Collections.Generic;

namespace CondorRules
{
    public static class EnumerableExtensions
    {
        public static void ForEach<T>(this IEnumerable<T> list, Action<T> callback)
        {
            foreach (var t in list)
            {
                callback(t);
            }
        }
    }
}
