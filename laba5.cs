using System;

class Program {
  public static void Main () {
    var ex_person = new Person("Vicia", "female");
    var maid_worker = new Worker("Vasia", "male", "maid", "maid suit"); 
    var ex_employer = new  Employer("Oleg", "Eduardovich", "male"); 
    var ex_cashier  = new  Cashier("Geliow Menicky", "male");
    var ex_accountant  = new  Accountant("Youiak Kachincky", "female");

    Console.WriteLine("________PersonClassExample________");
    Console.WriteLine(ex_person);
    ex_person.takeFood("Ribs");

    Console.WriteLine("\n________WorkerClassExample________");
    Console.WriteLine(maid_worker);
    maid_worker.doWork();
    maid_worker.takeALook();

    Console.WriteLine("\n________EmployerClassExample________");
    Console.WriteLine(ex_employer);
    ex_employer.hire(maid_worker);

    Console.WriteLine("\n________CashierClassExample________");
    Console.WriteLine(ex_cashier);
    ex_cashier.doWork();

    Console.WriteLine("\n________AccountantClassExample________");
    Console.WriteLine(ex_accountant);
    ex_accountant.doWork();
  }
}

class Person {
  public string Name { get; set; }
  public string Sex  { get; set; }
  
  public Person(string name, string sex) =>
    (Name, Sex) = (name, sex);

  public Person() =>
    (Name, Sex) = ("NoName", "NoSex");

  virtual protected string reference() =>
    Sex == "male" ? "He" : "She";

  public void takeFood(string food) =>
    Console.WriteLine($"{Name} take a food {food}!");

  public override string ToString() =>
    $"An Person whose name is: {Name}";
}

class Worker : Person {
  public string Post    { get; set; }
  public string Uniform { get; set; }

  public Worker(string name, string sex, string post, string uniform) =>
    (Name, Sex, Post, Uniform) = (name, sex, post, uniform);

  public Worker() =>
    (Name, Sex, Post, Uniform) = ("NoName", "NoSex", "NoPost", "NoUniform");

  public virtual void doWork() =>
    Console.WriteLine($"{Name} is working!");

  public void takeALook() => 
    Console.WriteLine($"{Name} is cute! {reference()} is wearing {Uniform}!");

  public override string ToString() =>
    $"An Worker whose name is: {Name}\n" +
    $"And post is: {Post}!";
}

class Employer : Person {
  public string Middlename { get; set; } 

  public Employer(string name,  string middlename, string sex) =>
    (Name, Sex, Middlename) = (name, sex, middlename);

  protected override string reference() =>
    $"{Name} {Middlename}";

  public void hire(Worker workman) =>
    Console.WriteLine($"{workman.Name}, {reference()} want to hire you!\n"+
                      $"Do you want to be my {workman.Post}? Of course for decent amount of $$$CASH$$$!");

  public override string ToString() =>
    $"An Employer whose name is: {reference()}";
}

class Cashier : Worker {
  public override void doWork() =>
    Console.WriteLine($"{Name} is working with huge amount of $$$$CASH$$$$!");
  
  public Cashier(string name, string sex) =>
    (Name, Sex, Post, Uniform) = (name, sex, "cashier", "cashier uniform");

  public override string ToString() =>
    $"An Cashier whose name is: {Name}\n" +
    $"And post is: Cashier!";
}

class Accountant : Worker {
  public override void doWork() =>
    Console.WriteLine($"{Name} is working with huge amount of an caluculating stuff ^_^!");
  
  public Accountant(string name, string sex) =>
    (Name, Sex, Post, Uniform) = (name, sex, "accountant", "accountant uniform");

  public override string ToString() =>
    $"An accountant whose name is: {Name}\n" +
    $"And post is: accountant meh....";
}
