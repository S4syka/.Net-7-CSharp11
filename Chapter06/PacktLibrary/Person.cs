﻿namespace Packt.Shared;

public class Person
{
    public int AngerLevel;
    public event EventHandler? Shout;

    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }

    public void WriteToConsole()
    {
        WriteLine($"{Name} was born on a {DateOfBirth:dddd}.");
    }

    public int MethodIWantToCall(string input)
    {
        return input.Length;
    }

    public void Poke()
    {
        AngerLevel++;
        if(AngerLevel >= 3)
        {
            Shout?.Invoke(this, EventArgs.Empty);
        }
    }
}