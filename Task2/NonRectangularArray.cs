using System;
using System.Collections.Generic;

namespace Task2
{
    public class NonRectangularArray
    {
        /// <summary>
        /// Sorts the non rectangular array in a specified order.
        /// </summary>
        /// <param name="array">The array for handling.</param>
        /// <param name="comparison">The method for sorting.</param>
        public static void BubbleSort(int[][] array, Comparison<int[]> comparison) => 
            BubbleSort(array, new ComparisonAdapter(comparison));

        /// <summary>
        /// An adapter for the Comparison delegate.
        /// </summary>
        private class ComparisonAdapter : IComparer<int[]>
        {
            private readonly Comparison<int[]> _comparison;

            public ComparisonAdapter(Comparison<int[]> comparison)
            {
                _comparison = comparison;
            }

            public int Compare(int[] x, int[] y) => _comparison(x, y);
        }

        /// <summary>
        /// Sorts the non rectangular array in a specified order.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if data is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if the array is empty.</exception>
        /// <param name="array">The array for handling.</param>
        /// <param name="iComparer">The method for sorting.</param>
        /// <returns>Returns the new sorted array.</returns>
        private static void BubbleSort(int[][] array, IComparer<int[]> iComparer)
        {
            if (array == null)
                throw new ArgumentNullException("Null data!");

            if (array.Length < 1)
                throw new ArgumentOutOfRangeException("Wrong array length!");

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (iComparer.Compare(array[j], array[j + 1]) > 0)
                        SwapIndexes(ref array[j], ref array[j + 1]);
        }

        /// <summary>
        /// Swaps two rows of the array.
        /// </summary>
        /// <param name="row1">The first row.</param>
        /// <param name="row2">The second row.</param>
        public static void SwapIndexes(ref int[] row1, ref int[] row2)
        {
            var tmp = row1;
            row1 = row2;
            row2 = tmp;
        }
    }
}
