namespace Exceptions_Homework
{
    using System;
    using System.Collections.Generic;

    using Exceptions_Homework.Exams;
    using Exceptions_Homework.Utils;

    internal class ExceptionsMain
    {
        private static void Main()
        {
            var substr = SubsequenceUtils.Subsequence("Hello!".ToCharArray(), 2, 3);
            Console.WriteLine(substr);

            var subarr = SubsequenceUtils.Subsequence(new[] { -1, 3, 2, 1 }, 0, 2);
            Console.WriteLine(string.Join(" ", subarr));

            var allarr = SubsequenceUtils.Subsequence(new[] { -1, 3, 2, 1 }, 0, 4);
            Console.WriteLine(string.Join(" ", allarr));

            var emptyarr = SubsequenceUtils.Subsequence(new[] { -1, 3, 2, 1 }, 0, 0);
            Console.WriteLine(string.Join(" ", emptyarr));

            Console.WriteLine(SubsequenceUtils.ExtractEnding("I love C#", 2));
            Console.WriteLine(SubsequenceUtils.ExtractEnding("Nakov", 4));
            Console.WriteLine(SubsequenceUtils.ExtractEnding("beer", 4));
            ////Console.WriteLine(SubsequenceUtils.ExtractEnding("Hi", 100));

            Console.WriteLine("23 is {0}.", NumberUtils.CheckPrime(23) ? "prime" : "not prime");
            Console.WriteLine("33 is {0}.", NumberUtils.CheckPrime(33) ? "prime" : "not prime");

            var peterExams = new List<Exam>
                                 {
                                     new SimpleMathExam(2), 
                                     new CSharpExam(55), 
                                     new CSharpExam(100), 
                                     new SimpleMathExam(1), 
                                     new CSharpExam(0)
                                 };
            var peter = new Student("Peter", "Petrov", peterExams);
            var peterAverageResult = peter.CalcAverageExamResultInPercents();
            Console.WriteLine("Average results = {0:p0}", peterAverageResult);
        }
    }
}