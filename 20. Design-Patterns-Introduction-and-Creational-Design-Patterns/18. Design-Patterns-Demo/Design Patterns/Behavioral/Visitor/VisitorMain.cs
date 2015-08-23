namespace Visitor
{
    using Visitor.EmployeesFolder;
    using Visitor.Vistiors;

    internal class VisitorMain
    {
        internal static void Main()
        {
            // Greshno, tai kato ne e rabota na Main metoda da vdiga zaplatatata na employee
            // Zatova se pravi IncomeVisitor, koito ima pravomostiata da ia vdiga
            var employee = new Clerk();
            employee.Income += 1000;

            // Setup employee collection
            var employees = new Employees();
            employees.Attach(new Clerk());
            employees.Attach(new Director());
            employees.Attach(new President());

            // Employees are 'visited'
            employees.Accept(new IncomeVisitor());
            employees.Accept(new VacationVisitor());
        }
    }
}