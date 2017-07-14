using System;
using System.Linq;
using System.Runtime.InteropServices;

namespace Array
{
    internal class BenchmarkException : Exception
    {
        public BenchmarkException()
        {
        }
    }

    internal class S
    {
        public int n;
    }

    internal class ArrayBenchmark
    {
        private const int Size = 100000;

        private static bool Int2bool(int i)
        {
            if (i == 0)
                return false;
            else
                return true;
        }

        private static void __VERIFIER_assert(bool cond)
        {
            if (!cond)
            {
                throw new BenchmarkException();
            }
        }

        private static int[] RandomInit(int size, int min, int max)
        {
            Random randNum = new Random();
            return Enumerable
                .Repeat(0, size)
                .Select(i => randNum.Next(min, max))
                .ToArray();
        }

        public static int Insert(int[] set, int size, int value)
        {
            set[size] = value;
            return size + 1;
        }

        public static bool Elem_exists_Bad(int[] set, int size, int value)
        {
            int i;
            for ( i = 0 ; i < size ; i++ ) {
                if ( set[ i ] == value ) return false;
            }
            return false;
        }

        public static bool Elem_exists(int[] set, int size, int value)
        {
            int i;
            for ( i = 0 ; i < size ; i++ ) {
                if ( set[ i ] == value ) return true;
            }
            return false;
        }

        public static void data_structures_set_multi_proc_false_unreach_call_ground(int[] set, int size)
        {
            // this is trivial
            int x;
            int y;
            for ( x = 0 ; x < size ; x++ ) {
                for ( y = x + 1 ; y < size ; y++ ) {
                    __VERIFIER_assert(set[ x ] != set[ y ]);
                }
            }

            // we have an array of values to insert
            int[] values = RandomInit(size, 0, size);

            // insert them in the array -- note that nothing ensures that values is not containing duplicates!
            int v;
            for ( v = 0 ; v < size ; v++ ) {
                // check if the element exists, if not insert it.
                if ( !Elem_exists_Bad( set , size , values[ v ] ) ) {
                    // parametes are passed by reference
                    size = Insert( set , size , values[ v ] );
                }
            }

            // this is not trivial!
            for ( x = 0 ; x < size ; x++ ) {
                for ( y = x + 1 ; y < size ; y++ ) {
                    __VERIFIER_assert(  set[ x ] != set[ y ]  );
                }
            }
        }

        public static void data_structures_set_multi_proc_trivial_true_unreach_call_ground_true_termination(int[] set, int size){
            // this is trivial
            int x;
            int y;
            for ( x = 0 ; x < size ; x++ ) {
                for ( y = x + 1 ; y < size ; y++ ) {
                    __VERIFIER_assert(set[ x ] != set[ y ]);
                }
            }

            // we have an array of values to insert
            int[] values = RandomInit(size, 0, size);

            // insert them in the array -- note that nothing ensures that values is not containing duplicates!
            int v;
            for ( v = 0 ; v < size ; v++ ) {
                // check if the element exists, if not insert it.
                if ( Elem_exists( set , size , values[ v ] ) ) {
                    // parametes are passed by reference
                    size = Insert( set , size , values[ v ] );
                }
                for ( x = 0 ; x < size ; x++ ) {
                    for ( y = x + 1 ; y < size ; y++ ) {
                        __VERIFIER_assert(  set[ x ] != set[ y ]  );
                    }
                }
            }

            // this is not trivial!
            for ( x = 0 ; x < size ; x++ ) {
                for ( y = x + 1 ; y < size ; y++ ) {
                    __VERIFIER_assert(  set[ x ] != set[ y ]  );
                }
            }
        }

        public static void sanfoundry_02_true_unreach_call_ground(int[] array, int size)
        {
            int i;
            int largest1;
            int largest2;
            int temp;

            /*  assume first element of array is the first larges t*/
            largest1 = array[0];
            /*  assume first element of array is the second largest */
            largest2 = array[1];

            if (largest1 < largest2)
            {
                temp = largest1;
                largest1 = largest2;
                largest2 = temp;
            }
            for (i = 2; i < size;  i++)
            {
                if (array[i] >= largest1)
                {
                    largest2 = largest1;
                    largest1 = array[i];
                }
                else if (array[i] > largest2)
                {
                    largest2 = array[i];
                }
            }

            int x;
            for( x = 0 ; x < size ; x++ ) {
                __VERIFIER_assert(  array[ x ] <= largest1  );
            }
            for( x = 0 ; x < size ; x++ ) {
                __VERIFIER_assert(  array[x] <= largest2 || array[x] == largest1  );
            }
        }

        public static void sanfoundry_10_true_unreach_call_ground(int[] array, int size, int element)
        {
            int i;
            int pos = -1;
            bool found = false;

            for (i = 0; i < size && !found; i++)
            {
                if (array[i] == element)
                {
                    found = true;
                    pos = i;
                }
            }
            if ( found )
            {
                for (i = pos; i <  size - 1; i++)
                {
                    array[i] = array[i + 1];
                }
            }

            if ( found ) {
                int x;
                for ( x = 0 ; x < pos ; x++ ) {
                    __VERIFIER_assert(  array[x] != element  );
                }
            }
        }

