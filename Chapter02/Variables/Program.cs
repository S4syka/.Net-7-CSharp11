﻿using System.Xml;

//object height = 1.88; // storing a double in an object
//object name = "Amir"; // storing a string in an object
//Console.WriteLine($"{name} is {height} metres tall.");

////int length1 = name.Length; // gives compile error!

//int length2 = ((string)name).Length; // tell compiler it is a string
//Console.WriteLine($"{name} has {length2} characters.");

//// storing a string in a dynamic object
//// string has a Length property
//dynamic something = "Ahmed";
//// int does not have a Length property
//something = 12;
//// an array of any type has a Length property
//// something = new[] { 3, 5, 7 };

//// this compiles but would throw an exception at run-time
//// if you later stored a data type that does not have a
//// property named Length
//Console.WriteLine($"Length is {something.Length}");

//XmlDocument xml3 = new(); // target-typed new in C# 9 or later

Console.WriteLine($"Default value of int is {default(int)}");
Console.WriteLine($"Default value of datetime is {default(DateTime)}");
Console.WriteLine($"default(string) = {default(string)}");
int x = 13;
Console.WriteLine(x);
x = default;
Console.WriteLine(x);