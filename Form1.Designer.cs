
namespace CreaterGraphs {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.addCircleButton = new System.Windows.Forms.Button();
            this.addArcButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.findShortestPathButton = new System.Windows.Forms.Button();
            this.matrixDataGridView = new System.Windows.Forms.DataGridView();
            this.lenghtPathDataGridView = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.countColumnNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.shortestPathTableButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cleanTableButton = new System.Windows.Forms.Button();
            this.deleteTableButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lenghtPathDataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.countColumnNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(798, 621);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            // 
            // addCircleButton
            // 
            this.addCircleButton.Location = new System.Drawing.Point(12, 631);
            this.addCircleButton.Name = "addCircleButton";
            this.addCircleButton.Size = new System.Drawing.Size(125, 23);
            this.addCircleButton.TabIndex = 2;
            this.addCircleButton.Text = "Добавить вершину";
            this.addCircleButton.UseVisualStyleBackColor = true;
            this.addCircleButton.Click += new System.EventHandler(this.addCircleButton_Click);
            // 
            // addArcButton
            // 
            this.addArcButton.Location = new System.Drawing.Point(143, 631);
            this.addArcButton.Name = "addArcButton";
            this.addArcButton.Size = new System.Drawing.Size(125, 23);
            this.addArcButton.TabIndex = 4;
            this.addArcButton.Text = "Добавить дугу";
            this.addArcButton.UseVisualStyleBackColor = true;
            this.addArcButton.Click += new System.EventHandler(this.addLineButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(274, 631);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(125, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // findShortestPathButton
            // 
            this.findShortestPathButton.Location = new System.Drawing.Point(405, 631);
            this.findShortestPathButton.Name = "findShortestPathButton";
            this.findShortestPathButton.Size = new System.Drawing.Size(223, 23);
            this.findShortestPathButton.TabIndex = 6;
            this.findShortestPathButton.Text = "Найти кратчайшие пути от вершины";
            this.findShortestPathButton.UseVisualStyleBackColor = true;
            this.findShortestPathButton.Click += new System.EventHandler(this.findShortestPathButton_Click);
            // 
            // matrixDataGridView
            // 
            this.matrixDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matrixDataGridView.Location = new System.Drawing.Point(804, 0);
            this.matrixDataGridView.Name = "matrixDataGridView";
            this.matrixDataGridView.RowTemplate.Height = 25;
            this.matrixDataGridView.Size = new System.Drawing.Size(667, 471);
            this.matrixDataGridView.TabIndex = 1000001;
            this.matrixDataGridView.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.changedCell_gridView);
            // 
            // lenghtPathDataGridView
            // 
            this.lenghtPathDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lenghtPathDataGridView.Location = new System.Drawing.Point(804, 501);
            this.lenghtPathDataGridView.Name = "lenghtPathDataGridView";
            this.lenghtPathDataGridView.RowTemplate.Height = 25;
            this.lenghtPathDataGridView.Size = new System.Drawing.Size(672, 74);
            this.lenghtPathDataGridView.TabIndex = 1000002;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(805, 478);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 15);
            this.label1.TabIndex = 1000003;
            this.label1.Text = "Коротчайшие пути";
            // 
            // countColumnNumericUpDown
            // 
            this.countColumnNumericUpDown.Location = new System.Drawing.Point(1090, 586);
            this.countColumnNumericUpDown.Name = "countColumnNumericUpDown";
            this.countColumnNumericUpDown.Size = new System.Drawing.Size(82, 23);
            this.countColumnNumericUpDown.TabIndex = 1000004;
            this.countColumnNumericUpDown.ValueChanged += new System.EventHandler(this.countColumnNumericUpDown_ValueChanged);
            // 
            // shortestPathTableButton
            // 
            this.shortestPathTableButton.Location = new System.Drawing.Point(962, 634);
            this.shortestPathTableButton.Name = "shortestPathTableButton";
            this.shortestPathTableButton.Size = new System.Drawing.Size(171, 23);
            this.shortestPathTableButton.TabIndex = 1000005;
            this.shortestPathTableButton.Text = "Найти кратчайшие пути";
            this.shortestPathTableButton.UseVisualStyleBackColor = true;
            this.shortestPathTableButton.Click += new System.EventHandler(this.shortestPathTableButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(962, 588);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 15);
            this.label2.TabIndex = 1000006;
            this.label2.Text = "Количество вершин:";
            // 
            // cleanTableButton
            // 
            this.cleanTableButton.Location = new System.Drawing.Point(1139, 634);
            this.cleanTableButton.Name = "cleanTableButton";
            this.cleanTableButton.Size = new System.Drawing.Size(125, 23);
            this.cleanTableButton.TabIndex = 1000007;
            this.cleanTableButton.Text = "Очистить таблицу";
            this.cleanTableButton.UseVisualStyleBackColor = true;
            this.cleanTableButton.Click += new System.EventHandler(this.cleanTableButton_Click);
            // 
            // deleteTableButton
            // 
            this.deleteTableButton.Location = new System.Drawing.Point(1270, 634);
            this.deleteTableButton.Name = "deleteTableButton";
            this.deleteTableButton.Size = new System.Drawing.Size(110, 23);
            this.deleteTableButton.TabIndex = 1000008;
            this.deleteTableButton.Text = "Удалить таблицу";
            this.deleteTableButton.UseVisualStyleBackColor = true;
            this.deleteTableButton.Click += new System.EventHandler(this.deleteTableButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1178, 588);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(107, 15);
            this.label3.TabIndex = 1000009;
            this.label3.Text = "Путь от вершины:";
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1291, 586);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(89, 23);
            this.numericUpDown1.TabIndex = 1000010;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1483, 666);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.deleteTableButton);
            this.Controls.Add(this.cleanTableButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.shortestPathTableButton);
            this.Controls.Add(this.countColumnNumericUpDown);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lenghtPathDataGridView);
            this.Controls.Add(this.matrixDataGridView);
            this.Controls.Add(this.findShortestPathButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addArcButton);
            this.Controls.Add(this.addCircleButton);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matrixDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lenghtPathDataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.countColumnNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button addCircleButton;
        private System.Windows.Forms.Button addArcButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button findShortestPathButton;
        private System.Windows.Forms.DataGridView matrixDataGridView;
        private System.Windows.Forms.DataGridView lenghtPathDataGridView;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown countColumnNumericUpDown;
        private System.Windows.Forms.Button shortestPathTableButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button cleanTableButton;
        private System.Windows.Forms.Button deleteTableButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
    }
}

