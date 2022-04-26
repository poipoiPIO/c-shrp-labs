using System;
using System.Linq;
using System.Collections.Generic;

class Solve {
  static void Main () {
    Console.WriteLine("Задание 1:");
    Laba11_2_1.Solve();
    Console.WriteLine();

    Console.WriteLine("Задание 2:");
    Laba11_2_2.Solve();
  }
}

static class Laba11_1_1 {
  static double Sum (double first, double second) =>
    first + second;

  static double Mult (double first, double second) => 
    first * second;
} 

static class Laba11_1_2 {
  static string FindInDirectory
    (string alphabet, string name, List<(string, string)[]> directory) {
      int alphabetLength = alphabet.Length;
      int numOfSheet     = alphabet.IndexOf(name[0]);
      var sheet = directory[numOfSheet];

      foreach(var elem in sheet) 
        if (elem.Item1 == name)
          return elem.Item2;
      return "Not found";
    }
}

class Laba11_1_3 {
  class Subject {
    public string Name { get; set; }
    public bool IsDebt { get; set; }

    Subject(string name, bool debt) =>
      (Name, IsDebt) = (name, debt);
  }

  class Student {
   public string    Name     { get; set; }
   public Subject[] Subjects { get; set; }

    Student (string name, Subject[] subjects) =>
      (Name, Subjects) = (name, subjects);

    public IEnumerable<Subject> getDebt() =>
      Subjects.Where(elem => elem.IsDebt);
  }
  
  void printDebtors( Student[] Group ) {
    foreach (var student in Group) 
      if (student.getDebt().Any()) {
        Console.WriteLine(student.Name);
        foreach(var debt in student.getDebt())
          Console.WriteLine(debt.Name);
      }
  }
}

static class Laba11_2_1 {
  /* Найдите среднее арифметическое значений 
     информационных полей элементов списка. */

  public static void Solve () {
    List<double> list = new List<double> {1, 2, 3, 4}; 

    Console.Write("Имеем вот список вот таких вот элементов: ");
    list.ForEach(elem => Console.Write($"{elem} "));
    Console.WriteLine();

    double result = list.Sum() / list.Count();

    Console.WriteLine($"Среднее арифметическое элементов списка: {result}");
  }
}

static class Laba11_2_2 {
  public static void Solve () {
    List<int> f1 = new List<int> {1, 2, 3, 4, 5, 1, 2, 3, 6},
              f2 = new List<int> {1, 2, 3};

    var histoghram = 
      f1.GroupBy(x => x)
        .Select(x => new {Value = x.Key, Count = x.Count()})
        .OrderByDescending(x => x.Count);

    var intersect = f1.Intersect(f2);

    Console.WriteLine 
      ("Члены множества f1 пересекающиеся с членами множества f2:");
    foreach(var item in intersect)
      Console.Write($"{item} ");
    Console.WriteLine();

    Console.WriteLine("Количество вхождений этих членов в множество f1:");
    foreach (var elem in histoghram)
      if (intersect.Contains(elem.Value))
          Console.WriteLine($"{elem.Value} был встречен {elem.Count} раз");

    Console.WriteLine
      ($"Целиком множество к ряду встретилось {countIntersections(f1, f2)} раз");
    }

  static int countIntersections 
    (List<int> array, List<int> intersectedArray) {

    int count             = 0,
        intersections     = 0,
        intersectedLength = intersectedArray.Count();

    foreach(int elem in array) {
      if (intersectedLength <= count) {
        count = 0; 
        intersections++;
      }

      if (elem == intersectedArray[count]) 
        count++;
      else 
        count = 0;
    }
    return intersections;
  }
}