        private static void PrintEven( int i ) {
            __VERIFIER_assert(  ( i % 2 ) == 0  );
            // printf( "%d" , i );
        }

        private static void PrintOdd( int i ) {
            __VERIFIER_assert(  ( i % 2 ) != 0  );
            // printf( "%d" , i );
        }

        public static void sanfoundry_24_true_unreach_call_ground(int[] array, int size)
        {
            int i;

            //printf("Even numbers in the array are - ");
            for (i = 0; i < size; i++)
            {
                if (array[i] % 2 == 0)
                {
                    PrintEven( array[i] );
                }
            }
            //printf("\n Odd numbers in the array are -");
            for (i = 0; i < size; i++)
            {
                if (array[i] % 2 != 0)
                {
                    PrintOdd( array[i] );
                }
            }
        }

        public static void sanfoundry_27_true_unreach_call(int[] array, int size)
        {
            int i;
            int largest = array[0];
            for (i = 1; i < size; i++)
            {
                if (largest < array[i])
                    largest = array[i];
            }

            int x;
            for ( x = 0 ; x < size ; x++ ) {
                __VERIFIER_assert(  largest >= array[ x ]  );
            }
        }

        private static void IncrementArray(int[] src , int[] dst, int size)
        {
            int i;
            for (i = 0; i < size; i++) {
                dst[i] = src[i]+1;
            }
        }


        // todo: check smth???
        public static void sanfoundry_43_true_unreach_call(int size)
        {
            int[] src = RandomInit(size, 0, size);
            int[] dst = RandomInit(size, 0, size);

            IncrementArray( src , dst, size);

            int x;
            for ( x = 0 ; x < size ; x++ ) {
                src[ x ] = dst[ x ]-1;
            }
        }

        public static void sorting_bubblesort_false_unreach_call_ground(int[] a, int size)
        {
            bool swapped = true;
            while ( swapped ) {
                swapped = false;
                int i = 1;
                while ( i < size ) {
                    if ( a[i-1] < a[i] ) {
                        int t = a[i];
                        a[i] = a[i - 1];
                        a[i-1] = t;
                        swapped = true;
                    }
                    i = i + 1;
                }
            }

            int x;
            int y;
            for ( x = 0 ; x < size ; x++ ) {
                for ( y = x+1 ; y < size ; y++ ) {
                    __VERIFIER_assert(  a[x] <= a[y]  );
                }
            }
        }

        public static void sorting_bubblesort_false_unreach_call2_ground(int[] a, int size)
        {
            bool swapped = true;
            while ( swapped ) {
                swapped = false;
                int i = 1;
                while ( i < size ) {
                    if ( a[i] > a[i-1] ) {
                        int t = a[i];
                        a[i] = a[i - 1];
                        a[i-1] = t;
                        swapped = true;
                    }
                    i = i + 1;
                }
            }

            int x;
            int y;
            for ( x = 0 ; x < size ; x++ ) {
                for ( y = x+1 ; y < size ; y++ ) {
                    __VERIFIER_assert(  a[x] <= a[y]  );
                }
            }
        }

        public static void sorting_bubblesort_true_unreach_call_ground(int[] a, int size)
        {
            bool swapped = true;
            while ( swapped ) {
                swapped = false;
                int i = 1;
                while ( i < size ) {
                    if ( a[i - 1] > a[i] ) {
                        int t = a[i];
                        a[i] = a[i - 1];
                        a[i-1] = t;
                        swapped = true;
                    }
                    i = i + 1;
                }
            }

            int x;
            int y;
            for ( x = 0 ; x < size ; x++ ) {
                for ( y = x+1 ; y < size ; y++ ) {
                    __VERIFIER_assert(  a[x] <= a[y]  );
                }
            }
        }


        public static void sorting_selectionsort_false_unreach_call2_ground(int[] a, int N)
        {
            int i = 0;
            int x;
            int y;
            while ( i < N ) {
                int k = i;
                int s = i + 1;
                while ( k < N ) {
                    if ( a[k] > a[s] ) {
                        s = k;
                    }
                    k = k+1;
                }
                if ( s != i ) {
                    int tmp = a[s];
                    a[s] = a[i];
                    a[i] = tmp;
                }

                for ( x = 0 ; x < i ; x++ ) {
                    for ( y = x + 1 ; y < i ; y++ ) {
                        __VERIFIER_assert(  a[x] <= a[y]  );
                    }
                }
                for ( x = i+1 ; x < N ; x ++ ) {
                    __VERIFIER_assert(  a[x] >= a[i]  );
                }

                i = i+1;
            }

            for ( x = 0 ; x < N ; x++ ) {
                for ( y = x + 1 ; y < N ; y++ ) {
                    __VERIFIER_assert(  a[x] <= a[y]  );
                }
            }
        }

