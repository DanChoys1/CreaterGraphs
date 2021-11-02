
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
            this.shortestPathTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(745, 471);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDown);
            // 
            // addCircleButton
            // 
            this.addCircleButton.Location = new System.Drawing.Point(12, 477);
            this.addCircleButton.Name = "addCircleButton";
            this.addCircleButton.Size = new System.Drawing.Size(125, 23);
            this.addCircleButton.TabIndex = 2;
            this.addCircleButton.Text = "Добавить вершину";
            this.addCircleButton.UseVisualStyleBackColor = true;
            this.addCircleButton.Click += new System.EventHandler(this.addCircleButton_Click);
            // 
            // addArcButton
            // 
            this.addArcButton.Location = new System.Drawing.Point(143, 477);
            this.addArcButton.Name = "addArcButton";
            this.addArcButton.Size = new System.Drawing.Size(125, 23);
            this.addArcButton.TabIndex = 4;
            this.addArcButton.Text = "Добавить дугу";
            this.addArcButton.UseVisualStyleBackColor = true;
            this.addArcButton.Click += new System.EventHandler(this.addLineButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(274, 477);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(125, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Удалить";
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // findShortestPathButton
            // 
            this.findShortestPathButton.Location = new System.Drawing.Point(405, 477);
            this.findShortestPathButton.Name = "findShortestPathButton";
            this.findShortestPathButton.Size = new System.Drawing.Size(156, 23);
            this.findShortestPathButton.TabIndex = 6;
            this.findShortestPathButton.Text = "Найти кратчайший путь";
            this.findShortestPathButton.UseVisualStyleBackColor = true;
            this.findShortestPathButton.Click += new System.EventHandler(this.findShortestPathButton_Click);
            // 
            // shortestPathTextBox
            // 
            this.shortestPathTextBox.Enabled = false;
            this.shortestPathTextBox.Location = new System.Drawing.Point(567, 478);
            this.shortestPathTextBox.Name = "shortestPathTextBox";
            this.shortestPathTextBox.Size = new System.Drawing.Size(178, 23);
            this.shortestPathTextBox.TabIndex = 1000000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(748, 510);
            this.Controls.Add(this.shortestPathTextBox);
            this.Controls.Add(this.findShortestPathButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addArcButton);
            this.Controls.Add(this.addCircleButton);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button addCircleButton;
        private System.Windows.Forms.Button addArcButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button findShortestPathButton;
        private System.Windows.Forms.TextBox shortestPathTextBox;
    }
}

