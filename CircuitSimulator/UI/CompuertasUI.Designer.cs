namespace CircuitSimulator.UI
{
    partial class CompuertasUI
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
            this.NOT = new System.Windows.Forms.Button();
            this.XNOR = new System.Windows.Forms.Button();
            this.XOR = new System.Windows.Forms.Button();
            this.NAND = new System.Windows.Forms.Button();
            this.NOR = new System.Windows.Forms.Button();
            this.AND = new System.Windows.Forms.Button();
            this.OR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NOT
            // 
            this.NOT.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NOT.Image = global::CircuitSimulator.Properties.Resources.NOT;
            this.NOT.Location = new System.Drawing.Point(35, 681);
            this.NOT.Name = "NOT";
            this.NOT.Size = new System.Drawing.Size(172, 105);
            this.NOT.TabIndex = 20;
            this.NOT.UseVisualStyleBackColor = true;
            this.NOT.Click += new System.EventHandler(this.Compuerta_Click);
            // 
            // XNOR
            // 
            this.XNOR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.XNOR.Image = global::CircuitSimulator.Properties.Resources.XNOR;
            this.XNOR.Location = new System.Drawing.Point(35, 570);
            this.XNOR.Name = "XNOR";
            this.XNOR.Size = new System.Drawing.Size(172, 105);
            this.XNOR.TabIndex = 19;
            this.XNOR.UseVisualStyleBackColor = true;
            this.XNOR.Click += new System.EventHandler(this.Compuerta_Click);
            // 
            // XOR
            // 
            this.XOR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.XOR.Image = global::CircuitSimulator.Properties.Resources.XOR;
            this.XOR.Location = new System.Drawing.Point(35, 459);
            this.XOR.Name = "XOR";
            this.XOR.Size = new System.Drawing.Size(172, 105);
            this.XOR.TabIndex = 18;
            this.XOR.UseVisualStyleBackColor = true;
            this.XOR.Click += new System.EventHandler(this.Compuerta_Click);
            // 
            // NAND
            // 
            this.NAND.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NAND.Image = global::CircuitSimulator.Properties.Resources.NAND;
            this.NAND.Location = new System.Drawing.Point(35, 348);
            this.NAND.Name = "NAND";
            this.NAND.Size = new System.Drawing.Size(172, 105);
            this.NAND.TabIndex = 17;
            this.NAND.UseVisualStyleBackColor = true;
            this.NAND.Click += new System.EventHandler(this.Compuerta_Click);
            // 
            // NOR
            // 
            this.NOR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.NOR.Image = global::CircuitSimulator.Properties.Resources.NOR;
            this.NOR.Location = new System.Drawing.Point(35, 237);
            this.NOR.Name = "NOR";
            this.NOR.Size = new System.Drawing.Size(172, 105);
            this.NOR.TabIndex = 16;
            this.NOR.UseVisualStyleBackColor = true;
            this.NOR.Click += new System.EventHandler(this.Compuerta_Click);
            // 
            // AND
            // 
            this.AND.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.AND.Image = global::CircuitSimulator.Properties.Resources.AND;
            this.AND.Location = new System.Drawing.Point(35, 126);
            this.AND.Name = "AND";
            this.AND.Size = new System.Drawing.Size(172, 105);
            this.AND.TabIndex = 15;
            this.AND.UseVisualStyleBackColor = true;
            this.AND.Click += new System.EventHandler(this.Compuerta_Click);
            // 
            // OR
            // 
            this.OR.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.OR.Image = global::CircuitSimulator.Properties.Resources.OR;
            this.OR.Location = new System.Drawing.Point(35, 15);
            this.OR.Name = "OR";
            this.OR.Size = new System.Drawing.Size(172, 105);
            this.OR.TabIndex = 14;
            this.OR.UseVisualStyleBackColor = true;
            this.OR.Click += new System.EventHandler(this.Compuerta_Click);
            // 
            // CompuertasUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NOT);
            this.Controls.Add(this.XNOR);
            this.Controls.Add(this.XOR);
            this.Controls.Add(this.NAND);
            this.Controls.Add(this.NOR);
            this.Controls.Add(this.AND);
            this.Controls.Add(this.OR);
            this.Name = "CompuertasUI";
            this.Size = new System.Drawing.Size(243, 726);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NOT;
        private System.Windows.Forms.Button XNOR;
        private System.Windows.Forms.Button XOR;
        private System.Windows.Forms.Button NAND;
        private System.Windows.Forms.Button NOR;
        private System.Windows.Forms.Button AND;
        private System.Windows.Forms.Button OR;
    }
}
