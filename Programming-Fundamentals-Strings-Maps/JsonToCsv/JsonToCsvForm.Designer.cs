namespace JsonToCsvConverter
{
	partial class JsonToCsvForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(JsonToCsvForm));
			btnRequest = new Button();
			textBoxJson = new TextBox();
			textBoxCsv = new TextBox();
			labelJson = new Label();
			labelCsv = new Label();
			labelUrl = new Label();
			btnConvert = new Button();
			textBoxUserInput = new TextBox();
			labelEndpoints = new Label();
			SuspendLayout();
			// 
			// btnRequest
			// 
			btnRequest.Location = new Point(485, 121);
			btnRequest.Name = "btnRequest";
			btnRequest.Size = new Size(170, 51);
			btnRequest.TabIndex = 1;
			btnRequest.Text = "Request API";
			btnRequest.UseVisualStyleBackColor = true;
			btnRequest.Click += RequestButtonClick;
			// 
			// textBoxJson
			// 
			textBoxJson.BackColor = SystemColors.Window;
			textBoxJson.Location = new Point(32, 121);
			textBoxJson.Margin = new Padding(3, 4, 3, 4);
			textBoxJson.Multiline = true;
			textBoxJson.Name = "textBoxJson";
			textBoxJson.ReadOnly = true;
			textBoxJson.ScrollBars = ScrollBars.Vertical;
			textBoxJson.Size = new Size(431, 460);
			textBoxJson.TabIndex = 2;
			textBoxJson.TextChanged += JsonTextBoxTextChanged;
			// 
			// textBoxCsv
			// 
			textBoxCsv.AccessibleDescription = "";
			textBoxCsv.BackColor = SystemColors.Window;
			textBoxCsv.Location = new Point(674, 121);
			textBoxCsv.Margin = new Padding(3, 4, 3, 4);
			textBoxCsv.Multiline = true;
			textBoxCsv.Name = "textBoxCsv";
			textBoxCsv.ReadOnly = true;
			textBoxCsv.ScrollBars = ScrollBars.Both;
			textBoxCsv.Size = new Size(431, 460);
			textBoxCsv.TabIndex = 3;
			textBoxCsv.WordWrap = false;
			textBoxCsv.TextChanged += CsvTextBoxTextChanged;
			// 
			// labelJson
			// 
			labelJson.AutoSize = true;
			labelJson.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			labelJson.ForeColor = SystemColors.Window;
			labelJson.Location = new Point(223, 85);
			labelJson.Name = "labelJson";
			labelJson.Size = new Size(47, 20);
			labelJson.TabIndex = 6;
			labelJson.Text = "JSON";
			// 
			// labelCsv
			// 
			labelCsv.AutoSize = true;
			labelCsv.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			labelCsv.ForeColor = SystemColors.Window;
			labelCsv.Location = new Point(863, 85);
			labelCsv.Name = "labelCsv";
			labelCsv.Size = new Size(36, 20);
			labelCsv.TabIndex = 7;
			labelCsv.Text = "CSV";
			// 
			// labelUrl
			// 
			labelUrl.AutoSize = true;
			labelUrl.BackColor = Color.DimGray;
			labelUrl.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
			labelUrl.ForeColor = SystemColors.Window;
			labelUrl.Location = new Point(354, 52);
			labelUrl.Name = "labelUrl";
			labelUrl.Size = new Size(263, 25);
			labelUrl.TabIndex = 8;
			labelUrl.Text = " https://restcountries.com/v3.1/";
			// 
			// btnConvert
			// 
			btnConvert.Location = new Point(485, 179);
			btnConvert.Name = "btnConvert";
			btnConvert.Size = new Size(170, 51);
			btnConvert.TabIndex = 9;
			btnConvert.Text = "Convert to CSV";
			btnConvert.UseVisualStyleBackColor = true;
			btnConvert.Visible = false;
			btnConvert.Click += ConvertButtonClick;
			// 
			// textBoxUserInput
			// 
			textBoxUserInput.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point);
			textBoxUserInput.Location = new Point(623, 47);
			textBoxUserInput.Name = "textBoxUserInput";
			textBoxUserInput.Size = new Size(158, 30);
			textBoxUserInput.TabIndex = 1;
			// 
			// labelEndpoints
			// 
			labelEndpoints.BorderStyle = BorderStyle.FixedSingle;
			labelEndpoints.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
			labelEndpoints.ForeColor = SystemColors.Window;
			labelEndpoints.Location = new Point(485, 265);
			labelEndpoints.Name = "labelEndpoints";
			labelEndpoints.Size = new Size(170, 187);
			labelEndpoints.TabIndex = 10;
			labelEndpoints.Text = "Endpoints:\r\n - name/{name}\r\n   (name/peru)\r\n - region/{region}\r\n   (region/europe)\r\n - subregion/{region}\r\n   (subregion/europe)\r\n - capital/{capital}\r\n   (capital/lima)";
			// 
			// JsonToCsvForm
			// 
			AcceptButton = btnRequest;
			AutoScaleDimensions = new SizeF(8F, 20F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(64, 64, 64);
			ClientSize = new Size(1132, 614);
			Controls.Add(labelEndpoints);
			Controls.Add(textBoxUserInput);
			Controls.Add(btnConvert);
			Controls.Add(labelUrl);
			Controls.Add(labelCsv);
			Controls.Add(labelJson);
			Controls.Add(textBoxCsv);
			Controls.Add(textBoxJson);
			Controls.Add(btnRequest);
			Icon = (Icon)resources.GetObject("$this.Icon");
			Margin = new Padding(4, 5, 4, 5);
			MaximumSize = new Size(1150, 680);
			MinimizeBox = false;
			MinimumSize = new Size(1150, 661);
			Name = "JsonToCsvForm";
			Text = "JSON to CSV";
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private System.Windows.Forms.Button btnRequest;
		private System.Windows.Forms.TextBox textBoxJson;
		private System.Windows.Forms.TextBox textBoxCsv;
		private Label labelJson;
		private Label labelCsv;
		private Label labelUrl;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.TextBox textBoxUserInput;
		private Label labelEndpoints;
	}
}

