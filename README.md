# 🇮🇳 NumberToIndianWords Library

This is a simple and powerful C# class library that converts numeric values into **Indian currency words**. It supports rupees and paise, and follows the Indian numbering system — including lakh, crore, arab, and kharab.

---

## 📖 What Is This?

This library helps you convert numbers like `123456.78` into readable currency words like: One lakh twenty three thousand four hundred and fifty six rupees and seventy eight paise


It’s useful for:
- Generating invoices
- Financial reports
- Cheque printing
- Any app that needs Indian currency in words

---

## 📦 Installation

### Option 1: Install via NuGet (Recommended)

If you've published this library to NuGet:

#### Using Package Manager Console:
```bash
Install-Package NumberToIndianWords
```
Using .NET CLI:

```bash
dotnet add package NumberToIndianWords
```

Using Visual Studio:

1.Right-click your project in Solution Explorer.
2.Select Manage NuGet Packages.
3.Search for NumberToIndianWords.
4.Click Install.


🛠️ How to Use
Step 1: Add the Namespace

```csharp
using NumberToIndianWords;
```

Step 2: Call the Method
```csharp
decimal amount = 123456.78m;
string result = amount.ToIndianCurrencyWords();
Console.WriteLine(result);
```

✅ Output
```code
one lakh twenty three thousand four hundred and fifty six rupees and seventy eight paise
```

💡 Supported Types
You can use .ToIndianCurrencyWords() on:
decimal
float
int
long
short

Examples:
```Csharp
Console.WriteLine(123.45m.ToIndianCurrencyWords());       // decimal
Console.WriteLine(99.99f.ToIndianCurrencyWords());        // float
Console.WriteLine(10000000.ToIndianCurrencyWords());      // int
Console.WriteLine(123456789L.ToIndianCurrencyWords());    // long
Console.WriteLine(((short)250).ToIndianCurrencyWords());  // short
Console.WriteLine((-5000).ToIndianCurrencyWords());       // negative int
```

📋 Output Samples
Input	Output
123.45m	one hundred twenty-three rupees and forty-five paise
10000000	one crore rupees
-2500	negative two thousand five hundred rupees
0	zero rupees

🧪 Edge Cases Handled
✅ Zero values → "zero rupees"
✅ Negative values → "negative one lakh rupees"
✅ Large numbers → up to "kharab"
✅ Decimal precision → "and paise"
✅ Grammar → "one rupee" vs "two rupees"



📄 License
This project is open-source and free to use under the MIT License.


🙌 Contributing
Pull requests are welcome! If you’re a fresher or beginner, feel free to ask questions or suggest improvements.


✨ Author
Crafted with ❤️ for developers who want clean, readable financial output in Indian format.

---

You can save this content as a file named `README.md` in your project directory. If you’re planning to publish this as a NuGet package or host it on GitHub, this file will automatically be used to show documentation. Let me know if you’d like help with packaging or publishing next!

