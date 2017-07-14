using System;
using System.Linq;

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
 * C Program to Increment every Element of the Array by one & Print Incremented Array
 */
    internal class Program
    {
        private const int SIZE = 100000;
        private const int Min = 0;
        private const int Max = 100000;

        private static void __VERIFIER_assert(bool cond)
        {
            if (!cond)
            {
                throw new BenchmarkException();
            }
        }

        private static void IncrementArray(int[] src , int[] dst)
        {
            int i;
            for (i = 0; i < SIZE; i++) {
                dst[i] = src[i]+1;     // this alters values in array in main()
            }
        }

        public static void Main(string[] args)
        {
            int[] src = new int[SIZE];
            int[] dst = new int[SIZE];

            IncrementArray( src , dst );

            int x;
            for ( x = 0 ; x < SIZE ; x++ ) {
                __VERIFIER_assert(src[ x ] == dst[ x ]-1);
            }
        }
    }
}