using System;
using System.Collections.Generic;
using System.Linq;
using Recursion;

namespace Recursion
{
    internal class BenchmarkException : Exception
    {
        public BenchmarkException()
        {
        }
    }

    internal class RecursionBenchmark
    {
        private static bool Int2bool(int i)
        {
            return i != 0;
        }

        private static int[] RandomInit(int size, int min, int max)
        {
            Random randNum = new Random();
            return Enumerable
                .Repeat(0, size)
                .Select(i => randNum.Next(min, max))
                .ToArray();
        }

        private static void __VERIFIER_assert(bool cond)
        {
            if (!cond)
            {
                throw new BenchmarkException();
            }
        }

        public static void f(int n) {
            if (n<3) return;
            n--;
            f2(n);
        }

        public static void f2(int n) {
            if (n<3) return;
            n--;
            f(n);
        }

        public static void f0(int n) {
            if (n<3) return;
            n--;
            f0(n);
        }

        public static void termination0()
        {
            f(4);
        }

        public static void termination01()
        {
            f(2);
        }

        public static void termination1()
        {
            f(2);
        }

        public static void termination2()
        {
            f(4);
        }

        public static int fibo(int n)
        {
            if (n < 1) {
                return 0;
            }
            if (n == 1) {
                return 1;
            }
            return fibo(n-1) + fibo(n-2);
        }

        public static void checkFibo()
        {
            int x = 10;
            int result = fibo(x);
            __VERIFIER_assert(result == 55);
        }

        public static void checkFibo1()
        {
            int x = 10;
            int result = fibo(x);
            __VERIFIER_assert(result != 55);
        }

        public static void checkFibo2()
        {
            int x = 15;
            int result = fibo(x);
            __VERIFIER_assert(result == 610);
        }

        public static void checkFibo3()
        {
            int x = 15;
            int result = fibo(x);
            __VERIFIER_assert(result != 610);
        }

        public static void checkFibo4()
        {
            int x = 20;
            int result = fibo(x);
            __VERIFIER_assert(result == 6765);
            x = 25;
            result = fibo(x);
            __VERIFIER_assert(result == 75025);
        }

        public static void checkFibo5()
        {
            int x = 20;
            int result = fibo(x);
            __VERIFIER_assert(result != 6765);
            x = 25;
            result = fibo(x);
            __VERIFIER_assert(result != 75025);
        }

        public static int fibo1(int n) {
            if (n < 1) {
                return 0;
            } else if (n == 1) {
                return 1;
            } else {
                return fibo2(n-1) + fibo2(n-2);
            }
        }

        public static int fibo2(int n) {
            if (n < 1) {
                return 0;
            } else if (n == 1) {
                return 1;
            } else {
                return fibo1(n-1) + fibo1(n-2);
            }
        }

        public static void checkFibo6()
        {
            int x = 25;
            int result = fibo1(x);
            __VERIFIER_assert(result != 75025);
        }

        public static int id(int x) {
            if (x==0) return 0;
            int ret = id2(x-1) + 1;
            if (ret > 2) return 2;
            return ret;
        }

        public static int id2(int x) {
            if (x==0) return 0;
            int ret = id(x-1) + 1;
            if (ret > 2) return 2;
            return ret;
        }

        public static int id_1(int x) {
            if (x==0) return 0;
            int ret = id2(x-1) + 1;
            if (ret > 3) return 3;
            return ret;
        }

        public static int id2_1(int x) {
            if (x==0) return 0;
            int ret = id(x-1) + 1;
            if (ret > 3) return 3;
            return ret;
        }

        public static void checkId(int input)
        {
            int result = id(input);
            __VERIFIER_assert(result == 3);
        }

        public static void checkId_1(int input)
        {
            int result = id_1(input);
            __VERIFIER_assert(result == 2);
        }


        public static int sum(int n, int m) {
            if (n <= 0) {
                return m + n;
            } else {
                return sum(n - 1, m + 1);
            }
        }

        public static void checkSum_1()
        {
            int a = 30;
            int b = 0;
            int result = sum(a, b);
            __VERIFIER_assert(result == a + b) ;
        }

        public static void checkSum_2(int a, int b)
        {
            int result = sum(a, b);
            __VERIFIER_assert(result == a + b) ;
        }


        public static int ackermann(int m, int n) {
            if (m==0) {
                return n+1;
            }

            if (n==0) {
                return ackermann(m-1,1);
            }
            return ackermann(m-1,ackermann(m,n-1));
        }

