namespace bazadanych
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
            this.PokazZleceniabutton = new System.Windows.Forms.Button();
            this.PokazKlientowButton = new System.Windows.Forms.Button();
            this.PokazAutaButton = new System.Windows.Forms.Button();
            this.PokazCzesciButton = new System.Windows.Forms.Button();
            this.PokazMechanikowButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PokazZleceniabutton
            // 
            this.PokazZleceniabutton.Location = new System.Drawing.Point(12, 12);
            this.PokazZleceniabutton.Name = "PokazZleceniabutton";
            this.PokazZleceniabutton.Size = new System.Drawing.Size(124, 40);
            this.PokazZleceniabutton.TabIndex = 0;
            this.PokazZleceniabutton.Text = "Pokaż zlecenia";
            this.PokazZleceniabutton.UseVisualStyleBackColor = true;
            this.PokazZleceniabutton.Click += new System.EventHandler(this.PokazZleceniabutton_Click);
            // 
            // PokazKlientowButton
            // 
            this.PokazKlientowButton.Location = new System.Drawing.Point(12, 58);
            this.PokazKlientowButton.Name = "PokazKlientowButton";
            this.PokazKlientowButton.Size = new System.Drawing.Size(124, 40);
            this.PokazKlientowButton.TabIndex = 1;
            this.PokazKlientowButton.Text = "Pokaż klientów";
            this.PokazKlientowButton.UseVisualStyleBackColor = true;
            this.PokazKlientowButton.Click += new System.EventHandler(this.PokazKlientowButton_Click);
            // 
            // PokazAutaButton
            // 
            this.PokazAutaButton.Location = new System.Drawing.Point(12, 104);
            this.PokazAutaButton.Name = "PokazAutaButton";
            this.PokazAutaButton.Size = new System.Drawing.Size(124, 40);
            this.PokazAutaButton.TabIndex = 2;
            this.PokazAutaButton.Text = "Pokaż auta";
            this.PokazAutaButton.UseVisualStyleBackColor = true;
            this.PokazAutaButton.Click += new System.EventHandler(this.PokazAutaButton_Click);
            // 
            // PokazCzesciButton
            // 
            this.PokazCzesciButton.Location = new System.Drawing.Point(142, 58);
            this.PokazCzesciButton.Name = "PokazCzesciButton";
            this.PokazCzesciButton.Size = new System.Drawing.Size(124, 40);
            this.PokazCzesciButton.TabIndex = 3;
            this.PokazCzesciButton.Text = "Pokaż części";
            this.PokazCzesciButton.UseVisualStyleBackColor = true;
            this.PokazCzesciButton.Click += new System.EventHandler(this.PokazCzesciButton_Click);
            // 
            // PokazMechanikowButton
            // 
            this.PokazMechanikowButton.Location = new System.Drawing.Point(142, 12);
            this.PokazMechanikowButton.Name = "PokazMechanikowButton";
            this.PokazMechanikowButton.Size = new System.Drawing.Size(124, 40);
            this.PokazMechanikowButton.TabIndex = 6;
            this.PokazMechanikowButton.Text = "Pokaż mechaników";
            this.PokazMechanikowButton.UseVisualStyleBackColor = true;
            this.PokazMechanikowButton.Click += new System.EventHandler(this.PokazMechanikowButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(279, 156);
            this.Controls.Add(this.PokazMechanikowButton);
            this.Controls.Add(this.PokazCzesciButton);
            this.Controls.Add(this.PokazAutaButton);
            this.Controls.Add(this.PokazKlientowButton);
            this.Controls.Add(this.PokazZleceniabutton);
            this.Name = "Form1";
            this.Text = "Warsztat";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PokazZleceniabutton;
        private System.Windows.Forms.Button PokazKlientowButton;
        private System.Windows.Forms.Button PokazAutaButton;
        private System.Windows.Forms.Button PokazCzesciButton;
        private System.Windows.Forms.Button PokazMechanikowButton;
    }
}

