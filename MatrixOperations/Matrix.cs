using System;

namespace MatrixOperations
{
    //Класс матрицы:
   [Serializable]
    class Matrix
    {
        public int[,] Array { get; set; } //Двумерный массив

        //Конструктор класса:
        public Matrix(int rows, int columns)
        {
            Array = new int[rows, columns];
        }

        //Метод заполнения матрицы случайными числами:
        public static void RandomFill(Matrix matrix)
        {
            //Переменная для генерирования случайных чисел:
            Random random = new Random();
            //В цикле устанавливаем случайные значения элементам матрицы:
            for (int i = 0; i < matrix.Array.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.Array.GetLength(1); j++)
                {
                    matrix.Array[i, j] = random.Next(0, 99);
                }
            }
        }

        //Статический метод умножения матрицы на число:
        public static Matrix MultByNumber(Matrix matrix, int num)
        {
            //Инициализируем матрицу, которую будет возвращать метод:
            Matrix m = new Matrix(matrix.Array.GetLength(0), matrix.Array.GetLength(1));
            for (int i = 0; i < m.Array.GetLength(0); i++)
            {
                for (int j = 0; j < m.Array.GetLength(1); j++)
                {
                    //Каждое значение умножаем на число:
                    m.Array[i, j] = matrix.Array[i, j] * num;
                }
            }
            //Возвращаем новый объект матрицы:
            return m;
        }

        //Статический метод деления матрицы на число:
        public static Matrix MultiDel(Matrix matrix, int num)
        {
            Matrix m = new Matrix(matrix.Array.GetLength(0), matrix.Array.GetLength(1));
            for (int i = 0; i < m.Array.GetLength(0); i++)
            {
                for (int j = 0; j < m.Array.GetLength(1); j++)
                {
                    //Каждое значение умножаем на число:
                    m.Array[i, j] = matrix.Array[i, j] / num;
                }
            }
            //Возвращаем новый объект матрицы:
            return m;
        }

        //Статический метод сложения матриц:
        public static Matrix Addition(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1.Array.GetLength(0), matrix2.Array.GetLength(1));
            for (int i = 0; i < matrix1.Array.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.Array.GetLength(1); j++)
                {
                    result.Array[i, j] = matrix1.Array[i, j] + matrix2.Array[i, j];
                }
            }
            return result;
        }

        //Статический метод вычитания матриц:
        public static Matrix Subtraction(Matrix matrix1, Matrix matrix2)
        {
            Matrix result = new Matrix(matrix1.Array.GetLength(0), matrix2.Array.GetLength(1));
            for (int i = 0; i < matrix1.Array.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.Array.GetLength(1); j++)
                {
                    result.Array[i, j] = matrix1.Array[i, j] - matrix2.Array[i, j];
                }
            }
            return result;
        }

        //Статический метод умножения матриц:
        public static Matrix MatrixMulti(Matrix matrix1, Matrix matrix2) 
        {
            Matrix matrix3 = new Matrix(matrix1.Array.GetLength(0), matrix2.Array.GetLength(1));
            for (int i = 0; i < matrix1.Array.GetLength(0); i++)
            {
                for (int j = 0; j < matrix2.Array.GetLength(1); j++)
                {
                    for (int k = 0; k < matrix1.Array.GetLength(1); k++)
                    {
                        matrix3.Array[i, j] += matrix1.Array[i, k] * matrix2.Array[k, j];
                    }
                }
            }
            return matrix3;
        }

        //Статический метод транспонирования матрицы:
        public static Matrix Transp(Matrix matrix)
        {
            Matrix result = new Matrix(matrix.Array.GetLength(1), matrix.Array.GetLength(0));
            for (int i = 0; i < matrix.Array.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.Array.GetLength(1); j++)
                    result.Array[j, i] = matrix.Array[i, j];
            }
            return result;
        }
    }
}
