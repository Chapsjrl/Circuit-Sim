namespace CircuitSimulator.UI
{
    partial class FuentesUI
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FuentesUI));
            this.TrueStart = new System.Windows.Forms.Button();
            this.FalseStart = new System.Windows.Forms.Button();
            this.Random = new System.Windows.Forms.Button();
            this.GND = new System.Windows.Forms.Button();
            this.VCC = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // TrueStart
            // 
            this.TrueStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.TrueStart.Image = ((System.Drawing.Image)(resources.GetObject("TrueStart.Image")));
            this.TrueStart.Location = new System.Drawing.Point(6, 175);
            this.TrueStart.Name = "TrueStart";
            this.TrueStart.Size = new System.Drawing.Size(215, 72);
            this.TrueStart.TabIndex = 9;
            this.TrueStart.UseVisualStyleBackColor = true;
            this.TrueStart.Click += new System.EventHandler(this.Pulso_Click);
            // 
            // FalseStart
            // 
            this.FalseStart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.FalseStart.Image = ((System.Drawing.Image)(resources.GetObject("FalseStart.Image")));
            this.FalseStart.Location = new System.Drawing.Point(6, 97);
            this.FalseStart.Name = "FalseStart";
            this.FalseStart.Size = new System.Drawing.Size(215, 72);
            this.FalseStart.TabIndex = 8;
            this.FalseStart.UseVisualStyleBackColor = true;
            this.FalseStart.Click += new System.EventHandler(this.Pulso_Click);
            // 
            // Random
            // 
            this.Random.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.Random.Image = ((System.Drawing.Image)(resources.GetObject("Random.Image")));
            this.Random.Location = new System.Drawing.Point(6, 19);
            this.Random.Name = "Random";
            this.Random.Size = new System.Drawing.Size(215, 72);
            this.Random.TabIndex = 7;
            this.Random.UseVisualStyleBackColor = true;
            this.Random.Click += new System.EventHandler(this.Pulso_Click);
            // 
            // GND
            // 
            this.GND.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.GND.Image = ((System.Drawing.Image)(resources.GetObject("GND.Image")));
            this.GND.Location = new System.Drawing.Point(121, 21);
            this.GND.Name = "GND";
            this.GND.Size = new System.Drawing.Size(100, 171);
            this.GND.TabIndex = 6;
            this.GND.UseVisualStyleBackColor = true;
            this.GND.Click += new System.EventHandler(this.VCC_Click);
            // 
            // VCC
            // 
            this.VCC.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.VCC.Image = ((System.Drawing.Image)(resources.GetObject("VCC.Image")));
            this.VCC.Location = new System.Drawing.Point(6, 19);
            this.VCC.Name = "VCC";
            this.VCC.Size = new System.Drawing.Size(101, 171);
            this.VCC.TabIndex = 5;
            this.VCC.UseVisualStyleBackColor = true;
            this.VCC.Click += new System.EventHandler(this.VCC_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.VCC);
            this.groupBox1.Controls.Add(this.GND);
            this.groupBox1.Location = new System.Drawing.Point(20, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(227, 198);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Entradas simples";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Random);
            this.groupBox2.Controls.Add(this.FalseStart);
            this.groupBox2.Controls.Add(this.TrueStart);
            this.groupBox2.Location = new System.Drawing.Point(20, 207);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(227, 256);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pulsos";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Location = new System.Drawing.Point(20, 469);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(227, 103);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Salida";
            // 
            // button1
            // 
            this.button1.Image = global::CircuitSimulator.Properties.Resources.OUTPUT;
            this.button1.Location = new System.Drawing.Point(6, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(215, 75);
            this.button1.TabIndex = 0;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FuentesUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "FuentesUI";
            this.Size = new System.Drawing.Size(270, 637);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button TrueStart;
        private System.Windows.Forms.Button FalseStart;
        private System.Windows.Forms.Button Random;
        private System.Windows.Forms.Button GND;
        private System.Windows.Forms.Button VCC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button1;
    }
}
