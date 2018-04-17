using System.Collections.Generic;

namespace TabletopCardCompanion.DataStructures
{
    /// <summary>
    /// Contains extension methods for shuffling collections.
    /// </summary>
    public static class ShuffleExtensions
    {
        /// <summary>
        /// Randomly order the elements in the list.
        /// <para>
        /// Performed in place on the provided list.
        /// </para>
        /// <remarks>
        /// Implemented using the Fischer-Yates algorithm found on wikipedia: https://en.wikipedia.org/wiki/Fisher%E2%80%93Yates_shuffle
        /// </remarks>
        /// </summary>
        public static List<T> Shuffle<T>(this List<T> list)
        {
            for (int i = list.Count - 1; i > 0; --i)
            {
                var j = UnityEngine.Random.Range(0, i + 1);

                var tmp = list[j];
                list[j] = list[i];
                list[i] = tmp;
            }

            return list;
        }
    }
}
