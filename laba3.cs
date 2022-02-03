using System;

class ConstructorTests {
  public static void Main (string[] args) {
    var vasia         = new Workman ("Vasia", 42, 12)          ;
    var internPetya   = new Workman ("Petya")                  ;
    var copyOfAnVasia = new Workman (vasia)                    ;
    var manWithNoName = new Workman ()                         ;

    var org         = new EmployerInfo ("PoiCon"               , 
                                        "Anoyebomu Maria Pop"  ,
                                        "Grustny Pereulok 12k");
    var strangeOrg  = new EmployerInfo ("AmoebaClash")         ;
    var copyOrg     = new EmployerInfo (org)                   ;
    var emptyOrg    = new EmployerInfo ()                      ;

    Console.WriteLine(vasia)                                   ;
    Console.WriteLine(manWithNoName)                           ;
    Console.WriteLine(internPetya)                             ;
    Console.WriteLine(copyOfAnVasia)                           ;

    Console.WriteLine(org)                                     ;
    Console.WriteLine(emptyOrg)                                ;
    Console.WriteLine(strangeOrg)                              ;
    Console.WriteLine(copyOrg)                                 ;
  }
}

class Workman {
  public  string Name          { get; set; }
  public  int    Age           { get; set; }
  public  int    ExperienceAge { get; set; }

  public Workman(string name, int age, int exAge) => 
    (Name, Age, ExperienceAge) = (name, age, exAge);

  public Workman(string name)                     => 
    (Name, Age, ExperienceAge) = (name, 0, 0);

  public Workman()                                => 
    (Name, Age, ExperienceAge) = ("NoName", 0, 0);

  public Workman(Workman previousWorkman)         => 
    (Name, Age, ExperienceAge) = (previousWorkman.Name          , 
                                  previousWorkman.Age           ,
                                  previousWorkman.ExperienceAge);

  public override string ToString() =>
    $"---------{Name}---------\n"   +
    $"Age:        {Age}\n"          +
    $"Experience: {ExperienceAge}\n";
}

class EmployerInfo {
  public  string OrganizationName    { get; set; }   
  public  string DirectorName        { get; set; }
  public  string OrganizationAddress { get; set; }

  public EmployerInfo(string name, string dirName, string orgAddress)                => 
    (OrganizationName, DirectorName, OrganizationAddress) = (name, dirName, orgAddress);

  public EmployerInfo(string name)                                                   => 
    (OrganizationName, DirectorName, OrganizationAddress) = (name, "NoName", "Empty");

  public EmployerInfo()                                                              => 
    (OrganizationName, DirectorName, OrganizationAddress) = ("NoName", "NoName", "Empty");

  public EmployerInfo(EmployerInfo employerInfo)                                     => 
    (OrganizationName, DirectorName, OrganizationAddress) = (employerInfo.OrganizationName    , 
                                                             employerInfo.DirectorName        ,
                                                             employerInfo.OrganizationAddress);
 
  public override string ToString() =>
    $"---------{OrganizationName}---------\n"       +
    $"Director Name:        {DirectorName}\n"       +
    $"Organization Address: {OrganizationAddress}\n";
}

