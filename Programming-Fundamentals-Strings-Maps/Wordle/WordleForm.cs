using System;
using System.Linq;

namespace Wordle;

public partial class WordleForm : Form
{
    private const string WordsTextFile = @"wordsForWordle.txt";
    private const int RowLength = 5;

    private Random rand = new Random();
	private int currentRow = 0;
	private int hintsCount = 1;
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

	private void StartNewGame()
	{
		// Get all words
        var wordList = GetAllWords();

        // Get a new word from word list
        currentWord = wordList[rand.Next(wordList.Count)];

		// Enable submit & hint
		btnSubmit.Enabled = true;
		btnHint.Enabled = true;
	}

	private List<string> GetAllWords()
	{
		var allWords = new List<string>();

        // Open the wordsForWordle.txt file and read all words (lines)
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

		if (currentRow == RowLength)
		{
			FinalizeLostGame();
			return;
		}

		ModifyTextBoxesAvailability(false);
        currentRow++;
        ModifyTextBoxesAvailability(true);

        this.btnHint.Enabled = true;
    }

	private void DisplayInvalidWordMessage()
	{
		MessageBox.Show("Please enter a valid, five-letter word.");
	}

	private void FinalizeLostGame()
	{
		MessageBox.Show($"Sorry you didn't win this time! The correct word was: {currentWord}");
		btnSubmit.Enabled = false;
		btnHint.Enabled = false;
	}

	private void ModifyTextBoxesAvailability(bool shouldBeEnabled)
	{
		var firstTextBoxIndexOnRow = currentRow * RowLength + 1;

		for (int i = 0; i < RowLength; i++)
		{
            // Get current row's text boxes
			var textBox = GetTextBox(firstTextBoxIndexOnRow + i);

			// Enable row's text boxes
			if(shouldBeEnabled)
			{
                textBox.Enabled = true;

                // Focus the first text box on the row
                if (i == 0)
                {
                    textBox.Focus();
                }
            }
            //  Disable row's text boxes
            else
            {
                // Make the row readonly and not accessible with [Tab]
                textBox.ReadOnly = true;
                textBox.TabStop = false;
            }
		}
	}

    private TextBox GetTextBox(int index)
    {
		// Get textBox name and the textBox itself
        string textBoxName = string.Format("textBox{0}", index);
        return this.Controls[textBoxName] as TextBox;
    }

    private void ColorBoxes()
	{
        for (int i = 0; i < currentBoxes.Count(); i++)
		{
			var textBox = currentBoxes[i];
			var currentTextBoxChar = textBox.Text.ToLower().FirstOrDefault();

			// If character is not in word -> gray
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
				// If in word and in index -> green
				textBox.BackColor = Color.LightGreen;
			}
		}
	}

	private bool IsCharOnCorrectIndex(int index, char ch) 
		=> this.currentWord[index] == ch;

	private bool WordContainsChar(char ch) 
		=> this.currentWord.Contains(ch, StringComparison.OrdinalIgnoreCase);

	private void FinalizeWinGame()
	{
		// Display message
		MessageBox.Show("Congratulations, you win!");

		// Disable the [Submit] and [Hint] buttons 
		this.btnSubmit.Enabled = false;
		this.btnHint.Enabled = false;

        // Change [Reset] button text
        this.btnReset.Text = "Play again?";

        ModifyTextBoxesAvailability(false);
	}

	private string GetInput()
	{
		currentBoxes = new List<TextBox>();
		string tempString = string.Empty;

		var firstTextBoxIndexOnRow = currentRow * RowLength + 1;

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

	private bool IsInputValid(string input)
	{
		if (input.All(char.IsLetter) && input.Length == RowLength)
		{
			return true;
		}

		return false;
	}

	private bool IsWordGuessed(string attempt)
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

	private void GiveHint(object sender, EventArgs e)
	{
		var unavailablePositions = new List<int>();

        var firstTextBoxIndexOnRow = currentRow * RowLength + 1;

        for (int i = 0; i < RowLength; i++)
		{
			var textBoxIndex = firstTextBoxIndexOnRow + i;
            var textBox = GetTextBox(textBoxIndex);
			if(!string.IsNullOrEmpty(textBox.Text))
			{
				unavailablePositions.Add(textBoxIndex);
            }
		}

        if (unavailablePositions.Count == RowLength)
        {
	        InvalidUsedHint();
	        return;
        }

        var random = new Random();

        RandomIndexAddToList(random, unavailablePositions);
	}
	private void RandomIndexAddToList(Random random, List<int> unavailablePositions)
	{
		while (true)
		{
			var randomIndex = random.Next(1, RowLength);

			if (unavailablePositions.Contains(randomIndex))
			{
				continue;
			}

			var randomTextBoxIndex = currentRow * RowLength + randomIndex;

			var textBox = GetTextBox(randomTextBoxIndex);

			if (textBox.Text != String.Empty)
			{
				continue;
			}

			var hintLetter = currentWord[randomIndex - 1].ToString();
			textBox.Text = hintLetter;

			unavailablePositions.Add(randomTextBoxIndex);

			HintCounterChecker();
			hintsCount++;
			break;
		}
	}
	
	private void HintCounterChecker()
	{
		if (hintsCount == 3)
		{
			this.btnHint.Enabled = false;
			this.hintsCount = 0;
		}
	}

	private void InvalidUsedHint()
	{
		MessageBox.Show("You can't use Hint right now.");
		btnHint.Enabled = true;
		btnSubmit.Focus();
	}

	private void MoveCursor(object sender, KeyEventArgs e)
	{
		var pressedKey = e.KeyData;
		if (pressedKey != Keys.Right && pressedKey != Keys.Left)
		{
			return;
		}
		var senderTextBox = sender as TextBox;
		PressedKey(pressedKey, senderTextBox);
	}

	private void FocusTextBox(object sender, MouseEventArgs e)
	{
		if (sender is TextBox textBox)
		{
			textBox.Focus();
		}
	}

	private void PressedKey(Keys pressedKey, TextBox senderTextBox)
	{
		var currentTextBoxIndex = int.Parse(senderTextBox.Name.Replace("textBox", ""));

		if (pressedKey == Keys.Right && currentTextBoxIndex % RowLength != 0)
		{
			currentTextBoxIndex++;
		}
		else if (pressedKey == Keys.Left && (currentTextBoxIndex + 4) % RowLength != 0)
		{
			currentTextBoxIndex--;
		}
		var textBox = GetTextBox(currentTextBoxIndex);
		textBox.Focus();
	}

}