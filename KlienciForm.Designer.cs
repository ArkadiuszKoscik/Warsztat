namespace bazadanych
{
    partial class KlienciForm
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.KlienciListView = new System.Windows.Forms.ListView();
            this.UsunKlientabutton = new System.Windows.Forms.Button();
            this.EdytujKlientaButton = new System.Windows.Forms.Button();
            this.DodajKlientaButton = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.AutaListView = new System.Windows.Forms.ListView();
            this.UsunAutoButton = new System.Windows.Forms.Button();
            this.EdytujAutoButton = new System.Windows.Forms.Button();
            this.DodajAutoButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(591, 504);
            this.splitContainer1.SplitterDistance = 366;
            this.splitContainer1.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.splitContainer2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(591, 366);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lista klientów";
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer2.Location = new System.Drawing.Point(3, 16);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.KlienciListView);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.UsunKlientabutton);
            this.splitContainer2.Panel2.Controls.Add(this.EdytujKlientaButton);
            this.splitContainer2.Panel2.Controls.Add(this.DodajKlientaButton);
            this.splitContainer2.Size = new System.Drawing.Size(585, 347);
            this.splitContainer2.SplitterDistance = 318;
            this.splitContainer2.TabIndex = 0;
            // 
            // KlienciListView
            // 
            this.KlienciListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.KlienciListView.Location = new System.Drawing.Point(0, 0);
            this.KlienciListView.Name = "KlienciListView";
            this.KlienciListView.Size = new System.Drawing.Size(585, 318);
            this.KlienciListView.TabIndex = 0;
            this.KlienciListView.UseCompatibleStateImageBehavior = false;
            this.KlienciListView.SelectedIndexChanged += new System.EventHandler(this.KlienciListView_SelectedIndexChanged);
            // 
            // UsunKlientabutton
            // 
            this.UsunKlientabutton.Location = new System.Drawing.Point(176, 2);
            this.UsunKlientabutton.Name = "UsunKlientabutton";
            this.UsunKlientabutton.Size = new System.Drawing.Size(82, 23);
            this.UsunKlientabutton.TabIndex = 2;
            this.UsunKlientabutton.Text = "Usuń klienta";
            this.UsunKlientabutton.UseVisualStyleBackColor = true;
            this.UsunKlientabutton.Click += new System.EventHandler(this.UsunKlientabutton_Click);
            // 
            // EdytujKlientaButton
            // 
            this.EdytujKlientaButton.Location = new System.Drawing.Point(88, 2);
            this.EdytujKlientaButton.Name = "EdytujKlientaButton";
            this.EdytujKlientaButton.Size = new System.Drawing.Size(82, 23);
            this.EdytujKlientaButton.TabIndex = 1;
            this.EdytujKlientaButton.Text = "Edytuj klienta";
            this.EdytujKlientaButton.UseVisualStyleBackColor = true;
            this.EdytujKlientaButton.Click += new System.EventHandler(this.EdytujKlientaButton_Click);
            // 
            // DodajKlientaButton
            // 
            this.DodajKlientaButton.Location = new System.Drawing.Point(0, 2);
            this.DodajKlientaButton.Name = "DodajKlientaButton";
            this.DodajKlientaButton.Size = new System.Drawing.Size(82, 23);
            this.DodajKlientaButton.TabIndex = 0;
            this.DodajKlientaButton.Text = "Dodaj klienta";
            this.DodajKlientaButton.UseVisualStyleBackColor = true;
            this.DodajKlientaButton.Click += new System.EventHandler(this.DodajKlientaButton_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.splitContainer3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(591, 134);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Auta klienta";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer3.Location = new System.Drawing.Point(3, 16);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.AutaListView);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.UsunAutoButton);
            this.splitContainer3.Panel2.Controls.Add(this.EdytujAutoButton);
            this.splitContainer3.Panel2.Controls.Add(this.DodajAutoButton);
            this.splitContainer3.Size = new System.Drawing.Size(585, 115);
            this.splitContainer3.SplitterDistance = 86;
            this.splitContainer3.TabIndex = 0;
            // 
            // AutaListView
            // 
            this.AutaListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.AutaListView.Location = new System.Drawing.Point(0, 0);
            this.AutaListView.Name = "AutaListView";
            this.AutaListView.Size = new System.Drawing.Size(585, 86);
            this.AutaListView.TabIndex = 0;
            this.AutaListView.UseCompatibleStateImageBehavior = false;
            // 
            // UsunAutoButton
            // 
            this.UsunAutoButton.Location = new System.Drawing.Point(162, 2);
            this.UsunAutoButton.Name = "UsunAutoButton";
            this.UsunAutoButton.Size = new System.Drawing.Size(75, 23);
            this.UsunAutoButton.TabIndex = 2;
            this.UsunAutoButton.Text = "Usuń auto";
            this.UsunAutoButton.UseVisualStyleBackColor = true;
            this.UsunAutoButton.Click += new System.EventHandler(this.UsunAutoButton_Click);
            // 
            // EdytujAutoButton
            // 
            this.EdytujAutoButton.Location = new System.Drawing.Point(81, 2);
            this.EdytujAutoButton.Name = "EdytujAutoButton";
            this.EdytujAutoButton.Size = new System.Drawing.Size(75, 23);
            this.EdytujAutoButton.TabIndex = 1;
            this.EdytujAutoButton.Text = "Edytuj auto";
            this.EdytujAutoButton.UseVisualStyleBackColor = true;
            this.EdytujAutoButton.Click += new System.EventHandler(this.EdytujAutoButton_Click);
            // 
            // DodajAutoButton
            // 
            this.DodajAutoButton.Location = new System.Drawing.Point(0, 2);
            this.DodajAutoButton.Name = "DodajAutoButton";
            this.DodajAutoButton.Size = new System.Drawing.Size(75, 23);
            this.DodajAutoButton.TabIndex = 0;
            this.DodajAutoButton.Text = "Dodaj auto";
            this.DodajAutoButton.UseVisualStyleBackColor = true;
            this.DodajAutoButton.Click += new System.EventHandler(this.DodajAutoButton_Click);
            // 
            // KlienciForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 504);
            this.Controls.Add(this.splitContainer1);
            this.Name = "KlienciForm";
            this.Text = "KlienciForm";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.ListView KlienciListView;
        private System.Windows.Forms.Button DodajKlientaButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.ListView AutaListView;
        private System.Windows.Forms.Button DodajAutoButton;
        private System.Windows.Forms.Button UsunKlientabutton;
        private System.Windows.Forms.Button EdytujKlientaButton;
        private System.Windows.Forms.Button UsunAutoButton;
        private System.Windows.Forms.Button EdytujAutoButton;
    }
}