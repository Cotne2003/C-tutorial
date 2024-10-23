using System;
using System.Collections.Generic;

internal class Program
{
	static void Main(string[] args)
	{
		Calculator calculator = new Calculator();
		calculator.condition(10, 5);
	}

	delegate double Condition(double a, double b);

	class Calculator
	{
		public Condition condition = null;
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
	}

}
