using System;

// Shape.cs
public class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    public void SetColor(string color)
    {
        _color = color;
    }

    // Virtual method to be overridden
    public virtual double GetArea()
    {
        return 0;
    }
}

// Square.cs
public class Square : Shape
{
    private double _side;

    public Square(string color, double side) : base(color)
    {
        _side = side;
    }

    public override double GetArea()
    {
        return _side * _side;
    }
}

// Rectangle.cs
public class Rectangle : Shape
{
    private double _width;
    private double _height;

    public Rectangle(string color, double width, double height) : base(color)
    {
        _width = width;
        _height = height;
    }

    public override double GetArea()
    {
        return _width * _height;
    }
}

// Circle.cs
public class Circle : Shape
{
    private double _radius;

    public Circle(string color, double radius) : base(color)
    {
        _radius = radius;
    }

    public override double GetArea()
    {
        return Math.PI * _radius * _radius;
    }
}


class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Shapes Project.");
         Square square = new Square("Red", 5);
        Rectangle rectangle = new Rectangle("Blue", 4, 6);
        Circle circle = new Circle("Green", 3);

        // Test individual calls
        Console.WriteLine($"Square color: {square.GetColor()}, area: {square.GetArea()}");
        Console.WriteLine($"Rectangle color: {rectangle.GetColor()}, area: {rectangle.GetArea()}");
        Console.WriteLine($"Circle color: {circle.GetColor()}, area: {circle.GetArea()}");

        // Build a list of shapes
        List<Shape> shapes = new List<Shape> { square, rectangle, circle };

        Console.WriteLine("\nIterating through shapes:");
    }
}