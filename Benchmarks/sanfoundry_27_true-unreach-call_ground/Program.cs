using System;

namespace Array
{
    internal class BenchmarkException : Exception
    {
        public BenchmarkException()
        {
        }
    }
/*
 * Adapted from http://www.sanfoundry.com/c-programming-examples-arrays/
 * C Program to Find the Largest Number in an Array
 */
    internal class Program
    {
        private const int SIZE = 100000;

        private static void __VERIFIER_assert(bool cond)
        {
            if (!cond)
            {
                throw new BenchmarkException();
            }
        }

        public static void Main(string[] args)
        {
            int[] array = new int[SIZE];
            int i;
            int largest = array[0];
            for (i = 1; i < SIZE; i++)
            {
                if (largest < array[i])
                    largest = array[i];
            }

            int x;
            for ( x = 0 ; x < SIZE ; x++ ) {
                __VERIFIER_assert(  largest >= array[ x ]  );
            }
        }
    }
}