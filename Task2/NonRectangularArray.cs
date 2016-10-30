using System;

namespace Task2
{
    /// <summary>
    /// Different methods for a bubble sort.
    /// </summary>
    public enum SortMethod
    {
        RowsSum,
        RowsMaxElements,
        RowsMinElements
    };

    /// <summary>
    /// Sort order of elements.
    /// </summary>
    public enum SortOrder
    {
        Increase,
        Decrease
    };

    public class NonRectangularArray
    {
        /// <summary>
        /// Sorts a non rectangular integer array with
        /// a specified sorting method in
        /// increasing or decreasing order.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown if an array is null.</exception>
        /// <exception cref="ArgumentOutOfRangeException">Thrown if an array is empty.</exception>
        /// <param name="arr">An array for handling.</param>
        /// <param name="sortMethod">A sorting method.</param>
        /// <param name="sortOrder">A sorting order.</param>
        /// <returns>Returns a new sorted array.</returns>
        public static int[][] BubbleSort(int[][] arr, SortMethod sortMethod, SortOrder sortOrder)
        {
            if (arr == null)
            {
                throw new NullReferenceException("NULL data!");
            }

            if (arr.Length < 1)
            {
                throw new ArgumentOutOfRangeException("Wrong array length!");
            }

            var indexes = new int[arr.Length];
            var arrInfo = new int[arr.Length];

            switch (sortMethod)
            {
                case SortMethod.RowsSum:
                    Sums(arr, indexes, arrInfo);
                    break;
                case SortMethod.RowsMaxElements:
                    MaxElements(arr, indexes, arrInfo);
                    break;
                case SortMethod.RowsMinElements:
                    MinElements(arr, indexes, arrInfo);
                    break;
            }

            for (var i = 0; i < arr.Length; i++)
            {
                for (var j = 0; j < arr.Length - i - 1; j++)
                {
                    switch (sortOrder)
                    {
                        case SortOrder.Increase:
                            if (arrInfo[j] > arrInfo[j + 1])
                            {
                                SwapIndexes(indexes, arrInfo, j, j + 1);
                            }
                            break;
                        case SortOrder.Decrease:
                            if (arrInfo[j] < arrInfo[j + 1])
                            {
                                SwapIndexes(indexes, arrInfo, j, j + 1);
                            }
                            break;
                    }
                }
            }

            return SortedArray(arr, indexes);
        }

        /// <summary>
        /// Initialise auxiliary arrays of row indexes and row sums.
        /// </summary>
        /// <param name="arr">An array for handling.</param>
        /// <param name="indexes">An auxiliary array of row indexes.</param>
        /// <param name="sums">An auxiliary array of row sums.</param>
        private static void Sums(int[][] arr, int[] indexes, int[] sums)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                indexes[i] = i;
                sums[i] = 0;

                for (var j = 0; j < arr[i].Length; j++)
                {
                    sums[i] += arr[i][j];
                }
            }
        }

        /// <summary>
        /// Initialise auxiliary arrays of row indexes and maximal elements in rows.
        /// </summary>
        /// <param name="arr">An array for handling.</param>
        /// <param name="indexes">An auxiliary array of row indexes.</param>
        /// <param name="maxElements">An auxiliary array of maximal elements in rows.</param>
        private static void MaxElements(int[][] arr, int[] indexes, int[] maxElements)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                indexes[i] = i;
                maxElements[i] = arr[i][0];

                for (var j = 1; j < arr[i].Length; j++)
                {
                    if (arr[i][j] > maxElements[i])
                    {
                        maxElements[i] = arr[i][j];
                    }
                }
            }
        }

        /// <summary>
        /// Initialise auxiliary arrays of row indexes and minimal elements in rows.
        /// </summary>
        /// <param name="arr">An array for handling.</param>
        /// <param name="indexes">An auxiliary array of row indexes.</param>
        /// <param name="minElements">An auxiliary array of minimal elements in rows.</param>
        private static void MinElements(int[][] arr, int[] indexes, int[] minElements)
        {
            for (var i = 0; i < arr.Length; i++)
            {
                indexes[i] = i;
                minElements[i] = arr[i][0];

                for (var j = 1; j < arr[i].Length; j++)
                {
                    if (arr[i][j] < minElements[i])
                    {
                        minElements[i] = arr[i][j];
                    }
                }
            }
        }

        /// <summary>
        /// Swaps specified indexes.
        /// </summary>
        /// <param name="indexes">An array of row indexes.</param>
        /// <param name="arrInfo">An array of row sums,
        /// maximal elements in rows or minimal elements in rows.</param>
        /// <param name="number1">The first index.</param>
        /// <param name="number2">The second index.</param>
        private static void SwapIndexes(int[] indexes, int[] arrInfo, int number1, int number2)
        {
            var tmp = indexes[number1];
            indexes[number1] = indexes[number2];
            indexes[number2] = tmp;

            tmp = arrInfo[number1];
            arrInfo[number1] = arrInfo[number2];
            arrInfo[number2] = tmp;
        }

        /// <summary>
        /// Creates a new array based on an old array
        /// and a specified order of rows.
        /// </summary>
        /// <param name="oldArr">A base array.</param>
        /// <param name="indexes">A specified order of rows.</param>
        /// <returns>Returns a new sorted array.</returns>
        private static int[][] SortedArray(int[][] oldArr, int[] indexes)
        {
            var newArr = new int[oldArr.Length][];

            for (var i = 0; i < oldArr.Length; i++)
            {
                var index = indexes[i];
                newArr[i] = new int[oldArr[index].Length];

                for (var j = 0; j < newArr[i].Length; j++)
                {
                    newArr[i][j] = oldArr[index][j];
                }
            }

            return newArr;
        }
    }
}
