﻿namespace SRT_editor
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
            this.btnopen = new System.Windows.Forms.Button();
            this.txtboxfrom = new System.Windows.Forms.RichTextBox();
            this.txtboxto = new System.Windows.Forms.RichTextBox();
            this.btnsave = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboboxto = new System.Windows.Forms.ComboBox();
            this.btntranslate = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.comboboxfrom = new System.Windows.Forms.ComboBox();
            this.AddTimeOffsetBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnopen
            // 
            this.btnopen.Location = new System.Drawing.Point(204, 18);
            this.btnopen.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnopen.Name = "btnopen";
            this.btnopen.Size = new System.Drawing.Size(132, 35);
            this.btnopen.TabIndex = 0;
            this.btnopen.Text = "Open SRT file";
            this.btnopen.UseVisualStyleBackColor = true;
            this.btnopen.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtboxfrom
            // 
            this.txtboxfrom.Location = new System.Drawing.Point(36, 80);
            this.txtboxfrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtboxfrom.Name = "txtboxfrom";
            this.txtboxfrom.Size = new System.Drawing.Size(514, 522);
            this.txtboxfrom.TabIndex = 1;
            this.txtboxfrom.Text = "";
            // 
            // txtboxto
            // 
            this.txtboxto.Location = new System.Drawing.Point(777, 80);
            this.txtboxto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtboxto.Name = "txtboxto";
            this.txtboxto.Size = new System.Drawing.Size(514, 522);
            this.txtboxto.TabIndex = 1;
            this.txtboxto.Text = "";
            // 
            // btnsave
            // 
            this.btnsave.Location = new System.Drawing.Point(946, 18);
            this.btnsave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnsave.Name = "btnsave";
            this.btnsave.Size = new System.Drawing.Size(148, 35);
            this.btnsave.TabIndex = 0;
            this.btnsave.Text = "Save SRT file";
            this.btnsave.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(244, 631);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Language";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(981, 631);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Language";
            // 
            // comboboxto
            // 
            this.comboboxto.FormattingEnabled = true;
            this.comboboxto.Items.AddRange(new object[] {
            "Dutch",
            "English",
            "German",
            "French"});
            this.comboboxto.Location = new System.Drawing.Point(946, 660);
            this.comboboxto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboboxto.Name = "comboboxto";
            this.comboboxto.Size = new System.Drawing.Size(180, 28);
            this.comboboxto.TabIndex = 2;
            // 
            // btntranslate
            // 
            this.btntranslate.Location = new System.Drawing.Point(598, 223);
            this.btntranslate.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btntranslate.Name = "btntranslate";
            this.btntranslate.Size = new System.Drawing.Size(132, 35);
            this.btntranslate.TabIndex = 0;
            this.btntranslate.Text = "Translate";
            this.btntranslate.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(740, 231);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "-->";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(561, 231);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "-->";
            // 
            // comboboxfrom
            // 
            this.comboboxfrom.FormattingEnabled = true;
            this.comboboxfrom.Items.AddRange(new object[] {
            "Dutch",
            "English",
            "German",
            "French"});
            this.comboboxfrom.Location = new System.Drawing.Point(204, 660);
            this.comboboxfrom.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboboxfrom.Name = "comboboxfrom";
            this.comboboxfrom.Size = new System.Drawing.Size(180, 28);
            this.comboboxfrom.TabIndex = 2;
            // 
            // AddTimeOffsetBtn
            // 
            this.AddTimeOffsetBtn.Location = new System.Drawing.Point(598, 905);
            this.AddTimeOffsetBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddTimeOffsetBtn.Name = "AddTimeOffsetBtn";
            this.AddTimeOffsetBtn.Size = new System.Drawing.Size(132, 35);
            this.AddTimeOffsetBtn.TabIndex = 5;
            this.AddTimeOffsetBtn.Text = "Add Time-offset";
            this.AddTimeOffsetBtn.UseVisualStyleBackColor = true;
            this.AddTimeOffsetBtn.Click += new System.EventHandler(this.AddTimeOffsetBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1348, 974);
            this.Controls.Add(this.AddTimeOffsetBtn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboboxto);
            this.Controls.Add(this.comboboxfrom);
            this.Controls.Add(this.txtboxto);
            this.Controls.Add(this.txtboxfrom);
            this.Controls.Add(this.btnsave);
            this.Controls.Add(this.btntranslate);
            this.Controls.Add(this.btnopen);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "SRT editor";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnopen;
        private System.Windows.Forms.RichTextBox txtboxfrom;
        private System.Windows.Forms.RichTextBox txtboxto;
        private System.Windows.Forms.Button btnsave;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboboxto;
        private System.Windows.Forms.Button btntranslate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.ComboBox comboboxfrom;
        private System.Windows.Forms.Button AddTimeOffsetBtn;
    }
}