        public static void sorting_selectionsort_false_unreach_call_ground(int[] a, int N)
        {
            int i = 0;
            int x;
            int y;
            while ( i < N ) {
                int k = i + 1;
                int s = i;
                while ( k < N ) {
                    if ( a[k] < a[s] ) {
                        s = k;
                    }
                    k = k+1;
                }
                if ( s != i ) {
                    int tmp = a[s];
                    a[s] = a[i];
                    a[i] = tmp;
                }

                for ( x = 0 ; x < i ; x++ ) {
                    for ( y = x + 1 ; y < i ; y++ ) {
                        __VERIFIER_assert(  a[x] <= a[y]  );
                    }
                }

                for ( x = 0 ; x < N ; x++ ) {
                    __VERIFIER_assert(  a[x] >= a[i]  );
                }

                i = i+1;
            }

            for ( x = 0 ; x < N ; x++ ) {
                for ( y = x + 1 ; y < N ; y++ ) {
                    __VERIFIER_assert(  a[x] <= a[y]  );
                }
            }
        }


        public static void sorting_selectionsort_true_unreach_call_ground(int[] a, int N)
        {
            int i = 0;
            int x;
            int y;
            while ( i < N ) {
                int k = i + 1;
                int s = i;
                while ( k < N ) {
                    if ( a[k] < a[s] ) {
                        s = k;
                    }
                    k = k+1;
                }
                if ( s != i ) {
                    int tmp = a[s];
                    a[s] = a[i];
                    a[i] = tmp;
                }

                for ( x = 0 ; x < i ; x++ ) {
                    for ( y = x + 1 ; y < i ; y++ ) {
                        __VERIFIER_assert(  a[x] <= a[y]  );
                    }
                }
                for ( x = i ; x < N ; x++ ) {
                    __VERIFIER_assert(  a[x] >= a[i]  );
                }

                i = i+1;
            }

            for ( x = 0 ; x < N ; x++ ) {
                for ( y = x + 1 ; y < N ; y++ ) {
                    __VERIFIER_assert(  a[x] <= a[y]  );
                }
            }
        }

        public static void standard_allDiff2_false_unreach_call_ground(int[] a, int N)
        {
            int i;
            bool r = true;
            for ( i = 1 ; i < N && r ; i++ ) {
                int j;
                for ( j = i-1 ; j >= 0 && r ; j-- ) {
                    if ( a[i] == a[j] ) {
                        r = true;
                    }
                }
            }

            if ( r ) {
                int x;
                int y;
                for ( x = 0 ; x < N ; x++ ) {
                    for ( y = x+1 ; y < N ; y++ ) {
                        __VERIFIER_assert(  a[x] != a[y]  );
                    }
                }
            }
        }

        public static void standard_compareModified_true_unreach_call_ground(int[] a, int[] b, int SIZE)
        {
            int i = 0;
            int[] c  = new int[SIZE];
            bool rv = true;
            while ( i < SIZE ) {
                if ( a[i] != b[i] ) {
                    rv = false;
                }
                c[i] = a[i];
                i = i+1;
            }

            int x;
            if ( rv ) {
                for ( x = 0 ; x < SIZE ; x++ ) {
                    __VERIFIER_assert(  a[x] == b[x]  );
                }
            }

            for ( x = 0 ; x < SIZE ; x++ ) {
                __VERIFIER_assert(  a[x] == c[x]  );
            }
        }

        public static void standard_compare_true_unreach_call_ground(int[] a, int[] b, int SIZE)
        {
            int i = 0;
            bool rv = true;
            while ( i < SIZE ) {
                if ( a[i] != b[i] ) {
                    rv = false;
                }
                i = i+1;
            }

            if ( rv ) {
                int x;
                for ( x = 0 ; x < SIZE ; x++ ) {
                    __VERIFIER_assert(  a[x] == b[x]  );
                }
            }
        }

