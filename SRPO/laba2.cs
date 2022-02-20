using System;

class Program {
  public static void Main (string[] args) {
    var vasia                  = new Workman();
    vasia.ExperienceAge        = 10;
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
  private string name = "undefined";
  public  string Name {
    get { return this.name; }
    set { this.name = value; }
  }

  private int age = 0;
  public  int Age {
    get { return this.age; }
    set { this.age = value; }
  }

  private int experienceAge = 0;
  public  int ExperienceAge {
    get { return this.experienceAge;  }
    set { this.experienceAge = value; }
  }

  public override string ToString() {
    return $"---------{this.name}---------\n"   +
           $"Age:        {this.age}\n"          +
           $"Experience: {this.experienceAge}\n";
  }
}

class EmployerInfo {
  private string organizationName    = "undefined";
  public  string OrganizationName {
    get { return this.organizationName; }
    set { this.organizationName = value; }
  }

  private string directorName        = "undefined";
  public  string DirectorName {
    get { return this.directorName; }
    set { this.directorName = value; }
  }

  private string organizationAddress = "undefined"; 
  public  string OrganizationAddress {
    get { return this.organizationAddress; }
    set { this.organizationAddress = value; }
  }

  public override string ToString() {
    return $"---------{this.organizationName}---------\n"       +
           $"Director Name:        {this.directorName}\n"       +
           $"Organization Address: {this.organizationAddress}\n";
  }
}

