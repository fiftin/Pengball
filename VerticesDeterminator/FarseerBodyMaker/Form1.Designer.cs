namespace FarseerBodyMaker
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.tabControlBody = new System.Windows.Forms.TabControl();
            this.tabVertices = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlCanvas = new System.Windows.Forms.Panel();
            this.toolStripBody = new System.Windows.Forms.ToolStrip();
            this.btnOpenImage = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.btnAngle = new System.Windows.Forms.ToolStripButton();
            this.btnVertices = new System.Windows.Forms.ToolStripButton();
            this.tabControlFixture = new System.Windows.Forms.TabControl();
            this.tabFixtureVertices = new System.Windows.Forms.TabPage();
            this.lstVertices = new System.Windows.Forms.ListBox();
            this.toolStripFixtureVertices = new System.Windows.Forms.ToolStrip();
            this.btnRemoveFixtureVertex = new System.Windows.Forms.ToolStripButton();
            this.btnUpFixtureVertex = new System.Windows.Forms.ToolStripButton();
            this.btnDownFixtureVertex = new System.Windows.Forms.ToolStripButton();
            this.tabFixtureProperties = new System.Windows.Forms.TabPage();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lstFixtures = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStripFixtures = new System.Windows.Forms.ToolStrip();
            this.btnAddFixture = new System.Windows.Forms.ToolStripButton();
            this.btnRemoveFixtrue = new System.Windows.Forms.ToolStripButton();
            this.label1 = new System.Windows.Forms.Label();
            this.tabProperties = new System.Windows.Forms.TabPage();
            this.txtWidth = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog2 = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.btnReflect = new System.Windows.Forms.ToolStripButton();
            this.tabControlBody.SuspendLayout();
            this.tabVertices.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.toolStripBody.SuspendLayout();
            this.tabControlFixture.SuspendLayout();
            this.tabFixtureVertices.SuspendLayout();
            this.toolStripFixtureVertices.SuspendLayout();
            this.panel2.SuspendLayout();
            this.toolStripFixtures.SuspendLayout();
            this.tabProperties.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlBody
            // 
            this.tabControlBody.Controls.Add(this.tabVertices);
            this.tabControlBody.Controls.Add(this.tabProperties);
            this.tabControlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlBody.Location = new System.Drawing.Point(2, 26);
            this.tabControlBody.Name = "tabControlBody";
            this.tabControlBody.SelectedIndex = 0;
            this.tabControlBody.Size = new System.Drawing.Size(657, 463);
            this.tabControlBody.TabIndex = 1;
            // 
            // tabVertices
            // 
            this.tabVertices.Controls.Add(this.splitContainer1);
            this.tabVertices.Location = new System.Drawing.Point(4, 22);
            this.tabVertices.Name = "tabVertices";
            this.tabVertices.Padding = new System.Windows.Forms.Padding(3);
            this.tabVertices.Size = new System.Drawing.Size(649, 437);
            this.tabVertices.TabIndex = 0;
            this.tabVertices.Text = "Vertices";
            this.tabVertices.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.panel1);
            this.splitContainer1.Panel1.Controls.Add(this.toolStripBody);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControlFixture);
            this.splitContainer1.Panel2.Controls.Add(this.splitter1);
            this.splitContainer1.Panel2.Controls.Add(this.panel2);
            this.splitContainer1.Size = new System.Drawing.Size(643, 431);
            this.splitContainer1.SplitterDistance = 408;
            this.splitContainer1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Controls.Add(this.pnlCanvas);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(408, 406);
            this.panel1.TabIndex = 0;
            // 
            // pnlCanvas
            // 
            this.pnlCanvas.BackColor = System.Drawing.Color.SkyBlue;
            this.pnlCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCanvas.Location = new System.Drawing.Point(0, 0);
            this.pnlCanvas.Name = "pnlCanvas";
            this.pnlCanvas.Size = new System.Drawing.Size(404, 402);
            this.pnlCanvas.TabIndex = 0;
            this.pnlCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pnlCanvas_MouseDown);
            // 
            // toolStripBody
            // 
            this.toolStripBody.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripBody.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripBody.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnOpenImage,
            this.btnReflect,
            this.toolStripSeparator1,
            this.toolStripButton1,
            this.btnAngle,
            this.btnVertices});
            this.toolStripBody.Location = new System.Drawing.Point(0, 406);
            this.toolStripBody.Name = "toolStripBody";
            this.toolStripBody.Size = new System.Drawing.Size(408, 25);
            this.toolStripBody.TabIndex = 1;
            this.toolStripBody.Text = "toolStrip1";
            // 
            // btnOpenImage
            // 
            this.btnOpenImage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnOpenImage.Image = ((System.Drawing.Image)(resources.GetObject("btnOpenImage.Image")));
            this.btnOpenImage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnOpenImage.Name = "btnOpenImage";
            this.btnOpenImage.Size = new System.Drawing.Size(37, 22);
            this.btnOpenImage.Text = "Load";
            this.btnOpenImage.Click += new System.EventHandler(this.btnOpenImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator1.Visible = false;
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(46, 22);
            this.toolStripButton1.Text = "Center";
            this.toolStripButton1.Visible = false;
            // 
            // btnAngle
            // 
            this.btnAngle.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAngle.Image = ((System.Drawing.Image)(resources.GetObject("btnAngle.Image")));
            this.btnAngle.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAngle.Name = "btnAngle";
            this.btnAngle.Size = new System.Drawing.Size(42, 22);
            this.btnAngle.Text = "Angle";
            this.btnAngle.Visible = false;
            // 
            // btnVertices
            // 
            this.btnVertices.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnVertices.Image = ((System.Drawing.Image)(resources.GetObject("btnVertices.Image")));
            this.btnVertices.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnVertices.Name = "btnVertices";
            this.btnVertices.Size = new System.Drawing.Size(52, 22);
            this.btnVertices.Text = "Vertices";
            this.btnVertices.Visible = false;
            // 
            // tabControlFixture
            // 
            this.tabControlFixture.Controls.Add(this.tabFixtureVertices);
            this.tabControlFixture.Controls.Add(this.tabFixtureProperties);
            this.tabControlFixture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlFixture.Location = new System.Drawing.Point(0, 190);
            this.tabControlFixture.Name = "tabControlFixture";
            this.tabControlFixture.SelectedIndex = 0;
            this.tabControlFixture.Size = new System.Drawing.Size(231, 241);
            this.tabControlFixture.TabIndex = 3;
            // 
            // tabFixtureVertices
            // 
            this.tabFixtureVertices.Controls.Add(this.lstVertices);
            this.tabFixtureVertices.Controls.Add(this.toolStripFixtureVertices);
            this.tabFixtureVertices.Location = new System.Drawing.Point(4, 22);
            this.tabFixtureVertices.Name = "tabFixtureVertices";
            this.tabFixtureVertices.Padding = new System.Windows.Forms.Padding(3);
            this.tabFixtureVertices.Size = new System.Drawing.Size(223, 215);
            this.tabFixtureVertices.TabIndex = 0;
            this.tabFixtureVertices.Text = "Vertices";
            this.tabFixtureVertices.UseVisualStyleBackColor = true;
            // 
            // lstVertices
            // 
            this.lstVertices.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVertices.FormattingEnabled = true;
            this.lstVertices.Location = new System.Drawing.Point(3, 3);
            this.lstVertices.Name = "lstVertices";
            this.lstVertices.Size = new System.Drawing.Size(217, 184);
            this.lstVertices.TabIndex = 5;
            // 
            // toolStripFixtureVertices
            // 
            this.toolStripFixtureVertices.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripFixtureVertices.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFixtureVertices.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnRemoveFixtureVertex,
            this.btnUpFixtureVertex,
            this.btnDownFixtureVertex});
            this.toolStripFixtureVertices.Location = new System.Drawing.Point(3, 187);
            this.toolStripFixtureVertices.Name = "toolStripFixtureVertices";
            this.toolStripFixtureVertices.Size = new System.Drawing.Size(217, 25);
            this.toolStripFixtureVertices.TabIndex = 4;
            this.toolStripFixtureVertices.Text = "toolStrip3";
            // 
            // btnRemoveFixtureVertex
            // 
            this.btnRemoveFixtureVertex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRemoveFixtureVertex.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveFixtureVertex.Image")));
            this.btnRemoveFixtureVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveFixtureVertex.Name = "btnRemoveFixtureVertex";
            this.btnRemoveFixtureVertex.Size = new System.Drawing.Size(54, 22);
            this.btnRemoveFixtureVertex.Text = "Remove";
            this.btnRemoveFixtureVertex.Click += new System.EventHandler(this.btnRemoveFixtureVertex_Click);
            // 
            // btnUpFixtureVertex
            // 
            this.btnUpFixtureVertex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnUpFixtureVertex.Image = ((System.Drawing.Image)(resources.GetObject("btnUpFixtureVertex.Image")));
            this.btnUpFixtureVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnUpFixtureVertex.Name = "btnUpFixtureVertex";
            this.btnUpFixtureVertex.Size = new System.Drawing.Size(26, 22);
            this.btnUpFixtureVertex.Text = "Up";
            this.btnUpFixtureVertex.Click += new System.EventHandler(this.btnUpFixtureVertex_Click);
            // 
            // btnDownFixtureVertex
            // 
            this.btnDownFixtureVertex.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnDownFixtureVertex.Image = ((System.Drawing.Image)(resources.GetObject("btnDownFixtureVertex.Image")));
            this.btnDownFixtureVertex.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnDownFixtureVertex.Name = "btnDownFixtureVertex";
            this.btnDownFixtureVertex.Size = new System.Drawing.Size(42, 22);
            this.btnDownFixtureVertex.Text = "Down";
            // 
            // tabFixtureProperties
            // 
            this.tabFixtureProperties.Location = new System.Drawing.Point(4, 22);
            this.tabFixtureProperties.Name = "tabFixtureProperties";
            this.tabFixtureProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabFixtureProperties.Size = new System.Drawing.Size(223, 215);
            this.tabFixtureProperties.TabIndex = 1;
            this.tabFixtureProperties.Text = "Properties";
            this.tabFixtureProperties.UseVisualStyleBackColor = true;
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 185);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(231, 5);
            this.splitter1.TabIndex = 4;
            this.splitter1.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lstFixtures);
            this.panel2.Controls.Add(this.toolStripFixtures);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(231, 185);
            this.panel2.TabIndex = 5;
            // 
            // lstFixtures
            // 
            this.lstFixtures.CheckBoxes = true;
            this.lstFixtures.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.lstFixtures.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstFixtures.FullRowSelect = true;
            this.lstFixtures.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.lstFixtures.HideSelection = false;
            this.lstFixtures.Location = new System.Drawing.Point(0, 17);
            this.lstFixtures.Name = "lstFixtures";
            this.lstFixtures.Size = new System.Drawing.Size(231, 143);
            this.lstFixtures.TabIndex = 5;
            this.lstFixtures.UseCompatibleStateImageBehavior = false;
            this.lstFixtures.View = System.Windows.Forms.View.Details;
            this.lstFixtures.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lstFixtures_ItemChecked);
            this.lstFixtures.SelectedIndexChanged += new System.EventHandler(this.lstFixtures_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 200;
            // 
            // toolStripFixtures
            // 
            this.toolStripFixtures.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStripFixtures.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripFixtures.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnAddFixture,
            this.btnRemoveFixtrue});
            this.toolStripFixtures.Location = new System.Drawing.Point(0, 160);
            this.toolStripFixtures.Name = "toolStripFixtures";
            this.toolStripFixtures.Size = new System.Drawing.Size(231, 25);
            this.toolStripFixtures.TabIndex = 3;
            this.toolStripFixtures.Text = "toolStrip2";
            // 
            // btnAddFixture
            // 
            this.btnAddFixture.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnAddFixture.Image = ((System.Drawing.Image)(resources.GetObject("btnAddFixture.Image")));
            this.btnAddFixture.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAddFixture.Name = "btnAddFixture";
            this.btnAddFixture.Size = new System.Drawing.Size(35, 22);
            this.btnAddFixture.Text = "New";
            this.btnAddFixture.Click += new System.EventHandler(this.btnAddFixture_Click);
            // 
            // btnRemoveFixtrue
            // 
            this.btnRemoveFixtrue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnRemoveFixtrue.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveFixtrue.Image")));
            this.btnRemoveFixtrue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnRemoveFixtrue.Name = "btnRemoveFixtrue";
            this.btnRemoveFixtrue.Size = new System.Drawing.Size(54, 22);
            this.btnRemoveFixtrue.Text = "Remove";
            this.btnRemoveFixtrue.Click += new System.EventHandler(this.btnRemoveFixtrue_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(2);
            this.label1.Size = new System.Drawing.Size(50, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Fixtures:";
            // 
            // tabProperties
            // 
            this.tabProperties.Controls.Add(this.label3);
            this.tabProperties.Controls.Add(this.txtWidth);
            this.tabProperties.Controls.Add(this.label2);
            this.tabProperties.Location = new System.Drawing.Point(4, 22);
            this.tabProperties.Name = "tabProperties";
            this.tabProperties.Padding = new System.Windows.Forms.Padding(3);
            this.tabProperties.Size = new System.Drawing.Size(649, 437);
            this.tabProperties.TabIndex = 1;
            this.tabProperties.Text = "Properties";
            this.tabProperties.UseVisualStyleBackColor = true;
            // 
            // txtWidth
            // 
            this.txtWidth.Location = new System.Drawing.Point(114, 22);
            this.txtWidth.Name = "txtWidth";
            this.txtWidth.Size = new System.Drawing.Size(73, 20);
            this.txtWidth.TabIndex = 1;
            this.txtWidth.Text = "1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Width:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(2, 2);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(657, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.openToolStripMenuItem.Text = "&Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.saveToolStripMenuItem.Text = "&Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(100, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(193, 25);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(15, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "m";
            // 
            // btnReflect
            // 
            this.btnReflect.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnReflect.Image = ((System.Drawing.Image)(resources.GetObject("btnReflect.Image")));
            this.btnReflect.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnReflect.Name = "btnReflect";
            this.btnReflect.Size = new System.Drawing.Size(47, 22);
            this.btnReflect.Text = "Reflect";
            this.btnReflect.Click += new System.EventHandler(this.btnReflect_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(659, 490);
            this.Controls.Add(this.tabControlBody);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Padding = new System.Windows.Forms.Padding(2, 2, 0, 1);
            this.Text = "Body Maker";
            this.tabControlBody.ResumeLayout(false);
            this.tabVertices.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.toolStripBody.ResumeLayout(false);
            this.toolStripBody.PerformLayout();
            this.tabControlFixture.ResumeLayout(false);
            this.tabFixtureVertices.ResumeLayout(false);
            this.tabFixtureVertices.PerformLayout();
            this.toolStripFixtureVertices.ResumeLayout(false);
            this.toolStripFixtureVertices.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.toolStripFixtures.ResumeLayout(false);
            this.toolStripFixtures.PerformLayout();
            this.tabProperties.ResumeLayout(false);
            this.tabProperties.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlBody;
        private System.Windows.Forms.TabPage tabVertices;
        private System.Windows.Forms.TabPage tabProperties;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStrip toolStripBody;
        private System.Windows.Forms.ToolStripButton btnOpenImage;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton btnAngle;
        private System.Windows.Forms.ToolStripButton btnVertices;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl tabControlFixture;
        private System.Windows.Forms.TabPage tabFixtureVertices;
        private System.Windows.Forms.TabPage tabFixtureProperties;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ListView lstFixtures;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStrip toolStripFixtures;
        private System.Windows.Forms.ToolStripButton btnAddFixture;
        private System.Windows.Forms.ToolStripButton btnRemoveFixtrue;
        private System.Windows.Forms.ToolStrip toolStripFixtureVertices;
        private System.Windows.Forms.ToolStripButton btnRemoveFixtureVertex;
        private System.Windows.Forms.ToolStripButton btnUpFixtureVertex;
        private System.Windows.Forms.ListBox lstVertices;
        private System.Windows.Forms.ToolStripButton btnDownFixtureVertex;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtWidth;
        private System.Windows.Forms.Panel pnlCanvas;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.SaveFileDialog saveFileDialog2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ToolStripButton btnReflect;
    }
}

