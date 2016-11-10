using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using static Task2.NonRectangularArray;
using static Task2_2.NonRectangularArray;

namespace Task2.Tests
{
    public class RowsSumIncrease : IComparer<int[]>
    {
        public int Compare(int[] arr1, int[] arr2) => arr1.Sum() - arr2.Sum();
    }

    public class RowsSumDecrease : IComparer<int[]>
    {
        public int Compare(int[] arr1, int[] arr2) => arr2.Sum() - arr1.Sum();
    }

    public class RowsMaxElementIncrease : IComparer<int[]>
    {
        public int Compare(int[] arr1, int[] arr2) => arr1.Max() - arr2.Max();
    }

    public class RowsMaxElementDecrease : IComparer<int[]>
    {
        public int Compare(int[] arr1, int[] arr2) => arr2.Max() - arr1.Max();
    }

    [TestFixture]
    public class NonRectangularArrayTests
    {
        private ComparerDelegate _comparerDelegate;

        private static readonly RowsSumIncrease RowsSumIncrease = new RowsSumIncrease();
        private static readonly RowsSumDecrease RowsSumDecrease = new RowsSumDecrease();
        private static readonly RowsMaxElementIncrease RowsMaxElementIncrease
            = new RowsMaxElementIncrease();
        private static readonly RowsMaxElementDecrease RowsMaxElementDecrease
            = new RowsMaxElementDecrease();

        private static readonly int[][] Source1 = {
            new[] {1, 2, 3, 4},
            new[] {5, 6},
            new[] {7},
            new[] {8, 9, 0}
        };

        private static readonly int[][] Source2 = {
            new[] {3, 18, 5, 5},
            new[] {4},
            new[] {0, 2, 1},
            new[] {15, 2, 3, 9, 10}
        };

        private static readonly int[][] Source3  = { };

        private static readonly int[][] Expected1 = {
            new[] {7},
            new[] {1, 2, 3, 4},
            new[] {5, 6},
            new[] {8, 9, 0}
        };

        private static readonly int[][] Expected2 = {
            new[] {8, 9, 0},
            new[] {5, 6},
            new[] {1, 2, 3, 4},
            new[] {7}
        };

        private static readonly int[][] Expected3 = {
            new[] {0, 2, 1},
            new[] {4},
            new[] {15, 2, 3, 9, 10},
            new[] {3, 18, 5, 5}
        };

        private static readonly int[][] Expected4 = {
            new[] {3, 18, 5, 5},
            new[] {15, 2, 3, 9, 10},
            new[] {4},
            new[] {0, 2, 1}
        };

        [Test, TestCaseSource(typeof(BubbleSort1TestClass), nameof(BubbleSort1TestClass.TestCases))]
        public void BubbleSort1Tests(int[][] array, int[][] expected, IComparer<int[]> iComparer)
        {
            _comparerDelegate = iComparer.Compare;
            BubbleSort(array, _comparerDelegate);
            Assert.AreEqual(array, expected);
        }

        public class BubbleSort1TestClass
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(Source1, Expected1, RowsSumIncrease);
                    yield return new TestCaseData(Source1, Expected2, RowsSumDecrease);
                    yield return new TestCaseData(Source2, Expected3, RowsMaxElementIncrease);
                    yield return new TestCaseData(Source2, Expected4, RowsMaxElementDecrease);
                    yield return new TestCaseData(Source3, Expected1, RowsSumIncrease)
                        .Throws(typeof (ArgumentOutOfRangeException));
                }
            }
        }

        [Test, TestCaseSource(typeof(BubbleSort2TestClass), nameof(BubbleSort2TestClass.TestCases))]
        public void BubbleSort2Tests(int[][] array, int[][] expected, IComparer<int[]> iComparer)
        {
            BubbleSort(array, iComparer);
            Assert.AreEqual(array, expected);
        }

        public class BubbleSort2TestClass
        {
            public static IEnumerable TestCases
            {
                get
                {
                    yield return new TestCaseData(Source1, Expected1, RowsSumIncrease);
                    yield return new TestCaseData(Source1, Expected2, RowsSumDecrease);
                    yield return new TestCaseData(Source2, Expected3, RowsMaxElementIncrease);
                    yield return new TestCaseData(Source2, Expected4, RowsMaxElementDecrease);
                    yield return new TestCaseData(Source3, Expected1, RowsSumIncrease)
                        .Throws(typeof(ArgumentOutOfRangeException));
                }
            }
        }
    }
}
