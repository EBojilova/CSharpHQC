namespace Logger.Contracts
{
    using System;

    public interface ILayout
    {
        string Format(DateTime date, ReportLevel reportLevel, string message);
    }
}