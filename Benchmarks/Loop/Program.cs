using System;
using System.Collections.Generic;

namespace Loop
{
    internal class BenchmarkException : Exception
    {
        public BenchmarkException()
        {
        }
    }

    internal class LoopBenchmark
    {
        private static bool Int2bool(int i)
        {
            return i != 0;
        }

        private static void __VERIFIER_assert(bool cond)
        {
            if (!cond)
            {
                throw new BenchmarkException();
            }
        }


        public static void array3_false(int[] A,int N) {
            int i;

            for (i = 0; i < N; i++) {
                A[i] = i;
            }

            for (i = 0; A[i] != 0; i++) {
                if (i >= N) {
                    break;
                }
            }

            __VERIFIER_assert(i <= N);
        }



        public static void array_false(int[] A,int N) {
            int i;

            for (i = 0; i < N / 2; i++) {
                A[i] = i;
            }

            __VERIFIER_assert(A[N/2] != N/2);
        }

        public static void array_false2(int[] A,int[] B,int SZ) {
            int i;
            int tmp;

            for (i = 0; i < SZ; i++) {
                tmp = A[i];
                B[i] = tmp;
            }

            __VERIFIER_assert(A[SZ/2] != B[SZ/2]);
        }

        public static void array_false3(int[] A,int[] B,int N) {
            int i;

            for (i = 0; i < N; i++) {
                A[i] = i * 3;
            }

            for (i = 0; A[i] != 0 && i < N; i++) {
            }

            __VERIFIER_assert(i <= N / 2);
        }

        public static void array_true(int[] A,int[] B,int N) {
            if (N < 1024) return;
            int i;

            for (i = 0; i < 1024; i++) {
                A[i] = i;
            }

            __VERIFIER_assert(A[1023] == 1023);
        }

        public static void array_true2(int[] A,int[] B,int SZ) {
            int i;
            int tmp;

            for (i = 0; i < SZ; i++) {
                tmp = A[i];
                B[i] = tmp;
            }

            __VERIFIER_assert(A[SZ/2] == B[SZ/2]);
        }

        public static void array_true3(int[] A,int[] B,int N) {

            int i;

            Random r = new Random();

            for (i = 0; i < N; i++) {
                A[i] = r.Next();
                A[i] *= A[i];
                A[i] += 1;
            }

            for (i = 0; A[i] != 0; i++) {
                if (i >= N-1) {
                    break;
                }
            }

            __VERIFIER_assert(i <= N);
        }

        public static void array_true4(int[] A,int[] B,int N) {
            int i;

            for (i = 0; i < N-1; i++)
            {
                A[i] = i * 25;
            }

            A[N-1] = 0;

            for (i = 0; A[i] != 0; i++) {
            }

            __VERIFIER_assert(i <= N);
        }

        public static void const_false() {
            uint x = 1;
            uint y = 0;

            while (y < 1024) {
                x = 0;
                y++;
            }

            __VERIFIER_assert(x == 1);
        }

        public static void diamond_false(uint y) {
            uint x = 0;

            while (x < 99) {
                if (y % 2 == 0) {
                    x++;
                } else {
                    x += 2;
                }
            }

            __VERIFIER_assert((x % 2) == (y % 2));
        }

        public static void diamond_true(uint y) {
            uint x = 0;

            while (x < 99) {
                if (y % 2 == 0) {
                    x += 2;
                } else {
                    x++;
                }
            }

            __VERIFIER_assert((x % 2) == (y % 2));
        }

        public static void diamond_true2(uint y) {
            uint x = 0;

            while (x < 99) {
                if (y % 2 == 0) x += 2;
                else x++;

                if (y % 2 == 0) x += 2;
                else x -= 2;

                if (y % 2 == 0) x += 2;
                else x += 2;

                if (y % 2 == 0) x += 2;
                else x -= 2;

                if (y % 2 == 0) x += 2;
                else x += 2;

                if (y % 2 == 0) x += 2;
                else x -= 4;

                if (y % 2 == 0) x += 2;
                else x += 4;

                if (y % 2 == 0) x += 2;
                else x += 2;

                if (y % 2 == 0) x += 2;
                else x -= 4;

                if (y % 2 == 0) x += 2;
                else x -= 4;
            }

            __VERIFIER_assert((x % 2) == (y % 2));
        }



