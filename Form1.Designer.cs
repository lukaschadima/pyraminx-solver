namespace Pyraminx_solver
{
    partial class Form1
    {
        /// <summary>
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód generovaný Návrhářem Windows Form

        /// <summary>
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.movesTable = new System.Windows.Forms.TableLayoutPanel();
            this.popisek = new System.Windows.Forms.Label();
            this.ovladaniTable = new System.Windows.Forms.TableLayoutPanel();
            this.startButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.scrambleLabel = new System.Windows.Forms.Label();
            this.playButton = new System.Windows.Forms.Button();
            this.randomButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.pyraminxPictureBox = new System.Windows.Forms.PictureBox();
            this.hintPictureBox = new System.Windows.Forms.PictureBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.movesTable.SuspendLayout();
            this.ovladaniTable.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pyraminxPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hintPictureBox)).BeginInit();
            this.tableLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.545455F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 88.67083F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.868867F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 8F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 66.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 21.5F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 4F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1199, 749);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.movesTable, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ovladaniTable, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(57, 560);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 56.09756F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 43.90244F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1056, 155);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // movesTable
            // 
            this.movesTable.ColumnCount = 17;
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 13.45337F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 5.409163F));
            this.movesTable.Controls.Add(this.popisek, 0, 0);
            this.movesTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.movesTable.Location = new System.Drawing.Point(3, 89);
            this.movesTable.Name = "movesTable";
            this.movesTable.RowCount = 1;
            this.movesTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.movesTable.Size = new System.Drawing.Size(1050, 63);
            this.movesTable.TabIndex = 0;
            // 
            // popisek
            // 
            this.popisek.AutoSize = true;
            this.popisek.Dock = System.Windows.Forms.DockStyle.Fill;
            this.popisek.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.popisek.Location = new System.Drawing.Point(3, 0);
            this.popisek.Name = "popisek";
            this.popisek.Size = new System.Drawing.Size(135, 63);
            this.popisek.TabIndex = 0;
            this.popisek.Text = "navolte vstup";
            this.popisek.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ovladaniTable
            // 
            this.ovladaniTable.ColumnCount = 6;
            this.ovladaniTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.817706F));
            this.ovladaniTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.817706F));
            this.ovladaniTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.09456F));
            this.ovladaniTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.069099F));
            this.ovladaniTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.86183F));
            this.ovladaniTable.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45.06551F));
            this.ovladaniTable.Controls.Add(this.startButton, 0, 0);
            this.ovladaniTable.Controls.Add(this.resetButton, 1, 0);
            this.ovladaniTable.Controls.Add(this.label2, 4, 0);
            this.ovladaniTable.Controls.Add(this.scrambleLabel, 5, 0);
            this.ovladaniTable.Controls.Add(this.playButton, 3, 0);
            this.ovladaniTable.Controls.Add(this.randomButton, 2, 0);
            this.ovladaniTable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ovladaniTable.Location = new System.Drawing.Point(3, 3);
            this.ovladaniTable.Name = "ovladaniTable";
            this.ovladaniTable.RowCount = 1;
            this.ovladaniTable.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.ovladaniTable.Size = new System.Drawing.Size(1050, 80);
            this.ovladaniTable.TabIndex = 1;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.Color.Lime;
            this.startButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.startButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.Location = new System.Drawing.Point(3, 3);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(83, 74);
            this.startButton.TabIndex = 0;
            this.startButton.Text = "Solve";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.BackColor = System.Drawing.Color.DodgerBlue;
            this.resetButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resetButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resetButton.Location = new System.Drawing.Point(92, 3);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(83, 74);
            this.resetButton.TabIndex = 1;
            this.resetButton.Text = "Reset";
            this.resetButton.UseVisualStyleBackColor = false;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(388, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 80);
            this.label2.TabIndex = 3;
            this.label2.Text = "Zvolený \nscramble:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // scrambleLabel
            // 
            this.scrambleLabel.AutoSize = true;
            this.scrambleLabel.Dock = System.Windows.Forms.DockStyle.Left;
            this.scrambleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scrambleLabel.Location = new System.Drawing.Point(535, 0);
            this.scrambleLabel.Name = "scrambleLabel";
            this.scrambleLabel.Size = new System.Drawing.Size(0, 80);
            this.scrambleLabel.TabIndex = 4;
            this.scrambleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // playButton
            // 
            this.playButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.playButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.playButton.Enabled = false;
            this.playButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playButton.Location = new System.Drawing.Point(308, 3);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(74, 74);
            this.playButton.TabIndex = 5;
            this.playButton.Text = "Play solution";
            this.playButton.UseVisualStyleBackColor = false;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // randomButton
            // 
            this.randomButton.BackColor = System.Drawing.Color.Yellow;
            this.randomButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.randomButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.randomButton.Location = new System.Drawing.Point(181, 3);
            this.randomButton.Name = "randomButton";
            this.randomButton.Size = new System.Drawing.Size(121, 74);
            this.randomButton.TabIndex = 2;
            this.randomButton.Text = "Random scramble";
            this.randomButton.UseVisualStyleBackColor = false;
            this.randomButton.Click += new System.EventHandler(this.randomButton_Click);
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.pyraminxPictureBox, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.hintPictureBox, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(57, 62);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 492F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(1056, 492);
            this.tableLayoutPanel3.TabIndex = 4;
            // 
            // pyraminxPictureBox
            // 
            this.pyraminxPictureBox.BackColor = System.Drawing.Color.Black;
            this.pyraminxPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pyraminxPictureBox.InitialImage = null;
            this.pyraminxPictureBox.Location = new System.Drawing.Point(3, 3);
            this.pyraminxPictureBox.Name = "pyraminxPictureBox";
            this.pyraminxPictureBox.Size = new System.Drawing.Size(522, 486);
            this.pyraminxPictureBox.TabIndex = 1;
            this.pyraminxPictureBox.TabStop = false;
            this.pyraminxPictureBox.Paint += new System.Windows.Forms.PaintEventHandler(this.pyraminxPictureBox_Paint);
            // 
            // hintPictureBox
            // 
            this.hintPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.hintPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hintPictureBox.Location = new System.Drawing.Point(531, 3);
            this.hintPictureBox.Name = "hintPictureBox";
            this.hintPictureBox.Size = new System.Drawing.Size(522, 486);
            this.hintPictureBox.TabIndex = 2;
            this.hintPictureBox.TabStop = false;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.label3, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(57, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1056, 53);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 28F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(426, 53);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pyraminx solver";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(531, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(522, 53);
            this.label3.TabIndex = 1;
            this.label3.Text = resources.GetString("label3.Text");
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1199, 749);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Pyraminx solver";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.movesTable.ResumeLayout(false);
            this.movesTable.PerformLayout();
            this.ovladaniTable.ResumeLayout(false);
            this.ovladaniTable.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pyraminxPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hintPictureBox)).EndInit();
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel movesTable;
        private System.Windows.Forms.Label popisek;
        private System.Windows.Forms.TableLayoutPanel ovladaniTable;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label scrambleLabel;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Button randomButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.PictureBox pyraminxPictureBox;
        private System.Windows.Forms.PictureBox hintPictureBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
    }
}

