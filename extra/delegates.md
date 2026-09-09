# Extra exercise - Delegates

1. Given the following `Printer` class with a `Print` method:

   ```cs
   class Printer
   {
     public void Print(int number, MyFormatter formatter)
     {
         Console.WriteLine(formatter(number));
     }
   }
   ```

1. Write code to define the delegate MyFormatter.

1. Create a class with a function that implements a "SuperDuper" formatting:

   ```cs
   class Layout
   {
     public string SuperDuperFormat(int number)
     {
      return $"The number is [{number}]";
     }
   }
   ```

1. Call the `Print` method so that the following is printed:

   ```txt
   The number is [54]
   ```

1. Add another formatting method that you can use in `Main`.
