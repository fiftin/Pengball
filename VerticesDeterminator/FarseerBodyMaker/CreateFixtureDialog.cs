using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FarseerBodyMaker
{
    public partial class CreateFixtureDialog : Form
    {
        public CreateFixtureDialog()
        {
            InitializeComponent();
            FixtureName = "";
        }

        public string FixtureName { get; private set; }

        private void btnOK_Click(object sender, EventArgs e)
        {
            FixtureName = textBox1.Text;
        }
    }
}
