namespace Secuirty_Plus_Project
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
            this.btnGenerate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.cboQuiz = new System.Windows.Forms.ComboBox();
            this.txtQuestions = new System.Windows.Forms.TextBox();
            this.lblSelect = new System.Windows.Forms.Label();
            this.lblQuestions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnGenerate
            // 
            this.btnGenerate.Font = new System.Drawing.Font("Perpetua", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerate.Location = new System.Drawing.Point(227, 217);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(140, 89);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "Generate Qustion(s)";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Perpetua", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.label2.Location = new System.Drawing.Point(147, 55);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(308, 33);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ascend Question Generator";
            this.label2.UseWaitCursor = true;
            // 
            // cboQuiz
            // 
            this.cboQuiz.FormattingEnabled = true;
            this.cboQuiz.Location = new System.Drawing.Point(178, 175);
            this.cboQuiz.Name = "cboQuiz";
            this.cboQuiz.Size = new System.Drawing.Size(113, 21);
            this.cboQuiz.TabIndex = 12;
            // 
            // txtQuestions
            // 
            this.txtQuestions.Location = new System.Drawing.Point(313, 175);
            this.txtQuestions.Name = "txtQuestions";
            this.txtQuestions.Size = new System.Drawing.Size(113, 20);
            this.txtQuestions.TabIndex = 13;
            // 
            // lblSelect
            // 
            this.lblSelect.AutoSize = true;
            this.lblSelect.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSelect.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblSelect.Location = new System.Drawing.Point(197, 154);
            this.lblSelect.Name = "lblSelect";
            this.lblSelect.Size = new System.Drawing.Size(77, 18);
            this.lblSelect.TabIndex = 14;
            this.lblSelect.Text = "Select Quiz";
            // 
            // lblQuestions
            // 
            this.lblQuestions.AutoSize = true;
            this.lblQuestions.Font = new System.Drawing.Font("Perpetua", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblQuestions.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblQuestions.Location = new System.Drawing.Point(320, 155);
            this.lblQuestions.Name = "lblQuestions";
            this.lblQuestions.Size = new System.Drawing.Size(97, 18);
            this.lblQuestions.TabIndex = 15;
            this.lblQuestions.Text = "# of Questions";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SlateBlue;
            this.ClientSize = new System.Drawing.Size(602, 324);
            this.Controls.Add(this.lblQuestions);
            this.Controls.Add(this.lblSelect);
            this.Controls.Add(this.txtQuestions);
            this.Controls.Add(this.cboQuiz);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnGenerate);
            this.Name = "Form1";
            this.Text = "Security Plus";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cboQuiz;
        private System.Windows.Forms.TextBox txtQuestions;
        private System.Windows.Forms.Label lblSelect;
        private System.Windows.Forms.Label lblQuestions;
    }
}

