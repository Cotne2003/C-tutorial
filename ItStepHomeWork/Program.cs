Point test1 = new Point(3, 3, 3);
Point test2 = new Point(3, 3, 3);
Point test3 = test1 / test2;

Console.WriteLine(test3.X);
Console.WriteLine(test3.Y);
Console.WriteLine(test3.Z);
struct Point
{
    public Point(double x, double y, double z)
    {
        X = x;
        Y = y;
        Z = z;
    }
    public double X { get; set; }
	public double Y { get; set; }
	public double Z { get; set; }
    public static Point operator +(Point p1, Point p2)
    {
        return new Point(p1.X + p2.X, p1.Y + p2.Y, p1.Z + p2.Z);
    }
    public static Point operator -(Point p1, Point p2)
    {
        return new Point(p1.X - p2.X, p1.Y - p2.Y, p1.Z - p2.Z);
    }
    public static Point operator *(Point p1, Point p2)
    {
        return new Point(p1.X * p2.X, p1.Y * p2.Y, p1.Z * p2.Z);
    }
    public static Point operator /(Point p1, Point p2)
    {
        return new Point(p1.X / p2.X, p1.Y / p2.Y, p1.Z / p2.Z);
    }
}