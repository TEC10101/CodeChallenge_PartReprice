using PartReprice.Data.Models;

namespace PartReprice
{
    partial class PartRepriceUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PartData_btn = new System.Windows.Forms.Button();
            this.RepriceData_btn = new System.Windows.Forms.Button();
            this.Submit_btn = new System.Windows.Forms.Button();
            this.PartData_Label = new System.Windows.Forms.Label();
            this.RepriceData_Label = new System.Windows.Forms.Label();
            this.SubmitMessage = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PartData_btn
            // 
            this.PartData_btn.Location = new System.Drawing.Point(34, 88);
            this.PartData_btn.Name = "PartData_btn";
            this.PartData_btn.Size = new System.Drawing.Size(111, 38);
            this.PartData_btn.TabIndex = 0;
            this.PartData_btn.Text = "Part Data File";
            this.PartData_btn.UseVisualStyleBackColor = true;
            this.PartData_btn.Click += new System.EventHandler(this.ReadPartDataButton_Click);
            // 
            // RepriceData_btn
            // 
            this.RepriceData_btn.Location = new System.Drawing.Point(34, 158);
            this.RepriceData_btn.Name = "RepriceData_btn";
            this.RepriceData_btn.Size = new System.Drawing.Size(111, 38);
            this.RepriceData_btn.TabIndex = 1;
            this.RepriceData_btn.Text = "Reprice File";
            this.RepriceData_btn.UseVisualStyleBackColor = true;
            this.RepriceData_btn.Click += new System.EventHandler(this.ReadRepriceButton_Click);
            // 
            // Submit_btn
            // 
            this.Submit_btn.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.Submit_btn.Location = new System.Drawing.Point(34, 231);
            this.Submit_btn.Name = "Submit_btn";
            this.Submit_btn.Size = new System.Drawing.Size(109, 38);
            this.Submit_btn.TabIndex = 2;
            this.Submit_btn.Text = "Reprice";
            this.Submit_btn.UseVisualStyleBackColor = true;
            this.Submit_btn.Click += new System.EventHandler(this.Submit_btn_Click);
            // 
            // PartData_Label
            // 
            this.PartData_Label.AutoSize = true;
            this.PartData_Label.Location = new System.Drawing.Point(203, 100);
            this.PartData_Label.Name = "PartData_Label";
            this.PartData_Label.Size = new System.Drawing.Size(141, 15);
            this.PartData_Label.TabIndex = 3;
            this.PartData_Label.Text = "No Part Data File Chosen!";
            // 
            // RepriceData_Label
            // 
            this.RepriceData_Label.AutoSize = true;
            this.RepriceData_Label.Location = new System.Drawing.Point(206, 171);
            this.RepriceData_Label.Name = "RepriceData_Label";
            this.RepriceData_Label.Size = new System.Drawing.Size(132, 15);
            this.RepriceData_Label.TabIndex = 4;
            this.RepriceData_Label.Text = "No Reprice File Chosen!";
            // 
            // SubmitMessage
            // 
            this.SubmitMessage.AutoSize = true;
            this.SubmitMessage.Location = new System.Drawing.Point(208, 240);
            this.SubmitMessage.Name = "SubmitMessage";
            this.SubmitMessage.Size = new System.Drawing.Size(0, 15);
            this.SubmitMessage.TabIndex = 5;
            // 
            // PartRepriceUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(418, 329);
            this.Controls.Add(this.SubmitMessage);
            this.Controls.Add(this.RepriceData_Label);
            this.Controls.Add(this.PartData_Label);
            this.Controls.Add(this.Submit_btn);
            this.Controls.Add(this.RepriceData_btn);
            this.Controls.Add(this.PartData_btn);
            this.Name = "PartRepriceUI";
            this.Text = "Reprice Parts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private List<PartData> partsData;
        private List<Reprices> reprices;
        private string partDataFilePath; // Used to save the new prices.

        private Button PartData_btn;
        private Button RepriceData_btn;
        private Button Submit_btn;
        private Label PartData_Label;
        private Label RepriceData_Label;
        private Label SubmitMessage;
    }
}