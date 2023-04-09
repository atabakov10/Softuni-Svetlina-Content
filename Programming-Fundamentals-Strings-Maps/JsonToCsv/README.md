# "JsonToCsv" App
Simple **C# Windows Forms App** implementation of **Json-To-Csv** game. 

<img width= 500px src="https://user-images.githubusercontent.com/99538671/211764493-560a73f2-53a5-475a-83e3-77b152201046.jpg" />

[Json-To-Csv](https://www.convertcsv.com/json-to-csv.htm) is an application, in which you **request an API**(https://restcountries.com/) and **display chosen elements from the JSON** returned from the response of the **URL you have provided**. To **enter an URI**, you type it in **the small text box, which is used for user input**. When you type the **URI**, you should hit the **Requiest API** button. After the **JSON objects you have chosen** are turned into **JSON**, they will be **displayed and then you can turn them** into a **CSV formatted text** by clicking the **Convert to CSV** button. The **application** is handling the errors by **try-catch statements**, which are then turned into a **message boxes and displayed** once an **error** is made.

Rules:
- The **URI should be valid**, you can see the **valid URI's in the legend** made between the **two big text boxes**.
- If you type an **invalid URI**(API path and endpoint), a **message box** will be shown for an **invalid input**.
- When the **converting** is **done**, you can copy the **CSV** format and you can **try another URI**, if you want.

# Settings of the Format and the Separate Controls

| Settings                        |  Picture                 |
| --------------------------------|:------------------------:| 
| **JsonToCsvForm**:<br>Text = "JsonToCsv",<br>Font = Segoe UI, 9pt,<br>AcceptButton = btnRequest,<br>BackColor = 64, 64, 64,<br>Size = 1150, 661|                                         <img alt="Image" width="1300" src="https://user-images.githubusercontent.com/99538671/227732192-54f1a002-9353-4dc3-a94c-626e871e8011.png"/>         
| **btnRequest**:<br>Text = Request API,<br>Font = Segoe UI, 9pt,<br>Text = Reset,<br>UseVisualStyleBackColor = True,<br>Location = 486, 126,<br>Margin = 3, 4, 3, 4,<br>Size = 170, 51|<img alt="Image" width="200" src="https://user-images.githubusercontent.com/99538671/227721500-247e0129-4448-45b4-9ca1-8ec5f914098f.png" />
| **btnConvert**:<br>Font = Segoe UI, 9pt,<br>Text = Convert to CSV,<br>Location = 486, 183,<br>Margin = 3, 3, 3, 3,<br>Size = 170, 51|<img alt="Image" width="200" src="https://user-images.githubusercontent.com/99538671/227721847-3c8460d9-caee-4da7-9e8e-af641c62ca04.png"/>
| **labelJson**:<br>Font = Segoe UI, 9pt, style=Bold<br>Text = JSON,<br>Location = 210, 81,<br>Size = 47, 20|<img alt="Image" width="50" src="https://user-images.githubusercontent.com/99538671/227721912-0efacf94-df67-4a73-99ac-26855f0c70c8.png" />
| **textBoxJson**:<br>ScrollBars = Vertical,<br>Multiline = True<br>Margin = 3, 3, 3, 3,<br>Size = 431, 460,<br>Location = 29, 126|<img alt="Image" width="400" src="https://user-images.githubusercontent.com/99538671/227722000-a2a13298-200d-4a7b-9953-26f7234b9280.png" />
| **labelCsv**:<br>Font = Segoe UI, 9pt, style=Bold<br>Text = CSV,<br>Location = 855, 81,<br>Size = 36, 20|<img alt="Image" width="50" src="https://user-images.githubusercontent.com/99538671/227722137-bb273f6a-b4f6-4683-957f-a7e65eef8ce2.png" />
| **textBoxCsv**:<br>ScrollBars = Both,<br>WordWrap = False,<br>Multiline = True,<br>Margin = 3, 3, 3, 3,<br>Size = 431, 460,<br>Location = 677, 126|<img alt="Image" width="400" src="https://user-images.githubusercontent.com/99538671/227722273-6714b703-93a5-4252-ba69-65fd7bd97f37.png" />
| **labelUrl**:<br>Font = Segoe UI, 10.8pt,<br>BackColor = DimGray,<br>ForeColor = Window,<br>Text = https://restcountries.com/v3.1/,<br>Location = 354, 52,<br>Size = 263, 25|<img alt="Image" width="250" src="https://user-images.githubusercontent.com/99538671/227722451-260bca2a-5387-483b-8598-76506f6d2d20.png" />
| **textBoxUserInput**:<br>Font = Segoe UI, 10.2pt,<br>TabIndex = 1,<br>Margin = 3, 3, 3, 3,<br>Size = 158, 30,<br>Size = 158, 30,<br>Location = 623, 47|<img alt="Image" width="250" src="https://user-images.githubusercontent.com/99538671/227722619-cfa0fe3b-fa48-4f89-af11-b37e65a0fb19.png" />
| **labelEndpoints**:<br>Font = Segoe UI, 9pt, style=Bold,<br>Margin = 3, 0, 3, 0,<br>Size = 158, 30,<br>Size = 170, 187,<br>BorderStyle = FixedSingle,<br>ForeColor = Window,<br>Location = 486, 264|<img alt="Image" width="150" src="https://user-images.githubusercontent.com/99538671/227722748-f58926d3-cf14-4adb-8188-5c58a13a55b4.png" />

# NuGet Packages

[Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json/)<br>
[CsvHelper](https://www.nuget.org/packages/CsvHelper/)

# Source Code

[Form Source code](https://github.com/atabakov10/JsonToCsvConverterByAngel/blob/master/JsonToCsvForm.cs)<br>
[Business class Source code](https://github.com/atabakov10/JsonToCsvConverterByAngel/blob/master/JsonToCsv.cs)

# Screenshots

<img alt="Image" width="900" src="https://user-images.githubusercontent.com/99538671/227723114-7cd323d2-b39d-4712-9197-a00d96d144a1.png" />
<img alt="Image" width="900" src="https://user-images.githubusercontent.com/99538671/227723141-5eb0817d-5624-4a9c-84a3-a59e927ec9a0.png" />
<img alt="Image" width="900" src="https://user-images.githubusercontent.com/99538671/227723171-20e5a13b-0bf9-4d67-bd5e-d93cbe01d01c.png" />


