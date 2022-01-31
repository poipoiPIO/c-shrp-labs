using System;

class Program {
  public static void Main () {
    var vasia                  = new Workman();
    vasia.ExperienceAges       = 10;
    vasia.Age                  = 19;
    vasia.Name                 = "Павлов Василий Денисович";

    var gromki                 = new EmployerInfo();
    gromki.OrganizationName    = "Павлов Василий Денисович";
    gromki.DirectorName        = "Минорная Александра Евпатиевна";
    gromki.OrganizationAddress = "Грустный переулок, 165к";

    Console.WriteLine(vasia);
    Console.WriteLine(gromki);
  }
}

class Workman {
  public string Name           = "undefined";
  public int    ExperienceAges = 0;
  public int    Age            = 0; 

  public override string ToString() {
    return $"---------{this.Name}---------\n"    +
           $"Age:        {this.Age}\n"           +
           $"Experience: {this.ExperienceAges}\n";
  }
}

class EmployerInfo {
  public string OrganizationName    = "undefined";
  public string DirectorName        = "undefined";
  public string OrganizationAddress = "undefined"; 

  public override string ToString() {
    return $"---------{this.OrganizationName}---------\n"       +
           $"Director Name:        {this.DirectorName}\n"       +
           $"Organization Address: {this.OrganizationAddress}\n";
  }
}

