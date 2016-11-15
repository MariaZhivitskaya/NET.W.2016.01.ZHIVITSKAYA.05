using System;
using System.Diagnostics;

namespace Task1
{
    public class GreatestCommonDivisor
    {
        private static Func<int, int, int> _funcTwoParams;

        private static Func<int, int, int, int> _funcThreeParams;

        /// <summary>
        /// Finds the greatest common divisor
        /// of 2 numbers according to Euclidean method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>Returns the GCD.</returns>
        public static int EuclideanGCD(int a, int b) => EuclideanGCDLogic(a, b);

        /// <summary>
        /// Finds the greatest common divisor
        /// of 2 numbers according to Euclidean method calculating the elapsed time;
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="elapsedTime">The elapsed time.</param>
        /// <returns>Returns the GCD.</returns>
        public static int EuclideanGCD(int a, int b, out long elapsedTime)
        {
            _funcTwoParams = EuclideanGCD;
            return GCDLogic(a, b, out elapsedTime);
        }

        /// <summary>
        /// Finds the greatest common divisor
        /// of 3 numbers according to Euclidean method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <returns>Returns the GCD.</returns>
        public static int EuclideanGCD(int a, int b, int c) => 
            EuclideanGCD(EuclideanGCD(a, b), c);

        /// <summary>
        /// Finds the greatest common divisor
        /// of 3 numbers according to Euclidean method calculating the elapsed time.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="elapsedTime">The elapsed time.</param>
        /// <returns>Returns the GCD.</returns>
        public static int EuclideanGCD(int a, int b, int c, out long elapsedTime)
        {
            _funcThreeParams = EuclideanGCD;
            return GCDLogic(a, b, c, out elapsedTime);
        }
        
        /// <summary>
        /// Finds the greatest common divisor
        /// of a various number of elements according to Euclidean method.
        /// </summary>
        /// <param name="data">Elements for calculating the GCD.</param>
        /// <returns>Returns the GCD.</returns>
        public static int EuclideanGCD(params int[] data)
        {
            _funcTwoParams = EuclideanGCD;
            return GCDLogic(data);
        }

        /// <summary>
        /// Finds the greatest common divisor
        /// of a various number of elements according to Euclidean method
        /// calculating the elapsed time.
        /// </summary>
        /// <param name="elapsedTime">The elapsed time.</param>
        /// <param name="data">Elements for calculating the GCD.</param>
        /// <returns>Returns the GCD.</returns>
        public static int EuclideanGCD(out long elapsedTime, params int[] data)
        {
            _funcTwoParams = EuclideanGCD;
            return GCDLogic(out elapsedTime, data);
        }

        /// <summary>
        /// Finds the greatest common divisor
        /// of 2 numbers according to the binary Euclidean method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>Returns the GCD.</returns>
        public static int BinaryGCD(int a, int b) => BinaryGCDLogic(a, b);

        /// <summary>
        /// Finds the greatest common divisor
        /// of 2 numbers according to the binary Euclidean method
        /// calculating the elapsed time.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="elapsedTime">The elapsed time.</param>
        /// <returns>Returns the GCD.</returns>
        public static int BinaryGCD(int a, int b, out long elapsedTime)
        {
            _funcTwoParams = BinaryGCD;
            return GCDLogic(a, b, out elapsedTime);
        }

        /// <summary>
        /// Finds the greatest common divisor
        /// of 3 numbers according to the binary Euclidean method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <returns>Returns the GCD.</returns>
        public static int BinaryGCD(int a, int b, int c) => 
            EuclideanGCD(BinaryGCD(a, b), c);

        /// <summary>
        /// Finds the greatest common divisor
        /// of 3 numbers according to the binary Euclidean method
        /// calculating the elapsed time.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="elapsedTime">The elapsed time.</param>
        /// <returns>Returns the GCD.</returns>
        public static int BinaryGCD(int a, int b, int c, out long elapsedTime)
        {
            _funcThreeParams = BinaryGCD;
            return GCDLogic(a, b, c, out elapsedTime);
        }

