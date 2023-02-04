# "Wordle" App
Simple **C# Windows Forms App** implementation of **Wordle** game.


<img width= 325px src="https://media-cldnry.s-nbcnews.com/image/upload/t_fit-560w,f_auto,q_auto:best/rockcms/2022-01/wordle-inline1-AW-220105-1acb81.jpg" />

[Wordle](https://en.wikipedia.org/wiki/Wordle) is a single-player **word-guessing** game. You need to **find the right word** by typing **random words** until you **guess the right one**. You have **6** tries to guess it.

# Controls
- Use `left`(**◄**) and `right`(**►**) keyboard arrows to **move** between the **boxes**.

Rules:
- The word will be **exactly 5** symbols.
- If the letter that you **type turns green**, it means that it is the **right letter** on the **right place**.
- If the **letter turns yellow**, that means that the **word** contains your **letter**, but you didn't put it on the **right place**.
- If the **letter turns  gray**, that means the letter **does not exist** in the **word**.
- If you **guess the word**, you will receive a **message** saying that you've **won** and you can **play again**.
- You **can't have same letters** in a word.

# Settings of the Format and the Separate Controls

| Settings                        |  Picture                 |
| --------------------------------|:------------------------:| 
| **WordleForm**:<br>Text = "Wordle",<br>Font = Segoe UI, 9pt,<br>AutoScaleMode = Font,<br>Size = 437, 356|                                         <img alt="Image" width="400" src="https://user-images.githubusercontent.com/99538671/214712801-0ab6ec9a-b7ea-4383-ac71-f55c57c351b4.png" />         
| **btnReset**:<br>Font = Segoe UI, 9pt,<br>Text = Reset,<br>UseVisualStyleBackColor = True,<br>Location = 264, 74,<br>Margin = 3, 4, 3, 4,<br>Size = 110, 43|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/209854900-3b4f4780-435a-4b6b-8985-005627d1a6e8.png" />
| **btnSubmit**:<br>Font = Segoe UI, 9pt,<br>Text = Submit,<br>UseVisualStyleBackColor = True,<br>Location = 264, 125,<br>Margin = 3, 4, 3, 4,<br>Size = 110, 43|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/209937640-634f5675-bcc9-41e8-8acc-3d4357be5d40.png" />  
| **btnHint**:<br>Font = Segoe UI, 9pt,<br>Text = Hint,<br>UseVisualStyleBackColor = True,<br>Location = 264, 176,<br>Margin = 3, 4, 3, 4,<br>Size = 110, 43|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/209938009-945de425-2ef1-438a-ada0-8b3299f3f3e5.png" />
| **textBox1-30**:<br>Font = Tahoma, 12pt,<br>MaxLength = 1,<br>Lines = String[] Array, 176,<br>Margin = 3, 4, 3, 4,<br>Size = 31, 32|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/209941312-8e5c68ed-9b76-4892-8cf7-6a2e8a34a59d.png" />
| **instructionsLabel**:<br>Font = Segoe UI, 9pt,<br>Location = 58, 11,<br>Text = Move with ← and →,<br>BackColor = ButtonHighlight,<br>Size = 141, 20|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/214715991-ac67625b-902c-4a94-a80e-363b497bbe5e.png" />

# Solution

<img alt="Image" width="450" src="https://user-images.githubusercontent.com/99538671/216777989-15d831af-1310-4831-8042-1c944a43c00d.png" />

[Form Source Code](WordleForm.cs)

# Screenshots


<img alt="Image" width="400" src="https://user-images.githubusercontent.com/99538671/216777140-6d21649a-0447-4b28-ba5e-ca98c40f97e8.png" />

<img alt="Image" width="400" src="https://user-images.githubusercontent.com/99538671/216777673-d7896886-e606-4244-b6de-c8e58c4531f4.png" /> -> <img alt="Image" width="350" src="https://user-images.githubusercontent.com/99538671/216777715-2fe39c8b-2b5e-43f7-8ece-179871642cf3.png" />

<img alt="Image" width="400" src="https://user-images.githubusercontent.com/99538671/216777170-4bed189c-681d-4757-930e-7bf2fe79d1a3.png" /> -> <img alt="Image" width="200" src="https://user-images.githubusercontent.com/99538671/216777298-2d81f660-34e5-4a22-a194-45f7b051a44f.png" />
