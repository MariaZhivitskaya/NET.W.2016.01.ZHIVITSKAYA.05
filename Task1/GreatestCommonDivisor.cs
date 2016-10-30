using System;

namespace Task1
{
    public class GreatestCommonDivisor
    {
        private static DateTime _startTime= new DateTime();
        private static DateTime _endTime = new DateTime();
        public static TimeSpan ElapsedTime { get; private set; } = new TimeSpan();

        /// <summary>
        /// Finds a greatest common divisor
        /// of a VARIOUS NUMBER of elements according to Euclidean method.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown if data is null.</exception>
        /// <exception cref="ArgumentException">Thrown if there are no parameters.</exception>
        /// <param name="data">Elements for calculating a GCD.</param>
        /// <returns>Returns a GCD.</returns>
        public static int EuclideanGCD(params int[] data)
        {
            if (data == null)
            {
               throw new NullReferenceException("NULL data!");
            }

            if (data.Length < 2)
            {
                throw new ArgumentException("Wrong number of parameters!");
            }

            _startTime = DateTime.Now;

            var divisor = EuclideanGCD(Math.Abs(data[0]), Math.Abs(data[1]));

            for (var i = 2; i < data.Length; i++)
            {
                divisor = EuclideanGCD(Math.Abs(data[i]), Math.Abs(divisor));
            }

            _endTime = DateTime.Now;
            ElapsedTime = _endTime - _startTime;

            return divisor;
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of a VARIOUS NUMBER of elements according to a binary Euclidean method.
        /// </summary>
        /// <exception cref="NullReferenceException">Thrown if data is null.</exception>
        /// <exception cref="ArgumentException">Thrown if there are no parameters.</exception>
        /// <param name="data">Elements for calculating a GCD.</param>
        /// <returns>Returns a GCD.</returns>
        public static int BinaryGCD(params int[] data)
        {
            if (data == null)
            {
                throw new NullReferenceException("NULL data!");
            }

            if (data.Length < 2)
            {
                throw new ArgumentException("Wrong number of parameters!");
            }

            _startTime = DateTime.Now;

            var divisor = BinaryGCD(Math.Abs(data[0]), Math.Abs(data[1]));

            for (var i = 2; i < data.Length; i++)
            {
                divisor = BinaryGCD(Math.Abs(data[i]), Math.Abs(divisor));
            }

            _endTime = DateTime.Now;
            ElapsedTime = _endTime - _startTime;

            return divisor;
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of TWO elements according to Euclidean method.
        /// </summary>
        /// <param name="a">The first element.</param>
        /// <param name="b">The second element.</param>
        /// <returns>Returns a GCD.</returns>
        private static int EuclideanGCD(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                {
                    a %= b;
                }
                else
                {
                    b %= a;
                }
            }

            return a + b;
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of TWO elements according to a binary Euclidean method.
        /// </summary>
        /// <param name="a">The first element.</param>
        /// <param name="b">The second element.</param>
        /// <returns>Returns a GCD.</returns>
        private static int BinaryGCD(int a, int b)
        {
            var counter = 1;

            while (a != 0 && b != 0)
            {
                while (a%2 == 0 && b%2 == 0)
                {
                    a /= 2;
                    b /= 2;
                    counter *= 2;
                }

                while (a%2 == 0)
                {
                    a /= 2;
                }

                while (b%2 == 0)
                {
                    b /= 2;
                }

                if (a >= b)
                {
                    a -= b;
                }
                else
                {
                    b -= a;
                }
            }

            return b*counter;
        }
    }
}
