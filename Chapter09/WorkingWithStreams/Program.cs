using System.Xml;
using WorkingWithStreams;
using static System.Environment;
using static System.IO.Path;

SectionTitle("Writing to text streams");

string textFile = Combine(CurrentDirectory, "Streams.txt");

StreamWriter text = File.CreateText(textFile);

foreach(string item in Viper.Callsigns)
{
    text.WriteLine(item);
}

text.Close();

WriteLine("{0} contains {1:N0} bytes.", textFile, new FileInfo(textFile).Length);

WriteLine(File.ReadAllText(textFile));
