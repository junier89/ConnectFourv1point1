namespace ConnectFour_v1._1
{
    partial class OpeningWindow
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
            this.TwoPlayerConnectFour = new System.Windows.Forms.Button();
            this.Prompt = new System.Windows.Forms.Label();
            this.TwoPlayerTicTacToe = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TwoPlayerConnectFour
            // 
            this.TwoPlayerConnectFour.Location = new System.Drawing.Point(76, 71);
            this.TwoPlayerConnectFour.Name = "TwoPlayerConnectFour";
            this.TwoPlayerConnectFour.Size = new System.Drawing.Size(152, 23);
            this.TwoPlayerConnectFour.TabIndex = 0;
            this.TwoPlayerConnectFour.Text = "2 Player Connect Four";
            this.TwoPlayerConnectFour.UseVisualStyleBackColor = true;
            this.TwoPlayerConnectFour.Click += new System.EventHandler(this.TwoPlayerConnectFour_Click);
            // 
            // Prompt
            // 
            this.Prompt.AutoSize = true;
            this.Prompt.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Prompt.Location = new System.Drawing.Point(73, 55);
            this.Prompt.Name = "Prompt";
            this.Prompt.Size = new System.Drawing.Size(155, 13);
            this.Prompt.TabIndex = 1;
            this.Prompt.Text = "Would you like to play a game?";
            this.Prompt.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // TwoPlayerTicTacToe
            // 
            this.TwoPlayerTicTacToe.Location = new System.Drawing.Point(76, 100);
            this.TwoPlayerTicTacToe.Name = "TwoPlayerTicTacToe";
            this.TwoPlayerTicTacToe.Size = new System.Drawing.Size(152, 23);
            this.TwoPlayerTicTacToe.TabIndex = 2;
            this.TwoPlayerTicTacToe.Text = "2 Player Tic Tac Toe";
            this.TwoPlayerTicTacToe.UseVisualStyleBackColor = true;
            this.TwoPlayerTicTacToe.Click += new System.EventHandler(this.TwoPlayerTicTacToe_Click);
            // 
            // OpeningWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.TwoPlayerTicTacToe);
            this.Controls.Add(this.Prompt);
            this.Controls.Add(this.TwoPlayerConnectFour);
            this.Name = "OpeningWindow";
            this.Text = "Welcome!";
            this.Load += new System.EventHandler(this.OpeningWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TwoPlayerConnectFour;
        private System.Windows.Forms.Label Prompt;
        private System.Windows.Forms.Button TwoPlayerTicTacToe;
    }
}

