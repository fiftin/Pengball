using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace VerticesDeterminator
{


    public partial class Form1 : Form
    {
        public class Vertex
        {
            public int X { get; set; }
            public int Y { get; set; }

            public override string ToString()
            {
                return string.Format("{0}; {1}", X, Y);
            }

            public Vertex(int x, int y)
            {
                X = x;
                Y = y;
            }

            public Point ToPoint()
            {
                return new Point(X, Y);
            }

            public PointF ToPointF(float scale)
            {
                return new PointF(X * scale, Y * scale);
            }

            public PointF ToPointF(int h, float scale)
            {
                return new PointF((h - X) * scale, Y * scale);
            }
        }

        public Form1()
        {
            InitializeComponent();
        }
        string fileName = "";
        private void btnLoadImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                fileName = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(fileName);

            }
        }


        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            listBox1.Items.Add(new Vertex(e.X, e.Y));
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                Draw(g, e.Location);
            }
        }

        private void listBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = listBox1.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    listBox1.Items.RemoveAt(listBox1.SelectedIndices[i]);
                }
                pictureBox1.Refresh();
            }
        }

        private Point[] GetPoints()
        {
            object[] ret = new object[listBox1.Items.Count];
            listBox1.Items.CopyTo(ret, 0);
            return Array.ConvertAll(ret, x => ((Vertex)x).ToPoint());
        }

        private PointF[] GetPointsF(int h, float factor)
        {
            object[] ret = new object[listBox1.Items.Count];
            listBox1.Items.CopyTo(ret, 0);
            return Array.ConvertAll(ret, x => ((Vertex)x).ToPointF(h, factor));
        }

        private void Draw(Graphics g, Point p)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            float r = 2;
            g.FillEllipse(Brushes.Black, p.X - r - 1, p.Y - r - 1, r * 2 + 2, r * 2 + 2);
            g.FillEllipse(Brushes.Red, p.X - r, p.Y - r, r * 2, r * 2);
        }

        private void Draw(Graphics g)
        {
            Point[] points = GetPoints();
            foreach (Point p in points)
            {
                Draw(g, p);
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            PointF[] points = GetPointsF(pictureBox1.Image.Height, float.Parse(txtFactor.Text, CultureInfo.InvariantCulture));
            string str = "";
            foreach (PointF p in points)
            {
                str += string.Format("{0},{1}\r\n", p.X.ToString(CultureInfo.InvariantCulture),
                    p.Y.ToString(CultureInfo.InvariantCulture));
            }
            /*
            string str = "new Vector2[] {\r\n";
            foreach (PointF p in points)
            {
                str += string.Format("    new Vector2({0}, {1}),\r\n", p.X.ToString(CultureInfo.InvariantCulture),
                    p.Y.ToString(CultureInfo.InvariantCulture));
            }
            str += "};";
             */
            Clipboard.SetText(str);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnLoadVertices_Click(object sender, EventArgs e)
        {
            if (openFileDialog2.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                LoadVertices(openFileDialog2.FileName);
            }
        }

        private void LoadVertices(string fileName)
        {
            listBox1.Items.Clear();
            StreamReader reader = new StreamReader(fileName);
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] s = line.Split(',', ';');
                if (s.Length != 2)
                    continue;
                int x, y;
                if (!int.TryParse(s[0].Trim(), out x)
                    || !int.TryParse(s[1].Trim(), out y))
                {
                    continue;
                }
                AddVertex(new Vertex(x, y));
            }
            Refresh();
        }

        void AddVertex(Vertex vertex)
        {
            listBox1.Items.Add(vertex);
        }

        private void btnSaveVertices_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                StreamWriter writter = new StreamWriter(saveFileDialog1.FileName);
                foreach (Vertex v in listBox1.Items)
                {
                    writter.WriteLine("{0},{1}", v.X, v.Y);
                }
                writter.Close();
            }
        }


        private void DrawError(Graphics g, Point p)
        {
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            float r = 2;
            g.FillEllipse(Brushes.Black, p.X - r - 1, p.Y - r - 1, r * 2 + 2, r * 2 + 2);
        }


        private void btnCheck_Click(object sender, EventArgs e)
        {
            //bool Q = true;
            var pt = GetPoints();
            //float T = pt[pt.Length - 1].X * pt[0].Y - pt[0].X * pt[pt.Length - 1].Y;
            //float Z = ((float)T) / Math.Abs(T);
            float P = 1;
            List<float> ps = new List<float>();
            using (Graphics g = pictureBox1.CreateGraphics())
            {
                for (int i = 0; i < pt.Length - 1; i++)
                {
                    float R = pt[i].X * pt[i + 1].Y - pt[i + 1].X * pt[i].Y;
                    P = P * R / Math.Abs(R);
                    if (P < 0)
                    {
                        //break;
                        DrawError(g, pt[i]);
                    }
                    ps.Add(P);
                }
            }
        }
    }
}
