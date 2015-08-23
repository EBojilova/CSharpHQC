namespace Softuni.Collections.Generic
{
    using System;
    using System.Collections.Generic;

    public class Stack<T>
    {
        private const int DefaultCapacity = 4;

        private List<T> items;

        public Stack(int capacity)
        {
            this.Capacity = capacity;
        }

        public Stack()
            : this(DefaultCapacity)
        {
        }

        public int Count
        {
            get
            {
                return this.items.Count;
            }
        }

        public int Capacity
        {
            get
            {
                return this.items.Capacity;
            }

            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentNullException("value", "Stack capacity should be positive");
                }

                this.items = new List<T>(value);
            }
        }

        public void Push(T item)
        {
            this.items.Add(item);
        }

        public T Pop()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot pop from empty stack.");
            }

            var lastIndex = this.items.Count - 1;
            var popedItem = this.Peak();
            this.items.RemoveAt(lastIndex);
            return popedItem;
        }

        public T Peak()
        {
            if (this.Count == 0)
            {
                throw new InvalidOperationException("Cannot peak from empty stack.");
            }

            var lastIndex = this.items.Count - 1;
            return this.items[lastIndex];
        }
    }
}