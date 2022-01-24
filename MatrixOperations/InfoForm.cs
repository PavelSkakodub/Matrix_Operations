﻿using System;
using System.Windows.Forms;

namespace MatrixOperations
{
    public partial class InfoForm : Form
    {
        public InfoForm()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Панель управления находится слева на форме, она окрашена в светло-серый цвет. \n\nС её помощью можно очищать форму, обновлять, создавать дочерние окна программы, открывать окно справки и закрывать форму. \n\nЧтобы воспользоваться нужной функцией, кликните на кнопку с подходящей иконкой.","Панель управления",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Меню находится в самом верху формы, оно окрашено в светло-голубой цвет.\n\nСодержит 5 функций: Матрица 1, Матрица 2, Операции, Ячейки, Изменить элементы. Благодаря им, можно создавать и заполнять матрицы, изменять значения и свойства ячеек, а также производить некоторые операции над матрицами.\n\nЧтобы использовать нужную функцию, кликните по соответствующей кнопке и выберите цель из выпадающего списка.","Меню", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Для создания матриц в Меню определены 2 функции: Матрица 1 и Матрица 2.\n\nДля того, чтобы создать матрицу, кликните на соответствующую кнопку в меню и в выпадающем списке, используя кнопки 'Строки' и 'Столбцы', задайте размерность матрицы.\n\nПосле этого, клкините на кнопку 'Создать' и на форме отобразится ваша матрица с подписью номера матрицы.","Создание матрицы", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В программе есть два метода заполнения матрицы:\n\n1) Рандомно. Каждый элемент матрицы будет равен случайному числу в диапазоне от 0 до 100. Этот способ реализуется путем клика по пункту 'Заполнить' при нажатии кнопки меню 'Матрица 1,2'.\n\n2) Вручную. Изменить любой элемент матрицы можно с помощью кнопки меню 'Изменить элементы'. Сперва  кликните на эту кнопку, затем наведите курсор на нужный элемент(ячейку) и при щелчке мыши всплывет окно, в котором вы укажите число элемента.","Заполнение матрицы", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("В данной программе реализовано 6 операций над матрицами: умножение и деление на число, сложение и вычитание, умножение матриц и транспонирование.\n\nЧтобы воспользоваться нужными операциями, сначала необходимо создать и заполнить матрицы. Затем кликните по кнопке меню 'Операции' и  выберите нужный пункт.\n\nПосле выбора операции, на форме отобразится ещё одна матрица с ответом и надписью 'Результат'.","Операции", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Редактор ячеек находится в меню. Он представлен кнопкой 'Ячейки' с выпадающим списком.\n\nРедактор позволяет изменять такие свойства ячейки, как: длина, ширина, цвет заливки, цвет текста, цвет контура, размер текста и толщина контура. Чтобы изменить нужный параметр, кликните по соответствующей кнопке выпадающего меню. ", "Редактор ячеек", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
