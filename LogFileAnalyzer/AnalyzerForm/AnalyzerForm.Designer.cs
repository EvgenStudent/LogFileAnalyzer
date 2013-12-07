namespace AnalyzerForm
{
	partial class AnalyzerForm
	{
		/// <summary>
		/// Требуется переменная конструктора.
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
		/// Обязательный метод для поддержки конструктора - не изменяйте
		/// содержимое данного метода при помощи редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnalyzerForm));
			this.button_open = new System.Windows.Forms.Button();
			this.textBox_LogFileName = new System.Windows.Forms.TextBox();
			this.dataGridView_input = new System.Windows.Forms.DataGridView();
			this.groupBox_for_config = new System.Windows.Forms.GroupBox();
			this.label2 = new System.Windows.Forms.Label();
			this.radioButton_codes = new System.Windows.Forms.RadioButton();
			this.label1 = new System.Windows.Forms.Label();
			this.radioButton_ip = new System.Windows.Forms.RadioButton();
			this.textBox_maxDate = new System.Windows.Forms.TextBox();
			this.radioButton_date = new System.Windows.Forms.RadioButton();
			this.textBox_minDate = new System.Windows.Forms.TextBox();
			this.button_analyze = new System.Windows.Forms.Button();
			this.dataGridView_output = new System.Windows.Forms.DataGridView();
			this.button_save_report = new System.Windows.Forms.Button();
			this.button_open_report = new System.Windows.Forms.Button();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_input)).BeginInit();
			this.groupBox_for_config.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_output)).BeginInit();
			this.SuspendLayout();
			// 
			// button_open
			// 
			this.button_open.Location = new System.Drawing.Point(12, 12);
			this.button_open.Name = "button_open";
			this.button_open.Size = new System.Drawing.Size(105, 23);
			this.button_open.TabIndex = 0;
			this.button_open.Text = "Open";
			this.button_open.UseVisualStyleBackColor = true;
			this.button_open.Click += new System.EventHandler(this.button_open_Click);
			// 
			// textBox_LogFileName
			// 
			this.textBox_LogFileName.BackColor = System.Drawing.Color.White;
			this.textBox_LogFileName.Location = new System.Drawing.Point(123, 14);
			this.textBox_LogFileName.Name = "textBox_LogFileName";
			this.textBox_LogFileName.ReadOnly = true;
			this.textBox_LogFileName.Size = new System.Drawing.Size(819, 20);
			this.textBox_LogFileName.TabIndex = 1;
			// 
			// dataGridView_input
			// 
			this.dataGridView_input.AllowUserToAddRows = false;
			this.dataGridView_input.AllowUserToDeleteRows = false;
			this.dataGridView_input.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridView_input.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_input.Location = new System.Drawing.Point(12, 114);
			this.dataGridView_input.Name = "dataGridView_input";
			this.dataGridView_input.ReadOnly = true;
			this.dataGridView_input.Size = new System.Drawing.Size(930, 245);
			this.dataGridView_input.TabIndex = 2;
			// 
			// groupBox_for_config
			// 
			this.groupBox_for_config.Controls.Add(this.label2);
			this.groupBox_for_config.Controls.Add(this.radioButton_codes);
			this.groupBox_for_config.Controls.Add(this.label1);
			this.groupBox_for_config.Controls.Add(this.radioButton_ip);
			this.groupBox_for_config.Controls.Add(this.textBox_maxDate);
			this.groupBox_for_config.Controls.Add(this.radioButton_date);
			this.groupBox_for_config.Controls.Add(this.textBox_minDate);
			this.groupBox_for_config.Enabled = false;
			this.groupBox_for_config.Location = new System.Drawing.Point(345, 40);
			this.groupBox_for_config.Name = "groupBox_for_config";
			this.groupBox_for_config.Size = new System.Drawing.Size(597, 68);
			this.groupBox_for_config.TabIndex = 3;
			this.groupBox_for_config.TabStop = false;
			this.groupBox_for_config.Text = "Report";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(199, 45);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(54, 13);
			this.label2.TabIndex = 11;
			this.label2.Text = "Max date:";
			// 
			// radioButton_codes
			// 
			this.radioButton_codes.AutoSize = true;
			this.radioButton_codes.Location = new System.Drawing.Point(181, 19);
			this.radioButton_codes.Name = "radioButton_codes";
			this.radioButton_codes.Size = new System.Drawing.Size(92, 17);
			this.radioButton_codes.TabIndex = 2;
			this.radioButton_codes.TabStop = true;
			this.radioButton_codes.Text = "Cose statistics";
			this.radioButton_codes.UseVisualStyleBackColor = true;
			this.radioButton_codes.CheckedChanged += new System.EventHandler(this.radioButton_codes_CheckedChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(6, 45);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(51, 13);
			this.label1.TabIndex = 10;
			this.label1.Text = "Min date:";
			// 
			// radioButton_ip
			// 
			this.radioButton_ip.AutoSize = true;
			this.radioButton_ip.Location = new System.Drawing.Point(103, 19);
			this.radioButton_ip.Name = "radioButton_ip";
			this.radioButton_ip.Size = new System.Drawing.Size(72, 17);
			this.radioButton_ip.TabIndex = 1;
			this.radioButton_ip.TabStop = true;
			this.radioButton_ip.Text = "Unique IP";
			this.radioButton_ip.UseVisualStyleBackColor = true;
			this.radioButton_ip.CheckedChanged += new System.EventHandler(this.radioButton_ip_CheckedChanged);
			// 
			// textBox_maxDate
			// 
			this.textBox_maxDate.Location = new System.Drawing.Point(259, 42);
			this.textBox_maxDate.MaxLength = 10;
			this.textBox_maxDate.Name = "textBox_maxDate";
			this.textBox_maxDate.Size = new System.Drawing.Size(100, 20);
			this.textBox_maxDate.TabIndex = 9;
			this.textBox_maxDate.Leave += new System.EventHandler(this.textBox_date_Leave);
			// 
			// radioButton_date
			// 
			this.radioButton_date.AutoSize = true;
			this.radioButton_date.Location = new System.Drawing.Point(6, 19);
			this.radioButton_date.Name = "radioButton_date";
			this.radioButton_date.Size = new System.Drawing.Size(91, 17);
			this.radioButton_date.TabIndex = 0;
			this.radioButton_date.TabStop = true;
			this.radioButton_date.Text = "General traffic";
			this.radioButton_date.UseVisualStyleBackColor = true;
			this.radioButton_date.CheckedChanged += new System.EventHandler(this.radioButton_traffic_CheckedChanged);
			// 
			// textBox_minDate
			// 
			this.textBox_minDate.Location = new System.Drawing.Point(63, 42);
			this.textBox_minDate.MaxLength = 10;
			this.textBox_minDate.Name = "textBox_minDate";
			this.textBox_minDate.Size = new System.Drawing.Size(100, 20);
			this.textBox_minDate.TabIndex = 8;
			this.textBox_minDate.Leave += new System.EventHandler(this.textBox_date_Leave);
			// 
			// button_analyze
			// 
			this.button_analyze.Enabled = false;
			this.button_analyze.Location = new System.Drawing.Point(234, 40);
			this.button_analyze.Name = "button_analyze";
			this.button_analyze.Size = new System.Drawing.Size(105, 42);
			this.button_analyze.TabIndex = 4;
			this.button_analyze.Text = "Analyze";
			this.button_analyze.UseVisualStyleBackColor = true;
			this.button_analyze.Click += new System.EventHandler(this.button_analyze_Click);
			// 
			// dataGridView_output
			// 
			this.dataGridView_output.AllowUserToAddRows = false;
			this.dataGridView_output.AllowUserToDeleteRows = false;
			this.dataGridView_output.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
			this.dataGridView_output.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView_output.Location = new System.Drawing.Point(12, 365);
			this.dataGridView_output.Name = "dataGridView_output";
			this.dataGridView_output.ReadOnly = true;
			this.dataGridView_output.Size = new System.Drawing.Size(930, 201);
			this.dataGridView_output.TabIndex = 5;
			// 
			// button_save_report
			// 
			this.button_save_report.Enabled = false;
			this.button_save_report.Location = new System.Drawing.Point(123, 40);
			this.button_save_report.Name = "button_save_report";
			this.button_save_report.Size = new System.Drawing.Size(105, 42);
			this.button_save_report.TabIndex = 6;
			this.button_save_report.Text = "Save report";
			this.button_save_report.UseVisualStyleBackColor = true;
			this.button_save_report.Click += new System.EventHandler(this.button_save_report_Click);
			// 
			// button_open_report
			// 
			this.button_open_report.Enabled = false;
			this.button_open_report.Location = new System.Drawing.Point(12, 40);
			this.button_open_report.Name = "button_open_report";
			this.button_open_report.Size = new System.Drawing.Size(105, 42);
			this.button_open_report.TabIndex = 7;
			this.button_open_report.Text = "Open report";
			this.button_open_report.UseVisualStyleBackColor = true;
			this.button_open_report.Click += new System.EventHandler(this.button_open_report_Click);
			// 
			// AnalyzerForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(954, 578);
			this.Controls.Add(this.button_open_report);
			this.Controls.Add(this.button_save_report);
			this.Controls.Add(this.dataGridView_output);
			this.Controls.Add(this.button_analyze);
			this.Controls.Add(this.groupBox_for_config);
			this.Controls.Add(this.dataGridView_input);
			this.Controls.Add(this.textBox_LogFileName);
			this.Controls.Add(this.button_open);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "AnalyzerForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Analyzer";
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_input)).EndInit();
			this.groupBox_for_config.ResumeLayout(false);
			this.groupBox_for_config.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView_output)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button button_open;
		private System.Windows.Forms.DataGridView dataGridView_input;
		private System.Windows.Forms.GroupBox groupBox_for_config;
		private System.Windows.Forms.RadioButton radioButton_codes;
		private System.Windows.Forms.RadioButton radioButton_ip;
		private System.Windows.Forms.RadioButton radioButton_date;
		private System.Windows.Forms.Button button_analyze;
		private System.Windows.Forms.DataGridView dataGridView_output;
		private System.Windows.Forms.TextBox textBox_LogFileName;
		private System.Windows.Forms.Button button_save_report;
		private System.Windows.Forms.Button button_open_report;
		private System.Windows.Forms.TextBox textBox_minDate;
		private System.Windows.Forms.TextBox textBox_maxDate;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
	}
}