        public static void standard_copy1_false_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a1[i] = a1[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a2[x]  );
            }
        }

        public static void standard_copy1_true_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a2[x]  );
            }
        }

        public static void standard_copy2_false_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a3[x]  );
            }

        }

        public static void standard_copy2_true_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a3[x]  );
            }
        }

        public static void standard_copy3_false_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a4[x]  );
            }
        }

        public static void standard_copy3_true_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a4[x]  );
            }
        }

        public static void standard_copy4_false_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a5[x]  );
            }
        }

        public static void standard_copy4_true_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a5[x]  );
            }
        }

        public static void standard_copy5_false_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];
            int[] a6  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a6[x]  );
            }
        }

        public static void standard_copy5_true_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];
            int[] a6  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a6[x]  );
            }
        }

        public static void standard_copy6_false_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];
            int[] a6  = new int[N];
            int[] a7  = new int[N];


            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a7[x]  );
            }
        }

        public static void standard_copy6_true_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];
            int[] a6  = new int[N];
            int[] a7  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a7[x]  );
            }
        }

        public static void standard_copy7_false_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];
            int[] a6  = new int[N];
            int[] a7  = new int[N];
            int[] a8  = new int[N];


            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a7[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a8[x]  );
            }

        }

        public static void standard_copy7_true_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];
            int[] a6  = new int[N];
            int[] a7  = new int[N];
            int[] a8  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a7[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a8[x]  );
            }
        }

        public static void standard_copy8_false_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];
            int[] a6  = new int[N];
            int[] a7  = new int[N];
            int[] a8  = new int[N];
            int[] a9  = new int[N];


            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a9[i] = a7[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a9[i] = a8[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a9[x]  );
            }
        }

        public static void standard_copy8_true_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];
            int[] a6  = new int[N];
            int[] a7  = new int[N];
            int[] a8  = new int[N];
            int[] a9  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a7[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a9[i] = a8[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a9[x]  );
            }
        }

        public static void standard_copy9_false_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];
            int[] a6  = new int[N];
            int[] a7  = new int[N];
            int[] a8  = new int[N];
            int[] a9  = new int[N];
            int[] a0  = new int[N];


            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a7[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a0[i] = a8[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a0[i] = a9[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a0[x]  );
            }
        }

        public static void standard_copy9_true_unreach_call_ground(int[] a1, int[] a2, int N)
        {
            int[] a3  = new int[N];
            int[] a4  = new int[N];
            int[] a5  = new int[N];
            int[] a6  = new int[N];
            int[] a7  = new int[N];
            int[] a8  = new int[N];
            int[] a9  = new int[N];
            int[] a0  = new int[N];

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a7[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a9[i] = a8[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a0[i] = a9[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a0[x]  );
            }
        }


        public static void standard_copy2_false_unreach_call_ground(int[] a1, int[] a2, int[] a3, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a3[x]  );
            }

        }

        public static void standard_copy2_true_unreach_call_ground(int[] a1, int[] a2, int[] a3, int N)
        {

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a3[x]  );
            }
        }

        public static void standard_copy3_false_unreach_call_ground(int[] a1, int[] a2, int[] a3, int[] a4, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a4[x]  );
            }
        }

        public static void standard_copy3_true_unreach_call_ground(int[] a1, int[] a2, int[] a3, int[] a4, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a4[x]  );
            }
        }

        public static void standard_copy4_false_unreach_call_ground(int[] a1, int[] a2, int[] a3, int[] a4, int[] a5, int N)
        {

            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a5[x]  );
            }
        }

        public static void standard_copy4_true_unreach_call_ground(int[] a1, int[] a2, int[] a3, int[] a4, int[] a5, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a5[x]  );
            }
        }

        public static void standard_copy5_false_unreach_call_ground(int[] a1, int[] a2, int[] a3, int[] a4, int[] a5, int[] a6, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a6[x]  );
            }
        }

        public static void standard_copy5_true_unreach_call_ground(int[] a1, int[] a2, int[] a3, int[] a4, int[] a5, int[] a6, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a6[x]  );
            }
        }

        public static void standard_copy6_false_unreach_call_ground(int[] a1
            , int[] a2, int[] a3, int[] a4, int[] a5, int[] a6, int[] a7, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a7[x]  );
            }
        }

        public static void standard_copy6_true_unreach_call_ground(int[] a1
            , int[] a2, int[] a3, int[] a4, int[] a5, int[] a6, int[] a7, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a7[x]  );
            }
        }

        public static void standard_copy7_false_unreach_call_ground(int[] a1
            , int[] a2, int[] a3, int[] a4, int[] a5, int[] a6, int[] a7, int[] a8, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a7[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a8[x]  );
            }

        }

        public static void standard_copy7_true_unreach_call_ground(int[] a1
            , int[] a2, int[] a3, int[] a4, int[] a5, int[] a6, int[] a7, int[] a8, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a7[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a8[x]  );
            }
        }

        public static void standard_copy8_false_unreach_call_ground(int[] a1
            , int[] a2, int[] a3, int[] a4, int[] a5, int[] a6, int[] a7, int[] a8, int[] a9, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a9[i] = a7[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a9[i] = a8[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a9[x]  );
            }
        }

        public static void standard_copy8_true_unreach_call_ground(int[] a1
            , int[] a2, int[] a3, int[] a4, int[] a5, int[] a6, int[] a7, int[] a8, int[] a9, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a7[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a9[i] = a8[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a9[x]  );
            }
        }

        public static void standard_copy9_false_unreach_call_ground(int[] a1
            , int[] a2, int[] a3, int[] a4, int[] a5, int[] a6, int[] a7, int[] a8, int[] a9, int[] a0, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a7[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a0[i] = a8[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a0[i] = a9[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a0[x]  );
            }
        }

        public static void standard_copy9_true_unreach_call_ground(int[] a1
            , int[] a2, int[] a3, int[] a4, int[] a5, int[] a6, int[] a7, int[] a8, int[] a9, int[] a0, int N)
        {
            int i;
            for ( i = 0 ; i < N ; i++ ) {
                a2[i] = a1[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a3[i] = a2[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a4[i] = a3[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a5[i] = a4[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a6[i] = a5[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a7[i] = a6[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a8[i] = a7[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a9[i] = a8[i];
            }
            for ( i = 0 ; i < N ; i++ ) {
                a0[i] = a9[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a1[x] == a0[x]  );
            }
        }

        public static void standard_copyInitSum2_false_unreach_call_ground(int[] a, int[] b, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }

            for ( i = 0 ; i < N ; i++ ) {
                b[i] = a[i];
            }

            for ( i = 0 ; i < N ; i++ ) {
                a[i] = b[i] + i;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  b[x] == 42 + x  );
            }
        }

        public static void standard_copyInitSum2_true_unreach_call_ground(int[] a, int[] b, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }

            for ( i = 0 ; i < N ; i++ ) {
                b[i] = a[i];
            }

            for ( i = 0 ; i < N ; i++ ) {
                b[i] = b[i] + i;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  b[x] == 42 + x  );
            }
        }

        public static void standard_copyInitSum3_true_unreach_call_ground(int[] a, int[] b, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }

            for ( i = 0 ; i < N ; i++ ) {
                b[i] = a[i];
            }

            for ( i = 0 ; i < N ; i++ ) {
                b[i] = b[i] + i;
            }

            for ( i = 0 ; i < N ; i++ ) {
                b[i] = b[i] - a[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  b[x] == x  );
            }
        }

        public static void standard_copyInit_true_unreach_call_ground(int[] a, int[] b, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }

            for ( i = 0 ; i < N ; i++ ) {
                b[i] = a[i];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  b[x] == 42  );
            }
        }


        public static void standard_init1_false(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 43  );
            }
        }

        public static void standard_init1_true(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 42  );
            }
        }

        public static void standard_init2_false(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 42  );
            }
        }

        public static void standard_init2_true(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 43  );
            }
        }

        public static void standard_init3_false(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 43  );
            }
        }

        public static void standard_init3_true(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 44  );
            }
        }

        public static void standard_init4_false(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 46  );
            }
        }

        public static void standard_init4_true(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 45  );
            }
        }

        public static void standard_init5_false(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 46;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 45  );
            }
        }

        public static void standard_init5_true(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 46;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 46  );
            }
        }

        public static void standard_init6_false(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 46;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 47;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 46  );
            }
        }

        public static void standard_init6_true(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 46;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 47;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 47  );
            }
        }
        public static void standard_init7_false(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 46;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 47;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 48;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 47  );
            }
        }

        public static void standard_init7_true(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 46;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 47;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 48;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 48  );
            }
        }

        public static void standard_init8_false(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 46;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 47;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 48;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 49;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 48  );
            }
        }

        public static void standard_init8_true(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 46;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 47;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 48;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 49;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 49  );
            }
        }
        public static void standard_init9_false(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 46;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 47;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 48;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 49;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 50;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 49  );
            }
        }

        public static void standard_init9_true(int[] a, int N)
        {
            int i = 0;
            while ( i < N ) {
                a[i] = 42;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 43;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 44;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 45;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 46;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 47;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 48;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 49;
                i = i + 1;
            }
            i = 0;
            while ( i < N ) {
                a[i] = 50;
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == 50  );
            }

        }


        public static void standard_maxInArray_true(int[] a, int N)
        {
            int max = 0;
            int i = 0;
            while ( i < N ) {
                if ( a[i] > max ) {
                    max = a[i];
                }
                i = i + 1;
            }

            int x;
            for (x = 0; x < N; x++)
            {
                __VERIFIER_assert(a[x] <= max);
            }
        }

        public static void standard_minInArray_false(int[] a, int N)
        {
            int min = 0;
            int i = 0;
            while ( i < N ) {
                if ( a[i] < min ) {
                    min = a[i];
                }
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] > min  );
            }
        }

        public static void standard_minInArray_true(int[] a, int N)
        {
            int min = 0;
            int i = 0;
            while ( i < N ) {
                if ( a[i] < min ) {
                    min = a[i];
                }
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] >= min  );
            }
        }

        public static void standard_palindrome_true(int[] a, int N)
        {
            int i;
            for (i = 0; i < N/2 ; i++ ) {
                a[i] = a[N-i-1];
            }

            int x;
            for ( x = 0 ; x < N/2 ; x++ ) {
                __VERIFIER_assert(  a[x] == a[N - x - 1]  );
            }
        }

        public static void standard_partial_init_true(int[] a, int[] b, int N)
        {
            int[] C = new int[ N ];
            int i;
            int j = 0;
            for (i = 0; i < N ; i++) {
                if ( a[i] == b[i] ) {
                    C[j] = i;
                    j = j + 1;
                }
            }

            int x;
            for ( x = 0 ; x < j ; x++ ) {
                __VERIFIER_assert(  C[x] <= x + i - j  );
            }
            for ( x = 0 ; x < j ; x++ ) {
                __VERIFIER_assert(  C[x] >= x  );
            }
        }

        public static void standard_partition_false(int[] aa, int[] bb, int N)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int[] cc= new int[ N ];;

            while( a < N ) {
                if( aa[ a ] >= 0 ) {
                    bb[ b ] = aa[ a ];
                    b = b + 1;
                }
                a = a + 1;
            }
            a = 0;
            while( a < N ) {
                if( aa[ a ] >= 0 ) {
                    cc[ c ] = aa[ a ];
                    c = c + 1;
                }
                a = a + 1;
            }

            int x;
            for ( x = 0 ; x < b ; x++ ) {
                __VERIFIER_assert(  bb[ x ] >= 0  );
            }
            for ( x = 0 ; x < c ; x++ ) {
                __VERIFIER_assert(  cc[ x ] < 0  );
            }
        }

        public static void standard_partition_original_true(int[] aa, int[] bb, int N)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int[] cc= new int[ N ];;
            while( a < N ) {
                if( aa[ a ] >= 0 ) {
                    bb[ b ] = aa[ a ];
                    b = b + 1;
                }
                else {
                    cc[ c ] = aa[ a ];
                    c = c + 1;
                }
                a = a + 1;
            }

            int x;
            for ( x = 0 ; x < b ; x++ ) {
                __VERIFIER_assert(  bb[ x ] >= 0  );
            }

            for ( x = 0 ; x < c ; x++ ) {
                __VERIFIER_assert(  cc[ x ] < 0  );
            }
        }

        public static void standard_partition_true(int[] aa, int[] bb, int N)
        {
            int a = 0;
            int b = 0;
            int c = 0;
            int[] cc= new int[ N ];

            while( a < N ) {
                if( aa[ a ] >= 0 ) {
                    bb[ b ] = aa[ a ];
                    b = b + 1;
                }
                a = a + 1;
            }
            a = 0;
            while( a < N ) {
                if( aa[ a ] < 0 ) {
                    cc[ c ] = aa[ a ];
                    c = c + 1;
                }
                a = a + 1;
            }

            int x;
            for ( x = 0 ; x < b ; x++ ) {
                __VERIFIER_assert(  bb[ x ] >= 0  );
            }
        }

        public static void standard_password_true(int[] password, int[] guess, int SIZE)
        {

            int i;
            bool result = true;
            for ( i = 0 ; i < SIZE ; i++ ) {
                if ( password[ i ] != guess[ i ] ) {
                    result = false;
                }
            }

            if ( result ) {
                int x;
                for ( x = 0 ; x < SIZE ; x++ ) {
                    __VERIFIER_assert(  password[ x ] == guess[ x ]  );
                }
            }
        }

        public static void standard_reverse_true(int[] a, int N)
        {
            int[] b = new int[N];
            int i;
            for( i = 0 ; i < N ; i++ ) {
                b[i] = a[N-i-1];
            }

            int x;
            for ( x = 0 ; x < N ; x++ ) {
                __VERIFIER_assert(  a[x] == b[N-x-1]  );
            }
        }

        public static void standard_running_false(int[] a, int N)
        {
            int[] b = new int[N];
            int i = 0;
            while ( i < N ) {
                if ( a[i] >= 0 ) b[i] = 1;
                else b[i] = 0;
                i = i + 1;
            }
            int f = 1;
            i = 0;
            while ( i < N ) {
                if ( a[i] >= 0 && !Int2bool(b[i]) ) f = 0;
                if ( a[i] < 0 && !Int2bool(b[i]) ) f = 0;
                i = i + 1;
            }
            __VERIFIER_assert ( Int2bool(f) );
        }


        public static void standard_running_true(int[] a, int N)
        {
            int[] b = new int[N];
            int i = 0;
            while ( i < N ) {
                if ( a[i] >= 0 ) b[i] = 1;
                else b[i] = 0;
                i = i + 1;
            }
            int f = 1;
            i = 0;
            while ( i < N ) {
                if ( a[i] >= 0 && !Int2bool(b[i]) ) f = 0;
                if ( a[i] < 0 && Int2bool(b[i]) ) f = 0;
                i = i + 1;
            }
            __VERIFIER_assert ( Int2bool(f) );
        }

        public static void standard_sentinel_false(int[] a, int N, int marker, int pos)
        {
            if ( pos >= 0 && pos < N ) {
                a[ pos ] = marker;

                int i = 0;
                while( a[ i ] != marker ) {
                    i = i + 1;
                }

                __VERIFIER_assert(  i <= pos  );
            }
        }

        public static void standard_seq_init_true(int[] a, int SIZE)
        {
            int i;
            i = 1;
            a[0] = 7;
            while( i < SIZE ) {
                a[i] = a[i-1] + 1;
                i = i + 1;
            }

            int x;
            for ( x = 1 ; x < SIZE ; x++ ) {
                __VERIFIER_assert(  a[x] >= a[x-1]  );
            }
        }

        public static bool _strcmp( int[] src , int[] dst, int N ) {
            int i = 0;
            while ( i < N ) {
                if( dst[i] != src[i] ) return false;
                i = i + 1;
            }
            return true;
        }

        public static void standard_strcmp_true(int[] a,int[] b, int N)
        {
            bool c = _strcmp( a , b, N);

            if (c) {
                int x;
                for ( x = 0 ; x < N ; x++ ) {
                    __VERIFIER_assert(  a[x] == b[x]  );
                }
            }
        }

        public static void standard_strcpy_false(int[] src, int N)
        {
            int[] dst = new int[N];
            int i = 0;
            while ( src[i] != 0 ) {
                dst[i] = src[i];
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < i ; x++ ) {
                __VERIFIER_assert(  dst[x] == src[x]  );
            }
        }

        public static void standard_strcpy_original_false(int[] src, int N)
        {
            int[] dst = new int[N];
            int i = 0;
            while ( src[i] != 0 ) {
                dst[i] = src[i];
                i = i + 1;
            }

            i = 0;
            while ( src[i] != 0 ) {
                __VERIFIER_assert(  dst[i] == src[i]  );
                i = i + 1;
            }
        }

        public static void standard_strcpy_original_true(int[] src, int N)
        {
            int[] dst = new int[N];
            int i = 0;
            int j = 0;


            while ( i < N && src[i] != 0 ) {
                dst[i] = src[i];
                i = i + 1;
            }

            i = 0;
            while ( i < N && src[i] != 0 ) {
                __VERIFIER_assert(  dst[i] == src[i]  );
                i = i + 1;
            }
        }

        public static void standard_strcpy_true(int[] src, int N)
        {
            int[] dst = new int[N];
            int i = 0;
            int j = 0;

            while ( i < N && src[i] != 0 ) {
                dst[i] = src[i];
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < i ; x++ ) {
                __VERIFIER_assert(  dst[x] == src[x]  );
            }
        }

        public static void standard_two_index_01_true(int[] b, int size)
        {
            int[] a = new int[size];
            int i = 0;
            int j = 0;
            while( i < size )
            {
                a[j] = b[i];
                i = i+1;
                j = j+1;
            }

            i = 0;
            j = 0;
            while( i < size )
            {
                __VERIFIER_assert( a[j] == b[j] );
                i = i+1;
                j = j+1;
            }
        }

        public static void standard_two_index_02_true(int[] b, int size)
        {
            int[] a = new int[size];
            int i = 0;
            int j = 0;
            while( i < size )
            {
                a[j] = b[i];
                i = i+2;
                j = j+1;
            }

            i = 1;
            j = 0;
            while( i < size )
            {
                __VERIFIER_assert( a[j] == b[2*j+1] );
                i = i+2;
                j = j+1;
            }
        }

        public static void standard_two_index_03_true(int[] b, int size)
        {
            int[] a = new int[size];
            int i = 0;
            int j = 0;
            while( i < size )
            {
                a[j] = b[i];
                i = i+3;
                j = j+1;
            }

            i = 1;
            j = 0;
            while( i < size )
            {
                __VERIFIER_assert( a[j] == b[3*j+1] );
                i = i+3;
                j = j+1;
            }

        }

        public static void standard_two_index_04_true(int[] b, int size)
        {
            int[] a = new int[size];
            int i = 0;
            int j = 0;
            while( i < size )
            {
                a[j] = b[i];
                i = i+4;
                j = j+1;
            }

            i = 1;
            j = 0;

            while( i < size )
            {
                __VERIFIER_assert( a[j] == b[4*j+1] );
                i = i+4;
                j = j+1;
            }

        }


        public static void standard_two_index_05_true(int[] b, int size)
        {
            int[] a = new int[size];
            int i = 0;
            int j = 0;
            while( i < size )
            {
                a[j] = b[i];
                i = i+5;
                j = j+1;
            }

            i = 1;
            j = 0;
            while( i < size )
            {
                __VERIFIER_assert( a[j] == b[5*j+1] );
                i = i+5;
                j = j+1;
            }
        }


        public static void standard_two_index_06_true(int[] b, int size)
        {
            int[] a = new int[size];
            int i = 0;
            int j = 0;
            while( i < size )
            {
                a[j] = b[i];
                i = i+6;
                j = j+1;
            }

            i = 1;
            j = 0;
            while( i < size )
            {
                __VERIFIER_assert( a[j] == b[6*j+1] );
                i = i+6;
                j = j+1;
            }
        }


        public static void standard_two_index_07_true(int[] b, int size)
        {
            int[] a = new int[size];
            int i = 0;
            int j = 0;
            while( i < size )
            {
                a[j] = b[i];
                i = i+7;
                j = j+1;
            }

            i = 1;
            j = 0;
            while( i < size )
            {
                __VERIFIER_assert( a[j] == b[7*j+1] );
                i = i+7;
                j = j+1;
            }
        }


        public static void standard_two_index_08_true(int[] b, int size)
        {
            int[] a = new int[size];
            int i = 0;
            int j = 0;
            while( i < size )
            {
                a[j] = b[i];
                i = i+8;
                j = j+1;
            }

            i = 1;
            j = 0;
            while( i < size )
            {
                __VERIFIER_assert( a[j] == b[8*j+1] );
                i = i+8;
                j = j+1;
            }
        }

        public static void standard_two_index_09_true(int[] b, int size)
        {
            int[] a = new int[size];
            int i = 0;
            int j = 0;
            while( i < size )
            {
                a[j] = b[i];
                i = i+9;
                j = j+1;
            }

            i = 1;
            j = 0;
            while( i < size )
            {
                __VERIFIER_assert( a[j] == b[9*j+1] );
                i = i+9;
                j = j+1;
            }
        }

        public static void standard_vararg_true(int[] aa, int N)
        {
            int a = 0;
            while( aa[a] >= 0 ) {
                a++;
            }

            int x;
            for ( x = 0 ; x < a ; x++ ) {
                __VERIFIER_assert(  aa[x] >= 0  );
            }

        }

        public static void standard_vector_difference_true(int[] a, int[] b, int SIZE)
        {
            int[] c = new int[SIZE];
            int i = 0;
            while (i < SIZE) {
                c[i] = a[i] - b[i];
                i = i + 1;
            }

            int x;
            for ( x = 0 ; x < SIZE ; x++ ) {
                __VERIFIER_assert(  c[x] == a[x] - b[x]  );
            }
        }

        public static void array_assert_loop_dep_false(int SIZE)
        {
            int i;
            int[] a = new int[SIZE];
            for(i = 0; i < SIZE; i++)
            {
                a[i] = 10;
            }


            for(i = 0; i < SIZE; i++)
            {
                __VERIFIER_assert(a[i] == 10 );

                if(i+1 != 15000)
                    a[i+1] = 20;
            }

        }

        public static void array_mul_init_true(int[] a, int[] b, int SIZE, int k)
        {
            int i;

            for (i  = 0; i<SIZE ; i++)
            {
                a[i] = i;
                b[i] = i ;
            }

            for (i=0; i< SIZE; i++)
            {
                if ( i % 2 == 0) {
                    a[i] = k;
                    b[i] = k * k ;
                }
            }

            for (i=0; i< SIZE; i++)
            {
                __VERIFIER_assert(a[i] == b[i] || b[i]  == a[i] * a[i]);
            }
        }

        public static void array_of_struct_break_true(S[] s, int SIZE, int c)
        {
            int i;
            for(i = 0; i < SIZE; i++)
            {
                if(c > 5)
                    break;

                s[i].n = 10;
            }

            for(i = 0; i < SIZE; i++)
            {
                if(c <= 5)
                    __VERIFIER_assert(s[i].n == 10);
            }
        }

        public static void array_of_struct_loop_dep_false(S[] a, int SIZE, int c)
        {
            int i;
            for(i = 0; i < SIZE; i++)
            {
                a[i].n = 10;
            }


            for(i = 0; i < SIZE; i++)
            {
                __VERIFIER_assert(a[i].n == 10);
                if(i+1 != 15000)
                    a[i+1].n = 20;

            }
        }

        public static void array_range_init_false(int[] a, int[] b, int SIZE)
        {
            int i;
            for(i = 0; i < SIZE; i++)
            {
                if(i>=0 && i<=10000)
                    a[i] = 10;
                else
                    a[i] = 0;
            }


            for(i = 0; i < SIZE; i++)
            {
                __VERIFIER_assert(a[i] == 10);

            }
        }

        public static void array_shadowinit_true( int N)
        {
            if(N > 0) {
                int i,k;
                int[] a = new int[N];

                i=0;
                k=0;
                while(i < N) {
                    a[k]=k;
                    i=i+1;
                    k=k+1;
                }

                i=0;
                while(i < N) {
                    __VERIFIER_assert(a[i]==i);
                    i=i+1;
                }
            }
        }

        public static void array_single_elem_init_false(int q ,int[] a, int[] b, int[] c, int SIZE)
        {
            int i;

            //init and update
            for (i = 0; i < SIZE; i++)
            {
                a[i] = 0;
                if (q == 0)
                {
                    a[i] = 1;
                    b[i] = i % 2;
                }
                if (a[i] != 0)
                {
                    if (b[i] == 0)
                    {
                        c[i] = 0;
                    }
                    else
                    {
                        c[i] = 1;
                    }
                }
            }

            a[15000] = 1;

            for (i = 0; i < SIZE; i++)
            {
                if (i == 15000 )
                {
                    __VERIFIER_assert(c[i] == 0);
                }
            }
        }

        public static void check_removal_from_set_after_insertion_false(int[] set, int[] values, int element, int SIZE)
        {
            int i, pos = 0, n = 0, found = 0;



            int v;
            for ( v = 0 ; v < SIZE ; v++ ) {
                if ( !Elem_exists( set , n , values[ v ] ) ) {
                    // parametes are passed by reference
                    n = Insert( set , n , values[ v ] );
                }
            }


            for (i = 0; i < SIZE && found != 1; i++) {
                if (set[i] == element)
                {
                    found = 1;
                    pos = i;
                }
            }
            
            if ( found == 1 )
            {
                for (i = pos; i <  SIZE - 1; i++)
                {
                    set[i] = set[i + 1];
                }
            }

            if(found == 1)
            {
                for(i=0; i < SIZE - 1; i++)
                {
                    __VERIFIER_assert(set[i] != element);
                }
            }
        }

        public static void Main(string[] args)
        {

        }
    }
}
