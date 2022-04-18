using System;
using System.Linq;
using System.Collections.Generic;

class Solve {
  static void Main () {
    Console.WriteLine("Задание 1:");
    Laba11_1.Solve();
    Console.WriteLine();

    Console.WriteLine("Задание 2:");
    Laba11_2.Solve();
  }
}

static class Laba11_1 {
  /* Найдите среднее арифметическое значений 
     информационных поле элементов списка. */

  public static void Solve () {
    List<double> list = new List<double> {1, 2, 3, 4}; 

    Console.Write("Имеем вот список вот таких вот элементов: ");
    list.ForEach(elem => Console.Write($"{elem} "));
    Console.WriteLine();

    double result = list.Sum() / list.Count();

    Console.WriteLine($"Среднее арифметическое элементов списка: {result}");
  }
}

static class Laba11_2 {
  /* Вставьте в список новый элемент перед каждым 
     элементом с заданным значением информационного поля 
     (информационные поля могут повторяться). */

public static void Solve () {
    List<double> list = new List<double> {1, 2, 3, 4}; 

    Console.Write("Имеем вот список вот таких вот элементов: ");
    list.ForEach(
        elem => Console.Write($"{elem} "));
    Console.WriteLine();

    var result = list.Select(x => new List<double> {x, x})
                     .SelectMany(x => x)
                     .ToList();

    Console.Write("Результирующий список: ");
    result.ForEach(
        elem => Console.Write($"{elem} "));
    Console.WriteLine();
  }
}
