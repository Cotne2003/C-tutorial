using System.ComponentModel.DataAnnotations;

Calculator calc = new Calculator();

Console.WriteLine(calc.Plus(10, 5.25));

public class Calculator
{
    public double Plus(double a, double b)
    {
        return a + b;
    }
    public double Minus(double a, double b)
    {
        return a - b;
    }
    public double Multiplication(double a, double b)
    {
        return a * b;
    }
    public double Divide(double a, double b)
    {
        if (a == 0 || b == 0)
        {
            Console.WriteLine("Do not use 0");
        }
        return a / b;
    }
}