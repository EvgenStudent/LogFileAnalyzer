namespace AnalyzerForm.FormsForParameters
{
	partial class ParametersForDate
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ParametersForDate));
			this.button_complete = new System.Windows.Forms.Button();
			this.textBox_minDate = new System.Windows.Forms.TextBox();
			this.textBox_maxDate = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// button_complete
			// 
			this.button_complete.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.button_complete.Location = new System.Drawing.Point(12, 58);
			this.button_complete.Name = "button_complete";
			this.button_complete.Size = new System.Drawing.Size(189, 28);
			this.button_complete.TabIndex = 0;
			this.button_complete.Text = "Complete";
			this.button_complete.UseVisualStyleBackColor = true;
			this.button_complete.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox_minDate
			// 
			this.textBox_minDate.Location = new System.Drawing.Point(95, 6);
			this.textBox_minDate.MaxLength = 50;
			this.textBox_minDate.Name = "textBox_minDate";
			this.textBox_minDate.Size = new System.Drawing.Size(106, 20);
			this.textBox_minDate.TabIndex = 1;
			// 
			// textBox_maxDate
			// 
			this.textBox_maxDate.Location = new System.Drawing.Point(95, 32);
			this.textBox_maxDate.MaxLength = 50;
			this.textBox_maxDate.Name = "textBox_maxDate";
			this.textBox_maxDate.Size = new System.Drawing.Size(106, 20);
			this.textBox_maxDate.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(9, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 13);
			this.label1.TabIndex = 3;
			this.label1.Text = "Min value date:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(9, 35);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(83, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Max value date:";
			// 
			// ParametersForDate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(213, 98);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox_maxDate);
			this.Controls.Add(this.textBox_minDate);
			this.Controls.Add(this.button_complete);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "ParametersForDate";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "ParametersForData";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_complete;
		private System.Windows.Forms.TextBox textBox_minDate;
		private System.Windows.Forms.TextBox textBox_maxDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}