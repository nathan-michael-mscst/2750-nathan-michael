namespace StudentInfo3B
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
            this.dateTextBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.saveGradeButton = new System.Windows.Forms.Button();
            this.pointsTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.assignmentsListBox = new System.Windows.Forms.ListBox();
            this.enrollmentsListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.sectionsDropDownList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.coursesDropDownList = new System.Windows.Forms.ComboBox();
            this.termsDropDownList = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.departmentsDropDownList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // dateTextBox
            // 
            this.dateTextBox.Location = new System.Drawing.Point(157, 322);
            this.dateTextBox.Name = "dateTextBox";
            this.dateTextBox.Size = new System.Drawing.Size(100, 20);
            this.dateTextBox.TabIndex = 47;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(67, 13);
            this.label7.TabIndex = 46;
            this.label7.Text = "Points/Date:";
            // 
            // saveGradeButton
            // 
            this.saveGradeButton.Location = new System.Drawing.Point(263, 322);
            this.saveGradeButton.Name = "saveGradeButton";
            this.saveGradeButton.Size = new System.Drawing.Size(67, 23);
            this.saveGradeButton.TabIndex = 45;
            this.saveGradeButton.Text = "Save";
            this.saveGradeButton.UseVisualStyleBackColor = true;
            this.saveGradeButton.Click += new System.EventHandler(this.saveGradeButton_Click);
            // 
            // pointsTextBox
            // 
            this.pointsTextBox.Location = new System.Drawing.Point(99, 322);
            this.pointsTextBox.Name = "pointsTextBox";
            this.pointsTextBox.Size = new System.Drawing.Size(52, 20);
            this.pointsTextBox.TabIndex = 44;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(21, 234);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 43;
            this.label6.Text = "Assignments:";
            // 
            // assignmentsListBox
            // 
            this.assignmentsListBox.FormattingEnabled = true;
            this.assignmentsListBox.Location = new System.Drawing.Point(99, 234);
            this.assignmentsListBox.Name = "assignmentsListBox";
            this.assignmentsListBox.Size = new System.Drawing.Size(231, 82);
            this.assignmentsListBox.TabIndex = 42;
            this.assignmentsListBox.SelectedValueChanged += new System.EventHandler(this.assignmentsListBox_SelectedValueChanged);
            // 
            // enrollmentsListBox
            // 
            this.enrollmentsListBox.FormattingEnabled = true;
            this.enrollmentsListBox.Location = new System.Drawing.Point(99, 120);
            this.enrollmentsListBox.Name = "enrollmentsListBox";
            this.enrollmentsListBox.Size = new System.Drawing.Size(231, 108);
            this.enrollmentsListBox.TabIndex = 41;
            this.enrollmentsListBox.SelectedValueChanged += new System.EventHandler(this.enrollmentsListBox_SelectedValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 123);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 13);
            this.label5.TabIndex = 40;
            this.label5.Text = "Student:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Section:";
            // 
            // sectionsDropDownList
            // 
            this.sectionsDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.sectionsDropDownList.FormattingEnabled = true;
            this.sectionsDropDownList.Location = new System.Drawing.Point(99, 93);
            this.sectionsDropDownList.Name = "sectionsDropDownList";
            this.sectionsDropDownList.Size = new System.Drawing.Size(170, 21);
            this.sectionsDropDownList.TabIndex = 39;
            this.sectionsDropDownList.SelectedValueChanged += new System.EventHandler(this.sectionsDropDownList_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "Term:";
            // 
            // coursesDropDownList
            // 
            this.coursesDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.coursesDropDownList.FormattingEnabled = true;
            this.coursesDropDownList.Location = new System.Drawing.Point(99, 39);
            this.coursesDropDownList.Name = "coursesDropDownList";
            this.coursesDropDownList.Size = new System.Drawing.Size(231, 21);
            this.coursesDropDownList.TabIndex = 35;
            this.coursesDropDownList.SelectedValueChanged += new System.EventHandler(this.coursesDropDownList_SelectedValueChanged);
            // 
            // termsDropDownList
            // 
            this.termsDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.termsDropDownList.FormattingEnabled = true;
            this.termsDropDownList.Location = new System.Drawing.Point(99, 66);
            this.termsDropDownList.Name = "termsDropDownList";
            this.termsDropDownList.Size = new System.Drawing.Size(170, 21);
            this.termsDropDownList.TabIndex = 37;
            this.termsDropDownList.SelectedValueChanged += new System.EventHandler(this.termsDropDownList_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "Course:";
            // 
            // departmentsDropDownList
            // 
            this.departmentsDropDownList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.departmentsDropDownList.FormattingEnabled = true;
            this.departmentsDropDownList.Location = new System.Drawing.Point(99, 12);
            this.departmentsDropDownList.Name = "departmentsDropDownList";
            this.departmentsDropDownList.Size = new System.Drawing.Size(170, 21);
            this.departmentsDropDownList.TabIndex = 33;
            this.departmentsDropDownList.SelectedValueChanged += new System.EventHandler(this.departmentsDropDownList_SelectedValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Department:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 360);
            this.Controls.Add(this.dateTextBox);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.saveGradeButton);
            this.Controls.Add(this.pointsTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.assignmentsListBox);
            this.Controls.Add(this.enrollmentsListBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.sectionsDropDownList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.coursesDropDownList);
            this.Controls.Add(this.termsDropDownList);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.departmentsDropDownList);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Exercise 3B: WinForm & Entity Framework";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox dateTextBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button saveGradeButton;
        private System.Windows.Forms.TextBox pointsTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ListBox assignmentsListBox;
        private System.Windows.Forms.ListBox enrollmentsListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox sectionsDropDownList;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox coursesDropDownList;
        private System.Windows.Forms.ComboBox termsDropDownList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox departmentsDropDownList;
        private System.Windows.Forms.Label label1;
    }
}

