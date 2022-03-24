using System;

class Program {
  public static void Main (string[] args) {
    CarService[] service = new CarService[3];

    //Fill array of structures with entitys
    for(int i = 0; i<service.Length; i++)
      initElem(ref service[i]);

    //Print what we got
    foreach(var carService in service)
      Console.WriteLine(carService);

    //Removing elem from array
    Console.WriteLine("Введите регистрационный номер машины для удаления сервиса!");
    int choise = int.Parse(Console.ReadLine());
    Array.Clear(service, Array.FindIndex(service, (CarService elem) => choise == elem.RegNum), 1);

    //find elem
    Console.WriteLine("Введите регистрационный номер машины для поиска сервиса!");
    choise = int.Parse(Console.ReadLine());
    Console.WriteLine(findElemByRegNumOrDie(choise, service));

    //edit elem
    Console.WriteLine("Введите регистрационный номер машины для редактирования ее сервиса!");
    choise = int.Parse(Console.ReadLine());
    editElemByRegNum(ref service, choise);
  }

  static CarService findElemByRegNumOrDie(int choise, CarService[] service) {
    foreach(var elem in service)
      if(elem.RegNum == choise) 
        return elem;
    throw new Exception($"Список не имеет машиныпод номером: {choise}");
  }

  static void editElemByRegNum(ref CarService[] service, int choise) {
    for(int i = 0; i<service.Length; i++)
      if(service[i].RegNum == choise){ 
        initElem(ref service[i]);
        return;
      }
    Console.WriteLine($"Не могу найти машину по запросу: {choise}");
  }

  static void initElem(ref CarService service) {
    Console.WriteLine("Введите регистрационный номер машины:");
    service.RegNum = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите пробег машины               :");
    service.Milage = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите стоимость ремонта           :");
    service.Cost = int.Parse(Console.ReadLine());
    Console.WriteLine("Введите имя мастера                 :");
    service.Mechanic = Console.ReadLine();
    Console.WriteLine("Введите марку машины                :");
    service.CarBrand = Console.ReadLine();
    Console.WriteLine();
  }
}

struct CarService {
  public  int RegNum;  
  public  int Milage;  
  public  int Cost;   
  public  string CarBrand; 
  public  string Mechanic; 

  public override string ToString() =>
     "--------CarServiceStruct--------\n" +
    $"Регистрационный номер машины: {RegNum}\n" +
    $"Пробег машины:                {Milage}\n" +
    $"Стоимость ремонта:            {Cost}\n" +
    $"Авто мастер:                  {Mechanic}\n" +
    $"Марка машины:                 {CarBrand}\n"; 
}
