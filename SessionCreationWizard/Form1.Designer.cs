namespace SessionCreationWizard
{
    partial class SessionCreationWizard
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
            this.wizardControl1 = new AeroWizard.WizardControl();
            this.typeSelectPage = new AeroWizard.WizardPage();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.timeAndDateSelectPage = new AeroWizard.WizardPage();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tutorSelectPage = new AeroWizard.WizardPage();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).BeginInit();
            this.typeSelectPage.SuspendLayout();
            this.timeAndDateSelectPage.SuspendLayout();
            this.tutorSelectPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // wizardControl1
            // 
            this.wizardControl1.BackColor = System.Drawing.Color.White;
            this.wizardControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wizardControl1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.wizardControl1.Location = new System.Drawing.Point(0, 0);
            this.wizardControl1.Name = "wizardControl1";
            this.wizardControl1.Pages.Add(this.typeSelectPage);
            this.wizardControl1.Pages.Add(this.timeAndDateSelectPage);
            this.wizardControl1.Pages.Add(this.tutorSelectPage);
            this.wizardControl1.Size = new System.Drawing.Size(703, 481);
            this.wizardControl1.TabIndex = 0;
            this.wizardControl1.Text = "Wizard Title";
            this.wizardControl1.Title = "Create A New Session";
            this.wizardControl1.SelectedPageChanged += new System.EventHandler(this.wizardControl1_SelectedPageChanged);
            // 
            // typeSelectPage
            // 
            this.typeSelectPage.Controls.Add(this.radioButton2);
            this.typeSelectPage.Controls.Add(this.radioButton1);
            this.typeSelectPage.Controls.Add(this.label1);
            this.typeSelectPage.Name = "typeSelectPage";
            this.typeSelectPage.Size = new System.Drawing.Size(656, 307);
            this.typeSelectPage.TabIndex = 0;
            this.typeSelectPage.Text = "Choose A Type";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(229, 203);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(118, 24);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Tutor Session";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(229, 173);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(120, 24);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Study Session";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(349, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please choose the type of session you would prefer:";
            this.label1.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // timeAndDateSelectPage
            // 
            this.timeAndDateSelectPage.Controls.Add(this.comboBox2);
            this.timeAndDateSelectPage.Controls.Add(this.comboBox1);
            this.timeAndDateSelectPage.Controls.Add(this.label2);
            this.timeAndDateSelectPage.Name = "timeAndDateSelectPage";
            this.timeAndDateSelectPage.Size = new System.Drawing.Size(656, 307);
            this.timeAndDateSelectPage.TabIndex = 1;
            this.timeAndDateSelectPage.Text = "Choose A Time and Date";
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(326, 169);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(121, 28);
            this.comboBox2.TabIndex = 2;
            this.comboBox2.Text = "Time";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(178, 169);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 1;
            this.comboBox1.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(313, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Please choose a time and date for the session:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // tutorSelectPage
            // 
            this.tutorSelectPage.Controls.Add(this.comboBox3);
            this.tutorSelectPage.Controls.Add(this.label3);
            this.tutorSelectPage.Name = "tutorSelectPage";
            this.tutorSelectPage.Size = new System.Drawing.Size(656, 307);
            this.tutorSelectPage.TabIndex = 2;
            this.tutorSelectPage.Text = "Choose A Tutor";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(241, 188);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(121, 28);
            this.comboBox3.TabIndex = 1;
            this.comboBox3.Text = "Tutors";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(201, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(233, 20);
            this.label3.TabIndex = 0;
            this.label3.Text = "Please choose an availabele tutor:";
            // 
            // textBox1
            // 
            this.textBox1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.textBox1.Location = new System.Drawing.Point(38, 108);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(598, 309);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // SessionCreationWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(703, 481);
            this.Controls.Add(this.wizardControl1);
            this.Controls.Add(this.textBox1);
            this.Name = "SessionCreationWizard";
            this.Text = "Session Creation Wizard";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.wizardControl1)).EndInit();
            this.typeSelectPage.ResumeLayout(false);
            this.typeSelectPage.PerformLayout();
            this.timeAndDateSelectPage.ResumeLayout(false);
            this.timeAndDateSelectPage.PerformLayout();
            this.tutorSelectPage.ResumeLayout(false);
            this.tutorSelectPage.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private AeroWizard.WizardControl wizardControl1;
        private System.Windows.Forms.TextBox textBox1;
        private AeroWizard.WizardPage typeSelectPage;
        private AeroWizard.WizardPage timeAndDateSelectPage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private AeroWizard.WizardPage tutorSelectPage;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.Label label3;
    }
}

