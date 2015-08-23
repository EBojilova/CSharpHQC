namespace OpenClosedDrawingShapesAfter
{
    using OpenClosedDrawingShapesAfter.Contracts;

    public class CircleDrawingManager : DrawingManager
    {
        protected override void DrawFigure(IShape shape)
        {
            var circle = shape as Circle;
            
            // Draw circle
        }
    }
}
