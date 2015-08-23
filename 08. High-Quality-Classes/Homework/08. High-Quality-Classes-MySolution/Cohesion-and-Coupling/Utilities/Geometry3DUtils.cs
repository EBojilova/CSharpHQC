namespace CohesionAndCoupling.Utilities
{
    using System;

    internal static class Geometry3DUtils
    {
        public static double CalcDistance3D(double x1, double y1, double z1, double x2, double y2, double z2)
        {
            var deltaX = x1 - x2;
            var deltaY = y1 - y2;
            var deltaZ = z1 - z2;

            var distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY) + (deltaZ * deltaZ));
            return distance;
        }

        public static double CalcVolume(Figure3D figure)
        {
            var volume = figure.Width * figure.Height * figure.Depth;
            return volume;
        }

        public static double CalcDiagonalXYZ(Figure3D figure)
        {
            var distance = CalcDistance3D(0, 0, 0, figure.Width, figure.Height, figure.Depth);
            return distance;
        }

        public static double CalcDiagonalXY(Figure3D figure)
        {
            var distance = Geometry2DUtils.CalcDistance2D(0, 0, figure.Width, figure.Height);
            return distance;
        }

        public static double CalcDiagonalXZ(Figure3D figure)
        {
            var distance = Geometry2DUtils.CalcDistance2D(0, 0, figure.Width, figure.Depth);
            return distance;
        }

        public static double CalcDiagonalYZ(Figure3D figure)
        {
            var distance = Geometry2DUtils.CalcDistance2D(0, 0, figure.Height, figure.Depth);
            return distance;
        }
    }
}