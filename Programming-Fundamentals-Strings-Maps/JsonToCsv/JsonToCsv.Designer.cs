
namespace JsonToCsv
{
	partial class JsonToCsv
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
			this.btnConvert = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.btnReset = new System.Windows.Forms.Button();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnConvert
			// 
			this.btnConvert.Location = new System.Drawing.Point(434, 132);
			this.btnConvert.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(213, 51);
			this.btnConvert.TabIndex = 1;
			this.btnConvert.Text = "Submit number";
			this.btnConvert.UseVisualStyleBackColor = true;
			this.btnConvert.Click += new System.EventHandler(this.ButtonConverter_Click);
			// 
			// textBox1
			// 
			this.textBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.textBox1.Location = new System.Drawing.Point(50, 132);
			this.textBox1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox1.Multiline = true;
			this.textBox1.Name = "textBox1";
			this.textBox1.ReadOnly = true;
			this.textBox1.Size = new System.Drawing.Size(332, 352);
			this.textBox1.TabIndex = 2;
			// 
			// textBox2
			// 
			this.textBox2.AccessibleDescription = "";
			this.textBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
			this.textBox2.Location = new System.Drawing.Point(695, 132);
			this.textBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox2.Multiline = true;
			this.textBox2.Name = "textBox2";
			this.textBox2.ReadOnly = true;
			this.textBox2.Size = new System.Drawing.Size(332, 352);
			this.textBox2.TabIndex = 3;
			this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			// 
			// btnReset
			// 
			this.btnReset.Location = new System.Drawing.Point(831, 38);
			this.btnReset.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.btnReset.Name = "btnReset";
			this.btnReset.Size = new System.Drawing.Size(129, 42);
			this.btnReset.TabIndex = 4;
			this.btnReset.Text = "Reset";
			this.btnReset.UseVisualStyleBackColor = true;
			this.btnReset.Click += new System.EventHandler(this.ResetButton_Click);
			// 
			// textBox3
			// 
			this.textBox3.Location = new System.Drawing.Point(530, 52);
			this.textBox3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.textBox3.MaxLength = 1;
			this.textBox3.Name = "textBox3";
			this.textBox3.Size = new System.Drawing.Size(19, 27);
			this.textBox3.TabIndex = 0;
			this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.textBox3.TextChanged += new System.EventHandler(this.TextBox3_TextChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(337, 28);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(212, 20);
			this.label1.TabIndex = 5;
			this.label1.Text = "Submit a number from 1 to 3 ↓";
			// 
			// JsonToCsv
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1067, 580);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.btnReset);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.btnConvert);
			this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			this.Name = "JsonToCsv";
			this.Text = "JsonToCsv";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button btnReset;
		private System.Windows.Forms.TextBox textBox3;
		private Label label1;
	}
}

