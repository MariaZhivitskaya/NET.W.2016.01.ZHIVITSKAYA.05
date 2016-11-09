using System;
using System.Diagnostics;

namespace Task1
{
    public class GreatestCommonDivisor
    {
        private static readonly Stopwatch StopWatch = new Stopwatch();

        private delegate int DelegateTwoParamsGCD(int a, int b);

        private delegate int DelegateThreeParamsGCD(int a, int b, int c);

        /// <summary>
        /// Finds a greatest common divisor
        /// of 2 numbers according to Euclidean method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>Returns a GCD.</returns>
        public static int EuclideanGCD(int a, int b)
        {
            return EuclideanGCDLogic(a, b);
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of 2 numbers according to Euclidean method calculating an elapsed time;
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="elapsedTime">An elapsed time.</param>
        /// <returns>Returns a GCD.</returns>
        public static int EuclideanGCD(int a, int b, out long elapsedTime)
        {
            DelegateTwoParamsGCD delGCD = EuclideanGCD;
            return GCDLogic(delGCD, a, b, out elapsedTime);
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of 3 numbers according to Euclidean method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <returns>Returns a GCD.</returns>
        public static int EuclideanGCD(int a, int b, int c)
        {
            int divisor = EuclideanGCD(a, b);
            return EuclideanGCD(divisor, c);
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of 3 numbers according to Euclidean method calculating an elapsed time.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="elapsedTime">An elapsed time.</param>
        /// <returns>Returns a GCD.</returns>
        public static int EuclideanGCD(int a, int b, int c, out long elapsedTime)
        {
            DelegateThreeParamsGCD delGCD = EuclideanGCD;
            return GCDLogic(delGCD, a, b, c, out elapsedTime);
        }
        
        /// <summary>
        /// Finds a greatest common divisor
        /// of a various number of elements according to Euclidean method.
        /// </summary>
        /// <param name="data">Elements for calculating a GCD.</param>
        /// <returns>Returns a GCD.</returns>
        public static int EuclideanGCD(params int[] data)
        {
            DelegateTwoParamsGCD delGCD = EuclideanGCD;
            return GCDLogic(delGCD, data);
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of a various number of elements according to Euclidean method
        /// calculating an elapsed time.
        /// </summary>
        /// <param name="elapsedTime">An elapsed time.</param>
        /// <param name="data">Elements for calculating a GCD.</param>
        /// <returns>Returns a GCD.</returns>
        public static int EuclideanGCD(out long elapsedTime, params int[] data)
        {
            DelegateTwoParamsGCD delGCD = EuclideanGCD;
            return GCDLogic(delGCD, out elapsedTime, data);
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of 2 numbers according to a binary Euclidean method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>Returns a GCD.</returns>
        public static int BinaryGCD(int a, int b)
        {
            return BinaryGCDLogic(a, b);
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of 2 numbers according to a binary Euclidean method
        /// calculating an elapsed time.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="elapsedTime">An elapsed time.</param>
        /// <returns>Returns a GCD.</returns>
        public static int BinaryGCD(int a, int b, out long elapsedTime)
        {
            DelegateTwoParamsGCD delGCD = BinaryGCD;
            return GCDLogic(delGCD, a, b, out elapsedTime);
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of 3 numbers according to a binary Euclidean method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <returns>Returns a GCD.</returns>
        public static int BinaryGCD(int a, int b, int c)
        {
            int divisor = BinaryGCD(a, b);
            return EuclideanGCD(divisor, c);
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of 3 numbers according to a binary Euclidean method
        /// calculating an elapsed time.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="elapsedTime">An elapsed time.</param>
        /// <returns>Returns a GCD.</returns>
        public static int BinaryGCD(int a, int b, int c, out long elapsedTime)
        {
            DelegateThreeParamsGCD delGCD = BinaryGCD;
            return GCDLogic(delGCD, a, b, c, out elapsedTime);
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of a various number of elements according to a binary Euclidean method.
        /// </summary>
        /// <param name="data">Elements for calculating a GCD.</param>
        /// <returns>Returns a GCD.</returns>
        public static int BinaryGCD(params int[] data)
        {
            DelegateTwoParamsGCD delGCD = BinaryGCD;
            return GCDLogic(delGCD, data);
        }

        /// <summary>
        /// Finds a greatest common divisor
        /// of a various number of elements according to a binary Euclidean method.
        /// </summary>
        /// <param name="elapsedTime">An elapsed time.</param>
        /// <param name="data">Elements for calculating a GCD.</param>
        /// <returns>Returns a GCD.</returns>
        public static int BinaryGCD(out long elapsedTime, params int[] data)
        {
            DelegateTwoParamsGCD delGCD = BinaryGCD;
            return GCDLogic(delGCD, out elapsedTime, data);
        }

        /// <summary>
        /// Implements a logic of Euclidean GCD method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>Returns a GCD.</returns>
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
        /// Implements a logic of a binary Euclidean GCD method.
        /// </summary>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <returns>>Returns a GCD.</returns>
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
        /// Finds a GCD according to a specified method.
        /// </summary>
        /// <param name="delGDC">A method.</param>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="time">An elapsed time.</param>
        /// <returns>Returns a GCD.</returns>
        private static int GCDLogic(DelegateTwoParamsGCD delGDC, int a, int b,
            out long time)
        {
            StopWatch.Start();

            int result = delGDC(a, b);

            StopWatch.Stop();
            time = StopWatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Finds a GCD according to a specified method.
        /// </summary>
        /// <param name="delGDC">A method.</param>
        /// <param name="a">The first number.</param>
        /// <param name="b">The second number.</param>
        /// <param name="c">The third number.</param>
        /// <param name="time">An elapsed time.</param>
        /// <returns>Returns a GCD.</returns>
        private static int GCDLogic(DelegateThreeParamsGCD delGDC, int a, int b, int c,
            out long time)
        {
            StopWatch.Start();

            int result = delGDC(a, b, c);

            StopWatch.Stop();
            time = StopWatch.ElapsedMilliseconds;

            return result;
        }

        /// <summary>
        /// Finds a GCD according to a specified method.
        /// </summary>
        /// <exception cref="ArgumentNullException">Thrown if data is null.</exception>
        /// <exception cref="ArgumentException">Thrown if there are no parameters.</exception>
        /// <param name="delGCD">A method.</param>
        /// <param name="data">Elements for calculating a GCD.</param>
        /// <returns>Returns a GCD.</returns>
        private static int GCDLogic(DelegateTwoParamsGCD delGCD, params int[] data)
        {
            if (data == null)
                throw new ArgumentNullException("Null data!");

            if (data.Length < 2)
                throw new ArgumentException("Wrong number of parameters!");

            int divisor = delGCD(data[0], data[1]);

            for (int i = 2; i < data.Length; i++)
                divisor = delGCD(data[i], divisor);

            return divisor;
        }

        /// <summary>
        /// Finds a GCD according to a specified method.
        /// </summary>
        /// <param name="delGCD">A method.</param>
        /// <param name="time">An elapsed time.</param>
        /// <param name="data">Elements for calculating a GCD.</param>
        /// <returns>Returns a GCD.</returns>
        private static int GCDLogic(DelegateTwoParamsGCD delGCD, 
            out long time, params int[] data)
        {
            StopWatch.Start();

            int result = GCDLogic(delGCD, data);

            StopWatch.Stop();
            time = StopWatch.ElapsedMilliseconds;

            return result;
        }
    }
}
