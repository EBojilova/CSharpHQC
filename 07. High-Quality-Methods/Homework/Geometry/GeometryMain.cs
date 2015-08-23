namespace Geometry
{
    using System;

    internal class GeometryMain
    {
        private static void Main()
        {
            Console.WriteLine(GeometryMethods.CalcTriangleArea(3, 4, 5));

            var point1 = new Point(3, -1);
            var point2 = new Point(3, 2.5);
            Console.WriteLine(GeometryMethods.CalcDistance(point1.X, point1.Y, point2.X, point2.Y));
            Console.WriteLine("Horizontal? {0}", GeometryMethods.IsHorizontal(point1.X, point1.Y, point2.X, point2.Y));
            Console.WriteLine("Vertical? {0}", GeometryMethods.IsVertical(point1.X, point1.Y, point2.X, point2.Y));
        }
    }
}