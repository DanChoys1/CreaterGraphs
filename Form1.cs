using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace CreaterGraphs {
    public partial class Form1 : Form {

        List<Label> vertex = new List<Label>();
        Dictionary<TextBox, List<Label>> line = new Dictionary<TextBox, List<Label>>();

        int[,] matrixLenght = null;
        int[] lenghtPathVertex = null;
        string[] minPath;

        Label previosClickedCircle = null;

        Color keyPressed = Color.Blue;
        Color keyReleased = ColorTranslator.FromHtml("#22ACDC");

        bool isMouseDownLabel = false;
        bool isMouseMovedLabel = false;
        bool isAddCircle = true;
        bool isAddLine = false;
        bool isDelete = false;
        bool isFindShortestPath = false;

        const int BIG_VALUE = 2147483647;

        public Form1() {

            InitializeComponent();
            pictureBox.BackColor = Color.White;

            matrixDataGridView.AllowUserToAddRows = false;
            matrixDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            matrixDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            matrixDataGridView.RowHeadersWidth = 50;

            lenghtPathDataGridView.AllowUserToAddRows = false;
            lenghtPathDataGridView.RowHeadersVisible = false;
            lenghtPathDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            lenghtPathDataGridView.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }


        private void circles_MouseDown(object sender, MouseEventArgs e) {
            isMouseDownLabel = true;
        }

        private void circles_MouseUp(object sender, MouseEventArgs e) {
            isMouseDownLabel = false;
            Label clickedCircle = (Label)sender;

            if (isDelete && !isMouseMovedLabel) {

                List<TextBox> deletedLine = new List<TextBox>();

                foreach (TextBox item in line.Keys) {
                    if (line[item].Contains(clickedCircle)) {
                        deletedLine.Add(item);
                    }
                }

                foreach(TextBox item in deletedLine){
                    deleteLine(item); 
                }

                deleteCircle(clickedCircle);
            }

            if (isAddLine && !isMouseMovedLabel) {

                if (previosClickedCircle == null || previosClickedCircle == clickedCircle) {
                    previosClickedCircle = clickedCircle;
                    previosClickedCircle.BackColor = keyPressed;
                    clickedCircle.BackColor = keyPressed;
                    return;
                }

                foreach(TextBox item in line.Keys) {
                    if (line[item].Contains(previosClickedCircle) && line[item].Contains(clickedCircle)) {
                        previosClickedCircle = clickedCircle;
                        return;
                    }
                }

                clickedCircle.BackColor = keyReleased;
                previosClickedCircle.BackColor = keyReleased;
                addLine(clickedCircle);
            }

            if (isFindShortestPath && !isMouseMovedLabel) {
                Label vertexClicked = (Label)sender;

                matrixLenght = fillMatrixLenght();
                lenghtPathVertex = fillLenghtPathVertex(vertexClicked.TabIndex, vertex.Count);
                findShortestPath(vertexClicked.TabIndex, vertex.Count);

                if(matrixDataGridView.Columns.Count > 0) {
                    while (matrixDataGridView.Rows.Count > 0) {
                        matrixDataGridView.Rows.RemoveAt(0);
                        matrixDataGridView.Columns.RemoveAt(0);
                    }
                    
                }

                for (int i = 0; i < lenghtPathVertex.Length; i++) {
                    matrixDataGridView.Columns.Add(i.ToString(), (i + 1).ToString());
                    
                    matrixDataGridView.Rows.Add();
                    matrixDataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }

                for (int i = 0; i < lenghtPathVertex.Length; i++) {
                    for (int j = 0; j < lenghtPathVertex.Length; j++) {

                        if (matrixLenght[i, j] >= 0) {
                            matrixDataGridView.Rows[i].Cells[j].Value = matrixLenght[i, j];
                        } else {
                            matrixDataGridView.Rows[i].Cells[j].Value = "-";
                        }

                    }
                }

                int width = (matrixDataGridView.Width - matrixDataGridView.RowHeadersWidth) / lenghtPathVertex.Length;
                int height = (matrixDataGridView.Height - matrixDataGridView.ColumnHeadersHeight) / lenghtPathVertex.Length;

                for (int i = 0; i < lenghtPathVertex.Length; i++) {
                    matrixDataGridView.Columns[i].Width = width;
                    matrixDataGridView.Rows[i].Height = height;
                }

                if (lenghtPathDataGridView.Columns.Count > 0) {

                    while (lenghtPathDataGridView.Columns.Count > 0) {
                        lenghtPathDataGridView.Columns.RemoveAt(0);
                    }

                }

                for (int i = 0; i < lenghtPathVertex.Length; i++) {
                    lenghtPathDataGridView.Columns.Add(i.ToString(), (i + 1).ToString());

                    if (i == 0) {
                        lenghtPathDataGridView.Rows.Add();
                    }

                    if (lenghtPathVertex[i] < BIG_VALUE) {
                        lenghtPathDataGridView.Columns[i].HeaderText = lenghtPathDataGridView.Columns[i].HeaderText + " (" + minPath[i] + ")";
                        lenghtPathDataGridView.Rows[0].Cells[i].Value = lenghtPathVertex[i];
                    } else {
                        lenghtPathDataGridView.Rows[0].Cells[i].Value = "-";
                    }
                }

                if (lenghtPathDataGridView.Width > lenghtPathDataGridView.Columns[0].Width * lenghtPathDataGridView.Columns.Count) {
                    width = lenghtPathDataGridView.Width / lenghtPathVertex.Length;

                    for (int i = 0; i < lenghtPathVertex.Length; i++) {
                        lenghtPathDataGridView.Columns[i].Width = width;
                    }
                }

                 height = lenghtPathDataGridView.Height - lenghtPathDataGridView.ColumnHeadersHeight - 15;
                 lenghtPathDataGridView.Rows[0].Height = height;

            }

            isMouseMovedLabel = false;
        }

        private void circles_MouseMove(object sender, MouseEventArgs e) {
            if (isMouseDownLabel) {
                Point move = PointToClient(Control.MousePosition);

                Label movedCircle = (Label)sender;

                if (move.X > 0 && move.Y > -5 && move.X < (pictureBox.Size.Width - 30) &&
                    move.Y < (pictureBox.Size.Height - 35)) {

                    List<TextBox> movedLine = new List<TextBox>();

                    foreach (TextBox item in line.Keys) {
                        if (line[item].Contains(movedCircle)) {
                            movedLine.Add(item);
                        }
                    }

                    if (movedLine.Count >= 0) {
                        Graphics gr = pictureBox.CreateGraphics();

                        foreach (TextBox item in movedLine) {
                            int x1 = line[item][0].Location.X;
                            int y1 = line[item][0].Location.Y;
                            int x2 = line[item][1].Location.X;
                            int y2 = line[item][1].Location.Y;

                            gr.DrawLine(new Pen(Color.White, 2), new Point(x1 + 20, y1 + 20), new Point(x2 + 20, y2 + 20));
                        }

                        movedCircle.Location = move;

                        foreach (TextBox item in movedLine) {
                            int x1 = line[item][0].Location.X;
                            int y1 = line[item][0].Location.Y;
                            int x2 = line[item][1].Location.X;
                            int y2 = line[item][1].Location.Y;

                            gr.DrawLine(new Pen(Color.Black, 2), new Point(x1 + 20, y1 + 20), new Point(x2 + 20, y2 + 20));

                            item.Location = new Point((x1 + x2) / 2 + 17, (y1 + y2) / 2 + 17);
                        }

                    } else {
                        movedCircle.Location = move;
                    }

                }

                isMouseMovedLabel = true;
            }

        }

        private void deleteCircle(Label clickedCircle) {
            int index = vertex.IndexOf(clickedCircle);
            vertex.Remove(clickedCircle);
            Controls.Remove(clickedCircle);

            for (int i = index; i < vertex.Count; i++) {
                vertex[i].Text = Convert.ToString((i + 1));
                vertex[i].TabIndex = i ;
            }
        }


        private void line_MouseClick(object sender, MouseEventArgs e) {

            if (isDelete) {
                deleteLine((TextBox)sender);
            }

        }

        private void addLine(Label clickedCircle) {
            int x1 = previosClickedCircle.Location.X;
            int y1 = previosClickedCircle.Location.Y;
            int x2 = clickedCircle.Location.X;
            int y2 = clickedCircle.Location.Y;

            Graphics gr = pictureBox.CreateGraphics();
            gr.DrawLine(new Pen(Color.Black, 2), new Point(x1 + 20, y1 + 20), new Point(x2 + 20, y2 + 20));

            TextBox textBox = new TextBox();
            textBox.AutoSize = true;
            textBox.Location = new Point((x1 + x2) / 2 + 17, (y1 + y2) / 2 + 17);
            textBox.Size = new Size(20, 20);
            textBox.TabIndex = line.Count();
            textBox.BackColor = Color.White;
            textBox.Font = new Font("Segoe UI", 8F, FontStyle.Regular, GraphicsUnit.Point);
            textBox.Text = Convert.ToString(0);
            textBox.ForeColor = Color.Black;
            textBox.MouseClick += new MouseEventHandler(this.line_MouseClick);
            textBox.TextChanged += new EventHandler(this.textBox_TextChanged);

            List<Label> labelList = new List<Label>();
            labelList.Add(previosClickedCircle);
            labelList.Add(clickedCircle);

            line.Add(textBox, labelList);

            Controls.Add(textBox);
            textBox.BringToFront();

            previosClickedCircle = null;
        }

        private void deleteLine(TextBox deletedLine) {
            int x1 = line[deletedLine][0].Location.X;
            int y1 = line[deletedLine][0].Location.Y;
            int x2 = line[deletedLine][1].Location.X;
            int y2 = line[deletedLine][1].Location.Y;

            Graphics gr = pictureBox.CreateGraphics();
            gr.DrawLine(new Pen(Color.White, 2), new Point(x1 + 20, y1 + 20), new Point(x2 + 20, y2 + 20));

            line.Remove(deletedLine);
            Controls.Remove(deletedLine);
        }


        private void pictureBox_MouseDown(object sender, MouseEventArgs e) {
            if (!isMouseDownLabel && isAddCircle && (e.Location.X > 0 && e.Location.Y > -5 &&
                e.Location.X < (pictureBox.Size.Width - 30) && e.Location.Y < (pictureBox.Size.Height - 35))) {

                Label label = new Label();
                label.AutoSize = true;
                label.Location = e.Location;
                label.Size = new Size(30, 30);
                label.TabIndex = vertex.Count();
                label.BackColor = keyReleased;
                label.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
                label.Text = Convert.ToString(vertex.Count() + 1);
                label.MouseDown += new MouseEventHandler(this.circles_MouseDown);
                label.MouseUp += new MouseEventHandler(this.circles_MouseUp);
                label.MouseMove += new MouseEventHandler(this.circles_MouseMove);

                GraphicsPath path = new GraphicsPath();
                path.AddEllipse(0, 5, label.Width, label.Height);

                label.Region = new Region(path);

                vertex.Add(label);

                this.Controls.Add(label);
                label.BringToFront();
            }
        }


        private void addCircleButton_Click(object sender, EventArgs e) {
            isAddCircle = true;
            isAddLine = false;
            isDelete = false;
            isFindShortestPath = false;
        }

        private void addLineButton_Click(object sender, EventArgs e) {
            isAddCircle = false;
            isAddLine = true;
            isDelete = false;
            isFindShortestPath = false;

            previosClickedCircle = null;
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            isAddCircle = false;
            isAddLine = false;
            isDelete = true;
            isFindShortestPath = false;
        }

        private void findShortestPathButton_Click(object sender, EventArgs e) {
            isAddCircle = false;
            isAddLine = false;
            isDelete = false;
            isFindShortestPath = true;
        }


        private int[,] fillMatrixLenght() {
            int[,] newMatrix = new int[vertex.Count, vertex.Count];

            for (int i = 0; i < vertex.Count; i++) {
                for (int j = 0; j < vertex.Count; j++) {
                    newMatrix[i, j] = -1;
                }
            }

            foreach (TextBox item in line.Keys) {
                int vertexIndex1 = line[item][0].TabIndex;
                int vertexIndex2 = line[item][1].TabIndex;

                newMatrix[vertexIndex1, vertexIndex2] = Convert.ToInt32(item.Text);
                newMatrix[vertexIndex2, vertexIndex1] = Convert.ToInt32(item.Text);
            }

            return newMatrix;
        }

        private int[] fillLenghtPathVertex(int startVertex, int count) {
            int[] newLenghtPathVertex = new int[count];
            minPath = new string[vertex.Count];

            for (int i = 0; i < vertex.Count; i++) {
                minPath[i] = (startVertex + 1).ToString();
            }

            for (int i = 0; i < count; i++) {
                newLenghtPathVertex[i] = BIG_VALUE;
            }

            newLenghtPathVertex[startVertex] = 0;
            
            return newLenghtPathVertex;
        }
        
        private void findShortestPath(int startVertex, int count) {

            for (int i = 0; i < count; i++) {

                if( (matrixLenght[startVertex, i] > -1) && (lenghtPathVertex[i] > (matrixLenght[startVertex, i] + lenghtPathVertex[startVertex])) ) {

                    minPath[i] = minPath[startVertex] + "-" + (i + 1).ToString();
                    lenghtPathVertex[i] = matrixLenght[startVertex, i] + lenghtPathVertex[startVertex];

                    findShortestPath(i, count);
                }

            }
        }


        private void textBox_TextChanged(object sender, EventArgs e) {
            TextBox textBox = (TextBox)sender;
            string value = textBox.Text.ToString();

            if (value.Length > 0) {
                try {
                    int i = Convert.ToInt32(value);
                } catch (FormatException) {
                    textBox.Text = "";

                    foreach (char item in value) {
                        if (Char.IsDigit(item)) {
                            textBox.Text += item;
                        }
                    }
                }
            }

        }



        private void countColumnNumericUpDown_ValueChanged(object sender, EventArgs e) {
            NumericUpDown num = (NumericUpDown)sender;
            int count = Convert.ToInt32(num.Value);

            if (matrixDataGridView.Columns.Count < num.Value) {
                
                for (int i = matrixDataGridView.Columns.Count; i < count; i++) {
                    string name = i.ToString();
                    string header = (i + 1).ToString();
                    matrixDataGridView.Columns.Add(name, header);

                    matrixDataGridView.Rows.Add();
                    matrixDataGridView.Rows[i].HeaderCell.Value = (i + 1).ToString();
                }

            }

            if (matrixDataGridView.Columns.Count > num.Value && num.Value > 0 ) {

                for (int i = matrixDataGridView.Columns.Count - 1; i >= count; i--) {
                    matrixDataGridView.Columns.RemoveAt(i);
                    matrixDataGridView.Rows.RemoveAt(i);
                }

            }

            if (num.Value > 0) {
                int width = (matrixDataGridView.Width - matrixDataGridView.RowHeadersWidth) / count;
                int height = (matrixDataGridView.Height - matrixDataGridView.ColumnHeadersHeight) / count;

                for (int i = 0; i < count; i++) {
                    matrixDataGridView.Columns[i].Width = width;
                    matrixDataGridView.Rows[i].Height = height;
                }
            }

            numericUpDown1.Maximum = count;

        }

        private void shortestPathTableButton_Click(object sender, EventArgs e) {

            if (countColumnNumericUpDown.Value > 0) {

                
                    matrixLenght = new int[matrixDataGridView.Columns.Count, matrixDataGridView.Columns.Count];

                    for (int i = 0; i < matrixDataGridView.Columns.Count; i++) {
                        for (int j = 0; j < matrixDataGridView.Rows.Count; j++) {
                            try {

                                if (i != j && matrixDataGridView.Rows[i].Cells[j].Value != null) {
                                    matrixLenght[i, j] = Convert.ToInt32(matrixDataGridView.Rows[i].Cells[j].Value);
                                } else {
                                    matrixLenght[i, j] = -1;
                                }

                            } catch {
                                matrixLenght[i, j] = -1;
                            }
                        }
                    }

                try {
                    lenghtPathVertex = fillLenghtPathVertex(Convert.ToInt32(numericUpDown1.Value - 1), matrixDataGridView.Columns.Count);
                    findShortestPath(Convert.ToInt32(numericUpDown1.Value - 1), matrixDataGridView.Columns.Count);

                    if (lenghtPathDataGridView.Columns.Count > 0) {

                        while (lenghtPathDataGridView.Columns.Count > 0) {
                            lenghtPathDataGridView.Columns.RemoveAt(0);
                        }

                    }

                    for (int i = 0; i < lenghtPathVertex.Length; i++) {
                        lenghtPathDataGridView.Columns.Add(i.ToString(), (i + 1).ToString());

                        if (i == 0) {
                            lenghtPathDataGridView.Rows.Add();
                        }

                        if (lenghtPathVertex[i] < BIG_VALUE) {
                            lenghtPathDataGridView.Rows[0].Cells[i].Value = lenghtPathVertex[i];
                        } else {
                            lenghtPathDataGridView.Rows[0].Cells[i].Value = "-";
                        }
                    }

                    if (lenghtPathDataGridView.Width > lenghtPathDataGridView.Columns[0].Width * lenghtPathDataGridView.Columns.Count) {
                       int width = lenghtPathDataGridView.Width / lenghtPathVertex.Length;

                        for (int i = 0; i < lenghtPathVertex.Length; i++) {
                            lenghtPathDataGridView.Columns[i].Width = width;
                        }
                    }

                    int height = lenghtPathDataGridView.Height - lenghtPathDataGridView.ColumnHeadersHeight - 15;
                    lenghtPathDataGridView.Rows[0].Height = height;

                } catch { }

            }
            
        }

        private void cleanTableButton_Click(object sender, EventArgs e) {
            for (int i = 0; i < matrixDataGridView.Columns.Count; i++) {
                for (int j = 0; j < matrixDataGridView.Rows.Count; j++) {
                    matrixDataGridView.Rows[i].Cells[j].Value = "";
                }
            }
        }

        private void deleteTableButton_Click(object sender, EventArgs e) {
            while (matrixDataGridView.Rows.Count > 0) {
                matrixDataGridView.Rows.RemoveAt(0);
                matrixDataGridView.Columns.RemoveAt(0);
            }
        }

        private void changedCell_gridView(object sender, DataGridViewCellEventArgs e) {
            try {
                matrixDataGridView.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = matrixDataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if(e.ColumnIndex == e.RowIndex) {
                    matrixDataGridView.Rows[e.ColumnIndex].Cells[e.RowIndex].Value = "";
                }

            } catch { }
        }

    }

}
