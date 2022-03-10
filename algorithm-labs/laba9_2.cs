using System;
using System.Linq;

class Program {
  public static void Main () {
    const int N    = 5;
    int[,]    arr  = new int[N,N];  
    int[]     X    = new int[5];
    int[] acc = new int[N];

    for (int i = 0; i < N; i++)
        for (int j = 0; j < N; j++)
            arr[i,j] = int.Parse(Console.ReadLine());
        
    for (int i = 0; i < N; i++) {
        for (int j = 0; j < N; j++)
            acc[j] = arr[i,j];
        
        int minTmp = acc.Min();
        int maxTmp = acc.Max();
        
        if (minTmp > 0 && maxTmp > 0 ||
            minTmp < 0 && maxTmp < 0)
            X[i] = acc.Sum();
        else 
            X[i] = 0;
    }

    foreach(int elem in X) 
        Console.Write(elem + " ");
    Console.WriteLine();
  }
}
