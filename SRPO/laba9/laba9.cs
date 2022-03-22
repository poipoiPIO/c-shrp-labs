using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;

class Program {
  static void Main() {
    var input = File.ReadAllText("./file-to-read.txt");
    var solve = prettiefyValues(calculateForArray(castStringNumsToInt(input)));
    File.WriteAllText("./file-to-write.txt", solve);
  }
  
  static IEnumerable<double> castStringNumsToInt(string input) =>
    input.Split(" ").Select(str => Double.Parse(str));

  static (double, double) calculateFormula(double x) =>
    (x, ((1 - Math.Pow(x, 2)) / (1 + Math.Pow(x, 4))));

  static IEnumerable<(double, double)> calculateForArray(IEnumerable<double> array) =>
    array.Select(x => calculateFormula(x));

  static string prettiefyValues(IEnumerable<(double, double)> results) =>
    string.Join("", results.Select(res => prettiefyValue(res)));

  static string prettiefyValue((double, double) result) =>
    $"x = {result.Item1} | y = {result.Item2}\n"; 
}

