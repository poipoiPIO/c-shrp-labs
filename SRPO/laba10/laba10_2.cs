using System;
using System.Linq;
using System.Collections.Generic;

class Ex2 {
  public static void Main() {
    Dictionary<string, string> cities = new Dictionary<string, string> {
      {"01", "Adegea"},
      {"31", "Belgorod oblast"},
      {"27", "Khabarovsky kray"},
      {"76", "Yaroslavsk oblast"},
      {"33", "Vladimirsk oblast"},
      {"32", "Bryansk oblast"}
    };

    foreach(var city in prettifyOutput(cities)) 
      Console.WriteLine(city);
  }

  static IEnumerable<string> prettifyOutput(Dictionary<string, string> cities) =>
    cities.Select(city => $"The number of {city.Value} is: {city.Key}");
}

