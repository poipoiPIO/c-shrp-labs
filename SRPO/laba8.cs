using System;
using System.Linq;

class Program {
  public static void Main() {
    var alphabet          = "aHOI_qUtTIE-kITTY@cAT!";
    var str               = "Monad is a monoid in category of endofunctors meow!~";
    var splittedString    = str.Split(" ");
    var averageLength     = splittedString.Select(word => word.Length)
                                          .Sum() / splittedString.Length;

    var result = splittedString
      .Select(w => {
          int deltaLength = w.Length-averageLength; 
          return deltaLength switch {
            > 2  => w.Remove(w.Length-deltaLength),
            < -2 => w + RandomString(-deltaLength, alphabet),
            _    => w
          };
      }); 
     
     Console.WriteLine($"Origin string:       {str}");
     Console.WriteLine($"Average word length: {averageLength}");
     Console.WriteLine($"Modified string:     {string.Join(" ", result)}");
  }

  static Random random = new();

  static string RandomString(int length, string chars) =>
    new(Enumerable.Range(1, length)
                  .Select(_ => chars[random.Next(chars.Length)])
                  .ToArray());
}

