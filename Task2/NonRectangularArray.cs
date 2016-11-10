﻿using System;
using System.Collections.Generic;

namespace Task2
{
    public delegate int ComparerDelegate(int[] array1, int[] array2);

    public class NonRectangularArray
    {
        /// <summary>
        /// Sorts a non rectangular array in a specified order.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if data is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if an array is empty.</exception>
        /// <param name="array">An array for handling.</param>
        /// <param name="comparerDelegate">A method for sorting.</param>
        /// <returns>Returns a new sorted array.</returns>
        public static void BubbleSort(int[][] array, ComparerDelegate comparerDelegate)
        {
            if (array == null)
                throw new ArgumentNullException("Null data!");

            if (array.Length < 1)
                throw new ArgumentOutOfRangeException("Wrong array length!");

            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (comparerDelegate(array[j], array[j + 1]) > 0)
                        SwapIndexes(ref array[j], ref array[j + 1]);
        }

        /// <summary>
        /// Swaps two rows of an array.
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
