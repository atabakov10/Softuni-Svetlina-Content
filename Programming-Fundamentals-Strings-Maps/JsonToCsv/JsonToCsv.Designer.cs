
namespace JsonToCsv
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
			this.btnConvert = new System.Windows.Forms.Button();
			this.jsonTextBox = new System.Windows.Forms.TextBox();
			this.csvTextBox = new System.Windows.Forms.TextBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.numberTextBox = new System.Windows.Forms.TextBox();
			this.numberLabel = new System.Windows.Forms.Label();
			this.jsonLabel = new System.Windows.Forms.Label();
			this.csvLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(457, 108);
			this.btnConvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(170, 51);
			this.btnConvert.TabIndex = 1;
			this.btnConvert.Text = "Submit number";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.ButtonConverter_Click);
			// 
			// jsonTextBox
			// 
			this.jsonTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.jsonTextBox.Location = new System.Drawing.Point(48, 132);
			this.jsonTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.jsonTextBox.Multiline = true;
			this.jsonTextBox.Name = "jsonTextBox";
			this.jsonTextBox.ReadOnly = true;
			this.jsonTextBox.Size = new System.Drawing.Size(301, 216);
			this.jsonTextBox.TabIndex = 2;
			// 
			// csvTextBox
			// 
			this.csvTextBox.AccessibleDescription = "";
			this.csvTextBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.csvTextBox.Location = new System.Drawing.Point(722, 132);
			this.csvTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.csvTextBox.Multiline = true;
			this.csvTextBox.Name = "csvTextBox";
			this.csvTextBox.ReadOnly = true;
			this.csvTextBox.Size = new System.Drawing.Size(301, 216);
			this.csvTextBox.TabIndex = 3;
			this.csvTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(479, 306);
			this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(113, 42);
			this.btnReset.TabIndex = 4;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// numberTextBox
			// 
			this.numberTextBox.Location = new System.Drawing.Point(530, 52);
			this.numberTextBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.numberTextBox.MaxLength = 1;
			this.numberTextBox.Name = "numberTextBox";
			this.numberTextBox.Size = new System.Drawing.Size(19, 27);
			this.numberTextBox.TabIndex = 0;
			this.numberTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.numberTextBox.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
			// 
			// numberLabel
			// 
			this.numberLabel.AutoSize = true;
			this.numberLabel.Location = new System.Drawing.Point(337, 28);
			this.numberLabel.Name = "numberLabel";
			this.numberLabel.Size = new System.Drawing.Size(212, 20);
			this.numberLabel.TabIndex = 5;
			this.numberLabel.Text = "Submit a number from 1 to 3 ↓";
			// 
			// jsonLabel
			// 
			this.jsonLabel.AutoSize = true;
			this.jsonLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.jsonLabel.Location = new System.Drawing.Point(172, 108);
			this.jsonLabel.Name = "jsonLabel";
			this.jsonLabel.Size = new System.Drawing.Size(47, 20);
			this.jsonLabel.TabIndex = 6;
			this.jsonLabel.Text = "JSON";
			// 
			// csvLabel
			// 
			this.csvLabel.AutoSize = true;
			this.csvLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
			this.csvLabel.Location = new System.Drawing.Point(855, 108);
			this.csvLabel.Name = "csvLabel";
			this.csvLabel.Size = new System.Drawing.Size(36, 20);
			this.csvLabel.TabIndex = 7;
			this.csvLabel.Text = "CSV";
			// 
			// JsonToCsvForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.SystemColors.Control;
			this.ClientSize = new System.Drawing.Size(1067, 416);
			this.Controls.Add(this.csvLabel);
			this.Controls.Add(this.jsonLabel);
			this.Controls.Add(this.numberLabel);
			this.Controls.Add(this.numberTextBox);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.csvTextBox);
			this.Controls.Add(this.jsonTextBox);
			this.Controls.Add(this.btnConvert);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.MaximumSize = new System.Drawing.Size(1150, 680);
			this.MinimizeBox = false;
			this.Name = "JsonToCsvForm";
			this.Text = "JSON to CSV";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.TextBox jsonTextBox;
		private System.Windows.Forms.TextBox csvTextBox;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.TextBox numberTextBox;
		private Label numberLabel;
		private Label jsonLabel;
		private Label csvLabel;
	}
}

