using System;

class Program {
  public static void Main () {
    Console.WriteLine($" a! + b! / a!, при 5 = {solvFirst(5, 5)}");
    progressive(3, 1);
  }

  static double solvFirst(double a, double b) =>
    (fact(a) + fact(b))/fact(a);

  static double fact(double x) => x < 1 ? 1 : x*fact(x-1);

  static void progressive(int n, int counter) {
    Console.WriteLine($"{counter}-ное значение последовательности: {n}");
    if(counter <= 10) progressive(n+4, counter+1);
  }
}