        public static uint f(uint z) {
            return z + 2;
        }

        public static void functions_false() {
            uint x = 0;

            while (x < 0x0fffffff) {
                x = f(x);
            }

            __VERIFIER_assert(x % 2 == 0);
        }



        public static void multivar_false(uint x) {
            uint y = x + 1;

            while (x < 1024) {
                x++;
                y++;
            }

            __VERIFIER_assert(x == y);
        }

        public static void nested_false() {
            uint x = 0;
            uint y = 0;

            while (x < 0x0fffffff) {
                y = 0;

                while (y < 10) {
                    y++;
                }

                x++;
            }

            __VERIFIER_assert(x % 2 != 1);
        }

        public static void nested_true() {
            uint x = 0;
            uint y = 0;

            while (x < 0x0fffffff) {
                y = 0;

                while (y < 10) {
                    y++;
                }

                x++;
            }

            __VERIFIER_assert(x % 2 == 1);
        }

        public static void phases_true(uint y) {

            uint x = 1;

            if (!(y > 0)) return;

            while (x < y) {
                if (x < y / x) {
                    x *= x;
                } else {
                    x++;
                }
            }

            __VERIFIER_assert(x == y);
        }

        public static void underapprox_true() {
            uint x = 0;
            uint y = 1;

            while (x < 6) {
                x++;
                y *= 2;
            }

            __VERIFIER_assert(x == 6);
        }

        public static void mod3_true(uint x, bool o1, bool o2) {
            uint y = 1;

            while(o1){
                if(x % 3 == 1){
                    x += 2; y = 0;}
                else{
                    if(x % 3 == 2){
                        x += 1; y = 0;}
                    else{
                        if(o2){
                            x += 4; y = 1;}
                        else{
                            x += 5; y = 1;}
                    }
                }
            }
            if(y == 0)
                __VERIFIER_assert(x % 3 == 0);
        }

        public static void count_by_1_true()
        {
            int LARGE_INT = Int32.MaxValue;
            int i;
            for (i = 0; i < LARGE_INT; i++) ;
            __VERIFIER_assert(i == LARGE_INT);
        }

        public static void count_by_1_variant_true()
        {
            int LARGE_INT = Int32.MaxValue;
            int i;
            for (i = 0; i != LARGE_INT; i++) ;
            __VERIFIER_assert(i == LARGE_INT);
        }

        public static void count_by_2_true()
        {
            int LARGE_INT = Int32.MaxValue;
            int i;
            for (i = 0; i != LARGE_INT; i+=2) ;
            __VERIFIER_assert(i == LARGE_INT);

        }

        public static void count_by_k_true(int k)
        {

            int LARGE_INT = Int32.MaxValue / k;
            int i;
            if (!(0 <= k && k <= 10)) return;
            for (i = 0; i < LARGE_INT*k; i += k) ;
            __VERIFIER_assert(i == LARGE_INT*k);
        }

        public static void gauss_sum_true(int n)
        {

            int  sum, i;
            if (!(1 <= n && n <= 1000)) return;
            sum = 0;
            for(i = 1; i <= n; i++) {
                sum = sum + i;
            }
            __VERIFIER_assert(2*sum == n*(n+1));
        }

        public static void nested_true(int n, int m)
        {
            int k = 0;
            int i,j;
            if (!(10 <= n && n <= 10000)) return;
            if (!(10 <= m && m <= 10000)) return;
            for (i = 0; i < n; i++) {
                for (j = 0; j < m; j++) {
                    k ++;
                }
            }
            __VERIFIER_assert(k >= 100);
        }

        public static void afnp2014_true(bool op1)
        {
            int x = 1;
            int y = 0;
            while (y < 1000 && op1) {
                x = x + y;
                y = y + 1;
            }
            __VERIFIER_assert(x >= y);
        }

        public static void bhmr2007_true(int n, bool op1)
        {
            int i, a, b;
            i = 0; a = 0; b = 0;
            int LARGE_INT = Int32.MaxValue;
            if (!(n >= 0 && n <= LARGE_INT)) return;
            while (i < n) {
                if (op1) {
                    a = a + 1;
                    b = b + 2;
                } else {
                    a = a + 2;
                    b = b + 1;
                }
                i = i + 1;
            }
            __VERIFIER_assert(a + b == 3*n);
        }

