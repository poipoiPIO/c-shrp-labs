using System;

class Program {
  public static void Main () {
    var lengthOfArr = int.Parse(Console.ReadLine());
    var arr = new int[lengthOfArr];

    for(int i = 0; i < lengthOfArr; i++) 
      arr[i] = int.Parse(Console.ReadLine());
    
    var posSum = 0;
    var negSum = 0;
    var posCount = 0;
    var negCount = 0;

    foreach(var elem in arr) 
      if(elem >= 0){
        posSum += elem;
        posCount++;
      } else {
        negSum += elem;
        negCount++;
      } 

    Console.WriteLine($"{negSum} {posSum} {posCount} {negCount}");
  }
}

