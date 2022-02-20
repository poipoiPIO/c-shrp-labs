#pragma warning disable 0169, 8602, 8625, 8600, 8618, 0414
using System;
using System.Collections.Generic;

public class C {
    static public void Main() {
        var list = new Linked<int>(1, new Linked<int>(2, new Linked<int>(2, new Linked<int>(2, null))));
        Console.WriteLine($"For now we have list of integers:    {list}");

        list.Cons(12);
        Console.WriteLine($"After consolidation with 12 we have: {list}");

        list.Append(123);
        Console.WriteLine($"After appending num 123 we have:     {list}");

        Console.WriteLine("\n---------------Next Example---------------");
        var listOfPoints = new Linked<Point>(new Point(1, 1), new Linked<Point>(new Point(0,0)));
        Console.WriteLine("Let's create the list of an objects");
        Console.WriteLine($"for example list of Points!\n {listOfPoints}");

        listOfPoints.Cons(new Point(0.1, 0.1));
        Console.WriteLine($"After consolidation with {new Point(0.1, 0.1)} we have:\n {listOfPoints}");

        listOfPoints.Append(new Point(2, 3));
        Console.WriteLine($"After appending {new Point(2, 3)} we have:\n {listOfPoints}");
    }

    // Just an class for example 
    public record Point(double x, double y) {
        public override string ToString() =>
            $"Point({x}, {y})";
    }
}


class Linked<T> {
    public T         Val   { get; set; } // Value of current node
    public Linked<T> Next  { get; set; } // Next node pointer
    
    // Constructor for relative node
    public Linked(T val, Linked<T> next) =>
        (Val, Next) = (val, next);
    
    // Copy constructor
    public Linked(Linked<T> obj)         =>
        (Val, Next) = (obj.Val, obj.Next);

    // Last node constructor
    public Linked(T val)                 =>
        (Val, Next) = (val, null);
     
    // Checks is node have any child
    private bool IsNodeRelative(Linked<T> node) =>
        node.Next is not null;
    
    // Enumerator will get us a oportunity to iterate over linked list
    private IEnumerable<T> GetEnumerator(){
       var currentNode = this;
       while (IsNodeRelative(currentNode)) { 
            yield return currentNode.Val; // put value of node into enumerator
            currentNode = currentNode.Next; 
       }
       yield return currentNode.Val; // put value of node into enumerator
       yield break; //return enumerator
    }
    
    public Linked<T> FindFirst(T val) {
       var currentNode = this;
       while (IsNodeRelative(currentNode)){
            if (currentNode.Val.Equals(val)) return currentNode;
            else currentNode = currentNode.Next;
       }
       throw new Exception($"Значения {val} нету в списке!");
    }

    public void Append(T val) {
       var currentNode = this;
       while (IsNodeRelative(currentNode))
           currentNode = currentNode.Next; // go to the end node 
       currentNode.Next = new Linked<T>(val, null); // change endnode pointer to appoint on our node
    }

    public void Cons(T val) { 
        var previous = new Linked<T>(this); //copy current first node
        Val = val; //change value of first node on our value 
        Next = previous; //apoint copied node
    }

    public void InsertAfter(Linked<T> node, T val) {
        var previous = new Linked<T>(node);
        node.Next = new Linked<T>(val, previous.Next);
    }

    // Pretty print linked list
    public override string ToString() {
        var   str = $"List of type {Val.GetType()}: [ ";
        IEnumerable<T> enumerator = GetEnumerator();
        foreach (var val in enumerator) str += $"{val} ";
        return str + "]";
    }
}