        public static void cggmp2005_true()
        {
            int i,j;
            i = 1;
            j = 10;
            while (j >= i) {
                i = i + 2;
                j = -1 + j;
            }
            __VERIFIER_assert(j == 6);
        }


        public static void cggmp2005_variant_true(int mid)
        {
            int lo,  hi;
            int LARGE_INT = Int32.MaxValue;
            lo = 0;
            if (!(mid > 0 && mid <= LARGE_INT)) return ;
            hi = 2*mid;

            while (mid > 0) {
                lo = lo + 1;
                hi = hi - 1;
                mid = mid - 1;
            }
            __VERIFIER_assert(lo == hi);
        }

        public static void cggmp2005b_true()
        {
            int i,j,k;
            i = 0;
            k = 9;
            j = -100;
            while (i <= 100) {
                i = i + 1;
                while (j < 20) {
                    j = i + j;
                }
                k = 4;
                while (k <= 3) {
                    k = k + 1;
                }
            }
            __VERIFIER_assert(k == 4);
        }

        public static void css2003_true(int k)
        {
            int i,j;
            i = 1;
            int LARGE_INT = Int32.MaxValue;
            j = 1;
            if (!(0 <= k && k <= 1)) return;
            while (i < LARGE_INT) {
                i = i + 1;
                j = j + k;
                k = k - 1;
                __VERIFIER_assert(1 <= i + k && i + k <= 2 && i >= 1);
            }
        }

        public static void ddlm2013_true(bool flag, bool op1)
        {
            uint i,j,a,b;
            a = 0;
            b = 0;
            j = 1;
            if (flag) {
                i = 0;
            } else {
                i = 1;
            }

            while (op1) {
                a++;
                b += (j - i);
                i += 2;
                if (i%2 == 0) {
                    j += 2;
                } else {
                    j++;
                }
            }
            if (flag) {
                __VERIFIER_assert(a == b);
            }
        }

        public static void gcnr2008_false(bool op1,bool op2,bool op3)
        {

            int x,y,z,w;
            x = y = z = w = 0;
            while (op1 && y < 10000) {
                if (op2) {
                    x = x + 1;
                    y = y + 100;
                } else if (op3) {
                    if (x >= 4) {
                        x = x + 1;
                        y = y + 1;
                    }
                } else if (y > 10*w && z >= 100*x) {
                    y = -y;
                }
                w = w + 1;
                z = z + 10;
            }
            __VERIFIER_assert(x >= 4 && y <= 2);
        }

        public static void gj2007_true()
        {

            int x = 0;
            int y = 50;
            while(x < 100) {
                if (x < 50) {
                    x = x + 1;
                } else {
                    x = x + 1;
                    y = y + 1;
                }
            }
            __VERIFIER_assert(y == 100);
        }

        public static void gj2007b_true(int n,bool op2)
        {

            int x = 0;
            int m = 0;
            while(x < n) {
                if(op2) {
                    m = x;
                }
                x = x + 1;
            }
            __VERIFIER_assert((m >= 0 || n <= 0));
            __VERIFIER_assert((m < n || n <= 0));
        }

        public static void gr2006_true()
        {
            int x,y;
            x = 0;
            y = 0;
            while (true) {
                if (x < 50) {
                    y++;
                } else {
                    y--;
                }
                if (y < 0) break;
                x++;
            }
            __VERIFIER_assert(x == 100);
        }

        public static void gsv2008_true(int y)
        {

            int x;
            x = -50;
            int LARGE_INT = Int32.MaxValue;
            if (!(-1000 < y && y < LARGE_INT)) return ;
            while (x < 0) {
                x = x + y;
                y++;
            }
            __VERIFIER_assert(y > 0);
        }

        public static void hhk2008_true(int a, int b)
        {
            int res, cnt;
            if (!(a <= 1000000)) return;
            if (!(0 <= b && b <= 1000000)) return;
            res = a;
            cnt = b;
            while (cnt > 0) {
                cnt = cnt - 1;
                res = res + 1;
            }
            __VERIFIER_assert(res == a + b);
        }

        public static void jm2006_true(int i, int j)
        {
            if (!(i >= 0 && j >= 0)) return;
            int x = i;
            int y = j;
            while(x != 0) {
                x--;
                y--;
            }

            if (i == j) {
                __VERIFIER_assert(y == 0);
            }
        }

