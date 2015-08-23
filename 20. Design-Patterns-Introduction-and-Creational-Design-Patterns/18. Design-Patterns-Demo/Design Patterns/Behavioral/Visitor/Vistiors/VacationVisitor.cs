namespace Visitor.Vistiors
{
    using System;

    using Visitor.EmployeesFolder;

    /// <summary>
    /// A 'ConcreteVisitor' class
    /// </summary>
    internal class VacationVisitor : IVisitor
    {
        public void Visit(Element element)
        {
            var employee = element as Employee;

            if (employee == null)
            {
                return;
            }

            // Provide 3 extra vacation days
            employee.VacationDays += 3;
            Console.WriteLine("{0} {1}'s new vacation days: {2}", employee.GetType().Name, employee.Name, employee.VacationDays);
        }
    }
}