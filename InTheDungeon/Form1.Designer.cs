namespace InTheDungeon
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.listBoxInv = new System.Windows.Forms.ListBox();
            this.buttonUse = new System.Windows.Forms.Button();
            this.buttonTurf = new System.Windows.Forms.Button();
            this.listBoxCur = new System.Windows.Forms.ListBox();
            this.labelHP = new System.Windows.Forms.Label();
            this.labelLvl = new System.Windows.Forms.Label();
            this.labelExp = new System.Windows.Forms.Label();
            this.labelStr = new System.Windows.Forms.Label();
            this.labelAgi = new System.Windows.Forms.Label();
            this.buttonMap = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.button1.Location = new System.Drawing.Point(640, 393);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(80, 80);
            this.button1.TabIndex = 0;
            this.button1.Text = "↑";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.button2.Location = new System.Drawing.Point(560, 473);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 80);
            this.button2.TabIndex = 1;
            this.button2.Text = "←";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.button3.Location = new System.Drawing.Point(640, 473);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(80, 80);
            this.button3.TabIndex = 2;
            this.button3.Text = "↓";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F);
            this.button4.Location = new System.Drawing.Point(720, 473);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(80, 80);
            this.button4.TabIndex = 3;
            this.button4.Text = "→";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBoxInv
            // 
            this.listBoxInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.listBoxInv.FormattingEnabled = true;
            this.listBoxInv.Location = new System.Drawing.Point(560, 245);
            this.listBoxInv.Name = "listBoxInv";
            this.listBoxInv.Size = new System.Drawing.Size(230, 121);
            this.listBoxInv.TabIndex = 4;
            // 
            // buttonUse
            // 
            this.buttonUse.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonUse.Location = new System.Drawing.Point(560, 361);
            this.buttonUse.Name = "buttonUse";
            this.buttonUse.Size = new System.Drawing.Size(115, 30);
            this.buttonUse.TabIndex = 5;
            this.buttonUse.Text = "Использовать";
            this.buttonUse.UseVisualStyleBackColor = true;
            this.buttonUse.Click += new System.EventHandler(this.buttonUse_Click);
            // 
            // buttonTurf
            // 
            this.buttonTurf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.buttonTurf.Location = new System.Drawing.Point(675, 361);
            this.buttonTurf.Name = "buttonTurf";
            this.buttonTurf.Size = new System.Drawing.Size(115, 30);
            this.buttonTurf.TabIndex = 6;
            this.buttonTurf.Text = "Выбросить";
            this.buttonTurf.UseVisualStyleBackColor = true;
            this.buttonTurf.Click += new System.EventHandler(this.buttonTurf_Click);
            // 
            // listBoxCur
            // 
            this.listBoxCur.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.listBoxCur.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F);
            this.listBoxCur.FormattingEnabled = true;
            this.listBoxCur.Location = new System.Drawing.Point(656, 196);
            this.listBoxCur.Name = "listBoxCur";
            this.listBoxCur.Size = new System.Drawing.Size(134, 43);
            this.listBoxCur.TabIndex = 7;
            // 
            // labelHP
            // 
            this.labelHP.AutoSize = true;
            this.labelHP.BackColor = System.Drawing.Color.Transparent;
            this.labelHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelHP.ForeColor = System.Drawing.Color.CadetBlue;
            this.labelHP.Location = new System.Drawing.Point(675, 59);
            this.labelHP.Name = "labelHP";
            this.labelHP.Size = new System.Drawing.Size(46, 18);
            this.labelHP.TabIndex = 8;
            this.labelHP.Text = "label1";
            // 
            // labelLvl
            // 
            this.labelLvl.AutoSize = true;
            this.labelLvl.BackColor = System.Drawing.Color.Transparent;
            this.labelLvl.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelLvl.ForeColor = System.Drawing.Color.CadetBlue;
            this.labelLvl.Location = new System.Drawing.Point(665, 81);
            this.labelLvl.Name = "labelLvl";
            this.labelLvl.Size = new System.Drawing.Size(46, 18);
            this.labelLvl.TabIndex = 9;
            this.labelLvl.Text = "label2";
            // 
            // labelExp
            // 
            this.labelExp.AutoSize = true;
            this.labelExp.BackColor = System.Drawing.Color.Transparent;
            this.labelExp.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelExp.ForeColor = System.Drawing.Color.CadetBlue;
            this.labelExp.Location = new System.Drawing.Point(637, 103);
            this.labelExp.Name = "labelExp";
            this.labelExp.Size = new System.Drawing.Size(46, 18);
            this.labelExp.TabIndex = 10;
            this.labelExp.Text = "label3";
            // 
            // labelStr
            // 
            this.labelStr.AutoSize = true;
            this.labelStr.BackColor = System.Drawing.Color.Transparent;
            this.labelStr.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelStr.ForeColor = System.Drawing.Color.CadetBlue;
            this.labelStr.Location = new System.Drawing.Point(633, 123);
            this.labelStr.Name = "labelStr";
            this.labelStr.Size = new System.Drawing.Size(46, 18);
            this.labelStr.TabIndex = 11;
            this.labelStr.Text = "label4";
            // 
            // labelAgi
            // 
            this.labelAgi.AutoSize = true;
            this.labelAgi.BackColor = System.Drawing.Color.Transparent;
            this.labelAgi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F);
            this.labelAgi.ForeColor = System.Drawing.Color.CadetBlue;
            this.labelAgi.Location = new System.Drawing.Point(672, 147);
            this.labelAgi.Name = "labelAgi";
            this.labelAgi.Size = new System.Drawing.Size(46, 18);
            this.labelAgi.TabIndex = 12;
            this.labelAgi.Text = "label5";
            // 
            // buttonMap
            // 
            this.buttonMap.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F);
            this.buttonMap.Location = new System.Drawing.Point(581, 411);
            this.buttonMap.Name = "buttonMap";
            this.buttonMap.Size = new System.Drawing.Size(40, 40);
            this.buttonMap.TabIndex = 13;
            this.buttonMap.Text = " M";
            this.buttonMap.UseVisualStyleBackColor = true;
            this.buttonMap.Click += new System.EventHandler(this.buttonMap_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::InTheDungeon.Properties.Resources.background;
            this.ClientSize = new System.Drawing.Size(792, 552);
            this.Controls.Add(this.buttonMap);
            this.Controls.Add(this.labelAgi);
            this.Controls.Add(this.labelStr);
            this.Controls.Add(this.labelExp);
            this.Controls.Add(this.labelLvl);
            this.Controls.Add(this.labelHP);
            this.Controls.Add(this.listBoxCur);
            this.Controls.Add(this.buttonTurf);
            this.Controls.Add(this.buttonUse);
            this.Controls.Add(this.listBoxInv);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(808, 591);
            this.MinimumSize = new System.Drawing.Size(808, 591);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InTheDungeon";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.ListBox listBoxInv;
        private System.Windows.Forms.Button buttonUse;
        private System.Windows.Forms.Button buttonTurf;
        private System.Windows.Forms.ListBox listBoxCur;
        private System.Windows.Forms.Label labelHP;
        private System.Windows.Forms.Label labelLvl;
        private System.Windows.Forms.Label labelExp;
        private System.Windows.Forms.Label labelStr;
        private System.Windows.Forms.Label labelAgi;
        private System.Windows.Forms.Button buttonMap;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

