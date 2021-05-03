namespace InTheDungeon
{
    partial class FormBattle
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBattle));
            this.labelHPHero = new System.Windows.Forms.Label();
            this.labelHPMonstr = new System.Windows.Forms.Label();
            this.buttonAttack = new System.Windows.Forms.Button();
            this.buttonDodge = new System.Windows.Forms.Button();
            this.buttonRun = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // labelHPHero
            // 
            this.labelHPHero.AutoSize = true;
            this.labelHPHero.BackColor = System.Drawing.Color.Transparent;
            this.labelHPHero.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelHPHero.ForeColor = System.Drawing.Color.CadetBlue;
            this.labelHPHero.Location = new System.Drawing.Point(10, 83);
            this.labelHPHero.Name = "labelHPHero";
            this.labelHPHero.Size = new System.Drawing.Size(46, 18);
            this.labelHPHero.TabIndex = 9;
            this.labelHPHero.Text = "label1";
            // 
            // labelHPMonstr
            // 
            this.labelHPMonstr.AutoSize = true;
            this.labelHPMonstr.BackColor = System.Drawing.Color.Transparent;
            this.labelHPMonstr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelHPMonstr.ForeColor = System.Drawing.Color.CadetBlue;
            this.labelHPMonstr.Location = new System.Drawing.Point(169, 83);
            this.labelHPMonstr.Name = "labelHPMonstr";
            this.labelHPMonstr.Size = new System.Drawing.Size(46, 18);
            this.labelHPMonstr.TabIndex = 10;
            this.labelHPMonstr.Text = "label1";
            // 
            // buttonAttack
            // 
            this.buttonAttack.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonAttack.Location = new System.Drawing.Point(0, 104);
            this.buttonAttack.Name = "buttonAttack";
            this.buttonAttack.Size = new System.Drawing.Size(80, 28);
            this.buttonAttack.TabIndex = 11;
            this.buttonAttack.Text = "Атака";
            this.buttonAttack.UseVisualStyleBackColor = true;
            this.buttonAttack.Click += new System.EventHandler(this.buttonAttack_Click);
            // 
            // buttonDodge
            // 
            this.buttonDodge.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonDodge.Location = new System.Drawing.Point(80, 104);
            this.buttonDodge.Name = "buttonDodge";
            this.buttonDodge.Size = new System.Drawing.Size(80, 28);
            this.buttonDodge.TabIndex = 12;
            this.buttonDodge.Text = "Уклонение";
            this.buttonDodge.UseVisualStyleBackColor = true;
            this.buttonDodge.Click += new System.EventHandler(this.buttonDodge_Click);
            // 
            // buttonRun
            // 
            this.buttonRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.buttonRun.Location = new System.Drawing.Point(160, 104);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(80, 28);
            this.buttonRun.TabIndex = 13;
            this.buttonRun.Text = "Сбежать";
            this.buttonRun.UseVisualStyleBackColor = true;
            this.buttonRun.Click += new System.EventHandler(this.buttonRun_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 500;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // FormBattle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(240, 133);
            this.ControlBox = false;
            this.Controls.Add(this.buttonRun);
            this.Controls.Add(this.buttonDodge);
            this.Controls.Add(this.buttonAttack);
            this.Controls.Add(this.labelHPMonstr);
            this.Controls.Add(this.labelHPHero);
            this.DoubleBuffered = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(256, 172);
            this.MinimumSize = new System.Drawing.Size(256, 172);
            this.Name = "FormBattle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Битва";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelHPHero;
        private System.Windows.Forms.Label labelHPMonstr;
        private System.Windows.Forms.Button buttonAttack;
        private System.Windows.Forms.Button buttonDodge;
        private System.Windows.Forms.Button buttonRun;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}