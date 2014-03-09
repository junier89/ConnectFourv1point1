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
        Box Box1 = new Box();
        Box BackgroundBox = new Box(0, 0, 500, 500);
        public TwoPlayerConnectFour()
        {
            InitializeComponent();
        }

        private void TwoPlayerConnectFour_Load(object sender, EventArgs e)
        {
            for (var row = 0; row < 6; row++)
            {
                for (int column = 0; column < 7; column++)
                {
                    Data[row, column] = 0;
                }
            } 
        }
        private void TwoPlayerConnectFour_Paint(object sender, PaintEventArgs e)
        {
            BoxDrawer(Box1);
            BoxDrawer(BackgroundBox, System.Drawing.Color.Black);
            BackgroundDrawer();
        }
        private void BackgroundDrawer()
        {
            var graphicsObj = this.CreateGraphics();
            var myPen = new Pen(System.Drawing.Color.Black, 5);
            for (var i = 0; i < 8; ++i)
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
        private void BoxDrawer(Box daBox)
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
        private void BoxDrawer(Box daBox, Color color)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(color, 5);
            Rectangle myRectangle = new Rectangle(daBox.X, daBox.Y, daBox.Width, daBox.Height);
            graphicsObj.DrawRectangle(myPen, myRectangle);

        }
        private void BoxEraser(Box daBox)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.SystemColors.Control, 3);
            Rectangle myRectangle = new Rectangle(daBox.X, daBox.Y, daBox.Width, daBox.Height);
            graphicsObj.DrawRectangle(myPen, myRectangle);
        }
        //Creates an image when a piece is dropped
        private void PieceDrop(Box daBox)
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
            DataUpdate(daBox, i);
        }
        //Finds the lowest empty place, used by various 
        private int FindLowestEmpty(Box daBox)
        {
            int i = 0;
            while (Data[i, daBox.Column] > 0)
            {
                ++i;
            }
            label1.Text = label1.Text + i.ToString() + ", ";
            return i;
        }
        //Updates the Data array when a piece is dropped
        private void DataUpdate(Box daBox, int i)
        {
            if (daBox.Turn % 2 == 0)
            {
                Data[i, daBox.Column] = 2;
            }
            else
            {
                Data[i, daBox.Column] = 1;
            }
            CheckFourInARow(i, daBox.Column);
        }
        //Checks the values around the dropped piece for win
        private void CheckFourInARow(int currentRow, int currentColumn)
        {
            for (int rowDirection = -1; rowDirection <= 1; ++rowDirection)
            {
                for (int columnDirection = -1; columnDirection <= 1; ++columnDirection)
                {
                    CheckSpot(rowDirection, columnDirection, currentRow, currentColumn);
                }
            }
        }
        //Uses the Values from CheckFourInARow to check further spots
        private void CheckSpot(int rowDirection, int columnDirection, int currentRow, int currentColumn)
        {
            int currentValue = Data[currentRow, currentColumn];
            int row = rowDirection + currentRow;
            int column = columnDirection + currentColumn;
            int numberInARow = 1;
            while ((row >= 0) && (column >= 0) && (row <= 5) && (column <= 6) && (numberInARow < 4) && 
                ((rowDirection != 0) || (columnDirection != 0)))
            {
                if ((Data[row, column] == currentValue) )
                {
                    row = rowDirection + row;
                    column = columnDirection + column;
                    numberInARow++;
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
        }
        private void TwoPlayerConnectFour_KeyUp(object sender, KeyEventArgs e)
        {
            var isOnLeftSide = (Box1.X == 417);
            var isOnRightSide = (Box1.X == 33);
            var columnIsFull = (Data[5, Box1.Column] == 0);
            switch (e.KeyCode)
            {
                case Keys.Right:
                    if (!isOnLeftSide)
                        MoveBoxHorizontally(64, 1);
                    break;
                case Keys.Left:
                    if(!isOnRightSide)
                        MoveBoxHorizontally(-64, -1);
                    break;
                case Keys.Enter:
                case Keys.Down:
                    if (!columnIsFull)
                    {
                        PieceDrop(Box1);
                        Box1.Turn = Box1.Turn + 1;
                        BoxDrawer(Box1);
                        label3.Text = Data[0, Box1.Column].ToString();
                    }
                    break;
            }
        }

        private void MoveBoxHorizontally(int horizontalOffset, int columnOffset)
        {
            BoxEraser(Box1);
            Box1.X += horizontalOffset;
            BoxDrawer(Box1);
            Box1.Column += columnOffset;
        }
    }
}