        public static void jm2006_variant_true(int i, int j)
        {

            int LARGE_INT = Int32.MaxValue;
            if (!(i >= 0 && i <= LARGE_INT)) return;
            if (!(j >= 0)) return;
            int x = i;
            int y = j;
            int z = 0;
            while(x != 0) {
                x --;
                y -= 2;
                z ++;
            }
            if (i == j) {
                __VERIFIER_assert(y == -z);
            }
        }

        public static void mcmillan2006_true(int n)
        {

            if (!(0 <= n && n <= 1000)) return;
            int[] x = new int[n];
            for (int i = 0; i < n; i++) x[i] = 0;
            for (int i = 0; i < n; i++) __VERIFIER_assert(x[i] == 0);
        }

        public static void array_false(int[] array,uint SIZE, int menor)
        {

            uint j,k;
            Random r = new Random();

            for(j=0;j<SIZE;j++)
            {
                array[j] = r.Next();

                if(array[j]<=menor)
                    menor = array[j];
            }

            __VERIFIER_assert(array[0]>menor);
        }



        public static void array_truee(int[] array,uint SIZE, int menor)
        {

            uint j,k;
            Random r = new Random();

            for(j=0;j<SIZE;j++)
            {
                array[j] = r.Next();

                if(array[j]<=menor)
                    menor = array[j];
            }

            __VERIFIER_assert(array[0]>=menor);
        }

        public static void  bubblesort(int size, int[] item)
        {
            int a, b, t;

            for(a = 1; a < size; ++a)
            {
                for(b = size-1; b >= a; --b)
                {

                    if (b-1 < size && b < size)
                    {
                        if(item[ b - 1] > item[ b ])
                        {
                            t = item[ b - 1];
                            item[ b - 1] = item[ b ];
                            item[ b ] = t;
                        }
                    }
                }
            }
        }

        public static void  bubblesort1(int size, int[] item)
        {
            int j, i, pivot;

            for(j = 1; j < size; ++j)
            {
                pivot = item[j];
                i = j - 1;

                while(i >= 0 && item[i] > pivot)
                {
                    item[i+1] = item[i];
                    i--;
                }
                item[i+1] = pivot;
            }
        }

        public static void q1(int N)
        {
            if (N < 2) return;

            int[] a = new int[N];
            int i;

            Random rand = new Random();

            for(i=0; i < N; ++i) a[i] = i;

            for (i=0; i<N; i++) {
                int r = i + (rand.Next() % (N-i));
                int temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }



            bubblesort(N, a);



            for (i = 0; i < N - 1; i++)
            {
                __VERIFIER_assert(a[i] <= a[i+1]);
            }
        }

        public static void q2(int N)
        {
            if (N < 2) return;

            int[] a = new int[N];
            int i;

            Random rand = new Random();

            for(i=0; i < N; ++i) a[i] = i;

            for (i=0; i<N; i++) {
                int r = i + (rand.Next() % (N-i));
                int temp = a[i];
                a[i] = a[r];
                a[r] = temp;
            }



            bubblesort1(N, a);



            for (i = 0; i < N - 1; i++)
            {
                __VERIFIER_assert(a[i] <= a[i+1]);
            }
        }

        public static void count_up_down_false(uint n)
        {
            uint x=n, y=0;
            while(x>0)
            {
                x--;
                y++;
            }
            __VERIFIER_assert(y!=n);
        }

        public static void count_up_down_true(uint n)
        {
            uint x=n, y=0;
            while(x>0)
            {
                x--;
                y++;
            }
            __VERIFIER_assert(y==n);
        }

        public static void eureka_01_false(int nodecount, int edgecount)
        {

            int INFINITY = 899;
            if (!(0 <= nodecount && nodecount <= 4)) return;
            if (!(0 <= edgecount && edgecount <= 19)) return;
            int source = 0;
            int[] Source  = {0,4,1,1,0,0,1,3,4,4,2,2,3,0,0,3,1,2,2,3};
            int[] Dest = {1,3,4,1,1,4,3,4,3,0,0,0,0,2,3,0,2,1,0,4};
            int[] Weight = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};
            int[] distance = new int[5];
            int x,y;
            int i,j;

