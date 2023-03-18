using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW_18._03._2023
{
    class MyArray
    {
        private float[] A = new float [5];
        private float[,] B = new float [3,4];
        private Random r= new Random();
        //public int a { get; set; }
        public MyArray()
        {
            Console.WriteLine("\n\tВведите значение элемента одномерного массива:");
            for (int i = 0; i < A.Length; i++) 
            {
                Console.Write(" ");
                A[i] = float.Parse(Console.ReadLine()); ;       
            }
            for (int i=0; i<B.GetLength(0); i++) 
            { 
                for (int j=0; j<B.GetLength(1); j++)
                {
                    B[i, j] = (float)r.NextDouble()*10;
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
                    Console.Write(B[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public float MaxEl()
        {
            float max = A[0];
            for (int i=0; i<A.Length; i++) 
            { 
                if (A[i]>max)
                {
                    max = A[i];
                }
            }
            float maxB = B[0, 0];
            int maxARound=(int)max;
            float tmp = B[0, 0];
            for (int j=0; j<B.GetLength(0); j++)
            {
                for (int i=0; i<B.GetLength(1); i++)
                {
                    if (B[j,i]==max)
                    {
                        return max;
                    }
                    //Если абсолютно одинаковых значений нет, приводим к int и определяем максимально общее значение второго массива
                    else if ((int)(B[j,i])==maxARound)
                    {
                        tmp = B[j,i];
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
            for (int i=0; i<B.GetLength(0); i++)
            {
                for (int j=0; j<B.GetLength(1); j++)
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
                if (el%2==0)
                {
                    sum+= el;
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
                choice = short.Parse(Console.ReadLine());
                switch(choice) 
                {
                    case 1:
                        {
                            MyArray arr= new MyArray();
                            arr.ShowArr();
                            float maxel = arr.MaxEl();
                            Console.WriteLine("\n\tМаксимальное общее значение: "+ maxel);
                            float minel = arr.MinEl();
                            Console.WriteLine("\n\tМинимальное общее значение: "+ minel);
                            Console.WriteLine("\n\tСумма всех элементов: "+ arr.SumTotal());
                            Console.WriteLine("\n\tРезультат умножения всех элементов: " + arr.Multip());
                            Console.WriteLine("\n\tРезультат cложения парных элементов массива А: " + arr.SumPairA());
                            Console.WriteLine("\n\tРезультат cложения непарных столбцов массива В: " + arr.SumnPairColsB());
                        }
                        break;
                    case 2:
                        {
                            Random t=new Random();
                            int[,] arr = new int[5, 5];
                            
                            for (int i=0; i<arr.GetLength(0); i++)
                            {
                                Console.Write("\n\t");
                                for (int j=0; j<arr.GetLength(1); j++)
                                {
                                    arr[i, j] = t.Next(-100,100);
                                    Console.Write(arr[i, j]+" ");
                                }
                                Console.WriteLine();
                            }
                            int max = arr[0,0], min = arr[0,0];
                            int maxRow = 0, maxCol = 0, minRow = 0, minCol = 0;
                            for (int i = 0; i < arr.GetLength(0); i++)
                            {
                                for (int j = 0; j < arr.GetLength(1); j++)
                                {
                                    if (arr[i,j]>max)
                                    {
                                        max = arr[i, j];
                                        maxRow = i;
                                        maxCol = j;
                                    }
                                        
                                    if (arr[i,j]<min)
                                    {
                                        min = arr[i, j];
                                        minRow= i;
                                        minCol = j;
                                    }     
                                }
                            }
                            Console.WriteLine($"\n\tМаксимальный элемент: {max}, строка: {maxRow}, столбец: { maxCol}");
                            Console.WriteLine($"\n\tМинимальный элемент: {min}, строка: {minRow}, столбец: {minCol}");
                            int sum = 0;
                            //int startRow, startCol, endRow, endCol;
                            if (maxRow>minRow)
                            {
                                Console.Write("\n\tСуммируем числа между мах и мин: ");
                                for (int i = minRow; i <= maxRow; i++)
                                {
                                    for (int j = (i==minRow)?(minCol + 1):0; j < arr.GetLength(1); j++ )
                                    {
                                        if (arr[i, j] == min || arr[i,j]==max)
                                        {
                                            //sum -= arr[i, j];
                                            break;
                                        }
                                            
                                        Console.Write(arr[i, j] + " ");
                                        sum += arr[i, j];
                                        
                                    }
                                }
                            }
                            else if (maxRow<minRow)
                            {
                                Console.Write("\n\tСуммируем числа между мах и мин: ");
                                for (int i = maxRow; i <=minRow; i++)
                                {
                                    for (int j = (i == minRow) ? (minCol + 1) : 0; j < arr.GetLength(1); j++)
                                    {
                                        if (arr[i, j] == min || arr[i, j] == max)
                                        {
                                            //sum -= arr[i, j];
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
                                    for (int j = minCol+1; j<=arr.GetLength(1); j++)
                                    {
                                        if (minCol + 1 == maxCol)
                                        {
                                            break;
                                        }
                                        if (arr[i, j] == min || arr[i, j] == max)
                                        {
                                            //sum -= arr[i, j];
                                            break;
                                        }

                                        Console.Write(arr[i, j] + " ");
                                        sum += arr[i, j];

                                    }
                                    i++;
                                } while (i < maxRow);
                               
                            }

                            //else if (maxRow<minRow)
                            //{
                            //    for (int i = maxRow; i < minRow; i++)
                            //    {
                            //        Console.Write(arr[i, j] + " ");
                            //        sum += arr[i, j];
                            //    }
                            //}
                            
                            //if (maxRow < minRow)
                            //{
                            //    startRow = maxRow;
                            //    endRow = minRow;
                            //}
                            //else
                            //{
                            //    startRow = minRow;
                            //    endRow = maxRow;
                            //}

                            //if (maxCol < minCol)
                            //{
                            //    startCol = maxCol;
                            //    endCol = minCol;
                            //}
                            //else
                            //{
                            //    startCol = minCol;
                            //    endCol = maxCol;
                            //}

                            //for (int i = startRow; i < endRow; i++)
                            //{
                            //    for (int j = startCol+1; j < endCol-1; j++)
                            //    {
                            //        Console.Write(arr[i,j] + " ");
                            //        sum += arr[i, j];
                            //    }
                            //}

                            //if (maxRow == minRow)
                            //{
                            //    if (maxCol < minCol)
                            //    {
                            //        for (int i = maxCol + 1; i < minCol; i++)
                            //        {
                            //            sum += arr[maxRow, i];
                            //        }
                            //    }
                            //    else
                            //    {
                            //        for (int i = minCol + 1; i < maxCol; i++)
                            //        {
                            //            sum += arr[maxRow, i];
                            //        }
                            //    }
                            //}
                            //else if (maxRow<minRow)
                            //{ 
                            
                            //}
                            //else if (maxCol == minCol)
                            //{
                            //    if (maxRow < minRow)
                            //    {
                            //        for (int i = maxRow + 1; i < minRow; i++)
                            //        {
                            //            sum += arr[i, maxCol];
                            //        }
                            //    }
                            //    else
                            //    {
                                    
                            //    }
                            //}
                            //startRow = Math.Min(minRow, maxRow);
                            //endRow=Math.Max(minRow, maxRow);
                            //startCol=Math.Min(minCol, maxCol);
                            //endCol=Math.Max(minCol, maxCol);
                            //for (int i = startRow; i < endRow; i++)
                            //{
                            //    for (int j=startCol; j<endCol; j++)
                            //    {
                            //        sum += arr[i,j];
                            //    }
                            //}
                            Console.WriteLine("\n\tСумма элементов между максимальным и минимальным: "+ sum);

                        }
                        break;
                }
            } 
            while (choice != 0);
        }
    }
}
