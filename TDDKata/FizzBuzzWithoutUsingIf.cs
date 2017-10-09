using System;
using System.Linq;

public class FizzBuzz {

    public string PrintNumbers() {
        string value = "";
        for (int i = 0; i < 100; i++) {
            value += PrintNumber(i) + "\n";
        }
        Console.Write(value);

        return value;
    }

    public string PrintNumber(int number) {
        string value = number.ToString();
        value = IsFizz(number) ? "Fizz" : value;
        value = IsBuzz(number) ? "Buzz" : value;
        value = IsFizzBuzz(number) ? "FizzBuzz" : value;

        return value;
    }

    public bool IsFizz(int number) {
        return number % 3 == 0;
    }

    public bool IsBuzz(int number) {
        return number % 5 == 0;
    }

    public bool IsFizzBuzz(int number) {
        return (IsFizz(number) && IsBuzz(number)) ? true : false;
    }

    public string PrintNumbersUsingLinq() {
        string value = "";
        Enumerable.Range(0, 100)
            .Select(n => IsFizzBuzz(n) ? "FizzBuzz" : IsFizz(n) ? "Fizz" : IsBuzz(n) ? "Buzz" :  n.ToString())
            .ToList()
            .ForEach(n => value += n + "\n");
        return value;
    }
}
