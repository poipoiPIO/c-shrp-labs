using System;

class Program {
  public static void Main (string[] args) {
    const int    earnings   = 2500;
    const int    sumOfLoans = 1000;
    const int    salaries   = 200;
    const double taxes      = 0.24;
    const double loan       = 0.12;

    Console.WriteLine($"The Earnings without a loan:          {getEarnings(earnings, loan, sumOfLoans)}");
    Console.WriteLine($"The Earnings without a salary outlay: {getEarnings(earnings, salaries)}");
    Console.WriteLine($"The Earnings without a taxes:         {getEarnings(earnings, taxes)}");
    Console.WriteLine($"The Earnings without any outlay:      {getEarnings(earnings)}");
  }

  static int getEarnings(int earnings) =>
    earnings;

  static double getEarnings(int earnings, double taxes) =>
    earnings - (earnings * taxes);

  static int getEarnings(int earnings, int salaries) =>
    earnings - salaries;

  static double getEarnings(int earnings, double loan, int sumOfLoan) =>
    earnings - (loan * sumOfLoan);

}