        /// <summary>
        /// Finds the greatest common divisor
        /// of a various number of elements according to the binary Euclidean method.
        /// </summary>
        /// <param name="data">Elements for calculating the GCD.</param>
        /// <returns>Returns the GCD.</returns>
        public static int BinaryGCD(params int[] data)
        {
            _funcTwoParams = BinaryGCD;
            return GCDLogic(data);
        }

        /// <summary>
        /// Finds the greatest common divisor
        /// of a various number of elements according to the binary Euclidean method.
        /// </summary>
        /// <param name="elapsedTime">The elapsed time.</param>
        /// <param name="data">Elements for calculating the GCD.</param>
        /// <returns>Returns the GCD.</returns>
        public static int BinaryGCD(out long elapsedTime, params int[] data)
        {
            _funcTwoParams = BinaryGCD;
            return GCDLogic(out elapsedTime, data);
        }

        /// <summary>
        /// Implements the logic of Euclidean GCD method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>Returns the GCD.</returns>
        private static int EuclideanGCDLogic(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);

            while (a != 0 && b != 0)
                if (a > b)
                    a %= b;
                else
                    b %= a;

            return a + b;
        }

        /// <summary>
        /// Implements the logic of a binary Euclidean GCD method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>>Returns the GCD.</returns>
        private static int BinaryGCDLogic(int a, int b)
        {
            a = Math.Abs(a);
            b = Math.Abs(b);
            int counter = 1;

            while (a != 0 && b != 0)
            {
                while (a % 2 == 0 && b % 2 == 0)
                {
                    a /= 2;
                    b /= 2;
                    counter *= 2;
                }

                while (a % 2 == 0)
                    a /= 2;

                while (b % 2 == 0)
                    b /= 2;

                if (a >= b)
                    a -= b;
                else
                    b -= a;
            }

            return b * counter;
        }

        /// <summary>
        /// Finds the GCD according to a specified method.
        /// </summary>
        /// <param name="delGDC">The method.</param>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="time">The elapsed time.</param>
        /// <returns>Returns the GCD.</returns>
        private static int GCDLogic(int a, int b,
            out long time)
        {
            var stopWatch = new Stopwatch();
            stopWatch.Start();

            int result = _funcTwoParams(a, b);

            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Finds the GCD according to a specified method.
        /// </summary>
        /// <param name="delGDC">The method.</param>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="time">The elapsed time.</param>
        /// <returns>Returns the GCD.</returns>
        private static int GCDLogic(int a, int b, int c,
            out long time)
        {
            var stopWatch = new Stopwatch();

            int result = _funcThreeParams(a, b, c);

            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Finds the GCD according to a specified method.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if data is null.</exception>
        /// <exception cref="ArgumentException">Thrown if there are no parameters.</exception>
        /// <param name="delGCD">The method.</param>
        /// <param name="data">Elements for calculating the GCD.</param>
        /// <returns>Returns the GCD.</returns>
        private static int GCDLogic(params int[] data)
        {
            if (data == null)
                throw new ArgumentNullException("Null data!");

            if (data.Length < 2)
                throw new ArgumentException("Wrong number of parameters!");

            int divisor = _funcTwoParams(data[0], data[1]);

            for (int i = 2; i < data.Length; i++)
                divisor = _funcTwoParams(data[i], divisor);

            return divisor;
        }

        /// <summary>
        /// Finds the GCD according to a specified method.
        /// </summary>
        /// <param name="delGCD">The method.</param>
        /// <param name="time">The elapsed time.</param>
        /// <param name="data">Elements for calculating the GCD.</param>
        /// <returns>Returns the GCD.</returns>
        private static int GCDLogic(out long time, params int[] data)
        {
            var stopWatch = new Stopwatch();

            int result = GCDLogic(data);

            stopWatch.Stop();
            time = stopWatch.ElapsedMilliseconds;

            return result;
        }
    }
}
