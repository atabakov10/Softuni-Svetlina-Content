# GUI "Wordle" App
Simple **C# Windows Forms App** implementation of **Wordle** game.


<img width= 325px src="https://media-cldnry.s-nbcnews.com/image/upload/t_fit-560w,f_auto,q_auto:best/rockcms/2022-01/wordle-inline1-AW-220105-1acb81.jpg" />

[Wordle](https://en.wikipedia.org/wiki/Wordle) is a single-player **word-guessing** game. You need to **find the right word** by typing **random words** until you **guess the right one**. You have **6** tries to guess it.

Rules:
- The word will be **exactly 5** symbols.
- If the letter that you **type** turns $\text{\color{green}{green}}$, it means that it is the **right letter** on the **right place**.
- If the **letter turns** $\text{\color{yellow}{yellow}}$, that means that the **word** contains your **letter**, but you didn't put it on the **right place**.
- If the **letter turns**  $\text{\color{gray}{gray}}$, that means the letter **does not exist** in the **word**.
- If you **guess the word**, you will receive a **message** saying that you've **won** and you can **play again**.
- You **can't have same letters** in a word.

# Settings of the Format and the Separate Controls

| Settings                        |  Picture                 |
| --------------------------------|:------------------------:| 
| **WordleForm**:<br>Text = "Wordle",<br>Font = Segoe UI, 9pt,<br>AutoScaleMode = Font,<br>Size = 437, 356|                                         <img alt="Image" width="400" src="https://user-images.githubusercontent.com/99538671/209855762-a40695f3-a1e0-4a4f-a030-d5b60eae6249.png" />         
| **btnReset**:<br>Font = Segoe UI, 9pt,<br>Text = Reset,<br>UseVisualStyleBackColor = True,<br>Location = 264, 74,<br>Margin = 3, 4, 3, 4,<br>Size = 110, 43|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/209854900-3b4f4780-435a-4b6b-8985-005627d1a6e8.png" />
| **btnSubmit**:<br>Font = Segoe UI, 9pt,<br>Text = Submit,<br>UseVisualStyleBackColor = True,<br>Location = 264, 125,<br>Margin = 3, 4, 3, 4,<br>Size = 110, 43|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/209937640-634f5675-bcc9-41e8-8acc-3d4357be5d40.png" />  
| **btnHint**:<br>Font = Segoe UI, 9pt,<br>Text = Hint,<br>UseVisualStyleBackColor = True,<br>Location = 264, 176,<br>Margin = 3, 4, 3, 4,<br>Size = 110, 43|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/209938009-945de425-2ef1-438a-ada0-8b3299f3f3e5.png" />
| **textBox**:<br>Font = Tahoma, 12pt,<br>MaxLength = 1,<br>Lines = String[] Array, 176,<br>Margin = 3, 4, 3, 4,<br>Size = 31, 32|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/209941312-8e5c68ed-9b76-4892-8cf7-6a2e8a34a59d.png" />

# Solution

<img alt="Image" width="450" src="https://user-images.githubusercontent.com/99538671/209941855-cf04ef37-1af0-4bb9-b030-bf1e032dcb98.png" />

[Form Source Code](WordleForm.cs)
