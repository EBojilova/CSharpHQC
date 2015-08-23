namespace DependencyInjectionVideo
{
    using DependencyInjectionVideo.Interfaces;

    public class StudentsSorter
    {
        ////private readonly CustomArraySorter<Student> studentSorter;
        private readonly IArraySorter<Student> studentSorter;

        ////public StudentsSorter()
        ////{
        ////    this.studentSorter = new CustomArraySorter<Student>();
        ////}
        public StudentsSorter(IArraySorter<Student> studentSorter)
        {
            this.studentSorter = studentSorter;
        }

        public Student[] Students { get; set; }

        public void OrderStudentsByFirstName()
        {
            this.studentSorter.Sort(this.Students);
        }
    }
}