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
            this.coderBtn = new System.Windows.Forms.Button();
            this.stopSimulation = new System.Windows.Forms.Button();
            this.runSimulation = new System.Windows.Forms.Button();
            this.projectManagerBtn = new System.Windows.Forms.Button();
            this.designerBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // logBox
            // 
            this.logBox.Location = new System.Drawing.Point(343, 38);
            this.logBox.Multiline = true;
            this.logBox.Name = "logBox";
            this.logBox.Size = new System.Drawing.Size(423, 297);
            this.logBox.TabIndex = 0;
            // 
            // coderBtn
            // 
            this.coderBtn.Location = new System.Drawing.Point(24, 38);
            this.coderBtn.Name = "coderBtn";
            this.coderBtn.Size = new System.Drawing.Size(239, 80);
            this.coderBtn.TabIndex = 1;
            this.coderBtn.Text = "Coder";
            this.coderBtn.UseVisualStyleBackColor = true;
            // 
            // stopSimulation
            // 
            this.stopSimulation.Location = new System.Drawing.Point(24, 358);
            this.stopSimulation.Name = "stopSimulation";
            this.stopSimulation.Size = new System.Drawing.Size(320, 80);
            this.stopSimulation.TabIndex = 2;
            this.stopSimulation.Text = "Stop";
            this.stopSimulation.UseVisualStyleBackColor = true;
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
            // projectManagerBtn
            // 
            this.projectManagerBtn.Location = new System.Drawing.Point(24, 255);
            this.projectManagerBtn.Name = "projectManagerBtn";
            this.projectManagerBtn.Size = new System.Drawing.Size(239, 80);
            this.projectManagerBtn.TabIndex = 4;
            this.projectManagerBtn.Text = "Project manager";
            this.projectManagerBtn.UseVisualStyleBackColor = true;
            // 
            // designerBtn
            // 
            this.designerBtn.Location = new System.Drawing.Point(24, 148);
            this.designerBtn.Name = "designerBtn";
            this.designerBtn.Size = new System.Drawing.Size(239, 80);
            this.designerBtn.TabIndex = 5;
            this.designerBtn.Text = "Designer";
            this.designerBtn.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.designerBtn);
            this.Controls.Add(this.projectManagerBtn);
            this.Controls.Add(this.runSimulation);
            this.Controls.Add(this.stopSimulation);
            this.Controls.Add(this.coderBtn);
            this.Controls.Add(this.logBox);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button coderBtn;
        private System.Windows.Forms.Button stopSimulation;
        private System.Windows.Forms.Button runSimulation;
        private System.Windows.Forms.Button projectManagerBtn;
        private System.Windows.Forms.Button designerBtn;

        private System.Windows.Forms.TextBox logBox;

        #endregion
    }
}

