using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;

namespace FarseerBodyMaker
{
    public class Canvas
    {
        private Control control;
        private Image image = null;
        BufferedGraphicsContext context = null;
        BufferedGraphics bufferedGraphics = null;
        Graphics targetGraphics = null;

        public Graphics Graphics
        {
            get
            {
                if (bufferedGraphics == null)
                    return null;
                return bufferedGraphics.Graphics;
            }
        }

        public Image Image
        {
            get { return image; }
            set
            {
                image = value;
                if (image != null)
                {
                    control.Size = image.Size;
                    InitializeGraphics();
                }
            }
        }

        private Rectangle DrawRect
        {
            get
            {
                if (image != null)
                    return new Rectangle(0, 0, image.Width, image.Height);
                return control.ClientRectangle;
            }
        }

        private void InitializeGraphics()
        {
            if (bufferedGraphics != null)
            {
                bufferedGraphics.Dispose();
            }
            if (targetGraphics != null)
                targetGraphics.Dispose();
            targetGraphics = control.CreateGraphics();
            bufferedGraphics = context.Allocate(targetGraphics, DrawRect);
        }

        public Canvas(Control control)
        {
            this.control = control;
            control.BackColor = Color.SkyBlue;
            context = new BufferedGraphicsContext();
            control.Paint += new PaintEventHandler(control_Paint);
            InitializeGraphics();
        }

        public void Draw()
        {
            Draw(targetGraphics);
        }

        public void Draw(Graphics g)
        {
            Draw(g, control.Bounds);
        }

        void control_Paint(object sender, PaintEventArgs e)
        {
            Draw(e.Graphics, control.ClientRectangle);
        }

        public void Draw(System.Drawing.Graphics g, Rectangle rectangle)
        {
            Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            Graphics.Clear(Color.SkyBlue);

            if (Image != null)
                Graphics.DrawImage(Image, DrawRect);

            if (Paint != null)
            {
                Paint(this, new PaintEventArgs(Graphics, rectangle));
            }

            bufferedGraphics.Render(g);

        }

        public event EventHandler<PaintEventArgs> Paint;
    }
}
