using System;

class Program {
  public static void Main (string[] args) {
    var enterprise = new Enterprise(1200, 2400, 1200, 15000000);
    Console.WriteLine(enterprise);
    Console.WriteLine($"The Earnings without a loan:          {enterprise.earningsWithoutLoan()}");
    Console.WriteLine($"The Earnings without a salary outlay: {enterprise.earningsWithoutSalary()}");
    Console.WriteLine($"The Earnings without a taxes:         {enterprise.earningsWithoutTaxes()}");
    Console.WriteLine($"The Earnings without any outlay:      {enterprise.earningsWithoutOutlay()}");
  }
}

class Enterprise {
  public int AllOutlay    { get; private set; }
  public int TaxOutlay    { get; set; }
  public int SalaryOutlay { get; set; }
  public int LoanOutlay   { get; set; }
  public int Earnings     { get; set; }

  public Enterprise(int tax, int loan, int salary, int earnings) =>
    (AllOutlay, TaxOutlay, LoanOutlay, SalaryOutlay, Earnings) = 
      (tax+salary+loan, tax, loan, salary, earnings);

  public int earningsWithoutOutlay() => Earnings - AllOutlay;
  public int earningsWithoutTaxes()  => Earnings - TaxOutlay;
  public int earningsWithoutSalary() => Earnings - SalaryOutlay;
  public int earningsWithoutLoan()   => Earnings - LoanOutlay;

  public override string ToString() =>
    "---------------summary--------------------\n"       +
    $"The Earnings of Enterprise is: {Earnings}\n"     +
    $"The sum of tax is:             {TaxOutlay}\n"    +
    $"The salary outlay is:          {SalaryOutlay}\n" +
    $"The loan outlay is:            {LoanOutlay}\n"   +
    $"The sum of all outlays is:     {AllOutlay}\n"       ; 
}
