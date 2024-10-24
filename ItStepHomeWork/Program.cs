using System;
using System.Collections.Generic;

internal class Program
{
	static void Main(string[] args)
	{
		Calculator calculator = new Calculator();
		Condition condition = null;
		condition = calculator.Minus; 
		condition += calculator.Plus; 
		condition += calculator.Division; 
		condition += calculator.Multiplication;
		condition += calculator.Remainder;
		condition(10, 5);
	}

	delegate double Condition(double a, double b);

	class Calculator
	{
		public double Plus(double a, double b)
		{
			Console.WriteLine($"{a} + {b} = {a + b}");
			return a + b;
		}
		public double Minus(double a, double b)
		{
			Console.WriteLine($"{a} - {b} = {a - b}");
			return a - b;
		}
		public double Division(double a, double b)
		{
			Console.WriteLine($"{a} / {b} = {a / b}");
			return a / b;
		}
		public double Multiplication(double a, double b)
		{
			Console.WriteLine($"{a} * {b} = {a * b}");
			return a * b;
		}
		public double Remainder(double a, double b)
		{
			Console.WriteLine($"{a} % {b} = {a % b}");
			return a % b;
		}
	}

}
