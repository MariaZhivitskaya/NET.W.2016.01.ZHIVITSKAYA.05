using System;

namespace Task2
{
    public interface IArrayComparer
    {
        int Compare(int[] arr1, int[] arr2);
    }

    public class NonRectangularArray
    {
        public static int[][] BubbleSort(int[][] arr, IArrayComparer iArrayComparer)
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

            for (int i = 0; i < arr.Length; i++)
            {
                indexes[i] = i;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    var index1 = indexes[j];
                    var index2 = indexes[j + 1];
                    if (iArrayComparer.Compare(arr[index1], arr[index2]) > 0)
                    {
                        SwapIndexes(indexes, j, j + 1);
                    }
                }
            }

            return SortedArray(arr, indexes);
        }

        public static void SwapIndexes(int[] indexes, int number1, int number2)
        {
            int tmp = indexes[number1];
            indexes[number1] = indexes[number2];
            indexes[number2] = tmp;
        }

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
