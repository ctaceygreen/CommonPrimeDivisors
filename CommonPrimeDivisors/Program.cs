using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Solution
    {
        public int solution(int[] A, int[] B)
        {
            // write your code in C# 6.0 with .NET 4.5 (Mono)

            //Find out if A and B share the same set of prime divisors
            int totalPairsWithSamePrimeDivisors = 0;
            for(int i = 0; i < A.Length; i++)
            {
                int a = A[i];
                int b = B[i];
                if(HasSamePrimeDivisors(a,b))
                {
                    totalPairsWithSamePrimeDivisors++;
                }
            }
            return totalPairsWithSamePrimeDivisors;

        }
        public bool HasSamePrimeDivisors(long a, long b)
        {
            long gcd = GreatestCommonDivisior(a, b); // This gcd contains all prime divisors

            long remainingDivisorA = RemoveCommonPrimeDivisors(a, gcd);

            long remainingDivisorB = RemoveCommonPrimeDivisors(b, gcd);

            if(remainingDivisorA == 1 && remainingDivisorB == 1)
            {
                return true;
            }
            return false;

        }

        private long RemoveCommonPrimeDivisors(long a, long gcd)
        {
            while (a != 1)
            {
                long newGcd = GreatestCommonDivisior(a, gcd);
                if (newGcd == 1)
                    break;
                a /= newGcd;
            }
            return a;
        }

        public long GreatestCommonDivisior(long a, long b)
        {
            return GreatestCommonDivisior(a, b, 1);
        }
        public long GreatestCommonDivisior(long a, long b, long res)
        {
            if (a == b)
                return res * a;
            else if ((a % 2 == 0) && (b % 2 == 0))
                return GreatestCommonDivisior(a / 2, b / 2, 2 * res);
            else if (a % 2 == 0)
                return GreatestCommonDivisior(a / 2, b, res);
            else if (b % 2 == 0)
                return GreatestCommonDivisior(a, b / 2, res);
            else if (a > b)
                return GreatestCommonDivisior(a - b, b, res);
            else
                return GreatestCommonDivisior(a, b - a, res);
        }
    }