            for(i = 0; i < nodecount; i++){
                if(i == source){
                    distance[i] = 0;
                }
                else {
                    distance[i] = INFINITY;
                }
            }

            for(i = 0; i < nodecount; i++)
            {
                for(j = 0; j < edgecount; j++)
                {
                    x = Dest[j];
                    y = Source[j];
                    if(distance[x] > distance[y] + Weight[j])
                    {
                        distance[x] = -1;
                    }
                }
            }
            for(i = 0; i < edgecount; i++)
            {
                x = Dest[i];
                y = Source[i];
                if(distance[x] > distance[y] + Weight[i])
                {
                    return;
                }
            }

            for(i = 0; i < nodecount; i++)
            {
                __VERIFIER_assert(distance[i]>=0);
            }
        }

        public static void eureka_01_true()
        {

            int INFINITY = 899;
            int nodecount = 5;
            int edgecount = 20;
            int source = 0;
            int[] Source = {0,4,1,1,0,0,1,3,4,4,2,2,3,0,0,3,1,2,2,3};
            int[] Dest = {1,3,4,1,1,4,3,4,3,0,0,0,0,2,3,0,2,1,0,4};
            int[] Weight = {0,1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19};
            int[] distance = new int[5];
            int x,y;
            int i,j;

            for(i = 0; i < nodecount; i++){
                if(i == source){
                    distance[i] = 0;
                }
                else {
                    distance[i] = INFINITY;
                }
            }

            for(i = 0; i < nodecount; i++)
            {
                for(j = 0; j < edgecount; j++)
                {
                    x = Dest[j];
                    y = Source[j];
                    if(distance[x] > distance[y] + Weight[j])
                    {
                        distance[x] = distance[y] + Weight[j];
                    }
                }
            }
            for(i = 0; i < edgecount; i++)
            {
                x = Dest[i];
                y = Source[i];
                if(distance[x] > distance[y] + Weight[i])
                {
                    return;
                }
            }

            for(i = 0; i < nodecount; i++)
            {
                __VERIFIER_assert(distance[i]>=0);
            }
        }

        public static void SelectionSort(int[] array, int n)
        {
            int lh, rh, i, temp;

            for (lh = 0; lh < n; lh++) {
                rh = lh;
                for (i = lh + 1; i < n; i++)
                    if (array[i] < array[rh]) rh = i;
                temp = array[lh];
                array[lh] = array[rh];
                array[rh] = temp;
            }
        }

        public static void eureka_05_true(int[] array, int SIZE)
        {
            int i;

            for(i=SIZE-1; i>=0; i--)
                array[i]=i;

            SelectionSort(array, SIZE);

            for(i=0; i<SIZE; i++)
                __VERIFIER_assert(array[i]==i);
        }

        public static void for_infinite_loop_1_true(int n)
        {
            uint i=0;
            int x=0, y=0;
            if (!(n>0)) return;
            for(i=0; true; i++)
            {
                __VERIFIER_assert(x==0);
            }
            __VERIFIER_assert(x==0);
        }

        public static void for_infinite_loop_2_true(int n)
        {
            uint i=0;
            int x=0, y=0;
            if (!(n>0)) return;
            for(i=0; true; i++)
            {
                __VERIFIER_assert(x==0);
            }
            __VERIFIER_assert(x!=0);
        }

        public static void insertion_sort_false(uint SIZE,int[] v)
        {
            int i, j, k, key;
            for (j=1;j<SIZE;j++) {
                key = v[j];
                i = j - 1;
                while((i>=0) && (v[i]>key)) {
                    if (i<2)
                        v[i+1] = v[i];
                    i = i - 1;
                }
                v[i+1] = key;
            }

            for (k=1;k<SIZE;k++)
                __VERIFIER_assert(v[k-1]<=v[k]);
        }

        public static void insertion_sort_true(uint SIZE,int[] v)
        {

            int i, j, k, key;
            for (j=1;j<SIZE;j++) {
                key = v[j];
                i = j - 1;
                while((i>=0) && (v[i]>key)) {
                    v[i+1] = v[i];
                    i = i - 1;
                }
                v[i+1] = key;
            }
            for (k=1;k<SIZE;k++)
                __VERIFIER_assert(v[k-1]<=v[k]);
        }

