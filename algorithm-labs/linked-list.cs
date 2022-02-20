using System;
using System.Collections.Generic;
public class C {
    static public void Main() {
        Console.WriteLine("Meow");
        var first = new Linked<int>(1, new Linked<int>(2, new Linked<int>(2, new Linked<int>(2))));
        first.Cons(12);
        first.Append(123);
        var enumerator = first.GetEnumerator();
        Console.WriteLine("Meowwww");
        foreach(var i in enumerator)
            Console.WriteLine(i);
    }
}

class Linked<T>{
    public T         Val   { get; set; }
    public Linked<T> Next  { get; set; }
    
    public Linked(T val, Linked<T> next) =>
        (Val, Next) = (val, next);
    
    public Linked(Linked<T> obj) =>
        (Val, Next) = (obj.Val, obj.Next);

    public Linked(T val)                 =>
        (Val, Next) = (val, null);
    
    public IEnumerable<T> GetEnumerator(){
       var currentNode = this;
       while (currentNode.Next is not null){
            yield return currentNode.Val;
            currentNode = currentNode.Next;
       }
       yield break;
    }
    
    public Linked<T> FindFirst(T val) {
       var currentNode = this;
       while (currentNode.Next is not null){
            if(currentNode.Val.Equals(val))
                return currentNode;
            else 
                currentNode = currentNode.Next;
       }
       throw new Exception($"Значения {val} нету в списке!");
    }

    public void Append(T val) {
       var currentNode = this;
       while (currentNode.Next is not null){
           currentNode = currentNode.Next;
       }
       currentNode.Next = new Linked<T>(val, null);
    }

    public override string ToString() =>
        $"Node of type {Val.GetType()}\n"+
        $"With value: {Val}\n"           +
        $"Next Node is {Next}";

    public void Cons(T val) { 
        var previous = new Linked<T>(this);
        Val = val;
        Next = previous;
    }

    public void InsertAfter(Linked<T> node, T val) {
        var previous = new Linked<T>(node);
        node.Next = new Linked<T>(val, previous.Next);
    }
}
