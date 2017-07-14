using System;

namespace Array
{
    internal class BenchmarkException : Exception
    {
        public BenchmarkException()
        {
        }

        public static void CheckCondition(bool cond)
        {
            if (!cond)
            {
                throw new BenchmarkException();
            }
        }
    }

    internal class Program
    {
        private const int Size = 100000;

        public static int Insert(int[] set, int size, int value)
        {
            set[size] = value;
            return size + 1;
        }

        public static bool Elem_exists(int[] set, int size, int value)
        {
            int i;
            for ( i = 0 ; i < size ; i++ ) {
                if ( set[ i ] == value ) return true;
            }
            return false;
        }

        public static void Main(string[] args)
        {
            int n = 0;
            int[] set = new int[Size];

            // this is trivial
            int x;
            int y;
            for ( x = 0 ; x < n ; x++ ) {
                for ( y = x + 1 ; y < n ; y++ ) {
                    BenchmarkException.CheckCondition(set[ x ] != set[ y ]);
                }
            }

            // we have an array of values to insert
            int[] values = new int[ Size ];

            // insert them in the array -- note that nothing ensures that values is not containing duplicates!
            int v;
            for ( v = 0 ; v < Size ; v++ ) {
                // check if the element exists, if not insert it.
                if ( Elem_exists( set , n , values[ v ] ) ) {
                    // parametes are passed by reference
                    n = Insert( set , n , values[ v ] );
                }
                for ( x = 0 ; x < n ; x++ ) {
                    for ( y = x + 1 ; y < n ; y++ ) {
                        BenchmarkException.CheckCondition(  set[ x ] != set[ y ]  );
                    }
                }
            }

            // this is not trivial!
            for ( x = 0 ; x < n ; x++ ) {
                for ( y = x + 1 ; y < n ; y++ ) {
                    BenchmarkException.CheckCondition(  set[ x ] != set[ y ]  );
                }
            }
        }
    }
}
