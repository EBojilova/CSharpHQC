namespace Interpreter
{
    using System;
    using System.Collections.Generic;

    using Interpreter.Expressions;

    internal class InterpreterMain
    {
        internal static void Main()
        {
            // Preobrazuva rimski cifri v desetichni
            // M- 1000, MM-2000
            // C-100, CC-200
            const string Input = "MCMXXVIII";

            var context = new Context(Input);

            // Build the 'parse tree'
            var tree = new List<Expression>
                           {
                               new ThousandExpression(),
                               new HundredExpression(),
                               new TenExpression(),
                               new OneExpression()
                           };

            // Interpret
            Console.WriteLine("Current context: Input={0} Output={1}", context.Input, context.Output);
            foreach (Expression expression in tree)
            {
                expression.Interpret(context);
                Console.WriteLine("Current context: Input={0} Output={1}", context.Input, context.Output);
            }

            Console.WriteLine();
            Console.WriteLine("Final: {0} = {1}", Input, context.Output);

            // Wait for user
            Console.ReadKey();
        }
    }
}
