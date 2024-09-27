
Square squ = new Square(8);
Console.WriteLine(squ.P());
Console.WriteLine(squ.A());

Circle circle = new Circle(5);
Console.WriteLine(circle.P());
Console.WriteLine(circle.A());

public class Square
{
    public Square(double side)
    {
        Side = side;
    }

    public double Side {  get; set; }

    public double P()
    {
        return Side * 4;
    }

    public double A()
    {
        return Side * Side;
    }
}

public class Circle
{
    public Circle(double radius)
    {
        Radius = radius;
    }
    public double Radius { get; set; }

    public double P()
    {
        return Math.PI * 2 * Radius;
    }

    public double A()
    {
        return Math.PI * Math.Pow(Radius, 2);
    }
}