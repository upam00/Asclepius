namespace DBMS_App
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCon = new System.Windows.Forms.TextBox();
            this.conBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(183, 126);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(444, 48);
            this.label1.TabIndex = 0;
            this.label1.Text = "Please Enter Connection String";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCon
            // 
            this.txtCon.Location = new System.Drawing.Point(59, 204);
            this.txtCon.Name = "txtCon";
            this.txtCon.Size = new System.Drawing.Size(696, 20);
            this.txtCon.TabIndex = 1;
            // 
            // conBtn
            // 
            this.conBtn.AutoSize = true;
            this.conBtn.Location = new System.Drawing.Point(344, 258);
            this.conBtn.Name = "conBtn";
            this.conBtn.Size = new System.Drawing.Size(137, 36);
            this.conBtn.TabIndex = 2;
            this.conBtn.Text = "Connect";
            this.conBtn.UseVisualStyleBackColor = true;
            this.conBtn.Click += new System.EventHandler(this.conBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.conBtn);
            this.Controls.Add(this.txtCon);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCon;
        private System.Windows.Forms.Button conBtn;
    }
}

