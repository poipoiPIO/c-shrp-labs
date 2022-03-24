using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

class Program {
  static void Main() {
    var input = File.ReadAllText("./file-to-read.txt");
    List<(int, string)> hashPairs = HashPairsFromFileString(input).ToList();

    foreach (var hashPair in hashPairs)
      Console.WriteLine($"Word '{hashPair.Item2}' has code of: {hashPair.Item1}");
  }

  static IEnumerable<(int, string)> HashPairsFromFileString(string input) =>
    input.Split(" ")
         .Distinct() //Remove duplecates
         .Select(word => (word.GetHashCode(), word))
         .OrderBy(pair => pair.Item1); // Sort by Hash
}

