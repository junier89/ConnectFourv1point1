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
    public partial class OpeningWindow : Form
    {
        public OpeningWindow()
        {
            InitializeComponent();
        }

        private void OpeningWindow_Load(object sender, EventArgs e)
        {

        }

        private void TwoPlayerConnectFour_Click(object sender, EventArgs e)
        {
            TwoPlayerConnectFour twoC4 = new TwoPlayerConnectFour();
            twoC4.Show();
        }

        private void TwoPlayerTicTacToe_Click(object sender, EventArgs e)
        {
            TwoPlayerTicTacToe twoTTT = new TwoPlayerTicTacToe();
            twoTTT.Show();
        }
    }
}
