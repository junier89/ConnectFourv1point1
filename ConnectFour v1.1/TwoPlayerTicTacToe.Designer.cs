﻿namespace ConnectFour_v1._1
{
    partial class TwoPlayerTicTacToe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TwoPlayerTicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 330);
            this.Name = "TwoPlayerTicTacToe";
            this.Text = "TwoPlayerTicTacToe";
            this.Load += new System.EventHandler(this.TwoPlayerTicTacToe_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TwoPlayerTicTacToe_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TwoPlayerTicTacToe_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}