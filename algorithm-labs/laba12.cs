using System;
using System.Collections.Generic;
using System.IO;

class Laba12 {
  public static void Main () {
    var stack = new Stack<char>();
    string brackets = Console.ReadLine();

    foreach(char ch in brackets)
      if(ch == '(') stack.Push(ch);
      else if(ch == ')')
        if (stack.IsEmpty())
          throw new Exception("Unmatched brackets!");
        else stack.Pop();
      else throw new Exception($"Unexpected character: {ch}");

    if (stack.IsEmpty())
      Console.WriteLine("The Sequence of brackets is matched successfully!");
    else
      throw new Exception($"Unmatched sequence of brackets!");
  }
}

public class Stack<T> {
  private List<T> _Arr;

  public Stack(List<T> arr) => _Arr = arr;
  public Stack() => _Arr = new List<T>();
  
  public T Top() => 
    IsEmpty() ? throw new Exception("Stack is Empty") : _Arr[0];

  public bool IsEmpty() {
    T top;
    try {
      top = _Arr[0];
    } catch(System.ArgumentOutOfRangeException) {
      return true;
    } 

    return false;
  }

  public void Push(T item) {
    _Arr.Insert(0, item);
  }

  public T Pop() {
    T acc = Top();
    _Arr.RemoveAt(0);
    return acc;
  }
}
