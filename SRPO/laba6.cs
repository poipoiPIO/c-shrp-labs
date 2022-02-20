using System;

class ConstructorTests {
  public static void Main (string[] args) {
    var vasia         = new Workman ("Vasia", 42, 12)                                   ;
    var vasiaCopy     = new Workman (vasia)                                             ;
    var internPetya   = new Workman ("Petya")                                           ;

    var org         = new EmployerInfo ("PoiCon"                                        , 
                                        "Anoyebomu Maria Pop"                           ,
                                        "Grustny Pereulok 12k")                         ;
    var orgCopy     = new EmployerInfo (org)                                            ;
    var strangeOrg  = new EmployerInfo ("AmoebaClash")                                  ;

    Console.WriteLine(vasia)                                                            ;
    Console.WriteLine(vasiaCopy)                                                        ;
    Console.WriteLine(internPetya)                                                      ;

    Console.WriteLine(org)                                                              ;
    Console.WriteLine(orgCopy)                                                          ;
    Console.WriteLine(strangeOrg)                                                       ;

    Console.WriteLine("________________Tests!________________")                         ;
    Console.WriteLine($"The Hash of vasia is:              {vasia.GetHashCode()}")      ;
    Console.WriteLine($"The Hash of petya is:              {internPetya.GetHashCode()}");
    Console.WriteLine($"The Hash of PoiCon is:             {org.GetHashCode()}")        ;
    Console.WriteLine($"The Hash of AmoebaClash is:        {strangeOrg.GetHashCode()}") ;
    Console.WriteLine($"Is vasia equals to petya:          {vasia.Equals(internPetya)}"); 
    Console.WriteLine($"Is vasia equals to his copy:       {vasia.Equals(vasiaCopy)}")  ; 
    Console.WriteLine($"Is PoiCon equals to AmoebaClash:   {org.Equals(strangeOrg)}")   ; 
    Console.WriteLine($"Is PoiCon equals to PoiCon's Copy: {org.Equals(orgCopy)}")      ; 
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

  public override bool Equals(object obj) { 
    Workman workman = obj as Workman;
    return workman == null ? false 
    : (Name, Age, ExperienceAge)
      .Equals((workman.Name, workman.Age, workman.ExperienceAge));
  }

  public override int GetHashCode()               =>
    Name.GetHashCode() + Age.GetHashCode() + ExperienceAge.GetHashCode();

  public override string ToString()               =>
    $"---------{Name}---------\n"   +
    $"Age:        {Age}\n"          +
    $"Experience: {ExperienceAge}\n";
}

class EmployerInfo {
  public string OrganizationName    { get; set; }   
  public string DirectorName        { get; set; }
  public string OrganizationAddress { get; set; }

  public EmployerInfo(string name, string dirName, string orgAddress) => 
    (OrganizationName, DirectorName, OrganizationAddress) =
      (name, dirName, orgAddress);

  public EmployerInfo(string name)                                    => 
    (OrganizationName, DirectorName, OrganizationAddress) =
     (name, "NoName", "Empty");

  public EmployerInfo()                                               => 
    (OrganizationName, DirectorName, OrganizationAddress) =
     ("NoName", "NoName", "Empty");

  public EmployerInfo(EmployerInfo employerInfo)                      => 
    (OrganizationName, DirectorName, OrganizationAddress) =
     (employerInfo.OrganizationName    , 
      employerInfo.DirectorName        ,
      employerInfo.OrganizationAddress);
 
  public override bool Equals(object obj) { 
    EmployerInfo employer = obj as EmployerInfo;
    return employer  == null ? false 
    : (OrganizationName, DirectorName, OrganizationAddress)
      .Equals((employer.OrganizationName, employer.DirectorName, employer.OrganizationAddress));
  }

  public override int GetHashCode()                                   =>
    DirectorName.GetHashCode() + 
    OrganizationName.GetHashCode() + 
    OrganizationAddress.GetHashCode();

  public override string ToString()                                   =>
    $"---------{OrganizationName}---------\n"       +
    $"Director Name:        {DirectorName}\n"       +
    $"Organization Address: {OrganizationAddress}\n";
}

