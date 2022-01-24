using System;
using System.Drawing;

namespace MatrixOperations
{
    //Класс ячейки:
    [Serializable]//необходимо для сериализации объекта
    class Cell
    {
        public Rectangle Rectangle { get; set; } //Прямоугольная область
        public Color FillColor { get; set; } //Цвет заливки
        public Color TextColor { get; set; } //Цвет текста
        public Color BorderColor { get; set; } //Цвет границ
        public int Thickness { get; set; } //Толщина пера
        public int TextSize { get; set; } //Размер текста
        public int Number { get; set; } //Значение ячейки

        //Конструктор класса:
        public Cell(int w, int h, int left, int top, Color fillColor, Color textColor, Color borderColor, int thickness, int textSize, int num)
        {
            Rectangle = new Rectangle(left, top, w, h);
            FillColor = fillColor;
            TextColor = textColor;
            BorderColor = borderColor;
            Thickness = thickness;
            TextSize = textSize;
            Number = num;
        }

        //Метод рисования ячейки:
        public void Draw(Graphics g)
        {
            //Перо для рисования границ:
            Pen pen = new Pen(BorderColor, Thickness);
            //Сплошная кисть для заливки:
            Brush brush = new SolidBrush(FillColor);
            //Заливаем область:
            g.FillRectangle(brush, Rectangle);
            //Рисуем границы:
            g.DrawRectangle(pen, Rectangle);
            //Сплошная кисть для текста:
            Brush textBrush = new SolidBrush(TextColor);
            //Формат текста:
            Font font = new Font("Tahoma", TextSize, FontStyle.Bold);
            //Формат строки:
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            //Выравнивание текста:
            format.Alignment = StringAlignment.Center;
            format.LineAlignment = StringAlignment.Center;
            //Рисуем текст (номер ячейки):
            g.DrawString(Number.ToString(), font, textBrush, Rectangle, format);
        }
    }
}
