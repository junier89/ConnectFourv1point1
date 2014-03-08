using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConnectFour_v1._1
{
    public partial class TwoPlayerConnectFour : Form
    {
        int[,] Data = new int[6, 7];
        Boxes Box1 = new Boxes();
        Boxes BackgroundBox = new Boxes(0, 0, 500, 500);
        public TwoPlayerConnectFour()
        {
            InitializeComponent();
        }

        private void TwoPlayerConnectFour_Load(object sender, EventArgs e)
        {
          
        }
        private void TwoPlayerConnectFour_Paint(object sender, PaintEventArgs e)
        {
            BoxDrawer(Box1);
            BoxDrawer(BackgroundBox, System.Drawing.Color.Black);
            BackgroundDrawer();
        }
        private void BackgroundDrawer()
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Black, 5);
            for (int i = 0; i < 8; ++i)
            {
                int xCoor = ((i * 64) + 26);
                graphicsObj.DrawLine(myPen, xCoor, 96, xCoor, 485);
            }
            for (int i = 0; i < 7; ++i)
            {
                int yCoor = (i * 64) + 98;
                graphicsObj.DrawLine(myPen, 26, yCoor, 476, yCoor);
            }
            for (int i = 0; i < 6; ++i)
            {
                for (int j = 0; j < 7; ++j)
                {
                    Data[i, j] = 0;
                }
            }
        }
        private void BoxDrawer(Boxes daBox)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Black, 3);
            if ((daBox.Turn % 2) == 1)
            {
                myPen.Color = System.Drawing.Color.Red;
            }
            Rectangle myRectangle = new Rectangle(daBox.X, daBox.Y, daBox.Width, daBox.Height);
            graphicsObj.DrawRectangle(myPen, myRectangle);
        }
        private void BoxDrawer(Boxes daBox, Color color)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(color, 5);
            Rectangle myRectangle = new Rectangle(daBox.X, daBox.Y, daBox.Width, daBox.Height);
            graphicsObj.DrawRectangle(myPen, myRectangle);

        }
        private void BoxEraser(Boxes daBox)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.SystemColors.Control, 3);
            Rectangle myRectangle = new Rectangle(daBox.X, daBox.Y, daBox.Width, daBox.Height);
            graphicsObj.DrawRectangle(myPen, myRectangle);
        }
        //Creates an image when a piece is dropped
        private void PieceDrop(Boxes daBox)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Black, 3);
            if ((daBox.Turn % 2) == 1)
            {
                myPen.Color = System.Drawing.Color.Red;
            }
            int i = FindLowestEmpty(daBox);
            int yCoor = 428 - (i * 64);
            Rectangle myRectangle = new Rectangle(daBox.X, yCoor, daBox.Width, daBox.Height);
            graphicsObj.DrawRectangle(myPen, myRectangle);
        }
        //Finds the lowest empty place, used by various 
        private int FindLowestEmpty(Boxes daBox)
        {
            int i = 0;
            while (Data[i, Box1.Column] != 0)
            {
                i++;
            }
            return i;
        }
        //Updates the Data array when a piece is dropped
        private void DataUpdate(Boxes daBox)
        {
            int i = FindLowestEmpty(daBox);
            if (daBox.Turn % 2 == 0)
                Data[i, daBox.Column] = 2;
            else
            {
                Data[i, daBox.Column] = 1;
            }
            CheckFourInARow(i, daBox.Column);
        }
        //Checks the values around the dropped piece for win
        private void CheckFourInARow(int currentRow, int currentColumn)
        {
            int currentValue = Data [currentRow, currentColumn];
            for (int rowDirection = -1; rowDirection <= 1; ++rowDirection)
            {
                for (int columnDirection = -1; columnDirection <= 1; ++columnDirection)
                {
                    bool connectFour = CheckSpot(rowDirection, columnDirection, currentValue, currentRow, currentColumn);
                    label4.Text = connectFour.ToString();
                }
            }
        }
        //Uses the Values from CheckFourInARow to check further spots
        private bool CheckSpot(int rowDirection, int columnDirection, int currentValue, int currentRow, int currentColumn)
        {
            bool match = false;
            int row = rowDirection + currentRow;
            int column = columnDirection + currentColumn;
            int numberInARow = 1;
            while ((row >= 0) && (column >= 0) && (row <= 5) && (column <= 6) && (numberInARow < 4) && 
                (rowDirection !=0) && (columnDirection != 0))
            {
                if ((Data[row, column] == currentValue) )
                {
                    row = rowDirection + row;
                    column = columnDirection + column;
                    ++numberInARow;
                    label2.Text = numberInARow.ToString();
                }
                else
                {
                    numberInARow = 20;
                }
            }
            if (numberInARow == 4)
            {
                label1.Text = "We have a winner!";
            }
            return match;
        }
        private void TwoPlayerConnectFour_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode.Equals(Keys.Right) && (Box1.X != 417))
            {
                BoxEraser(Box1);
                Box1.X = Box1.X + 64;
                BoxDrawer(Box1);
                Box1.Column = Box1.Column + 1;
            }
            else if (e.KeyCode.Equals(Keys.Left) && (Box1.X != 33))
            {
                BoxEraser(Box1);
                Box1.X = Box1.X - 64;
                BoxDrawer(Box1);
                Box1.Column = Box1.Column - 1;
            }
            else if ((e.KeyCode.Equals(Keys.Enter) || e.KeyCode.Equals(Keys.Down)) && (Data[5, Box1.Column] == 0))
            {
                PieceDrop(Box1);
                DataUpdate(Box1);
                Box1.Turn = Box1.Turn + 1;
                BoxDrawer(Box1);
                label3.Text = Data[0, Box1.Column].ToString();
            }

        }
    }
    class Boxes
    {
        public int X { get; set; }
        public int Width { get; set; }
        public int Y { get; set; }
        public int Height { get; set; }
        public int Turn { get; set; }
        public int Column { get; set; }

        public Boxes()
        {
            X = 33;
            Width = 50;
            Y = 25;
            Height = 50;
            Turn = 15;
            Column = 0;
        }
        public Boxes(int x, int y, int width, int height)
        {
            this.X = x;
            this.Y = y;
            this.Width = width;
            this.Height = height;
        }
    }

}
