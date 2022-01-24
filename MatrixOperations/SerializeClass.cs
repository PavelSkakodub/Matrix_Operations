using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MatrixOperations
{
    [Serializable]//атрибут для сериализации класса
    class SerializeClass
    {  
        //данные которые будут сериализованы
         public   Matrix mat1, mat2, mat3;
         public   Cell[,] cell1, cell2, cell3;
         public int left;
         public int top;
         public int firstRows, firstColumns;
         public int secondRows, secondColumns;
         public int cellWidth, cellHeight;
         public Color fillColor, textColor, borderColor;
         public int thickness, textSize;
         public string statusLabel;
    }
}
