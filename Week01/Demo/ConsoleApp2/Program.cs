using System.Security.Cryptography;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Nguyên thủy - value
            var start = 1; // ==> boxing
            var end = 10;
            var sum = 0; // j

            // if, for, do, while
            sum = calcSum(start, end);

            Console.WriteLine($"Tong tu {start} den {end} la:{sum}");
                

            var message = start.ToString() + " $";

            var a = new int[4];

            try
            {
                a[0] = 1;
                a[1] = 2;
                a[2] = 3;
                a[3] = 4;
                //a[4] = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Cannot operate: reason {ex.Message}");
                // Log / Debug
            }

            var primes = new int[] { 2, 3, 5, 7, 11, 13 };
            int[] squares = { 4, 9, 16, 25 };

            string[] colors = { "red", "green", "blue" , "magenta", "yellow", "white"};
            var line = new string[] // new Collection / new Arraylist
            {
                "straight", "curved", "foldable"
            };

            var rng = new Random(); // random number generator / dob = date of birth / gpa= 
            int i = rng.Next();
            int limit = rng.Next(100);
            int range = rng.Next(20, 50);

            int index = rng.Next(colors.Length);
            string selectedColor = colors[index];


            // string interpolation
            //for(int i = 0; i < a.Length; i++)
            //{
            //    Console.Write($"{a[i]} ");
            //}
        }

        /// <summary>
        /// Kiểm tra một số có phải số nguyên tố hay không
        /// </summary>
        /// <param name="number">Số cần kiểm tra (>2)</param>
        /// <returns>Kết quả kiểm tra</returns>
        static bool IsPrime(int number) // checkPrime
        {
            bool result = true;

            if (number < 2)
            {
                result = false;
            } else
            {
                    
            }

            return result;
        }

        // hasAllOddDigits - isAllOddDigits
        bool isAllOddDigits(int number)
        {
            bool result = true; // goto

            // Đọc dễ hiểu
            // Dễ debug
            while (number > 0)
            {
                int digit = number % 10;
                if (digit % 2 == 0)
                {
                    result = false;
                    break;
                }
                number /= 10;
            }

            return result;
        }

        /// <summary>
        /// Tính tổng dãy số
        /// </summary>
        /// <param name="start">Số bắt đầu</param>
        /// <param name="end">Số kết thúc</param>
        /// <returns></returns>
        private static int calcSum(int start, int end)
        {
            int sum = 0;

            for (int i = start; i <= end; i++)
            {
                sum += i;
            }

            return sum;
        }

    }
}