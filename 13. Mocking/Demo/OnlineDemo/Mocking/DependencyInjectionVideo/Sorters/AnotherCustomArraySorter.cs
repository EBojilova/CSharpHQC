namespace DependencyInjectionVideo.Sorters
{
    using System;

    using DependencyInjectionVideo.Interfaces;

    internal class AnotherCustomArraySorter<T> : IArraySorter<T>
    {
        public void Sort(T[] items)
        {
            Console.WriteLine("Another Custom Array Sorter");
        }
    }
}