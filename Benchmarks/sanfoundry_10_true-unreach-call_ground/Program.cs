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
 * C program to accept an array of integers and delete the
 * specified integer from the list
 */
    internal class Program
    {
        private const int MAX = 100000;

        private static void __VERIFIER_assert(bool cond)
        {
            if (!cond)
            {
                throw new BenchmarkException();
            }
        }

        public static void Main(string[] args)
        {
            int i;
            int n = 100000;
            int pos = 0;
            int element = 0;
            bool found = false;
            int[] vectorx = new int[n];

            for (i = 0; i < n && !found; i++)
            {
                if (vectorx[i] == element)
                {
                    found = true;
                    pos = i;
                }
            }
            if ( found )
            {
                for (i = pos; i <  n - 1; i++)
                {
                    vectorx[i] = vectorx[i + 1];
                }
            }

            if ( found ) {
                int x;
                for ( x = 0 ; x < pos ; x++ ) {
                    __VERIFIER_assert(  vectorx[x] != element  );
                }
            }
        }
    }
}
