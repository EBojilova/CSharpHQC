namespace Geometry
{
    using System;

    internal static class GeometryMethods
    {
        internal static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentOutOfRangeException("All sides of a triangle should be positive.");
            }

            if (a + b < c || a + c < b || b + c < a)
            {
                throw new ArgumentOutOfRangeException(
                    "Each triangle side should be shorter than the sum of the other two sides.");
            }

            var semiPerimeter = (a + b + c) / 2;
            var area = Math.Sqrt(semiPerimeter * (semiPerimeter - a) * (semiPerimeter - b) * (semiPerimeter - c));

            return area;
        }

        internal static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            var deltaX = x1 - x2;
            var deltaY = y1 - y2;

            var distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return distance;
        }

        internal static bool IsHorizontal(double x1, double y1, double x2, double y2)
        {
            var isHorizontal = y1.Equals(y2);
            return isHorizontal;
        }

        internal static bool IsVertical(double x1, double y1, double x2, double y2)
        {
            var isVertical = x1.Equals(x2);
            return isVertical;
        }
    }
}