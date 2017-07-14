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
        private const int SIZE = 100000;

        private static void __VERIFIER_assert(bool cond)
        {
            if (!cond)
            {
                throw new BenchmarkException();
            }
        }

        private static void printEven( int i ) {
            __VERIFIER_assert(  ( i % 2 ) == 0  );
            // printf( "%d" , i );
        }

        private static void printOdd( int i ) {
            __VERIFIER_assert(  ( i % 2 ) != 0  );
            // printf( "%d" , i );
        }

        public static void Main(string[] args)
        {
            int[] array = new int[SIZE];
            int i;
            int num = 42;

            //printf("Even numbers in the array are - ");
            for (i = 0; i < num; i++) // use of uninitialized num
            {
                if (array[i] % 2 == 0)
                {
                    printEven( array[i] );
                }
            }
            //printf("\n Odd numbers in the array are -");
            for (i = 0; i < num; i++)
            {
                if (array[i] % 2 != 0)
                {
                    printOdd( array[i] );
                }
            }
        }
    }
}