        public static void invert_string_false(int MAX, char[] str1, char[] str2)
        {
            int cont, i, j = 0;
            cont = 0;
    
            for (i = MAX - 1; i >= 0; i--) {
                str2[j] = str1[0];
                j++;
            }

            j = MAX-1;
            for (i=0; i<MAX; i++) {
                __VERIFIER_assert(str1[i] == str2[j]);
                j--;
            }
        }
        
        public static bool linear_search(int[] a, int n, int q) {
            uint j=0;
            while (j<n && a[j]!=q) {
                j++;
            }
            return (j < n);
        }


        public static void linear_search_false(int[]a, int SIZE)
        {
            a[SIZE/2]=3;
            __VERIFIER_assert(linear_search(a,SIZE,3));
        }

        public static void matrix_false(int[][] matriz, int N_LIN, int N_COL)
        {
            uint j,k;
            int maior;
  
            maior = int.MaxValue;
            for(j=0;j<N_COL;j++)
            for(k=0;k<N_LIN;k++)
            {       
       
                if(matriz[j][k]>maior)
                    maior = matriz[j][k];                          
            }                       
    
            for(j=0;j<N_COL;j++)
            for(k=0;k<N_LIN;k++)
                __VERIFIER_assert(matriz[j][k]<maior);   
        }

        public static void matrix_true(int[][] matriz, int N_LIN, int N_COL)
        {
            uint j,k;
            int maior;
  
            maior = int.MaxValue;
            for(j=0;j<N_COL;j++)
            for(k=0;k<N_LIN;k++)
            {       
       
                if(matriz[j][k]>maior)
                    maior = matriz[j][k];                          
            }                       
    
            for(j=0;j<N_COL;j++)
            for(k=0;k<N_LIN;k++)
                __VERIFIER_assert(matriz[j][k]<maior);   
        }

        public static void c40_true(int[] x,int[] y,int SIZE, int k)
        {
  
            int i = 0;
            while(x[i] != 0){
                y[i] = x[i];
                i++;
            }
            
            y[i] = 0;
  
            if(k >= 0 && k < i)
                __VERIFIER_assert(y[k] != 0);
        }
        
        public static int a = 2;

        public static void sum01_bug02_false(int n)
        {
            int i, j=10, sn=0;
            for(i=1; i<=n; i++) {
                if (i<j) 
                    sn = sn + a;
                j--;
            }
            __VERIFIER_assert(sn==n*a || sn == 0);
        }

        public static void sum01_bug02_sum01_bug02_base(int n)
        {
            
            int i, sn=0;
            for(i=1; i<=n; i++) {
                sn = sn + a;
                if (i==4) sn=-10;
            }
            __VERIFIER_assert(sn==n*a || sn == 0);
        }

        public static void sum04_true(int SIZE)
        {
            int i, sn=0;
            for(i=1; i<=SIZE; i++) {
                sn = sn + a;
            }
            __VERIFIER_assert(sn==SIZE*a || sn == 0);
        }

        public static void sum_array_true(int[] A, int[]B, int M)
        {
            int[] C = new int[M];
            uint  i;
  
            for(i=0;i<M;i++)
                C[i]=A[i]+B[i];
  
            for(i=0;i<M;i++)
                __VERIFIER_assert(C[i]==A[i]+B[i]);
        }

        public static void terminator_03_false(int x, int y)
        {
            if (y>0)
            {
                while(x<100) 
                {
                    x=x+y;
                }
            }                           
            __VERIFIER_assert(y<=0 || (y<0 && x>=100));     
        }

        public static int x;

        public static void foo() {
            x--;
        }
        
        public static void trex02_false(int x1, bool c)
        {
            x = x1;
            while (x > 0) {
                if(c) foo();
                else foo();
            }
            __VERIFIER_assert(x==0);
        }
        

        public static void while_infinite_loop_1_true()
        {
            
            int x=0;

            while(true)
            {
                __VERIFIER_assert(x==0);    
            }

            __VERIFIER_assert(x!=0);
        }


        public  static  void eval() 
        {
            while (true) {
                x=0;
                break;
            }
        }


        public  static  void  while_infinite_loop_3_true()
        {

            x = 1;
            while(true)
            {
                eval();
                __VERIFIER_assert(x==0);    
            }

            __VERIFIER_assert(x!=0);

        }
        
//        public static void ()
//        {
//        }

        public static void Main(string[] args)
        {
        }
    }
}