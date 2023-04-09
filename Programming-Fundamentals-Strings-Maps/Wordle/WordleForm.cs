namespace Wordle;

public partial class WordleForm : Form
{
	private const string WordsTextFile = @"wordsForWordle.txt";
	private const int RowLength = 5;
	private const string PlayAgainMessage = "Play again?";

	private int previousRow = 0;
	private int hintsCount = 0;
	private string currentWord = string.Empty;
	private List<TextBox> currentBoxes = new List<TextBox>();

	public WordleForm()
	{
		InitializeComponent();
		StartNewGame();
		foreach (TextBox tb in this.Controls.OfType<TextBox>())
		{
			tb.MouseClick += this.FocusTextBox;
			tb.KeyDown += this.MoveCursor;
		}
	}

	private void FocusTextBox(object sender, MouseEventArgs e)
	{
		if (sender is TextBox textBox)
		{
			textBox.Focus();
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
		OnPressedArrowKey(pressedKey, senderTextBox);
	}

	private void OnPressedArrowKey(Keys pressedKey, TextBox senderTextBox)
	{
		var currentTextBoxIndex = int.Parse(senderTextBox
			.Name
			.Replace("textBox", ""));

		// Separate methods
		if (RightKeyIsPressed(pressedKey, currentTextBoxIndex))
		{
			currentTextBoxIndex++;
		}
		else if (LeftKeyIsPressed(pressedKey, currentTextBoxIndex))
		{
			currentTextBoxIndex--;
		}

		var textBox = GetTextBox(currentTextBoxIndex);
		textBox.Focus();
	}

	private bool LeftKeyIsPressed(Keys pressedKey, int currentTextBoxIndex)
		=> pressedKey == Keys.Left && (currentTextBoxIndex + 4) % RowLength != 0;

	private bool RightKeyIsPressed(Keys pressedKey, int currentTextBoxIndex)
		=> pressedKey == Keys.Right && currentTextBoxIndex % RowLength != 0;

	private TextBox GetTextBox(int index)
	{
		string textBoxName = string.Format("textBox{0}", index);
		return this.Controls[textBoxName] as TextBox;
	}

	private void StartNewGame()
	{
		// Get all words
		var wordList = GetAllWords();

		var random = new Random();

		// Get a new word from word list
		currentWord = wordList[random.Next(wordList.Count)];

		// Enable [Submit] and [Hint]
		btnSubmit.Enabled = true;
		btnHint.Enabled = true;
	}

	private List<string> GetAllWords()
	{
		var allWords = new List<string>();

		// Open the wordsForWordle.txt file and read all words(lines)
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

		if (!IsInputValid(userWord))
		{
			// If input is invalid, display a message
			DisplayInvalidWordMessage();
			return;
		}

		ColorBoxes();

		if (IsWordGuessed(userWord))
		{
			FinalizeWinGame();
			return;
		}

		if (IsCurrentRowLast())
		{
			FinalizeLostGame();
			return;
		}

		ModifyTextBoxesAvailability(false);
		previousRow++;
		ModifyTextBoxesAvailability(true);
	}

	private string GetInput()
	{
		this.currentBoxes = new List<TextBox>();
		string tempString = string.Empty;
		int firstTextBoxIndexOnRow = GetFirstTextBoxIndexOnRow();

		for (int i = 0; i < RowLength; i++)
		{
			var textBox = GetTextBox(firstTextBoxIndexOnRow + i);

			if (string.IsNullOrEmpty(textBox.Text))
			{
				return textBox.Text;
			}

			tempString += textBox.Text[0];
			this.currentBoxes.Add(textBox);
		}

		return tempString;
	}

	private int GetFirstTextBoxIndexOnRow()
		=> this.previousRow * RowLength + 1;

	private bool IsInputValid(string input)
	{
		if (input.All(char.IsLetter) && input.Length == RowLength)
		{
			return true;
		}

		return false;
	}

	private void DisplayInvalidWordMessage()
	{
		MessageBox.Show("Please enter a valid five-letter word.");
	}

	private void ColorBoxes()
	{
		for (int i = 0; i < this.currentBoxes.Count(); i++)
		{
			var textBox = this.currentBoxes[i];
			var currentTextBoxChar = textBox.Text.ToLower().FirstOrDefault();

			// If character is not in word->gray
			if (!WordContainsChar(currentTextBoxChar))
			{
				textBox.BackColor = Color.Gray;
			}

			// If character is not at the correct index -> yellow
			else if (!IsCharOnCorrectIndex(i, currentTextBoxChar))
			{
				textBox.BackColor = Color.Yellow;
			}
			else
			{
				// If in word and in index->green
				textBox.BackColor = Color.LightGreen;
			}
		}
	}

	private bool WordContainsChar(char ch)
		=> this.currentWord.Contains(ch, StringComparison.OrdinalIgnoreCase);

	private bool IsCharOnCorrectIndex(int index, char ch)
		=> this.currentWord[index] == ch;

	private bool IsWordGuessed(string attempt)
	{
		if (this.currentWord.Equals(attempt, StringComparison.OrdinalIgnoreCase))
		{
			return true;
		}

		return false;
	}

	private void FinalizeWinGame()
	{
		// Display message
		MessageBox.Show("Congratulations, you win!");

		// Disable the [Submit] and [Hint] buttons
		this.btnSubmit.Enabled = false;
		this.btnHint.Enabled = false;

		// Change [Reset] button text
		this.btnReset.Text = PlayAgainMessage;

		ModifyTextBoxesAvailability(false);
	}

	private void ModifyTextBoxesAvailability(bool shouldBeEnabled)
	{
		var firstTextBoxIndexOnRow = GetFirstTextBoxIndexOnRow();

		for (int i = 0; i < RowLength; i++)
		{
			// Get current row's text boxes
			var textBox = GetTextBox(firstTextBoxIndexOnRow + i);

			// Enable row's text boxes
			if (shouldBeEnabled)
			{
				textBox.Enabled = true;

				// Focus the first text box on the row
				if (i == 0)
				{
					textBox.Focus();
				}
			}
			// Disable row's text boxes
			else
			{
				// Make the row readonly and not accessible with[Tab]
				textBox.ReadOnly = true;
				textBox.TabStop = false;
			}
		}
	}

	private bool IsCurrentRowLast()
	{
		var columnsCount = 6;
		return this.previousRow == columnsCount - 1;
	}

	private void FinalizeLostGame()
	{
		MessageBox.Show($"Sorry you didn't win this time!" +
						$" The correct word was: {this.currentWord}");
		btnSubmit.Enabled = false;
		btnHint.Enabled = false;
		btnReset.Text = PlayAgainMessage;
	}

	private void GameRestart(object sender, EventArgs e)
	{
		Application.Restart();
	}

	private void GiveHint(object sender, EventArgs e)
	{
		var unavailablePositions = GetUnavailablePositions();

		if (unavailablePositions.Count == RowLength)
		{
			ShowInvalidUseOfHintMessage();
			return;
		}

		RevealRandomWordLetter(unavailablePositions);
	}

	private List<int> GetUnavailablePositions()
	{
		var firstIndexOnRow = GetFirstTextBoxIndexOnRow();

		var positions = new List<int>();

		for (int i = 0; i < RowLength; i++)
		{
			var textBoxIndex = firstIndexOnRow + i;
			var textBox = GetTextBox(textBoxIndex);
			if (!string.IsNullOrEmpty(textBox.Text))
			{
				positions.Add(textBoxIndex);
			}
		}

		return positions;
	}

	private void ShowInvalidUseOfHintMessage()
	{
		MessageBox.Show("Free up a space for a hint.");
		this.btnSubmit.Focus();
		this.hintsCount -= 1;
	}

	private void RevealRandomWordLetter(List<int> unavailablePositions)
	{
		var random = new Random();

		while (true)
		{
			var randomIndex = random.Next(1, RowLength + 1);
			var randomTexBoxIndex = this.previousRow * RowLength + randomIndex;

			var textBox = GetTextBox(randomTexBoxIndex);

			if (textBox.Text != String.Empty)
			{
				continue;
			}

			var hintLetter = this.currentWord[randomIndex - 1].ToString();
			textBox.Text = hintLetter;
			unavailablePositions.Add(randomTexBoxIndex);

			break;
		}
	}

	private void HintCounterMouseClick(object sender, MouseEventArgs e)
	{
		this.hintsCount++;
		if (this.hintsCount >= 3)
		{
			this.btnHint.Enabled = false;
		}
	}
}
