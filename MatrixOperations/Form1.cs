using System;
using Microsoft.VisualBasic;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Collections;
using System.Collections.Generic;

namespace MatrixOperations
{
    public partial class Form1 : Form
    {
        //Матрицы:
        Matrix matrix1, matrix2, matrix3;
        
        //Стартовые отступы:
        public int left, top;
        public int X, Y;
        
        //условие изменения элемента и клика по кнопке очистки
        bool flag = false;

        //Поля для установок свойств объектам:
        int firstRows, firstColumns;
        int secondRows, secondColumns;
        int cellWidth, cellHeight;
        Color fillColor, textColor, borderColor;
        int thickness, textSize;

        //Объекты надписи и их стандартные свойства:
        Label lbl1 = new Label();
        Label lbl2 = new Label();
        Label lbl3 = new Label();
        Size labelSize = new Size(108, 18);
        Font labelFont = new Font("Georgia", 12, FontStyle.Bold);
        Color labelColor = Color.Gold;

        //Массивы объектов:
        Cell[,] cells1, cells2, cells3;

        public Form1()
        {
            InitializeComponent();
            Init();
        }

        //Метод начальной инициализации:
        private void Init()
        {
            //Стандартные значения:
            cellWidth = 30;
            cellHeight = 20;
            fillColor = Color.White;
            textColor = Color.Black;
            borderColor = Color.Black;
            thickness = 2;
            textSize = 10;
            //свойства надписей
            lbl1.Font = labelFont;
            lbl2.Font = labelFont;
            lbl3.Font = labelFont;
            lbl1.Size = labelSize;
            lbl2.Size = labelSize;
            lbl3.Size = labelSize;
            lbl1.BackColor = labelColor;
            lbl2.BackColor = labelColor;
            lbl3.BackColor = labelColor;
            lbl1.Text = "Матрица 1:";
            lbl2.Text = "Матрица 2:";
            lbl3.Text = "Результат:";
            X = 45; Y = 60;
        }

        //Метод перерисовки формы:
        private void Form1_Paint(object sender, PaintEventArgs e)
        {        
            //Рисуем первую матрицу:
            if (matrix1 != null)
            {
                //Начальные значения отступов:
                left = X; top = Y;
                lbl1.Location = new Point(left, top-25);

                //Проходимся по элементам матрицы:
                for (int i = 0; i < matrix1.Array.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix1.Array.GetLength(1); j++)
                    {
                        //Инициализируем клетку:
                        cells1[i, j] = new Cell(cellWidth, cellHeight, left, top, fillColor, textColor, borderColor, thickness, textSize, matrix1.Array[i, j]);
                        //Рисуем клетку:
                        cells1[i, j].Draw(e.Graphics);
                        //Увеличиваем смещение слева:
                        left += cellWidth;
                    }
                    //Восстанавливаем смещение слева:
                    left = X;
                    //Увеличиваем смещение сверху:
                    top += cellHeight;
                }
            }

            //Рисуем вторую матрицу:
            if (matrix2 != null)
            {
                //Начальные значения отступов:
                left = X + firstColumns * cellWidth + 30; top = Y;

                //Положение надписи2:
                lbl2.Location = new Point(left,top-25);

                //Проходимся по элементам матрицы:
                for (int i = 0; i < matrix2.Array.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix2.Array.GetLength(1); j++)
                    {
                        //Инициализируем клетку:
                        cells2[i, j] = new Cell(cellWidth, cellHeight, left, top, fillColor, textColor, borderColor, thickness, textSize, matrix2.Array[i, j]);
                        //Рисуем клетку:
                        cells2[i, j].Draw(e.Graphics);
                        //Увеличиваем смещение слева:
                        left += cellWidth;
                    }
                    //Восстанавливаем смещение слева:
                    left = X + firstColumns * cellWidth + 30;
                    //Увеличиваем смещение сверху:
                    top += cellHeight;
                }
            }

