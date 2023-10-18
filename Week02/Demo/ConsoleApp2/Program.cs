using System.Collections;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //// Nguyên thủy - value
            //var start = 1; // ==> boxing
            //var end = 10;
            //var sum = 0; // j

            //// if, for, do, while
            //sum = calcSum(start, end);

            //Console.WriteLine($"Tong tu {start} den {end} la:{sum}");


            //var message = start.ToString() + " $";

            //var a = new int[4];

            //try
            //{
            //    a[0] = 1;
            //    a[1] = 2;
            //    a[2] = 3;
            //    a[3] = 4;
            //    //a[4] = 1;
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Cannot operate: reason {ex.Message}");
            //    // Log / Debug
            //}

            //var primes = new int[] { 2, 3, 5, 7, 11, 13 };
            //int[] squares = { 4, 9, 16, 25 };

            //string[] colors = { "red", "green", "blue" , "magenta", "yellow", "white"};
            //var line = new string[] // new Collection / new Arraylist
            //{
            //    "straight", "curved", "foldable"
            //};

            //var rng = new Random(); // random number generator / dob = date of birth / gpa= 
            //int i = rng.Next();
            //int limit = rng.Next(100);
            //int range = rng.Next(20, 50);

            //int index = rng.Next(colors.Length);
            //string selectedColor = colors[index];


            // string interpolation
            //for(int i = 0; i < a.Length; i++)
            //{
            //    Console.Write($"{a[i]} ");
            // swift kotlin flutter js

            // generic - List<int> / List<string> / List<Student> / List<double>
            // List / ArrayList (object)
            var a = new List<int>(); // DynamicArray<int>
            var b = new ArrayList(); // object

            var count = 10;
            var numberGen = new Random();
            var maximum = 100; // const int Maximum = 100;

            for (int i = 0; i < count; i++)
            {
                int number = numberGen.Next(maximum);
                a.Add(number);
            }

            foreach(var number in a)
            {
                Console.Write($"{number} ");
            }

            //** Tìm sub array các số lẻ **
            #region Tìm mảng con các số lẻ
            var odds = new List<int>(); // BindingList / ObservableCollection

            foreach (var number in a)
            {
                if (number % 2 == 1)
                {
                    odds.Add(number);
                }
            }
            #endregion
            Console.WriteLine();


            //int data = 10 / 0;
            //Console.WriteLine(data); // 1

            double ratio = 10.0f / 0;
            Console.WriteLine(ratio); // 2 infinity

            int zero = 0;


            // Nếu có quyền nói - nói
            // Không có thì la 
            //try
            //{
            //    Console.WriteLine(10 / zero); // 3
            //}
            //catch (Exception ex)
            //{
            //    //Console.WriteLine($"Cannot divide. reason: {ex.Message}");
            //    throw;
            //}


            //Console.WriteLine(10.0f / zero); // 4

            //int  vnd = 0;
            //int? sgd = 0; // database
            ////int money = ()!;

            //int amount = sgd ?? 0;
            //string message = sgd != null ? 
            //    $"Avail: {sgd}" : "Cannot do anything";

            //if (sgd == null)
            //{
            //    message = "Cannot do anything";
            //}
            //// "Lý", "", "Quang", "", "", "Đính"
             
            //string fullname = "Lý Quang Đính";
            //const string Space = " ";

            //// Tokenizer
            //var tokens = fullname.Split(new string[] { Space }, 
            //    StringSplitOptions.RemoveEmptyEntries);
            //string first = tokens[0];
            //string middle = tokens[1];
            //string last = tokens[2];

            //Console.WriteLine($"{first} - {middle} - {last}");

            //// "Lý Quang Đính"
            //int index = fullname.IndexOf(" ");
            //int lastIndex = fullname.LastIndexOf(" ");
            //string name = fullname.Substring(lastIndex + 1,
            //    fullname.Length - lastIndex - 1); // 13-8-1

            //var vector = new Tuple<int, int>(1, 2);
            //var result = new Tuple<bool, string, int>(
            //    true, "Success", 7);


            // Auto destructruring
            var (success, message) = check(100);

            if (success == true) {

            }

            string path = @"C:\Windows\Dev\data.rar";

            var (folder, filename, extension) = Extract(path);

            string info = "";

            // StringExtension.IsEmpty(info) ==> extension method
            if (info.IsEmpty()) // Check if string is empty
            {
                Console.WriteLine("Chuoi rong");
            }

        }

        private static Tuple<string, string, string> Extract(string path)
        {
            //int lastSlashIndex = path.LastIndexOf(@"\");
            //string folder = path.Substring(0, lastSlashIndex);

            //string fullFilename = path.Substring(lastSlashIndex + 1,
            //    path.Length - lastSlashIndex - 1);
            //var tokens = fullFilename.Split(new string[] { "."}, 
            //    StringSplitOptions.RemoveEmptyEntries);
            //string filename = tokens[0];
            //string extension = tokens[1];
            var info = new FileInfo(path);
            var folder = info.DirectoryName!;
            var filename = info.Name;
            var extension = info.Extension;

            return new Tuple<string, string, string>(folder, filename, extension);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Item1: Success, Item2: Message</returns>
        static Tuple<bool, string> check(int number)
        {
            bool success = true;
            string message = "";
            if (number == 0)            {
                success = true;
                message = "Success";
            } else            {
                success = false;
                message = "Failed";
            }
            var result = new Tuple<bool, string>(success, message);
            return result;
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

            return result == true;
        }

        bool isEven(int number)
        {
            return number % 2 == 0;
        }

        // Tổng kết
        // 1. Tránh ngắt chương trình đột ngột - viết unit test
        // 2. Kết quả của hàm nên dồn vào một biến - debug


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