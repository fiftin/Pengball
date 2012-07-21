using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml.Linq;

namespace FarseerBodyMaker
{
    public partial class Form1 : Form
    {
        Canvas canvas;
        public Form1()
        {
            InitializeComponent();
            body.FixtureAdded += new EventHandler<FixtureEventArgs>(body_FixtureAdded);
            body.FixtureRemoved += new EventHandler<FixtureEventArgs>(body_FixtureRemoved);
            canvas = new Canvas(pnlCanvas);
            canvas.Paint += new EventHandler<PaintEventArgs>(canvas_Paint);
        }

        private void DrawFixture(Fixture fixture, Color color, Graphics g)
        {
            var vertices = fixture.GetVertices();
            if (vertices.Length > 2)
            {
                g.DrawClosedCurve(new Pen(color), vertices, 0, System.Drawing.Drawing2D.FillMode.Winding);
            }

            for (var i = 0; i <vertices.Length; i++)
            {
                var vertex = vertices[i];
                g.FillEllipse(new SolidBrush(color), vertex.X - 2, vertex.Y - 2, 4, 4);
                g.DrawString(i.ToString(), pnlCanvas.Font, new SolidBrush(color), vertex.X - 4, vertex.Y - 15);
            }
        }

        private void DrawCheckedFixtures(Graphics g)
        {
            foreach (ListViewItem item in lstFixtures.CheckedItems)
            {
                var fixture = body.Fixtures[item.Name];
                DrawFixture(fixture, Color.Red, g);
            }
        }

        private void DrawSelectedFixture(Graphics g)
        {
            if (lstFixtures.SelectedItems.Count > 0)
            {
                var fixture = body.Fixtures[lstFixtures.SelectedItems[0].Name];
                DrawFixture(fixture, Color.LightGreen, g);
            }
        }

        private void DrawCenter(Graphics g)
        {
            if (body.Center != null)
            {
                g.FillEllipse(new SolidBrush(Color.Orange), body.Center.Value.X - 4, body.Center.Value.Y - 4, 8, 8);
            }
        }

        private void Draw(Graphics g)
        {
            DrawCheckedFixtures(g);
            DrawSelectedFixture(g);
            DrawCenter(g);
        }

        private void canvas_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics);
        }

        private void body_FixtureRemoved(object sender, FixtureEventArgs e)
        {
            lstFixtures.Items.RemoveByKey(e.Fixture.Name);
        }

        private void body_FixtureAdded(object sender, FixtureEventArgs e)
        {
            var item = lstFixtures.Items.Add(e.Fixture.Name, e.Fixture.Name, 0);
            item.Selected = true;
            item.Checked = true;
        }

        private void btnOpenImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pnlCanvas.Dock = DockStyle.None;
                canvas.Image = Image.FromFile(openFileDialog1.FileName);
                canvas.Draw();
            }
        }

        private void btnAddFixture_Click(object sender, EventArgs e)
        {
            using (CreateFixtureDialog dialog = new CreateFixtureDialog())
            {
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var fixture = new Fixture(dialog.FixtureName);
                    body.AddFixture(fixture);
                }
            }
        }

        private Body body = new Body();

        private void btnRemoveFixtrue_Click(object sender, EventArgs e)
        {
            for (int i = lstFixtures.SelectedIndices.Count - 1; i >= 0; i--)
            {
                lstFixtures.Items.RemoveAt(lstFixtures.SelectedIndices[i]);
            }

        }

        private Fixture selectedFixture;

        private Fixture SelectedFixture
        {
            get
            {
                return selectedFixture;
            }
        }

        private void FillFixtureViewControls()
        {
            lstVertices.Items.Clear();
            if (selectedFixture != null)
            {
                foreach (var vertex in selectedFixture.GetVertices())
                {
                    lstVertices.Items.Add(vertex.X + "; " + vertex.Y);
                }
            }
        }

        private void lstFixtures_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstFixtures.SelectedItems.Count > 0)
            {
                selectedFixture = body.Fixtures[lstFixtures.SelectedItems[0].Name];
            }
            else
            {
                selectedFixture = null;
            }
            FillFixtureViewControls();
            canvas.Draw();
        }

        private void btnRemoveFixtureVertex_Click(object sender, EventArgs e)
        {
            for (int i = lstVertices.SelectedIndices.Count - 1; i >= 0; i--)
            {
                int index = lstVertices.SelectedIndices[i];
                lstVertices.Items.RemoveAt(index);
                selectedFixture.RemoveVertex(index);
            }
            canvas.Draw();
        }

        private void pnlCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                if (selectedFixture != null)
                {
                    selectedFixture.AddVertex(e.Location);
                    lstVertices.Items.Add(e.Location.X + "; " + e.Location.Y);
                    canvas.Draw();
                }
            }
            else if (e.Button == System.Windows.Forms.MouseButtons.Right)
            {
                body.Center = e.Location;
                canvas.Draw();
            }
        }


        private void lstFixtures_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            canvas.Draw();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReflect_Click(object sender, EventArgs e)
        {
            if (canvas.Image != null)
            {
                canvas.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                foreach (var fixture in body.Fixtures.Values)
                {
                    var points = fixture.GetVertices();
                    for (int i = 0; i < points.Length; i++)
                    {
                        points[i] = new Point(canvas.Image.Width - points[i].X, points[i].Y);
                    }
                    fixture.SetVertices(points);
                }
                canvas.Draw();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnUpFixtureVertex_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XDocument doc = new XDocument();

        }
    }
}
