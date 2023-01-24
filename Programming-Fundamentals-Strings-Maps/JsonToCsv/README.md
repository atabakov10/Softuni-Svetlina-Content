# "JsonToCsv" App
Simple **C# Windows Forms App** implementation of **Json-To-sv** game.

<img width= 325px src="https://user-images.githubusercontent.com/99538671/211764493-560a73f2-53a5-475a-83e3-77b152201046.jpg" />

[Json-To-Csv](https://edutechwiki.unige.ch/en/JSON-CSV_Converter) is a simple game, where you need to **enter a number from 1 to 3** by typing it in **the small box **. When you type the **digit**, you should hit the **Submit number** button. After that,
the **JSON** with the same **identification
number** that you've entered in the **small box** will appear in the big box on the **left**. After this **operation**, the **button** will 
change to **Convert to JSON** and when
you **hit** it, it will **convert the JSON to a CSV** variation.

Rules:
- The number should be exactly from **1 to 3**.
- You cannot **type anything** except the **digit**.
- When the **converting** is **done**, you can copy the **CSV** file and you can **restart the converter**, if you want.

# Settings of the Format and the Separate Controls



| Settings                        |  Picture                 |
| --------------------------------|:------------------------:| 
| **JsonToCsvForm**:<br>Text = "JSON to CSV",<br>Font = Segoe UI, 9pt,<br>AutoScaleMode = Font,<br>Size = 1085, 463|                                         <img alt="Image" width="600" src="https://user-images.githubusercontent.com/99538671/212061187-068bd564-c497-48a1-96c3-f517372fe235.png"/>         
| **btnReset**:<br>Font = Segoe UI, 9pt,<br>Text = Reset,<br>UseVisualStyleBackColor = True,<br>Location = 479, 306,<br>Margin = 3, 4, 3, 4,<br>Size = 113, 42|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/212062148-ad074911-0131-4196-b97f-d1af796e1ec8.png" />
| **btnConvert**:<br>Font = Segoe UI, 9pt,<br>Text = Submit number,<br>UseVisualStyleBackColor = True,<br>Location = 457, 108,<br>Margin = 3, 4, 3, 4,<br>Size = 170, 51|<img alt="Image" width="250" src="https://user-images.githubusercontent.com/99538671/212062506-479b454c-27f3-4209-872a-971af892a900.png"/>
| **jsonLabel**:<br>Font = Segoe UI, 9pt, style=Bold<br>Text = JSON,<br>Location = 172, 108,<br>Size = 47, 20|<img alt="Image" width="50" src="https://user-images.githubusercontent.com/99538671/212064406-defc0d0c-b175-4870-ae07-e76a2733ac15.png" />
| **jsonTextBox**:<br>Font = Segoe UI, 9pt,<br>MaxLength = 32767,<br>Margin = 3, 4, 3, 4,<br>Size = 301, 216,<br>Location = 48, 132|<img alt="Image" width="400" src="https://user-images.githubusercontent.com/99538671/212063939-d7d8344c-479f-4559-a9f6-397e6f7e6fb4.png" />
| **csvLabel**:<br>Font = Segoe UI, 9pt, style=Bold<br>Text = CSV,<br>Location = 855, 108,<br>Size = 36, 20|<img alt="Image" width="50" src="https://user-images.githubusercontent.com/99538671/212067409-d9b319ff-361e-4569-8f82-fc18d02ba8c4.png" />
| **csvTextBox**:<br>Font = Segoe UI, 9pt,<br>MaxLength = 32767,<br>Margin = 3, 4, 3, 4,<br>Size = 301, 216,<br>Location = 722, 132|<img alt="Image" width="400" src="https://user-images.githubusercontent.com/99538671/212068098-72e251c9-c35e-41ec-b4e6-02c83cd75f62.png" />
| **numberLabel**:<br>Font = Segoe UI, 9pt,<br>Text = Submit a number from 1 to 3 ↓,<br>Location = 337, 28,<br>Size = 212, 20|<img alt="Image" width="250" src="https://user-images.githubusercontent.com/99538671/212069165-c62f92a5-b312-4717-8fd0-6b89c3040b5a.png" />
| **numberTextBox**:<br>Font = Segoe UI, 9pt,<br>MaxLength = 1,<br>Margin = 3, 4, 3, 4,<br>Size = 19, 27,<br>MaxLength = 1,<br>Location = 530, 52|<img alt="Image" width="250" src="https://user-images.githubusercontent.com/99538671/212069476-3c3d89fe-e9b7-44d6-a7eb-8d32406baf8c.png" />