            //Рисуем третью матрицу:
            if (matrix3 != null)
            {
                //Начальные значения отступов:
                left = X + firstColumns * cellWidth + 30 + secondColumns * cellWidth + 30; top = Y;

                    //Положение надписи3:
                    lbl3.Location = new Point(left, top - 25);
                    

                //Проходимся по элементам матрицы:
                for (int i = 0; i < matrix3.Array.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix3.Array.GetLength(1); j++)
                    {
                        //Инициализируем клетку:
                        cells3[i, j] = new Cell(cellWidth, cellHeight, left, top, fillColor, textColor, borderColor, thickness, textSize, matrix3.Array[i, j]);
                        //Рисуем клетку:
                        cells3[i, j].Draw(e.Graphics);
                        //Увеличиваем смещение слева:
                        left += cellWidth;
                    }
                    //Восстанавливаем смещение слева:
                    left = X + firstColumns * cellWidth + 30 + secondColumns * cellWidth + 30;
                    //Увеличиваем смещение сверху:
                    top += cellHeight;
                }
            }
        }

        //Метод замены цвета:
        public Color SwapColor(string colorName)
        {
            Color color;
            switch (colorName)
            {
                case "Красный": color = Color.Red; break;
                case "Синий": color = Color.Blue; break;
                case "Зелёный": color = Color.Green; break;
                case "Жёлтый": color = Color.Yellow; break;
                case "Фиолетовый": color = Color.Violet; break;
                case "Коричневый": color = Color.Brown; break;
                case "Чёрный": color = Color.Black; break;
                case "Серый": color = Color.Gray; break;
                case "Случайный":
                    {
                        Random random = new Random();
                        color = Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256));
                        break;
                    }
                default: color = Color.White; break;
            }
            return color;
        }

        //Метод установки значения количества строк первой матрицы:
        private void строкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            firstRows = Convert.ToInt32(Interaction.InputBox("Число строк первой матрицы: "));
        }

        //Метод установки значения количества столбцов первой матрицы:
        private void столбцыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            firstColumns = Convert.ToInt32(Interaction.InputBox("Число столбцов первой матрицы: "));
        }

        //Метод инициализации матрицы 1:
        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Рисование надписи1:                                 
            Controls.Add(lbl1);
            //Инициализация матрицы 1:
            matrix1 = new Matrix(firstRows, firstColumns);
            cells1 = new Cell[firstRows, firstColumns];
            Invalidate();
        }

        //Метод инициализации матрицы 2:
        private void создатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Рисование надписи2:            
            Controls.Add(lbl2);
            
            //Инициализация матрицы 2:
            matrix2 = new Matrix(secondRows, secondColumns);
            cells2 = new Cell[secondRows, secondColumns];
            Invalidate();
        }

        //Метод умножения матрицы 1 на число:
        private void матрица1ToolStripMenuItem_Click(object sender, EventArgs e)
        {           
            //Вводим число:
            int num = int.Parse(Interaction.InputBox("Введите число: "));
            //Выделяем память под объекты, но для матрицы делаем это через статический метод:
            matrix3 = Matrix.MultByNumber(matrix1, num);
            cells3 = new Cell[firstRows, firstColumns];
            toolStripStatusLabel1.Text = "Умножение матрицы 1 на "+num;
            Invalidate();
        }

        //Метод деления матрицы 1 на число:
        private void матрица1ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Вводим число:
            int num = int.Parse(Interaction.InputBox("Введите число: "));
            //Выделяем память под объекты, но для матрицы делаем это через статический метод:
            matrix3 = Matrix.MultiDel(matrix1, num);
            cells3 = new Cell[firstRows, firstColumns];
            toolStripStatusLabel1.Text = "Деление матрицы 1 на " + num;
            Invalidate();
        }
        
        //Метод деления матрицы 2 на число:
        private void матрица2ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            //Вводим число:
            int num = int.Parse(Interaction.InputBox("Введите число: "));
            //Выделяем память под объекты, но для матрицы делаем это через статический метод:
            matrix3 = Matrix.MultiDel(matrix2, num);
            cells3 = new Cell[secondRows, secondColumns];
            toolStripStatusLabel1.Text = "Деление матрицы 2 на " + num;
            Invalidate();
        }

        //Метод сложения матриц:
        private void сложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matrix3 = Matrix.Addition(matrix1, matrix2);
            cells3 = new Cell[firstRows, secondColumns];
            toolStripStatusLabel1.Text = "Сложение матриц ";
            Invalidate();
        }

        //Метод вычитания матриц:
        private void вычитаниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matrix3 = Matrix.Subtraction(matrix1, matrix2);
            cells3 = new Cell[firstRows, secondColumns];
            toolStripStatusLabel1.Text = "Вычитание матриц ";
            Invalidate();
        }

        //Метод умножения матриц:
        private void умножениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            matrix3 = Matrix.MatrixMulti(matrix1, matrix2);
            cells3 = new Cell[firstRows, secondColumns];
            toolStripStatusLabel1.Text = "Умножение матриц ";
            Invalidate();
        }

        //Метод транспонирования матрицы 1:
        private void матрица1ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            matrix3 = Matrix.Transp(matrix1);
            cells3 = new Cell[firstColumns, firstRows];
            toolStripStatusLabel1.Text = "Транспонирование матрицы 1 ";
            Invalidate();
        }

        //Метод транспонирования матрицы 2:
        private void матрица2ToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            matrix3 = Matrix.Transp(matrix2);
            cells3 = new Cell[secondColumns, secondRows];
            toolStripStatusLabel1.Text = "Транспонирование матрицы 1 ";
            Invalidate();
        }

        //разрешение изменения элементов матриц:
        private void изменитьЭлементToolStripMenuItem_Click(object sender, EventArgs e)
        {
            flag = true;
        }

        //Метод умножения матрицы 2 на число:
        private void матрица2ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //Вводим число:
            int num = int.Parse(Interaction.InputBox("Введите число: "));
            //Выделяем память под объекты, но для матрицы делаем это через статический метод:
            matrix3 = Matrix.MultByNumber(matrix2, num);
            cells3 = new Cell[secondRows, secondColumns];
            toolStripStatusLabel1.Text = "Умножение матрицы 2 на " + num;
            Invalidate();
        }

        //Метод рандомного заполнения матрицы 1:
        private void заполнитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Matrix.RandomFill(matrix1);
            Invalidate();
        }

        //Метод рандомного заполнения матрицы 2:
        private void заполнитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Matrix.RandomFill(matrix2);
            Invalidate();
        }

        private void очиститьToolStripButton_Click(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = "";
            Graphics p = CreateGraphics();
            p.Clear(Color.White);
            //делаем нулевой размер чтобы убрать надписи
            lbl1.Size = new Size(0,0);
            lbl2.Size = new Size(0, 0);
            lbl3.Size = new Size(0,0);
        }

        private void закрытьToolStripButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void обновитьToolStripButton_Click(object sender, EventArgs e)
        {
            Invalidate();
        }

        //рисование надписи3 при клике на "операции"
        private void действияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Controls.Add(lbl3);
        }

        private void добавитьОкноToolStripButton_Click(object sender, EventArgs e)
        {
            Form1 newForm = new Form1();
            newForm.Text = "Дочернее окно";
            newForm.ShowDialog();
        }

        private void справкаToolStripButton_Click(object sender, EventArgs e)
        {
            InfoForm info = new InfoForm();
            info.Show();
        }

        //сериализация оъектов
        private void toolStripButton1_Click(object sender, EventArgs e)
        {          
            SerializeClass ser = new SerializeClass();
            ser.mat1 = matrix1;
            ser.mat2 = matrix2;
            ser.mat3 = matrix3;
            ser.cell1 = cells1;
            ser.cell2 = cells2;
            ser.cell3 = cells3;
            ser.left = left;
            ser.top = top;
            ser.cellHeight = cellHeight;
            ser.cellWidth = cellWidth;
            ser.firstRows = firstRows;
            ser.firstColumns = firstColumns;
            ser.secondRows = secondRows;
            ser.secondColumns = secondColumns;
            ser.textColor = textColor;
            ser.fillColor = fillColor;
            ser.borderColor = borderColor;
            ser.textSize = textSize;
            ser.thickness = thickness;
            ser.statusLabel = toolStripStatusLabel1.Text;
            BinaryFormatter bin = new BinaryFormatter();
            FileStream stream = File.Open("Проект матриц.dat", FileMode.Create, FileAccess.Write);
            bin.Serialize(stream,ser);
            stream.Close();
        }

        //десериализация объеков
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            FileStream s = File.Open("Проект матриц.dat", FileMode.Open, FileAccess.Read);
            BinaryFormatter bf = new BinaryFormatter();
            object m1 = bf.Deserialize(s);
            SerializeClass obj = m1 as SerializeClass;
            left = obj.left;
            top = obj.top;
            matrix1 = obj.mat1;
            cells1 = obj.cell1;
            matrix2 = obj.mat2;
            cells2 = obj.cell2;
            matrix3 = obj.mat3;
            cells3 = obj.cell3;
            cellHeight = obj.cellHeight;
            cellWidth = obj.cellWidth;
            firstRows = obj.firstRows;
            firstColumns = obj.firstColumns;
            secondColumns = obj.secondColumns;
            secondRows = obj.secondRows;
            textColor = obj.textColor;
            fillColor = obj.fillColor;
            borderColor = obj.borderColor;
            textSize = obj.textSize;
            thickness = obj.thickness;
            toolStripStatusLabel1.Text = obj.statusLabel;
            Controls.Add(lbl1);
            Controls.Add(lbl2);
            Controls.Add(lbl3);
            s.Close();
            Invalidate();                
        }

        //перемещение с помощью клавиш wasd
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //перемещение кнопкой вниз
            if (e.KeyChar==115)
            {
                Y += 10;
                Invalidate();
            }
            //перемещение кнопкой вправо
            if (e.KeyChar == 100)
            {
                X += 10;
                Invalidate();
            }
            //перемещение кнопкой влево
            if (e.KeyChar == 97)
            {
                X -= 10;
                Invalidate();
            }
            //перемещение кнопкой вверх
            if (e.KeyChar == 119)
            {
                Y -= 10;
                Invalidate();
            }
        }

        //Метод установки значения количества строк второй матрицы:
        private void строкиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            secondRows = Convert.ToInt32(Interaction.InputBox("Число строк второй матрицы: "));
        }

        //Метод установки значения количества столбцов первой матрицы:
        private void столбцыToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            secondColumns = Convert.ToInt32(Interaction.InputBox("Число столбцов второй матрицы: "));
        }

        //Метод установки ширины клеток:
        private void ширинаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cellHeight = Convert.ToInt32(Interaction.InputBox("Высота клеток: "));
            Invalidate();
        }

        //Метод установки высоты клеток:
        private void длинаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            cellWidth = Convert.ToInt32(Interaction.InputBox("Длина клеток: "));       
            Invalidate();
        }

        //Метод установки цвета заливки:
        private void цветЗаливкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fillColor = SwapColor(Interaction.InputBox("Цвет заливки: "));
            Invalidate();
        }

        //Метод установки цвета текста:
        private void цветToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textColor = SwapColor(Interaction.InputBox("Цвет текста: "));
            Invalidate();
        }

        //Метод установки цвета контура:
        private void цветКонтураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            borderColor = SwapColor(Interaction.InputBox("Цвет контура: "));
            Invalidate();
        }

        //Метод установки размера текста:
        private void размерТекстаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            textSize = int.Parse(Interaction.InputBox("Размер текста: "));
            Invalidate();
        }

        //Метод установки толщины контура:
        private void толщинаКонтураToolStripMenuItem_Click(object sender, EventArgs e)
        {
            thickness = int.Parse(Interaction.InputBox("Размер текста: "));
            Invalidate();
        }
 
        //Метод определения значения ячейки:
        private void TryShowCellValue(Point point, Cell[,] cell, Matrix matrix)
        {
            //Проходимся по ячейкам:
            for (int i = 0; i < cell.GetLength(0); i++)
            {
                for (int j = 0; j < cell.GetLength(1); j++)
                {
                    //Если прямоугольная область, которая ограничивает ячейку, содержит в себе точку:
                    if (cell[i, j].Rectangle.Contains(point))
                    {
                        //Меняем значение ячейки:
                        int num = int.Parse(Interaction.InputBox("Новое значение: "));
                        matrix.Array[i, j] = num;
                    }
                }
            }
        }

        //Метод нажатия мышью на форму, при помощи которого определяется ячейка:
        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            if (flag == true)
            {
                //Вызываем метод определения значения ячейки для каждого массива ячеек:
                if (cells1 != null)
                {
                    //Проверяем принадлежность ячейки:
                    TryShowCellValue(e.Location, cells1, matrix1);
                }
                if (cells2 != null)
                {
                    //Проверяем принадлежность ячейки:
                    TryShowCellValue(e.Location, cells2, matrix2);
                }
                Invalidate();
            }
        }
    }
}
