using System;
using System.Collections.Generic; 

class Program {
  public static void Main () {
    Console.WriteLine("\n____________________FOR_NORMIES___________________");
    Console.WriteLine($"Test 1, Find min for 1, 2, 3, 4: {minFromFour(1, 2, 3, 4)}");
    Console.WriteLine($"Test 2, Find min for 1, 2: {min(1, 2)}");
    Console.WriteLine("\n____________________FOR_FLOATS____________________");
    Console.WriteLine($"Test 3, Find min for 1.23, 2.333, 3.33, 0.4: {minFromFour(1.23, 2.333, 3.33, 0.4)}");
    Console.WriteLine($"Test 4, Find min for 1.3333, 0.2: {min(1.3333, 0.2)}");
  }

  static double min(double x, double y) =>
    x < y ? x : y;

  static double minFromFour(double x, double y, double z, double o) =>
    min(x, y) < min(z, o) ? min(x, y) : min(z, o); 
}

