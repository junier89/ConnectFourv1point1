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
    public partial class TwoPlayerTicTacToe : Form
    {
        Locations singletonLocation = new Locations();
        int[,] board = { { 0, 0, 0 }, { 0, 0, 0 }, { 0, 0, 0 } };
        public TwoPlayerTicTacToe()
        {
            InitializeComponent();
        }

        private void TwoPlayerTicTacToe_Load(object sender, EventArgs e)
        {
        }
        private void BackgroundDrawer()
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(System.Drawing.Color.Black, 14);
            graphicsObj.DrawLine(myPen, 100, 27, 100, 253);
            graphicsObj.DrawLine(myPen, 180, 27, 180, 253);
            graphicsObj.DrawLine(myPen, 27, 100, 253, 100);
            graphicsObj.DrawLine(myPen, 27, 180, 253, 180);
        }
        private void CreateAnX(Locations theSpot, Color color)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(color, 10);
            int Corner1x = 33 + (80 * theSpot.Column);
            int Corner1y = 33 + (80 * theSpot.Row);
            int Corner2x = 87 + (80 * theSpot.Column);
            int Corner2y = 87 + (80 * theSpot.Row);
            graphicsObj.DrawLine(myPen, Corner1x, Corner1y, Corner2x, Corner2y);
            graphicsObj.DrawLine(myPen, Corner2x, Corner1y, Corner1x, Corner2y);
        }
        private void CreateAnO(Locations theSpot, Color color)
        {
            System.Drawing.Graphics graphicsObj;
            graphicsObj = this.CreateGraphics();
            Pen myPen = new Pen(color, 10);
            int CornerX = 33 + (80 * theSpot.Column);
            int CornerY = 33 + (80 * theSpot.Row);
            graphicsObj.DrawEllipse(myPen, CornerX, CornerY, 54, 54);
        }
        private void RemovePiece(Locations theSpot)
        {
            board[theSpot.Column, theSpot.Row] = theSpot.Turn;
            if (theSpot.Turn % 2 == 1)
            {
                CreateAnX(theSpot, System.Drawing.SystemColors.Control);
            }
            else
            {
                CreateAnO(theSpot, System.Drawing.SystemColors.Control);
            }
        }
        private void MovedPiece(Locations theSpot)
        {
            if (theSpot.Turn % 2 == 1)
            {
                CreateAnX(theSpot, System.Drawing.Color.Purple);
            }
            else
            {
                CreateAnO(theSpot, System.Drawing.Color.Purple);
            }
        }
        private void PlacePiece(Locations theSpot)
        {
            if (theSpot.Turn % 2 == 1)
            {
                CreateAnX(theSpot, System.Drawing.Color.Blue);
            }
            else
            {
                CreateAnO(theSpot, System.Drawing.Color.Red);
            }
            theSpot.Turn += 1;
        }
        private Boolean EmptyCheck(Locations theSpot, int horizontalMovement, int verticalMovement)
        {
            bool valid = false;
            if (board[theSpot.Column + horizontalMovement, theSpot.Row + verticalMovement] == 0)
            {
                valid = true;
            }
            return valid;
        }
        private void MovementAfterPlace(Locations theSpot)
        {
            if (theSpot.Column != 2)
            {
                theSpot.Column += 1;
            }
        }
        private void TwoPlayerTicTacToe_Paint(object sender, PaintEventArgs e)
        {
            BackgroundDrawer();
            CreateAnX(singletonLocation, System.Drawing.Color.Purple);
        }

        private void TwoPlayerTicTacToe_KeyDown(object sender, KeyEventArgs e)
        {            
            if (e.KeyCode.Equals(Keys.Right) && EmptyCheck(singletonLocation, 1,0))
            {
                RemovePiece(singletonLocation);
                singletonLocation.Column += 1;
                MovedPiece(singletonLocation);
            }
            else if (e.KeyCode.Equals(Keys.Left) && EmptyCheck(singletonLocation, -1, 0))
            {
                RemovePiece(singletonLocation);
                singletonLocation.Column -= 1;
                MovedPiece(singletonLocation);
            }
            else if (e.KeyCode.Equals(Keys.Down) && EmptyCheck(singletonLocation, 0, 1))
            {
                RemovePiece(singletonLocation);
                singletonLocation.Row += 1;
                MovedPiece(singletonLocation);
            }
            else if (e.KeyCode.Equals(Keys.Up) && EmptyCheck(singletonLocation, 0, -1))
            {
                RemovePiece(singletonLocation);
                singletonLocation.Row -= 1;
                MovedPiece(singletonLocation);
            }
            else if (e.KeyCode.Equals(Keys.Space))
            {
                PlacePiece(singletonLocation);
            }
        }
    }
    class Locations
    {
        public int Column { get; set; }
        public int Row { get; set; }
        public int Turn { get; set; }
        public Locations()
        {
            Column = 0;
            Row = 0;
            Turn = 1;
        }
    }
}
//Need to change how movement works so that it can move with all sides blocked