using System.Linq;

namespace Wordle;

public partial class WordleForm : Form
{
	private Random rand = new Random();
	private int currentRow = 0;
	private int hintsCount = 1;
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
		foreach (TextBox tb in this.Controls.OfType<TextBox>())
		{
			tb.MouseClick += this.FocusTextBox;
			tb.KeyDown += this.MoveCursor;
		}
	}

	private void StartNewGame()
	{
		// Get a new word from word list (open file, get all words, choose one at random)
		currentWord = wordList[rand.Next(wordList.Count)];

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

		if (currentRow == 5)
		{
			MessageBox.Show($"Sorry you didn't win this time! The correct word was: {currentWord}");
			btnSubmit.Enabled = false;
			btnHint.Enabled = false;

			return;
		}

		currentRow++;

		var firstTextBoxIndexOnRow = currentRow * 5 + 1;

		for (int i = 0; i < 5; i++)
		{
			var name = string.Format("textBox{0}", firstTextBoxIndexOnRow + i);
			var textBox = this.Controls[name] as TextBox;

			// Enabling the next row's textBoxes
			textBox.Enabled = true;

			var firstName = string.Format("textBox{0}", firstTextBoxIndexOnRow + i - 5);
			var beforeTextBoxes = this.Controls[firstName] as TextBox;

			// Making the previous row readonly and not accessible with [Tab]
			beforeTextBoxes.ReadOnly = true;
			beforeTextBoxes.TabStop = false;

			if (i == 0)
			{
				textBox.Focus();
			}
		}

		this.btnHint.Enabled = true;
	}

	private void ColorBox(int index, TextBox textBox)
	{
		// If not in word -> gray
		if (!this.currentWord.Contains(textBox.Text, StringComparison.OrdinalIgnoreCase))
		{
			textBox.BackColor = Color.Gray;
		}
		// If in word but not at index -> yellow
		else if (this.currentWord[index].ToString().ToLower() != textBox.Text.ToLower())
		{
			textBox.BackColor = Color.Yellow;
		}
		else
		{
			// If in word and in index -> green
			textBox.BackColor = Color.LightGreen;
		}
	}

	private void EndGame()
	{
		// Display message
		MessageBox.Show("Congratulations, you win!");
		// Disable the [Submit] and [Hint] and change the [Reset]
		this.btnSubmit.Enabled = false;
		this.btnHint.Enabled = false;
		this.btnReset.Text = "Play again?";
	}

	private string GetInput()
	{
		currentBoxes = new List<TextBox>();
		string tempString = string.Empty;

		var firstTextBoxIndexOnRow = currentRow * 5 + 1;

		for (int i = 0; i < 5; i++)
		{
			var name = string.Format("textBox{0}", firstTextBoxIndexOnRow + i);
			var textBox = this.Controls[name] as TextBox;

			if (string.IsNullOrEmpty(textBox.Text))
			{
				return textBox.Text;
			}

			tempString += textBox.Text[0];
			this.currentBoxes.Add(textBox);
		}

		return tempString;
	}

	private bool ValidateInput(string input)
	{
		if (input.All(char.IsLetter) && input.Length == 5)
		{
			return true;
		}

		// If not successful, 
		// display message (invalid/incomplete word)
		MessageBox.Show("Please enter a valid, five-letter word.");
		return false;
	}

	private bool IsCorrectWord(string attempt)
	{
		if (this.currentWord.Equals(attempt, StringComparison.OrdinalIgnoreCase))
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
		var random = new Random();
		var list = new List<string>();

		while (true)
		{
			var randomIndex = random.Next(1, 5);

			var randomTextBoxIndex = currentRow * 5 + randomIndex;

			var name = $"textBox{randomTextBoxIndex}";
			var textBox = this.Controls[name] as TextBox;
			var firstTextBoxIndexOnRow = currentRow * 5 + 1;


			for (int i = 0; i < 5; i++)
			{
				var nameOftextBox = string.Format("textBox{0}", firstTextBoxIndexOnRow + i);
				var textBoxReal = this.Controls[nameOftextBox] as TextBox;
				
				list.Add(textBoxReal.Text);
			}

			var emptyTextBoxes = list.Any(x => x.Equals(String.Empty));
			if (emptyTextBoxes == false)
			{
				MessageBox.Show("You can't use the Hint right now.");
				btnHint.Enabled = false;
				return;
			}

			if (textBox.Text != String.Empty)
			{
				continue;
			}

			var hintLetter = currentWord[randomIndex - 1].ToString();
			textBox.Text = hintLetter;

			if (hintsCount == 3)
			{
				this.btnHint.Enabled = false;
				this.hintsCount = 0;
			}

			hintsCount++;
			break;
		}
	}

	private void MoveCursor(object sender, KeyEventArgs e)
	{
		var pressedKey = e.KeyData;
		if (pressedKey != Keys.Right && pressedKey != Keys.Left)
		{
			return;
		}

		var senderTextBox = sender as TextBox;
		var currentTextBoxIndex = int.Parse(senderTextBox.Name.Replace("textBox", ""));

		if (pressedKey == Keys.Right && currentTextBoxIndex % 5 != 0)
		{
			currentTextBoxIndex++;
		}
		else if (pressedKey == Keys.Left && (currentTextBoxIndex + 4) % 5 != 0)
		{
			currentTextBoxIndex--;
		}

		var textBoxName = string.Format("textBox{0}", currentTextBoxIndex);
		var textBox = this.Controls[textBoxName] as TextBox;

		textBox.Focus();
	}

	private void FocusTextBox(object sender, MouseEventArgs e)
	{
		if (sender is TextBox textBox)
		{
			textBox.Focus();
		}
	}
}