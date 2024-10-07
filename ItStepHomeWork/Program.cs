using ItStepHomeWork.Classes;

internal class Program
{
	static void Main(string[] args)
	{
		Square square = new Square();
		Console.WriteLine(square.GetSquareArea(10));

		Triangle triangle = new Triangle();
		Console.WriteLine(triangle.GetTriangleArea(10, 20));

		Circle circle = new Circle();
		Console.WriteLine(circle.GetCircleArea(10));
	}
}


