namespace DependencyInjectionVideo
{
    using DependencyInjectionVideo.Interfaces;
    using DependencyInjectionVideo.Sorters;

    internal static class DependencyContainer
    {
        internal static StudentsSorter GetStudentsSorter()
        {
            //// Here we can apply CustomArraySorter or AnotherCustomArraySorter;
            ////IArraySorter<Student> sorter = new CustomArraySorter<Student>();
            IArraySorter<Student> sorter = new AnotherCustomArraySorter<Student>();
            return new StudentsSorter(sorter);
        }
    }
}