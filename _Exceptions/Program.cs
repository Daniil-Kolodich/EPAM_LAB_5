using _NSMatrix;
using _NSUserException;
using System;
namespace _Exceptions {

    class Program {
        static void Main(string[] args) {
            Random rand = new Random();
            Matrix A = null;
            Matrix B = null;
            int choice;
            while (true) {
                Console.WriteLine("0. Show info");
                Console.WriteLine("1. Reset matrix A");
                Console.WriteLine("2. Reset matrix B");
                Console.WriteLine("3. Sum of A & B");
                Console.WriteLine("4. Sub of А & B");
                Console.WriteLine("5. Sub of В & А");
                Console.WriteLine("6. Mult of А & B");
                Console.WriteLine("7. Mult of В & А");
                Console.WriteLine("8. Mult of A & int");
                Console.WriteLine("9. Mult of B & int");
                Console.WriteLine("10. Выход");
                CheckInputForInt(out choice, "Введите желаемую операцию : ");
                if (choice == 0) {
                    if (A is null || B is null) {
                        Console.WriteLine("Enter value of Matrix A & B first");
                        continue;
                    }
                    Console.Clear();
                    A.Info("first matrix");
                    B.Info("second matrix");
                }
                else if (choice == 1)
                    A = GetMatrix(ref rand, "first matrix");
                else if (choice == 2)
                    B = GetMatrix(ref rand, "second matrix");
                else if (choice == 10)
                    break;
                else if (A is null || B is null) {
                    Console.WriteLine("Enter value of Matrix A & B first");
                    continue;
                }
                else {
                    try {
                        Matrix result = choice switch {
                            3 => A + B,
                            4 => A - B,
                            5 => B - A,
                            6 => A * B,
                            7 => B * A,
                            8 => A * GetMultValue(),
                            9 => B * GetMultValue(),
                            _ => throw new ArgumentOutOfRangeException(),
                        };
                        result.Info("result matrix");
                    }
                    catch (UserException ex) {
                        Console.WriteLine(ex.Message);
                    }
                    catch (ArgumentOutOfRangeException) {
                        Console.WriteLine("invalid choice, try again");
                    }
                }
            }
        }
        public static double GetMultValue() {
            double tmp;
            while (true) {
                try {
                    Console.WriteLine("Enter multiplicator");
                    tmp = double.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException) {
                    Console.WriteLine("Wrong input\n");
                }
            }
            return tmp;
        }
        public static Matrix GetMatrix(ref Random rand, string message = "tmp matrix", int maxNum = 15) {
            while (true) {
                int heigth, width;
                CheckInputForInt(out heigth, $"Enter height for {message} :");
                CheckInputForInt(out width, $"Enter width for {message} :");
                try {
                    if (heigth <= 0 || width <= 0)
                        throw new ArgumentOutOfRangeException();
                    double[,] data = new double[heigth, width];
                    for (int i = 0; i < heigth; i++)
                        for (int j = 0; j < width; j++)
                            data[i, j] = rand.NextDouble() * rand.Next(0, maxNum) + 1;
                    return new Matrix(heigth, width, data);
                }
                catch (ArgumentOutOfRangeException) {
                    Console.WriteLine("Wrong sizes of matrix, try again");
                }
            }
        }
        public static void CheckInputForInt(out int num, string message) {
            while (true) {
                try {
                    Console.WriteLine(message);
                    num = int.Parse(Console.ReadLine());
                    break;
                }
                catch (FormatException) {
                    Console.WriteLine("Wrong input\n");
                }
            }
        }
    }
}