        public static void Ackermann01_true(int n, int m)
        {
            if (m < 0 || m > 3) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return;
            }
            if (n < 0 || n > 23) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                //
                return;
            }
            int result = ackermann(m,n);
            __VERIFIER_assert(m < 0 || n < 0 || result >= 0);
        }

        public static void Ackermann02_false(int n, int m)
        {
            if (m < 0 || m > 3) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return;
            }
            if (n < 0 || n > 23) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                //
                return;
            }
            int result = ackermann(m,n);
            __VERIFIER_assert(m < 2 || result >= 4);
        }

        public static void Ackermann03_true(int n, int m)
        {
            if (m < 0 || m > 3) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return;
            }
            if (n < 0 || n > 23) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                //
                return;
            }
            int result = ackermann(m,n);
            __VERIFIER_assert(m != 2 || n != 2 || result == 7);
        }

        public static void Ackermann04_true(int n, int m)
        {
            if (m < 0 || m > 3) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return;
            }
            if (n < 0 || n > 23) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                //
                return;
            }
            int result = ackermann(m,n);
            __VERIFIER_assert(m < 2 || n < 2 || result >= 7);
        }


        public static int addition(int m, int n) {
            if (n == 0) {
                return m;
            }
            if (n > 0) {
                return addition(m+1, n-1);
            }

            //n < 0
            return addition(m-1, n+1);
        }
        public static long addition2(int m, int n) {
            if (n == 0) {
                return m;
            }
            if (n > 0) {
                return addition(m+1, n-1);
            }

            //n < 0
            return addition(m-1, n+1);
        }

        public static void Addition01_true(int n, int m)
        {
            if (m < 0 || m > 1073741823) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return;
            }
            if (n < 0 || n > 1073741823) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return ;
            }
            int result = addition(m,n);
            __VERIFIER_assert(result == m + n);
        }

        public static void Addition02WithOverflowBug(int n, int m)
        {
            int result = addition(m,n);
            __VERIFIER_assert(result == m - n);
        }

        public static void Addition02_false(int n, int m)
        {
            if (m < 0 || m > 1073741823) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return;
            }
            if (n < 0 || n > 1073741823) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return;
            }
            int result = addition(m,n);
            __VERIFIER_assert(result == m - n);
        }

        public static void Addition03_false(int n, int m)
        {
            int result = addition(m,n);
            __VERIFIER_assert(m < 100 || n < 100 || result >= 200);
        }

        public static void Addition03_true(int n, int m)
        {
            long result = addition2(m,n);
            __VERIFIER_assert(m < 100 || n < 100 || result >= 200);
        }

        public static bool g;

        public static void A(bool a1, bool a2) {
            if (a1) {
                A(a2,a1);
            } else {
                g = a2;
            }
        }


        public static void BallRajamani(bool g1)
        {
            g = g1;
            bool h = !g;
            A(g,h);
            A(g,h);
            __VERIFIER_assert(g);
        }


        public static int isOdd(int n) {
            if (n == 0) {
                return 0;
            } else if (n == 1) {
                return 1;
            } else {
                return isEven(n - 1);
            }
        }

        public static int isEven(int n) {
            if (n == 0) {
                return 1;
            } else if (n == 1) {
                return 0;
            } else {
                return isOdd(n - 1);
            }
        }

        public static void EvenOdd01_true(int n)
        {
            if (n < 0) {
                return;
            }
            int result = isOdd(n);
            int mod = n % 2;
            __VERIFIER_assert(result < 0 || result == mod);
        }

        public static void EvenOdd03WithOverflowBug(int n)
        {
            int result = isEven(n);
            int mod = n % 2;
            __VERIFIER_assert(result < 0 || result == mod);
        }

        public static void EvenOdd03_false(int n)
        {
            if (n < 0) {
                return;
            }
            int result = isEven(n);
            int mod = n % 2;
            __VERIFIER_assert(result < 0 || result == mod);
        }

        public static int fibonacci(int n) {
            if (n < 1) {
                return 0;
            } else if (n == 1) {
                return 1;
            } else {
                return fibonacci(n-1) + fibonacci(n-2);
            }
        }

        public static void Fibonacci01_true(int x)
        {
            if (x > 46 || x == -2147483648) {
                return;
            }

            int result = fibonacci(x);
            __VERIFIER_assert(result >= x - 1);
        }

        public static void Fibonacci04_false(int x)
        {
            int result = fibonacci(x);
            __VERIFIER_assert(x < 8 || result >= 34);
        }

        public static int f91(int x) {
            if (x > 100)
                return x -10;
            else {
                return f91(f91(x+11));
            }
        }


        // Multiplies two integers n and m
        public static int mult(int n, int m) {
            if (m < 0) {
                return mult(n, -m);
            }
            if (m == 0) {
                return 0;
            }
            return n + mult(n, m - 1);
        }

        public static void McCarthy91_true(int x)
        {
            int result = f91(x);
            __VERIFIER_assert(result == 91 || x > 101 && result == x - 10);
        }

        public static void MultCommutative_true(int m, int n)
        {
            if (m < 0 || m > 46340) {
                return;
            }
            if (n < 0 || n > 46340) {
                return;
            }
            int res1 = mult(m, n);
            int res2 = mult(n, m);
            __VERIFIER_assert(res1 != res2 && m > 0 && n > 0);
        }


        // Is n a multiple of m?
        public static int multiple_of(int n, int m) {
            if (m < 0) {
                return multiple_of(n, -m);
            }
            if (n < 0) {
                return multiple_of(-n, m); // false
            }
            if (m == 0) {
                return 0; // false
            }
            if (n == 0) {
                return 1; // true
            }
            return multiple_of(n - m, m);
        }


        // Is n prime?
        public static int is_prime(int n) {
            return is_prime_(n, n - 1);
        }


        public static int is_prime_(int n, int m) {
            if (n <= 1) {
                return 0; // false
            }
            if (n == 2) {
                return 1; // true
            }

            if (n > 2) {
                if (m <= 1) {
                    return 1; // true
                }

                if (multiple_of(n, m) == 0) {
                    return 0; // false
                }
                return is_prime_(n, m - 1);
            }

            throw new ArgumentException();
        }


        public static void Primes_true(int n, int f1, int f2)
        {
            if (n < 1 || n > 46340) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return;
            }
            int result = is_prime(n);
            if (f1 < 1 || f1 > 46340) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return ;
            }
            if (f2 < 1 || f2 > 46340) {
                // additional branch to avoid undefined behavior
                // (because of signed integer overflow)
                return ;
            }

            __VERIFIER_assert(!(result == 1 && mult(f1, f2) == n && f1 > 1 && f2 > 1));
        }

        public static int gcd(int y1, int y2) {
            if (y1 <= 0 || y2 <= 0) {
                return 0;
            }
            if (y1 == y2) {
                return y1;
            }
            if (y1 > y2) {
                return gcd(y1 - y2, y2);
            }
            return gcd(y1, y2 - y1);
        }

        public static void gcd01_true(int m, int n)
        {
            if (m <= 0 || m > 2147483647) {
                return;
            }
            if (n <= 0 || n > 2147483647) {
                return ;
            }
            int z = gcd(m, n);
            __VERIFIER_assert(!(z < 1 && m > 0 && n > 0));
        }

        public static int gcd2(int y1, int y2) {
            if (y1 <= 0 || y2 <= 0) {
                throw new ArgumentException();
            }
            if (y1 == y2) {
                return y1;
            }
            if (y1 > y2) {
                return gcd(y1 - y2, y2);
            }
            return gcd(y1, y2 - y1);
        }

        // does n divide m?
        public static int divides(int n, int m) {
            if (m == 0) {
                return 1; // true
            }
            if (n > m) {
                return 0; // false
            }
            return divides(n, m - n);
        }

        public static void gcd02_true(int m, int n)
        {
            if (m <= 0 || m > 2147483647) {
                return;
            }
            if (n <= 0 || n > 2147483647) {
                return;
            }

            if (m <= 0 || n <= 0) return;
            int z = gcd(m, n);
            __VERIFIER_assert (divides(z, m) != 0);
        }


        public static int counter;
        /*
         * This function returns the optimal amount of steps,
         * needed to solve the problem for n-disks
         */
        public static int hanoi(int n) {
            if (n == 1) {
                return 1;
            }
            return 2 * (hanoi(n-1)) + 1;
        }

        public static void applyHanoi(int n, int from, int to, int via)
        {
            if (n == 0) {
                return;
            }
            // increment the number of steps
            counter++;
            applyHanoi(n-1, from, via, to);
            applyHanoi(n-1, via, to, from);
        }

        public static void recHanoi01_true(int n)
        {
            if (n < 1 || n > 31) {
                return;
            }
            counter = 0;
            applyHanoi(n, 1, 3, 2);
            int result = hanoi(n);
            // result and the counter should be the same!
            __VERIFIER_assert(result == counter);
        }

        public static void recHanoi02_true(int n)
        {
            if (n < 1 || n > 31) {
                return;
            }
            int result = hanoi(n);
            __VERIFIER_assert(result >= 0);
        }


        public static void Main(string[] args)
        {
            Console.Write("ololo");
        }
    }
}
