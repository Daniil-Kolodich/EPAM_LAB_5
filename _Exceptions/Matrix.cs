using _NSUserException;
using System;

namespace _NSMatrix {
    class Matrix {
        private double[,] data;
        private int width;
        public int Width {
            get {
                return width;
            }
            private set {
                width = value;
            }
        }
        private int height;
        public int Heigth {
            get {
                return height;
            }
            private set {
                height = value;
            }
        }
        public Matrix(int height, int width, double[,] data) {
            Width = width;
            Heigth = height;
            this.data = data;
        }
        public void Info(string message = "matrix") {
            Console.WriteLine($"Info for {message} : ");
            Console.WriteLine($"\tHeight = {height} , width = {width}");
            Console.Write("\tMatrix : \n\t");
            for (int i = 0; i < Heigth; Console.Write("\n\t"), i++)
                for (int j = 0; j < Width; j++)
                    Console.Write($"{this[i, j],-10:0.00}");
            Console.WriteLine();
        }
        public double this[int i, int j] {
            get {
                return data[i, j];
            }
            private set {
                data[i, j] = value;
            }
        }
        public static Matrix GetEmpty(int height, int width) {
            return new Matrix(height, width, new double[height, width]);
        }
        public static Matrix operator *(Matrix obj, double mult) {
            double[,] data = new double[obj.Heigth, obj.Width];
            for (int i = 0; i < obj.Heigth; i++)
                for (int j = 0; j < obj.Width; j++)
                    data[i, j] = obj[i, j] * mult;
            return new Matrix(obj.Heigth, obj.Width, data);
        }
        public static Matrix operator *(Matrix obj1, Matrix obj2) {
            if (obj1.Width != obj2.Heigth)
                throw new UserException($"Invalid sizes for multiplication\n" +
                                        $"First matrix size [{obj1.Heigth} , {obj1.Width}]\n" +
                                        $"Second matrix size [{obj2.Heigth} , {obj2.Width}]");
            double[,] data = new double[obj1.Heigth, obj2.Width];
            int length = obj1.Width;
            for (int i = 0; i < obj1.Heigth; i++)
                for (int j = 0; j < obj2.Width; j++)
                    for (int k = 0; k < length; k++) {
                        data[i, j] += obj1[i, k] * obj2[k, j];
                    }
            return new Matrix(obj1.Heigth, obj2.Width, data);
        }
        public static Matrix operator +(Matrix obj1, Matrix obj2) {
            if (obj1.Heigth != obj2.Heigth || obj1.Width != obj2.Width)
                throw new UserException($"Invalid sizes for addition\n" +
                                        $"First matrix size [{obj1.Heigth} , {obj1.Width}]\n" +
                                        $"Second matrix size [{obj2.Heigth} , {obj2.Width}]");
            double[,] data = new double[obj1.Heigth, obj1.Width];
            for (int i = 0; i < obj1.Heigth; i++)
                for (int j = 0; j < obj2.Width; j++)
                    data[i, j] = obj1[i, j] + obj2[i, j];
            return new Matrix(obj1.Heigth, obj2.Width, data);
        }
        public static Matrix operator -(Matrix obj1, Matrix obj2) {
            if (obj1.Heigth != obj2.Heigth || obj1.Width != obj2.Width)
                throw new UserException($"Invalid sizes for subtraction\n" +
                           $"First matrix size [{obj1.Heigth} , {obj1.Width}]\n" +
                           $"Second matrix size [{obj2.Heigth} , {obj2.Width}]");

            double[,] data = new double[obj1.Heigth, obj1.Width];
            for (int i = 0; i < obj1.Heigth; i++)
                for (int j = 0; j < obj2.Width; j++)
                    data[i, j] = obj1[i, j] - obj2[i, j];
            return new Matrix(obj1.Heigth, obj2.Width, data);
        }
    }
}
