using System;
using System.Collections.Generic;
using System.Linq;

using Exceptions_Homework;
using Exceptions_Homework.Exams;

public class Student
{
    private IList<Exam> exams;

    private string firstName;

    private string lastName;

    public Student(string firstName, string lastName, IList<Exam> exams)
    {
        this.FirstName = firstName;
        this.LastName = lastName;
        this.Exams = exams;
    }

    public Student(string firstName, string lastName)
        : this(firstName, lastName, new List<Exam>())
    {
    }

    public string FirstName
    {
        get
        {
            return this.firstName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("firstName", "First name cannot be null or empty.");
            }

            this.firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return this.lastName;
        }

        set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentNullException("lastName", "Last name cannot be null or empty.");
            }

            this.lastName = value;
        }
    }

    public IList<Exam> Exams
    {
        get
        {
            return this.exams;
        }

        private set
        {
            if (value == null)
            {
                throw new ArgumentNullException("exams", "The exams cannot be null.");
            }

            this.exams = value;
        }
    }

    public double CalcAverageExamResultInPercents()
    {
        if (this.Exams.Count == 0)
        {
            throw new InvalidOperationException("Cannot calculate average on missing exams");
        }

        double[] examScores = new double[this.Exams.Count];

        IList<ExamResult> examResults = this.CheckExams();
        for (int i = 0; i < examResults.Count; i++)
        {
            int gradeRange = examResults[i].MaxGrade - examResults[i].MinGrade;
            double normalizedGrade = examResults[i].Grade - examResults[i].MinGrade;

            examScores[i] = normalizedGrade / gradeRange;
        }

        return examScores.Average();
    }

    private IList<ExamResult> CheckExams()
    {
        return this.Exams.Select(t => t.Check()).ToList();
    }
}