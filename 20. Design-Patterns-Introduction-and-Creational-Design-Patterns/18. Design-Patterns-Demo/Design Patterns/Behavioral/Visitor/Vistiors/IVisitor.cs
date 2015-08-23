namespace Visitor
{
    using Visitor.EmployeesFolder;

    /// <summary>
    /// The 'Visitor' interface
    /// </summary>
    internal interface IVisitor
    {
        void Visit(Element element);
    }
}
