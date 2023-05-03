using System.Diagnostics;
using Microsoft.Extensions.Configuration;

string logPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "log.txt");

Console.WriteLine($"Writing to: {logPath}");

TextWriterTraceListener logFile = new(File.CreateText(logPath));

Trace.Listeners.Add(logFile);

Trace.AutoFlush = true;

Console.WriteLine("Reading settings from appsettings.json in {0}", Directory.GetCurrentDirectory());

ConfigurationBuilder builder = new();
builder.SetBasePath(Directory.GetCurrentDirectory());
builder.AddJsonFile("appsettings.json", 
    optional: true, reloadOnChange: true);

IConfigurationRoot configuration = builder.Build();

TraceSwitch ts = new(
    displayName: "PacktSwitch", 
    description: "This switch is set with JSON config");

configuration.GetSection("PacktSwitch").Bind(ts);

Trace.WriteLineIf(ts.TraceError, "Trace error!");
Trace.WriteLineIf(ts.TraceWarning, "Trace warning!");
Trace.WriteLineIf(ts.TraceInfo, "Trace info!");
Trace.WriteLineIf(ts.TraceVerbose, "Trace verbose!");

Console.ReadLine();