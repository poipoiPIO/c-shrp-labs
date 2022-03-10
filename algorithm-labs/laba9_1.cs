using System;

class Program {
  public static void Main () {
    const int N = 5;
    int[,] arr = new int[N,N];
    int[] acc = new int[5];

    // Вводим значения в массив
    for (int i = 0; i < N; i++)
        for (int j = 0; j < N; j++)
            arr[i,j] = int.Parse(Console.ReadLine());
        
    // Считаем сумму элементов над главной диагональю 
    // Для каждой строки и суем полученную сумму в массив
    // В соответствии с индексом строк
    for (int i = 0; i < N; i++)
        for (int j = 0; j < N; j++)
            if (i < j) acc[j] += arr[i,j];

    foreach(int elem in acc) //Выводим значения массива
        Console.Write(elem + " ");
    Console.WriteLine();
  }
}

