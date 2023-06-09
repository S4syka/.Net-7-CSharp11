﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Packt.Shared;

public partial class Person
{
    public static int Factorial(int number)
    {
        if (number < 0)
        {
            throw new ArgumentException(
            $"{nameof(number)} cannot be less than zero.");
        }

        return localFactorial(number);
    
        int localFactorial(int localNumber) // local function
        {
            if (localNumber == 0) return 1;
            return localNumber * localFactorial(localNumber - 1);
        }
    }
}
