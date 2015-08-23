namespace DependencyInjectionVideo.Sorters
{
    using System;

    using DependencyInjectionVideo.Interfaces;

    public class CustomArraySorter<T> : IArraySorter<T>
    {
        public void Sort(T[] items)
        {
            Console.WriteLine("Custom Array Sorter");
        }
    }
}