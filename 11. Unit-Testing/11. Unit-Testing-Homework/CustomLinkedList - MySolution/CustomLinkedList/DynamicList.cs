namespace CustomLinkedList
{
    using System;

    /// <summary>Dynamic (linked) list class definition</summary>
    public class DynamicList<T>
    {
        private ListNode head;

        private ListNode tail;

        public DynamicList()
        {
            this.head = null;
            this.tail = null;
            this.Count = 0;
        }

        public int Count { get; private set; }

        /// <summary>
        /// Gets or sets the element at the specified position
        /// </summary>
        /// <param name="index">
        /// The position of the element [0 … count-1]
        /// </param>
        /// <returns>The item at the specified index</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// When an invalid index is specified
        /// </exception>
        public T this[int index]
        {
            get
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

                var currentNode = this.head;
                for (var i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                return currentNode.Element;
            }

            set
            {
                if (index >= this.Count || index < 0)
                {
                    throw new ArgumentOutOfRangeException("Invalid index: " + index);
                }

                var currentNode = this.head;
                for (var i = 0; i < index; i++)
                {
                    currentNode = currentNode.NextNode;
                }

                currentNode.Element = value;
            }
        }

        /// <summary>Add element at the end of the list</summary>
        /// <param name="item">The element to be added</param>
        public void Add(T item)
        {
            if (this.head == null)
            {
                // We have an empty list -> create a new head and tail
                this.head = new ListNode(item);
                this.tail = this.head;
            }
            else
            {
                // We have a non-empty list -> append the item after tail
                var newNode = new ListNode(item, this.tail);
                this.tail = newNode;
            }

            this.Count++;
        }

        /// <summary>Removes and returns element on the specified index
        /// </summary>
        /// <param name="index">The index of the element to be removed
        /// </param>
        /// <returns>The removed element</returns>
        /// <exception cref="System.ArgumentOutOfRangeException">
        /// if the index is invalid</exception>
        public T RemoveAt(int index)
        {
            if (index >= this.Count || index < 0)
            {
                throw new ArgumentOutOfRangeException("Invalid index: " + index);
            }

            // Find the element at the specified index
            var currentIndex = 0;
            var currentNode = this.head;
            ListNode prevNode = null;
            while (currentIndex < index)
            {
                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            // Remove the found element from the list of nodes
            this.RemoveListNode(currentNode, prevNode);

            // Return the removed element
            return currentNode.Element;
        }

        /// <summary>
        /// Removes the specified item and return its index.
        /// </summary>
        /// <param name="item">The item for removal</param>
        /// <returns>The index of the element or -1 if it does not exist</returns>
        public int Remove(T item)
        {
            // Find the element containing the searched item
            var currentIndex = 0;
            var currentNode = this.head;
            ListNode prevNode = null;
            while (currentNode != null)
            {
                if (Equals(currentNode.Element, item))
                {
                    break;
                }

                prevNode = currentNode;
                currentNode = currentNode.NextNode;
                currentIndex++;
            }

            if (currentNode != null)
            {
                // The element is found in the list -> remove it
                this.RemoveListNode(currentNode, prevNode);
                return currentIndex;
            }

            // The element is not found in the list -> return -1
            return -1;
        }

        /// <summary>Searches for given element in the list</summary>
        /// <param name="item">The item to be searched</param>
        /// <returns>
        /// The index of the first occurrence of the element
        /// in the list or -1 when it is not found
        /// </returns>
        public int IndexOf(T item)
        {
            var index = 0;
            var currentNode = this.head;
            while (currentNode != null)
            {
                if (Equals(currentNode.Element, item))
                {
                    return index;
                }

                currentNode = currentNode.NextNode;
                index++;
            }

            return -1;
        }

        /// <summary>
        /// Checks if the specified element exists in the list
        /// </summary>
        /// <param name="item">The item to be checked</param>
        /// <returns>
        /// True if the element exists or false otherwise
        /// </returns>
        public bool Contains(T item)
        {
            var index = this.IndexOf(item);
            var found = index != -1;
            return found;
        }

        /// <summary>
        /// Remove the specified currentNode from the list of nodes
        /// </summary>
        /// <param name="currentNode">the currentNode for removal</param>
        /// <param name="prevNode">the predecessor of currentNode</param>
        private void RemoveListNode(ListNode currentNode, ListNode prevNode)
        {
            this.Count--;
            if (this.Count == 0)
            {
                // The list becomes empty -> remove head and tail
                this.head = null;
                this.tail = null;
            }
            else if (prevNode == null)
            {
                // The head currentNode was removed --> update the head, so we skip currentNode element T
                this.head = currentNode.NextNode;
            }
            else
            {
                // Redirect the pointers to skip the removed currentNode element T
                prevNode.NextNode = currentNode.NextNode;
            }

            // Fix the tail in case it was removed
            if (ReferenceEquals(this.tail, currentNode))
            {
                this.tail = prevNode;
            }
        }

        private class ListNode
        {
            public ListNode(T element)
            {
                this.Element = element;
                this.NextNode = null;
            }

            public ListNode(T element, ListNode prevNode)
            {
                this.Element = element;
                prevNode.NextNode = this;
            }

            public T Element { get; set; }

            public ListNode NextNode { get; set; }
        }
    }
}