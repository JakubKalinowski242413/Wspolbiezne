namespace Kule
{
    partial class KuleWidok
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timer1 = new System.Windows.Forms.Timer(components);
            basen = new Panel();
            StartStop = new Button();
            ballCount = new NumericUpDown();
            label1 = new Label();
            label2 = new Label();
            collisionCounter = new TextBox();
            ((System.ComponentModel.ISupportInitialize)ballCount).BeginInit();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 50;
            timer1.Tick += AktualizujKulki;
            // 
            // basen
            // 
            basen.BackColor = SystemColors.ControlLight;
            basen.Location = new Point(10, 10);
            basen.Name = "basen";
            basen.Size = new Size(760, 440);
            basen.TabIndex = 0;
            // 
            // StartStop
            // 
            StartStop.BackColor = Color.Lime;
            StartStop.Cursor = Cursors.Hand;
            StartStop.Font = new Font("Segoe UI", 24F, FontStyle.Regular, GraphicsUnit.Point);
            StartStop.Location = new Point(775, 350);
            StartStop.Name = "StartStop";
            StartStop.Size = new Size(200, 100);
            StartStop.TabIndex = 1;
            StartStop.Text = "START";
            StartStop.UseVisualStyleBackColor = false;
            StartStop.Click += StartStop_Click;
            // 
            // ballCount
            // 
            ballCount.Cursor = Cursors.Hand;
            ballCount.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ballCount.Location = new Point(775, 40);
            ballCount.Name = "ballCount";
            ballCount.Size = new Size(200, 32);
            ballCount.TabIndex = 2;
            ballCount.TextAlign = HorizontalAlignment.Right;
            ballCount.Value = new decimal(new int[] { 5, 0, 0, 0 });
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(775, 10);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(101, 25);
            label1.TabIndex = 3;
            label1.Text = "Ball count";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label2.Location = new Point(775, 75);
            label2.Margin = new Padding(0);
            label2.Name = "label2";
            label2.Size = new Size(145, 25);
            label2.TabIndex = 4;
            label2.Text = "Collision count";
            // 
            // collisionCounter
            // 
            collisionCounter.Enabled = false;
            collisionCounter.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            collisionCounter.Location = new Point(775, 103);
            collisionCounter.Name = "collisionCounter";
            collisionCounter.ReadOnly = true;
            collisionCounter.Size = new Size(200, 29);
            collisionCounter.TabIndex = 5;
            collisionCounter.Text = "0";
            collisionCounter.TextAlign = HorizontalAlignment.Right;
            // 
            // KuleWidok
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ControlDarkDark;
            ClientSize = new Size(984, 461);
            Controls.Add(collisionCounter);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ballCount);
            Controls.Add(StartStop);
            Controls.Add(basen);
            Margin = new Padding(3, 2, 3, 2);
            Name = "KuleWidok";
            Text = "Form1";
            Paint += RysujKulki;
            ((System.ComponentModel.ISupportInitialize)ballCount).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private Panel basen;
        private Button StartStop;
        private NumericUpDown ballCount;
        private Label label1;
        private Label label2;
        private TextBox collisionCounter;
    }
}