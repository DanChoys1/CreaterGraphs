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

        Label previosClickedCircle = null;

        Color keyPressed = Color.Blue;
        Color keyReleased = ColorTranslator.FromHtml("#22ACDC");

        bool isMouseDownLabel = false;
        bool isMouseMovedLabel = false;
        bool isAddCircle = true;
        bool isAddLine = false;
        bool isDelete = false;
        bool isFindShortestPath = false;

        enum isCheckedVertex {
            NO,
            YES
        }

        const int PATH_LENGHT = 0;
        const int CHECKED_VERTEX = 1;

        public Form1() {

            InitializeComponent();
            pictureBox.BackColor = Color.White;
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
                const int BIG_VALUE = 2147483647;

                if (previosClickedCircle == null || previosClickedCircle == vertexClicked) {
                    previosClickedCircle = vertexClicked;
                    previosClickedCircle.BackColor = keyPressed;
                    vertexClicked.BackColor = keyPressed;
                    return;
                }

                int[,] matrixLenght = fillMatrixLenght();
                int[,] matrixReachability = fillMatrixReachability();
                int[,] lenghtPathVertex = fillLenghtPathVertex(previosClickedCircle.TabIndex, vertexClicked.TabIndex);

                lenghtPathVertex = findShortestPath(lenghtPathVertex, matrixLenght, previosClickedCircle.TabIndex, vertexClicked.TabIndex);

                if (lenghtPathVertex[vertexClicked.TabIndex, 0] != BIG_VALUE) {
                    shortestPathTextBox.Text = lenghtPathVertex[vertexClicked.TabIndex, 0].ToString();
                } else {
                    shortestPathTextBox.Text = (0).ToString();
                }

                previosClickedCircle.BackColor = keyReleased;
                vertexClicked.BackColor = keyReleased;
                previosClickedCircle = null;
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
                vertex[i].TabIndex = (i + 1);
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

            previosClickedCircle = null;
        }


        private int[,] fillMatrixLenght() {
            int[,] matrix = new int[vertex.Count, vertex.Count];

            for (int i = 0; i < vertex.Count; i++) {
                for (int j = 0; j < vertex.Count; j++) {
                    matrix[i, j] = -1;
                }
            }

            foreach (TextBox item in line.Keys) {
                int vertexIndex1 = line[item][0].TabIndex;
                int vertexIndex2 = line[item][1].TabIndex;

                matrix[vertexIndex1, vertexIndex2] = Convert.ToInt32(item.Text);
                matrix[vertexIndex2, vertexIndex1] = Convert.ToInt32(item.Text);
            }

            return matrix;
        }

        private int[,] fillMatrixReachability() {
            int[,] matrix = new int[vertex.Count, vertex.Count];

            for (int i = 0; i < vertex.Count; i++) {
                for (int j = 0; j < vertex.Count; j++) {
                    matrix[i, j] = 0;
                }
            }

            foreach (TextBox item in line.Keys) {
                int vertexIndex1 = line[item][0].TabIndex;
                int vertexIndex2 = line[item][1].TabIndex;

                matrix[vertexIndex1, vertexIndex2] = 1;
                matrix[vertexIndex2, vertexIndex1] = 1;
            }

            return matrix;
        }

        private int[,] fillLenghtPathVertex(int startVertex, int endVertex) {
            int[,] lenghtPathVertex = new int[vertex.Count, 2];

            const int BIG_VALUE = 2147483647;

            for (int i = 0; i < vertex.Count; i++) {
                lenghtPathVertex[i, PATH_LENGHT] = BIG_VALUE;
                lenghtPathVertex[i, CHECKED_VERTEX] = ((int)isCheckedVertex.NO);
            }

            lenghtPathVertex[startVertex, PATH_LENGHT] = 0;

            return lenghtPathVertex;
        }

        private int[,] findShortestPath(int[,] lenghtPathVertex, int[,] matrix, int startVertex, int endVertex) {
            for (int i = 0; i < vertex.Count; i++) {

                if( (matrix[startVertex, i] > -1) && (lenghtPathVertex[i, 0] > (matrix[startVertex, i] + lenghtPathVertex[startVertex, 0])) ) {

                    lenghtPathVertex[i, 0] = matrix[startVertex, i] + lenghtPathVertex[startVertex, 0];

                    lenghtPathVertex = findShortestPath(lenghtPathVertex, matrix, i, endVertex);
                }

            }

            return lenghtPathVertex;
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

    }

}
