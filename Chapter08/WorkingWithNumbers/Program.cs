using System.Numerics;
using System.Text.RegularExpressions;

//WriteLine("Working with large integers:");
//WriteLine("-----------------------------------");
//ulong big = ulong.MaxValue;
//WriteLine($"{big,40:N0}");
//BigInteger bigger = BigInteger.Parse("123456789012345678901234567890");
//WriteLine($"{bigger,40:N0}");

Random r = Random.Shared;

// minValue is an inclusive lower bound i.e. 1 is a possible value
// maxValue is an exclusive upper bound i.e. 7 is not a possible value
int dieRoll = r.Next(minValue: 1, maxValue: 7); // returns 1 to 6
double randomReal = r.NextDouble(); // returns 0.0 to less than 1.0
byte[] arrayOfBytes = new byte[256];
r.NextBytes(arrayOfBytes); // 256 random bytes in an array

Regex csv = new("(?:^|,)(?=[^\"]|(\")?)\"?((?(1)[^\"]*|[^,\"]*))\"?(?=,|$)");
