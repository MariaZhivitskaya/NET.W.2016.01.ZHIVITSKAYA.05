using System;
using NUnit.Framework;

namespace Task2.Tests
{

    [TestFixture]
    public class NonRectangularArrayTests
    {
        [Test]
        public void BubbleSortRowsSumIncrease()
        {
            var arr = new[]
            {
                new[] {1, 2, 3, 4},
                new[] {5, 6},
                new[] {7},
                new[] {8, 9, 0}
            };

            var source = NonRectangularArray.BubbleSort(arr, SortMethod.RowsSum, SortOrder.Increase);

            var expected = new[]
            {
                new[] {7},
                new[] {1, 2, 3, 4},
                new[] {5, 6},
                new[] {8, 9, 0}
            };

            Assert.AreEqual(source, expected);
        }

        [Test]
        public void BubbleSortRowsSumDecrease()
        {
            var arr = new[]
            {
                new[] {1, 2, 3, 4},
                new[] {5, 6},
                new[] {7},
                new[] {8, 9, 0}
            };

            var source = NonRectangularArray.BubbleSort(arr, SortMethod.RowsSum, SortOrder.Decrease);

            var expected = new[]
            {
                new[] {8, 9, 0},
                new[] {5, 6},
                new[] {1, 2, 3, 4},
                new[] {7}
            };

            Assert.AreEqual(source, expected);
        }

        [Test]
        public void BubbleSortRowsMaxElementIncrease()
        {
            var arr = new[]
            {
                new[] {3, 18, 5, 5},
                new[] {4},
                new[] {0, 2, 1},
                new[] {15, 2, 3, 9, 10}
            };

            var source = NonRectangularArray.BubbleSort(arr, SortMethod.RowsMaxElements, SortOrder.Increase);

            var expected = new[]
            {
                new[] {0, 2, 1},
                new[] {4},
                new[] {15, 2, 3, 9, 10},
                new[] {3, 18, 5, 5}
            };

            Assert.AreEqual(source, expected);
        }

        [Test]
        public void BubbleSortRowsMaxElementDecrease()
        {
            var arr = new[]
            {
                new[] {3, 18, 5, 5},
                new[] {4},
                new[] {0, 2, 1},
                new[] {15, 2, 3, 9, 10}
            };

            var source = NonRectangularArray.BubbleSort(arr, SortMethod.RowsMaxElements, SortOrder.Decrease);

            var expected = new[]
            {
                new[] {3, 18, 5, 5},
                new[] {15, 2, 3, 9, 10},
                new[] {4},
                new[] {0, 2, 1}
            };

            Assert.AreEqual(source, expected);
        }

        [Test]
        public void BubbleSortRowsMinElementIncrease()
        {
            var arr = new[]
            {
                new[] {3, 18, 5, 5},
                new[] {4},
                new[] {0, 2, 1},
                new[] {15, 2, 3, 9, 10}
            };

            var source = NonRectangularArray.BubbleSort(arr, SortMethod.RowsMinElements, SortOrder.Increase);

            var expected = new[]
            {
                new[] {0, 2, 1},
                new[] {15, 2, 3, 9, 10},
                new[] {3, 18, 5, 5},
                new[] {4}
            };

            Assert.AreEqual(source, expected);
        }

        [Test]
        public void BubbleSortRowsMinElementDecrease()
        {
            var arr = new[]
            {
                new[] {3, 18, 5, 5},
                new[] {4},
                new[] {0, 2, 1},
                new[] {15, 2, 3, 9, 10}
            };

            var source = NonRectangularArray.BubbleSort(arr, SortMethod.RowsMinElements, SortOrder.Decrease);

            var expected = new[]
            {
                new[] {4},
                new[] {3, 18, 5, 5},
                new[] {15, 2, 3, 9, 10},
                new[] {0, 2, 1}
            };

            Assert.AreEqual(source, expected);
        }

        [Test]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void BubbleSortException()
        {
            var arr = new int[][]{};
            var source = NonRectangularArray.BubbleSort(arr, SortMethod.RowsSum, SortOrder.Increase);
        }
    }
}
