using Packt.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

partial class Program
{
    static void OutputPeopleNames(IEnumerable<Person?> people, string title)
    {
        WriteLine(title);
        foreach (Person? p in people)
        {
            WriteLine(" {0}",
            p is null ? "<null> Person" : p.Name ?? "<null> Name");
            /* if p is null then output: <null> Person
            else output: p.Name
            unless p.Name is null in which case output: <null> Name */
        }
    }
}
