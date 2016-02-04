namespace Snake
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            this.mainAreaPb = new System.Windows.Forms.PictureBox();
            this.scoreLabel = new System.Windows.Forms.Label();
            this.pointsLabel = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            this.gameOverLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.mainAreaPb)).BeginInit();
            this.SuspendLayout();
            // 
            // mainAreaPb
            // 
            this.mainAreaPb.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.mainAreaPb.Location = new System.Drawing.Point(27, 31);
            this.mainAreaPb.Name = "mainAreaPb";
            this.mainAreaPb.Size = new System.Drawing.Size(617, 504);
            this.mainAreaPb.TabIndex = 0;
            this.mainAreaPb.TabStop = false;
            this.mainAreaPb.Paint += new System.Windows.Forms.PaintEventHandler(this.mainAreaPb_Paint);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scoreLabel.Location = new System.Drawing.Point(27, 553);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(65, 26);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Score:";
            // 
            // pointsLabel
            // 
            this.pointsLabel.AutoSize = true;
            this.pointsLabel.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pointsLabel.Location = new System.Drawing.Point(112, 553);
            this.pointsLabel.Name = "pointsLabel";
            this.pointsLabel.Size = new System.Drawing.Size(0, 26);
            this.pointsLabel.TabIndex = 2;
            // 
            // gameTimer
            // 
            this.gameTimer.Enabled = true;
            // 
            // gameOverLabel
            // 
            this.gameOverLabel.AutoSize = true;
            this.gameOverLabel.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.gameOverLabel.Location = new System.Drawing.Point(137, 100);
            this.gameOverLabel.Name = "gameOverLabel";
            this.gameOverLabel.Size = new System.Drawing.Size(0, 33);
            this.gameOverLabel.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 606);
            this.Controls.Add(this.gameOverLabel);
            this.Controls.Add(this.pointsLabel);
            this.Controls.Add(this.scoreLabel);
            this.Controls.Add(this.mainAreaPb);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Snake";
            ((System.ComponentModel.ISupportInitialize)(this.mainAreaPb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainAreaPb;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label pointsLabel;
        private System.Windows.Forms.Timer gameTimer;
        private System.Windows.Forms.Label gameOverLabel;
    }
}

