using System.ComponentModel;

namespace lab2
{
    partial class AddEntityForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.descriptionTextBox = new System.Windows.Forms.TextBox();
            this.rimeRequiredTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.saveNewTask = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // descriptionTextBox
            // 
            this.descriptionTextBox.Location = new System.Drawing.Point(12, 45);
            this.descriptionTextBox.Name = "descriptionTextBox";
            this.descriptionTextBox.Size = new System.Drawing.Size(309, 22);
            this.descriptionTextBox.TabIndex = 0;
            // 
            // rimeRequiredTextBox
            // 
            this.rimeRequiredTextBox.Location = new System.Drawing.Point(360, 45);
            this.rimeRequiredTextBox.Name = "rimeRequiredTextBox";
            this.rimeRequiredTextBox.Size = new System.Drawing.Size(155, 22);
            this.rimeRequiredTextBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(308, 22);
            this.label1.TabIndex = 2;
            this.label1.Text = "Task description";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(360, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Time required";
            // 
            // saveNewTask
            // 
            this.saveNewTask.Location = new System.Drawing.Point(12, 82);
            this.saveNewTask.Name = "saveNewTask";
            this.saveNewTask.Size = new System.Drawing.Size(503, 33);
            this.saveNewTask.TabIndex = 4;
            this.saveNewTask.Text = "Save";
            this.saveNewTask.UseVisualStyleBackColor = true;
            this.saveNewTask.Click += new System.EventHandler(this.saveNewTask_Click);
            // 
            // AddEntityForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(545, 127);
            this.Controls.Add(this.saveNewTask);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rimeRequiredTextBox);
            this.Controls.Add(this.descriptionTextBox);
            this.Name = "AddEntityForm";
            this.Text = "AddEntityForm";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button saveNewTask;

        private System.Windows.Forms.TextBox descriptionTextBox;
        private System.Windows.Forms.TextBox rimeRequiredTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        #endregion
    }
}