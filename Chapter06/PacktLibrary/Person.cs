namespace Packt.Shared;

public class Person : IComparable<Person>
{
    public int AngerLevel;
    public event EventHandler? Shout;

    public string? Name { get; set; }
    public DateTime DateOfBirth { get; set; }

    public virtual void WriteToConsole()
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

    public int CompareTo(Person? other)
    {
        int position;

        if ((this is not null) && (other is not null))
        {
            if ((Name is not null) && other.Name is not null) position = Name.CompareTo(other.Name);
            else if ((Name is not null) && other.Name is null) position = -1;
            else if ((Name is null) && other.Name is not null) position = 1;
            else position = 0;
        }
        else if ((this is null) && other is not null) position = 1;
        else if ((this is not null) && other is null) position = -1;
        else position = 0;

        return position;
    }

    public override string ToString()
    {
        return $"{Name} is a {base.ToString()}";
    }

}