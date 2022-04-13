namespace lab2
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.logBox = new System.Windows.Forms.TextBox();
            this.coderInfoBtn = new System.Windows.Forms.Button();
            this.stopSimulation = new System.Windows.Forms.Button();
            this.runSimulation = new System.Windows.Forms.Button();
            this.coderAddTask = new System.Windows.Forms.Button();
            this.projectManagerAddTask = new System.Windows.Forms.Button();
            this.projectManagerInfoBtn = new System.Windows.Forms.Button();
            this.designerAddTask = new System.Windows.Forms.Button();
            this.designerInfoBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(343, 12);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(423, 321);
            this.logBox.TabIndex = 0;
            // 
            // coderInfoBtn
            // 
            this.coderInfoBtn.Location = new System.Drawing.Point(24, 12);
            this.coderInfoBtn.Name = "coderInfoBtn";
            this.coderInfoBtn.Size = new System.Drawing.Size(239, 45);
            this.coderInfoBtn.TabIndex = 1;
            this.coderInfoBtn.Text = "Coder info";
            this.coderInfoBtn.UseVisualStyleBackColor = true;
            this.coderInfoBtn.Click += new System.EventHandler(this.coderInfoBtn_Click);
            // 
            // stopSimulation
            // 
            this.stopSimulation.Location = new System.Drawing.Point(24, 358);
            this.stopSimulation.Name = "stopSimulation";
            this.stopSimulation.Size = new System.Drawing.Size(320, 80);
            this.stopSimulation.TabIndex = 2;
            this.stopSimulation.Text = "Stop";
            this.stopSimulation.UseVisualStyleBackColor = true;
            this.stopSimulation.Click += new System.EventHandler(this.stopSimulation_Click);
            // 
            // runSimulation
            // 
            this.runSimulation.Location = new System.Drawing.Point(413, 358);
            this.runSimulation.Name = "runSimulation";
            this.runSimulation.Size = new System.Drawing.Size(353, 80);
            this.runSimulation.TabIndex = 3;
            this.runSimulation.Text = "Run";
            this.runSimulation.UseVisualStyleBackColor = true;
            this.runSimulation.Click += new System.EventHandler(this.runSimulation_Click);
            // 
            // coderAddTask
            // 
            this.coderAddTask.Location = new System.Drawing.Point(24, 63);
            this.coderAddTask.Name = "coderAddTask";
            this.coderAddTask.Size = new System.Drawing.Size(239, 45);
            this.coderAddTask.TabIndex = 6;
            this.coderAddTask.Text = "Add task";
            this.coderAddTask.UseVisualStyleBackColor = true;
            // 
            // projectManagerAddTask
            // 
            this.projectManagerAddTask.Location = new System.Drawing.Point(24, 288);
            this.projectManagerAddTask.Name = "projectManagerAddTask";
            this.projectManagerAddTask.Size = new System.Drawing.Size(239, 45);
            this.projectManagerAddTask.TabIndex = 7;
            this.projectManagerAddTask.Text = "Add task";
            this.projectManagerAddTask.UseVisualStyleBackColor = true;
            // 
            // projectManagerInfoBtn
            // 
            this.projectManagerInfoBtn.Location = new System.Drawing.Point(24, 237);
            this.projectManagerInfoBtn.Name = "projectManagerInfoBtn";
            this.projectManagerInfoBtn.Size = new System.Drawing.Size(239, 45);
            this.projectManagerInfoBtn.TabIndex = 8;
            this.projectManagerInfoBtn.Text = "Project manager info";
            this.projectManagerInfoBtn.UseVisualStyleBackColor = true;
            this.projectManagerInfoBtn.Click += new System.EventHandler(this.projectManagerInfoBtn_Click);
            // 
            // designerAddTask
            // 
            this.designerAddTask.Location = new System.Drawing.Point(24, 176);
            this.designerAddTask.Name = "designerAddTask";
            this.designerAddTask.Size = new System.Drawing.Size(239, 45);
            this.designerAddTask.TabIndex = 9;
            this.designerAddTask.Text = "Add task";
            this.designerAddTask.UseVisualStyleBackColor = true;
            // 
            // designerInfoBtn
            // 
            this.designerInfoBtn.Location = new System.Drawing.Point(24, 125);
            this.designerInfoBtn.Name = "designerInfoBtn";
            this.designerInfoBtn.Size = new System.Drawing.Size(239, 45);
            this.designerInfoBtn.TabIndex = 10;
            this.designerInfoBtn.Text = "Designer info";
            this.designerInfoBtn.UseVisualStyleBackColor = true;
            this.designerInfoBtn.Click += new System.EventHandler(this.designerInfoBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.designerInfoBtn);
            this.Controls.Add(this.designerAddTask);
            this.Controls.Add(this.projectManagerInfoBtn);
            this.Controls.Add(this.projectManagerAddTask);
            this.Controls.Add(this.coderAddTask);
            this.Controls.Add(this.runSimulation);
            this.Controls.Add(this.stopSimulation);
            this.Controls.Add(this.coderInfoBtn);
            this.Controls.Add(this.logBox);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button coderAddTask;
        private System.Windows.Forms.Button projectManagerAddTask;
        private System.Windows.Forms.Button projectManagerInfoBtn;
        private System.Windows.Forms.Button designerAddTask;
        private System.Windows.Forms.Button designerInfoBtn;

        private System.Windows.Forms.Button coderInfoBtn;
        private System.Windows.Forms.Button stopSimulation;
        private System.Windows.Forms.Button runSimulation;

        private System.Windows.Forms.TextBox logBox;

        #endregion
    }
}

