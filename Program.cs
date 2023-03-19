using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_18._03._2023
{
    class MyArray
    {
        private float[] A = new float[5];
        private float[,] B = new float[3, 4];
        private Random r = new Random();
        //public int a { get; set; }
        public MyArray()
        {
            Console.WriteLine("\n\tВведите значение элемента одномерного массива:");
            for (int i = 0; i < A.Length; i++)
            {
                Console.Write(" ");
                A[i] = float.Parse(Console.ReadLine()); ;
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    B[i, j] = (float)r.NextDouble() * 10;
                }
            }
        }

        public void ShowArr()
        {
            Console.Write("\n\tОдномерный массив: \n\t");
            foreach (var k in A)
            {
                Console.Write(k + "  ");
            }
            Console.WriteLine();
            Console.Write("\n\tДвумерный массив: \n\t");
            for (int i = 0; i < B.GetLength(0); i++)
            {
                Console.Write("\n\t");
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    Console.Write(B[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public float MaxEl()
        {
            float max = A[0];
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] > max)
                {
                    max = A[i];
                }
            }
            float maxB = B[0, 0];
            int maxARound = (int)max;
            float tmp = B[0, 0];
            for (int j = 0; j < B.GetLength(0); j++)
            {
                for (int i = 0; i < B.GetLength(1); i++)
                {
                    if (B[j, i] == max)
                    {
                        return max;
                    }
                    //Если абсолютно одинаковых значений нет, приводим к int и определяем максимально общее значение второго массива
                    else if ((int)(B[j, i]) == maxARound)
                    {
                        tmp = B[j, i];
                        if (tmp > B[j, i])
                        { maxB = B[j, i]; }
                        else
                            maxB = tmp;
                    }
                }
            }
            Console.WriteLine($"\n\tОбщих идентичных максимальных значений не найдено, " +
                            "\n\tно если округлить числа,максимально общими будут: " +
                            "\n\tдля массива А: {0}, для массива B: {1}, результат операции - большее значений из них.", max, maxB);
            if (max > maxB)
                return max;
            else
                return maxB;
        }

        public float MinEl()
        {
            float min = A[0];
            for (int i = 0; i < A.Length; i++)
            {
                if (A[i] < min)
                {
                    min = A[i];
                }
            }
            float minB = B[0, 0];
            int minARound = (int)min;
            float tmp = B[0, 0];
            for (int j = 0; j < B.GetLength(0); j++)
            {
                for (int i = 0; i < B.GetLength(1); i++)
                {
                    if (B[j, i] == min)
                    {
                        return min;
                    }
                    //Если абсолютно одинаковых значений нет, приводим к int и определяем минимальное общее значение второго массива
                    else if ((int)(B[j, i]) == minARound)
                    {
                        tmp = B[j, i];
                        if (tmp < B[j, i])
                        { minB = B[j, i]; }
                        else
                            minB = tmp;
                    }
                }
            }
            Console.WriteLine($"\n\tОбщих идентичных минимальных значений не найдено, " +
                            "\n\tно если округлить числа, общими будут: " +
                            "\n\tдля массива А: {0}, для массива B: {1}, результат операции - наименьшее из них.", min, minB);
            if (min < minB)
                return min;
            else
                return minB;
        }

        public float SumTotal()
        {
            float sum = 0;
            foreach (var el in A)
            {
                sum += el;
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    sum += B[i, j];
                }
            }
            return sum;
        }

        public float Multip()
        {
            float mul = 1;
            foreach (var el in A)
            {
                mul *= el;
            }
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    mul *= B[i, j];
                }
            }
            return mul;
        }

        public float SumPairA()
        {
            float sum = 0;
            foreach (var el in A)
            {
                if (el % 2 == 0)
                {
                    sum += el;
                }
            }

            return sum;
        }

        public float SumnPairColsB()
        {
            float sum = 0;
            for (int i = 0; i < B.GetLength(0); i++)
            {
                for (int j = 0; j < B.GetLength(1); j++)
                {
                    if (j % 2 != 0)
                    {
                        sum += B[i, j];
                    }
                }
            }
            return sum;
        }
    }

    class Matrix
    {
        private int[,] matrix1;
        private int[,] matrix2;
        private Random r = new Random();
        int row;
        public Matrix()
        {
            Console.Write("\n\tВведите размер матрицы: ");
            row = int.Parse(Console.ReadLine());
            matrix1 = new int[row, row];
            matrix2 = new int[row, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    matrix1[i, j] = r.Next(1, 50);
                }
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    matrix2[i, j] = r.Next(-20, 50);
                }
            }
        }

        public int[,] MyltiplyNum(int matrixNum, int number)
        {
            int[,] result = new int[row, row];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    if (matrixNum == 1)
                    {
                        result[i, j] = matrix1[i, j] * number;
                    }
                    else if (matrixNum == 2)
                    {
                        result[i, j] = matrix2[i, j] * number;
                    }
                    else
                    {
                        Console.WriteLine("\n\tОшибка! Неправильный номер матрицы ");
                        break;
                    }
                }
            }
            return result;
        }


        public int[,] SumMatrix()
        {
            int[,] result = new int[row, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    result[i, j] = matrix1[i, j] + matrix2[i, j];
                }
            }
            return result;
        }

        public int[,] MultiplyMatrix()
        {
            int[,] result = new int[row, row];
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < row; j++)
                {
                    result[i, j] = matrix1[i, j] * matrix2[i, j];
                }
            }
            return result;
        }

        public void ShowMatrix()
        {
            for (int i = 0; i < row; i++)
            {
                Console.Write("\n\t");
                for (int j = 0; j < row; j++)
                {
                    Console.Write(matrix1[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            for (int i = 0; i < row; i++)
            {
                Console.Write("\n\t");
                for (int j = 0; j < row; j++)
                {
                    Console.Write(matrix2[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        public void ShowResultMatrix(int[,] matrix)
        {
            for (int i = 0; i < row; i++)
            {
                Console.Write("\n\t");
                for (int j = 0; j < row; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

    }

    internal class Program
    {
        static void Main(string[] args)
        {
            short choice;
            do
            {
                Console.WriteLine("\n\t Выберите задание: ");
                Console.WriteLine("\n\t1-Операции с одномерным и двумерным массивом");
                Console.WriteLine("\n\t2-Двумерный массив, посчитать сумму между максимальным и минимальным эл.");
                Console.WriteLine("\n\t4-Умножение матрицы на число, сложение матриц, умножение матриц.");
                Console.WriteLine("\n\t5-Пользователь вводит выражение (+/-), посчитать результат.");
                Console.WriteLine("\n\t6-Перевести буквы в верхний регистр. ");
                Console.Write("\n\t0 - Выйти из программы. "); 
                choice = short.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        {
                            MyArray arr = new MyArray();
                            arr.ShowArr();
                            float maxel = arr.MaxEl();
                            Console.WriteLine("\n\tМаксимальное общее значение: " + maxel);
                            float minel = arr.MinEl();
                            Console.WriteLine("\n\tМинимальное общее значение: " + minel);
                            Console.WriteLine("\n\tСумма всех элементов: " + arr.SumTotal());
                            Console.WriteLine("\n\tРезультат умножения всех элементов: " + arr.Multip());
                            Console.WriteLine("\n\tРезультат cложения парных элементов массива А: " + arr.SumPairA());
                            Console.WriteLine("\n\tРезультат cложения непарных столбцов массива В: " + arr.SumnPairColsB());
                        }
                        break;
                    case 2:
                        {
                            Random t = new Random();
                            int[,] arr = new int[5, 5];

                            for (int i = 0; i < arr.GetLength(0); i++)
                            {
                                Console.Write("\n\t");
                                for (int j = 0; j < arr.GetLength(1); j++)
                                {
                                    arr[i, j] = t.Next(-100, 100);
                                    Console.Write(arr[i, j] + " ");
                                }
                                Console.WriteLine();
                            }
                            int max = arr[0, 0], min = arr[0, 0];
                            int maxRow = 0, maxCol = 0, minRow = 0, minCol = 0;
                            for (int i = 0; i < arr.GetLength(0); i++)
                            {
                                for (int j = 0; j < arr.GetLength(1); j++)
                                {
                                    if (arr[i, j] > max)
                                    {
                                        max = arr[i, j];
                                        maxRow = i;
                                        maxCol = j;
                                    }

                                    if (arr[i, j] < min)
                                    {
                                        min = arr[i, j];
                                        minRow = i;
                                        minCol = j;
                                    }
                                }
                            }
                            Console.WriteLine($"\n\tМаксимальный элемент: {max}, строка: {maxRow}, столбец: {maxCol}");
                            Console.WriteLine($"\n\tМинимальный элемент: {min}, строка: {minRow}, столбец: {minCol}");
                            int sum = 0;
                            if (maxRow > minRow)
                            {
                                Console.Write("\n\tСуммируем числа между мах и мин: ");
                                for (int i = minRow; i <= maxRow; i++)
                                {
                                    for (int j = (i == minRow) ? (minCol + 1) : 0; j < arr.GetLength(1); j++)
                                    {
                                        if (arr[i, j] == min || arr[i, j] == max)
                                        {
                                            break;
                                        }

                                        Console.Write(arr[i, j] + " ");
                                        sum += arr[i, j];

                                    }
                                }
                            }
                            else if (maxRow < minRow)
                            {
                                Console.Write("\n\tСуммируем числа между мах и мин: ");
                                for (int i = maxRow; i <= minRow; i++)
                                {
                                    for (int j = (i == minRow) ? (minCol + 1) : 0; j < arr.GetLength(1); j++)
                                    {
                                        if (arr[i, j] == min || arr[i, j] == max)
                                        {
                                            break;
                                        }

                                        Console.Write(arr[i, j] + " ");
                                        sum += arr[i, j];
                                    }
                                }
                            }

                            else
                            {
                                int i = minRow;
                                do
                                {
                                    Console.Write("\n\tСуммируем числа между мах и мин: ");
                                    for (int j = minCol + 1; j <= arr.GetLength(1); j++)
                                    {
                                        if (minCol + 1 == maxCol)
                                        {
                                            break;
                                        }
                                        if (arr[i, j] == min || arr[i, j] == max)
                                        {
                                            break;
                                        }

                                        Console.Write(arr[i, j] + " ");
                                        sum += arr[i, j];

                                    }
                                    i++;
                                } while (i < maxRow);

                            }
                            Console.WriteLine("\n\tСумма элементов между максимальным и минимальным: " + sum);

                        }
                        break;
                    case 4:
                        {
                            Matrix matrix = new Matrix();
                            matrix.ShowMatrix();
                            Console.Write("\n\tВведите число, на которое нужно умножить матрицу: ");
                            int num = int.Parse(Console.ReadLine());
                            int matrixNum = 0;
                            while (matrixNum == 0)
                            {
                                Console.Write("\n\tВведите номер матрицы, которую нужно умножить (1 или 2): ");
                                matrixNum = int.Parse(Console.ReadLine());
                            }
                            Console.WriteLine("\n\tРезультат умножения: ");
                            matrix.ShowResultMatrix(matrix.MyltiplyNum(matrixNum, num));
                            Console.WriteLine("\n\tРезультат сложения матриц: ");
                            matrix.ShowResultMatrix(matrix.SumMatrix());
                            Console.WriteLine("\n\tРезультат умножения матриц: ");
                            matrix.ShowResultMatrix(matrix.MultiplyMatrix());

                        }
                        break;
                    case 5:
                        {
                            Console.Write("\n\tВведите арифметическое выражение (допустимы " +
                                "только операции \"+\" и \"-\") :");
                            string expression = Console.ReadLine();
                            expression = expression.Replace(" ", "");

                            int result = 0;
                            char operation = '+';
                            bool isFirstNum = true;
                            string tmp = "";
                            for (int i = 0; i < expression.Length; i++)
                            {
                                if (Char.IsDigit(expression[i]))
                                {
                                    tmp += expression[i];
                                }
                                else
                                {
                                    int num = int.Parse(tmp);
                                    if (isFirstNum)
                                    {
                                        result = num;
                                        isFirstNum = false;
                                    }
                                    else
                                    {
                                        if (operation == '+')
                                        {
                                            result += num;
                                        }
                                        else if (operation == '-')
                                        {
                                            result -= num;
                                        }
                                        else
                                        {
                                            Console.WriteLine("\n\tВведена недопустимая операция, результат вычисления будет некорректен!");
                                            continue;
                                        }
                                    }
                                    operation = expression[i];
                                    tmp = "";
                                }
                            }
                            int lastNum = int.Parse(tmp);
                            if (operation == '+')
                            {
                                result += lastNum;
                            }
                            else if (operation == '-')
                            {
                                result -= lastNum;
                            }
                            Console.WriteLine("\n\tРезультат: " + result);
                        }
                        break;
                    case 6:
                        {
                            Console.Write("\n\tВведите текст: ");
                            string text=Console.ReadLine();
                            StringBuilder res=new StringBuilder(text);
                            bool uppercase = true;
                            for (int i=0; i<res.Length; i++)
                            {
                                if (res[i] == '.' || res[i] == '!' || res[i]=='?')
                                {
                                    uppercase = true;
                                }
                                else if (char.IsLetter(res[i])&&uppercase)
                                {
                                    res[i] = char.ToUpper(res[i]);
                                    uppercase= false;
                                }
                            }
                            Console.WriteLine("\n\tРезультат: "+ res.ToString());
                        }
                        break;
                    default:
                        Console.WriteLine("\n\tВы сделали неверный выбор. Попробуйте снова (обратите внимания, что нельзя выбрать задание 3.)");
                        break;
                } 
            } while (choice != 0);

        }
    }
}