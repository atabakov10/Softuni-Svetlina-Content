using System.ComponentModel.DataAnnotations;

namespace Wordle;

public partial class WordleForm : Form
{
	private Random rand = new Random();
	private int currentOffset = 1;
	private int currentTextBox = 1;
	private string currentWord = string.Empty;
	private const string WordsTextFile = @"wordsForWordle.txt";

	private List<string> wordList = new List<string>();
	private List<TextBox> currentBoxes = new List<TextBox>();
	private List<string> allWords = new List<string>();
	public WordleForm()
	{
		InitializeComponent();
		this.wordList = GetAllWords();
		StartNewGame();
	}


	private void StartNewGame()
	{
		// Get a new word from word list (open file, get all words, choose one at random)
		currentWord = wordList[rand.Next(wordList.Count)];

		// Reset offset
		currentOffset = 1;

		// Enable submit & hint
		btnSubmit.Enabled = true;
		btnHint.Enabled = true;
	}

	private List<string> GetAllWords()
	{
		// Opens the wordsForWordle.txt file

		using (StreamReader reader = new StreamReader(WordsTextFile))
		{
			while (!reader.EndOfStream)
			{
				var nextLine = reader.ReadLine();
				allWords.Add(nextLine);
			}
		}
		return allWords;
	}

	private void Submit(object sender, EventArgs e)
	{

		var userWord = GetInput();


		if (!ValidateInput(userWord))
		{
			return;
		}

		bool isCorrect = IsCorrectWord(userWord);

		for (int i = 0; i < currentBoxes.Count(); i++)
		{
			ColorBox(i, currentBoxes[i]);
		}

		if (isCorrect)
		{
			EndGame();
			return;
		}

		currentOffset++;
		if (currentOffset == 2)
		{
			textBox6.Enabled = true;
			textBox7.Enabled = true;
			textBox8.Enabled = true;
			textBox9.Enabled = true;
			textBox10.Enabled = true;

		}
		if (currentOffset == 3)
		{
			textBox11.Enabled = true;
			textBox12.Enabled = true;
			textBox13.Enabled = true;
			textBox14.Enabled = true;
			textBox15.Enabled = true;

		}
		if (currentOffset == 4)
		{
			textBox16.Enabled = true;
			textBox17.Enabled = true;
			textBox18.Enabled = true;
			textBox19.Enabled = true;
			textBox20.Enabled = true;
		}
		if (currentOffset == 5)
		{
			textBox21.Enabled = true;
			textBox22.Enabled = true;
			textBox23.Enabled = true;
			textBox24.Enabled = true;
			textBox25.Enabled = true;
		}
		if (currentOffset == 6)
		{
			textBox26.Enabled = true;
			textBox27.Enabled = true;
			textBox28.Enabled = true;
			textBox29.Enabled = true;
			textBox30.Enabled = true;
		}
		if (currentOffset > 6)
		{
			MessageBox.Show($"Sorry you didn't win this time! The correct word was: {currentWord}");
			btnSubmit.Enabled = false;
		}
	}

	private void ColorBox(int index, TextBox t)
	{
		//if not in word -> gray
		if (!currentWord.Contains(t.Text, StringComparison.OrdinalIgnoreCase))
		{
			t.BackColor = Color.Gray;
		}
		//if in word but not at index -> yellow
		else if (currentWord[index].ToString().ToLower() != t.Text.ToLower())
		{
			t.BackColor = Color.Yellow;
		}
		else
		{
			//if in word and in index -> green
			t.BackColor = Color.LightGreen;
		}
	}

	private void EndGame()
	{
		//display message
		MessageBox.Show("Congratulations, you win!");
		//disable the [Submit] and [Hint]
		btnSubmit.Enabled = false;
		btnHint.Enabled = false;

		btnReset.Text = "Play again?";
	}

	private string GetInput()
	{
		currentBoxes = new List<TextBox>();

		string tempString = string.Empty;

		for (int i = 0; i < 5; i++)
		{
			var name = string.Format("textBox{0}", currentTextBox + i);
			var textbox = this.Controls[name] as TextBox;

			if (string.IsNullOrEmpty(textbox.Text))
			{
				return textbox.Text;
			}

			tempString += textbox.Text[0];
			currentBoxes.Add(textbox);

		}
		currentTextBox += 5;


		return tempString;
	}

	private bool ValidateInput(string input)
	{
		for (int i = 0; i < input.Length; i++)
		{

			if (char.IsLetter(input[i]) && input.Length == 5)
			{
				return true;
			}

		}

		//if not successful, 
		//display message (invalid/incomplete word)
		MessageBox.Show("Please enter a valid, five-letter word.");
		return false;
	}

	private bool IsCorrectWord(string attempt)
	{

		if (currentWord.Equals(attempt, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}

		return false;
	}

	private void GameRestart(object sender, EventArgs e)
	{
		Application.Restart();
	}

	private void Hint(object sender, EventArgs e)
	{
		if (currentOffset == 1)
		{
			textBox1.Text = currentWord[0].ToString();
		}
		else if (currentOffset == 2)
		{
			textBox6.Text = currentWord[0].ToString();
			textBox7.Text = currentWord[1].ToString();
		}
		else if (currentOffset == 3)
		{
			textBox11.Text = currentWord[0].ToString();
			textBox12.Text = currentWord[1].ToString();
			textBox13.Text = currentWord[2].ToString();
		}
		else if (currentOffset == 4)
		{
			textBox16.Text = currentWord[0].ToString();
			textBox17.Text = currentWord[1].ToString();
			textBox18.Text = currentWord[2].ToString();
			textBox19.Text = currentWord[3].ToString();
		}
		else if (currentOffset == 5)
		{
			textBox21.Text = currentWord[0].ToString();
			textBox22.Text = currentWord[1].ToString();
			textBox23.Text = currentWord[2].ToString();
			textBox24.Text = currentWord[3].ToString();
			textBox25.Text = currentWord[4].ToString();
		}
		else
		{
			textBox26.Text = currentWord[0].ToString();
			textBox27.Text = currentWord[1].ToString();
			textBox28.Text = currentWord[2].ToString();
			textBox29.Text = currentWord[3].ToString();
			textBox30.Text = currentWord[4].ToString();
		}
	}

	private void btnSubmit_ClickEnter(object sender, KeyEventArgs e)
	{
		if (e.KeyCode == Keys.Enter)
		{
			btnSubmit.PerformClick();
		}
	}
}