using System;
using System.Collections;
using System.Linq;
using NUnit.Framework;
using static Task2.NonRectangularArray;

namespace Task2.Tests
{
    public class RowsSumIncrease : IArrayComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            return arr1.Sum() - arr2.Sum();
        }
    }

    public class RowsSumDecrease : IArrayComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            return arr2.Sum() - arr1.Sum();
        }
    }

    public class RowsMaxElementIncrease : IArrayComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            return arr1.Max() - arr2.Max();
        }
    }

    public class RowsMaxElementDecrease : IArrayComparer
    {
        public int Compare(int[] arr1, int[] arr2)
        {
            return arr2.Max() - arr1.Max();
        }
    }

    [TestFixture]
    public class NonRectangularArrayTests
    {
        private static RowsSumIncrease rowsSumIncrease = new RowsSumIncrease();
        private static RowsSumDecrease rowsSumDecrease = new RowsSumDecrease();
        private static RowsMaxElementIncrease rowsMaxElementIncrease
            = new RowsMaxElementIncrease();
        private static RowsMaxElementDecrease rowsMaxElementDecrease
            = new RowsMaxElementDecrease();

        private static int[][] source1 = new[]
        {
            new[] {1, 2, 3, 4},
            new[] {5, 6},
            new[] {7},
            new[] {8, 9, 0}
        };
        private static int[][] source2 = new[]
        {
            new[] {3, 18, 5, 5},
            new[] {4},
            new[] {0, 2, 1},
            new[] {15, 2, 3, 9, 10}
        };
        private static int[][] source3  = new int[][] { };
        private static int[][] expected1 = new[]
        {
            new[] {7},
            new[] {1, 2, 3, 4},
            new[] {5, 6},
            new[] {8, 9, 0}
        };
        private static int[][] expected2 = new[]
        {
            new[] {8, 9, 0},
            new[] {5, 6},
            new[] {1, 2, 3, 4},
            new[] {7}
        };
        private static int[][] expected3 = new[]
        {
            new[] {0, 2, 1},
            new[] {4},
            new[] {15, 2, 3, 9, 10},
            new[] {3, 18, 5, 5}
        };
        private static int[][] expected4 = new[]
        {
            new[] {3, 18, 5, 5},
            new[] {15, 2, 3, 9, 10},
            new[] {4},
            new[] {0, 2, 1}
        };

        [Test, TestCaseSource(typeof(BubbleSortTestClass), nameof(BubbleSortTestClass.TestCases))]
        public int[][] BubbleSortTests(int[][] arr, IArrayComparer iArrayComparer)
        {
            return BubbleSort(arr, iArrayComparer);
        }

        public class BubbleSortTestClass
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(source1, rowsSumIncrease).Returns(expected1);
                    yield return new TestCaseData(source1, rowsSumDecrease).Returns(expected2);
                    yield return new TestCaseData(source2, rowsMaxElementIncrease).Returns(expected3);
                    yield return new TestCaseData(source2, rowsMaxElementDecrease).Returns(expected4);
                    yield return new TestCaseData(source3, rowsSumIncrease)
                        .Throws(typeof (ArgumentOutOfRangeException));
                }
            }
        }
    }
}
