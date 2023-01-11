using System.Text.Json;
using System.Text.RegularExpressions;
using static System.Int32;

namespace JsonToCsv
{
	public partial class JsonToCsv : Form
	{

		public JsonToCsv()
		{
			InitializeComponent();
		}

		private int count;
		private string info;

		public void OutputInformation(Dictionary<string, object> information)
		{
			if (information == null)
			{
				MessageBox.Show("Invalid JSON");
				textBox3.Focus();
				return;
			}
			foreach (var d in information)
			{
				info = info + d.Key + ", ";
			}
			AddLine(info);
			info = "";
			foreach (var d in information)
			{
				info = info + d.Value + ", ";
			}
			AddLine(info);
		}

		public void AddObjects(string[] arrayObjects)
		{
			int row = 0;

			foreach (string objects in arrayObjects)
			{
				// Deserializes our json and validates it
				if (row == 0)
				{
					var information = JsonSerializer.Deserialize<Dictionary<string, object>>(objects);
					OutputInformation(information);
				}
				else
				{
					string modifiedObject = "{" + objects;
					var information = JsonSerializer.Deserialize<Dictionary<string, object>>(modifiedObject);
					OutputInformation(information);
				}
				row++;
			}
		}
		public void AddLine(string s)
		{
			// Appends our csv converted json into two lines
			s = s.Remove(s.Length - 2);
			textBox2.AppendText(string.Join(" ", s, Environment.NewLine));
		}

		private void ResetButton_Click(object sender, EventArgs e)
		{
			// Resets the application
			Application.Restart();
		}

		private void ButtonConverter_Click(object sender, EventArgs e)
		{
			// Using counter to count the clicks of the covert button, since it has two functions
			count++;
			string url = "https://contactbook.nakov.repl.co/api/contacts/";

			HttpClient client = new HttpClient();

			var userDigit = textBox3.Text;
			if (ValidateUserDigit(userDigit))
			{
				Task<string> response = client.GetStringAsync(url + userDigit);

				textBox1.Text = response.Result;
				var convertToJson = "Convert to JSON";

				// If counter is at 1, it means we already clicked the btn, so now we need to rename it to [Convert to JSON]
				if (count == 1)
				{
					btnConvert.Text = convertToJson;
				}

				// If we're at second click, we need to show the csv version of the json
				else if (count == 2)
				{
					textBox3.ReadOnly = true;
					btnConvert.Enabled = false;
					Regex arrayFinder = new Regex(@"\{(?<items>[^\]]*)\}");
					string array = arrayFinder.Match(textBox1.Text).Value;
					string[] arrayObjects = array.Split(new string[] { ",{", ",\n{", ",\n  {" }, StringSplitOptions.None);

					AddObjects(arrayObjects);
				}
			}
		}
		private bool ValidateUserDigit(string userDigit)
		{
			// Tries to parse the text given from the user
			TryParse(userDigit, out int digit);

			if (digit == 0 || digit > 3)
			{
				count--;
				MessageBox.Show("The number should be a valid, 1 to 3.");
				textBox3.Focus();
				return false;
			}
			return true;
		}

		private void TextBox3_TextChanged(object sender, EventArgs e)
		{
			if (textBox3.TextLength != 0)
			{
				label1.Hide();
				btnConvert.Focus();
			}
		}
	}
}
