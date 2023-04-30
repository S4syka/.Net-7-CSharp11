using static System.Console;
using static System.Convert;

//double c = 9.8;

////int d = c; // compiler gives an error for this line
////WriteLine(d);

//int d = (int)c;
//WriteLine(d); // d is 9 losing the .8 part

//int a = 10;
//double b = a; // an int can be safely cast into a double
//WriteLine(b);

//double g = 9.5;
//int h = ToInt32(g);
//WriteLine($"g is {g} and h is {h}");

byte[] binaryObject = new byte[128]; 
Random.Shared.NextBytes(binaryObject);
WriteLine("This are the bytes");

for (int i = 0; i < binaryObject.Length; i++)
{
    Write("{0:X} ", binaryObject[i]);
}

string encoded = ToBase64String(binaryObject);
WriteLine();
WriteLine(encoded);

binaryObject = FromBase64String(encoded);

for (int i = 0; i < binaryObject.Length; i++)
{
    Write("{0:X} ", binaryObject[i]);
}