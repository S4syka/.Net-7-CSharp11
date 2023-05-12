using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Packt.Shared;

partial class Program
{
    static void Harry_Shout(object? sender, EventArgs e)
    {
        if (sender == null)
        {
            return;
        }

        Person? p = sender as Person;
        if (p is null) return;

        WriteLine($"{p.Name} is this angry: {p.AngerLevel}.");
    }
}
