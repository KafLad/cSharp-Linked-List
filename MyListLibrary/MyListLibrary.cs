using System.Collections.Generic;
using System.Collections;
using System;

namespace MyListLibrary
{

    public class MyList<T> : IEnumerable<T> where T: IComparable
    {

        private class Node<T> // Node class used within the linked list that allows for storage of data.
        {
            public T data;
            public Node<T> next;
            public Node()
            {
                data = default;
                next = null;
            }
            public Node(T data, Node<T> next)
            {
                this.data = data;
                this.next = next;
            }
            public override string ToString()
            {
                return $"[Node with {data} and points to {next}]";
            }
        } // End of Node class
        
        // Beginning of Linked List
        private Node<T> head;
        private Node<T> tail;
        private int count;
        public int Count => count;

        public MyList() // Default Constructor
        {
            head = null;
            tail = null;
            count = 0;
        }

        public MyList(T[] arr) // Constructor with pre-made array
        {
            foreach(T item in arr)
            {
                Add(item);
            }
        }


        /*
            ====================
            |       LIST       |
            |    FUNCTIONS     |
            ====================
        */
        public void Add(T item) 
        {
            // Function that adds an item to the end of the linked list
            if(head == null)
            {
            head = new Node<T>(item, null);
            tail = head;
            }
            else
            {
            Node<T> new_tail = new Node<T>(item, null);
            tail.next = new_tail;
            tail = new_tail;
            }
            count++;
        }

        public int IndexOf(T item, int startAt = 0)
        {
            // Function that finds where a particular item is located inside the linked list. If it does not exist, will return -1.
            int idx = startAt;
            Node<T> curr = WalkToIndex(idx);
            while(curr != null)
            {
                if(item.CompareTo(curr.data) == 0)
                {
                return idx;
                }
                curr = curr.next;
                idx++;
            }
            return -1;
        }

        private Node<T> WalkToIndex(int index)
        {
            Node<T> curr = head;
            if ( (index < 0) || (index > count))
            {
            throw new IndexOutOfRangeException($"Error: index {index} is out of range!");
            }
            for(int i = 0; i < index; i++)
            {
                curr = curr.next;
            }
            return curr;
        }

        public void Insert(T item, int index)
        {
            Node<T> prev = WalkToIndex(index-1);
            Node<T> node = new Node<T>(item, prev.next);
            prev.next = node;
            count++;
        }

        public void RemoveAt(int index)
        {
            Node<T> del = WalkToIndex(index);
            Node<T> delPrev = WalkToIndex(index - 1);
            delPrev.next = del.next;
            del = null;
            count--;
        }

        public bool Contains(T item)
        {
            Node<T> curr = head;
            while(curr != null)
            {
                if(item.CompareTo(curr.data) == 0)
                {
                    return true;
                }
                curr = curr.next;
            }
            return false;
        }
        
        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public T[] ToArray()
        {
            T[] arr = new T[count];
            Node<T> node = head;
            for (int i = 0; i < count; i++)
            {
                node = WalkToIndex(i);
                arr[i] = node.data;
            }
            return arr;
        }


        /*
            =====================
            |       SORTING     |
            |      METHODS      |
            =====================
        */
        private void Shuffle(int indexOne, int indexTwo)
        {
            T temp = this[indexOne];
            this[indexOne] = this[indexTwo];
            this[indexTwo] = temp;
        }

        public void SimpleSort()
        {
            for(int i = 0; i < count; i++)
            {
                int mindex = i;
                for(int j = i; j < count; j++)
                {
                    if(this[j].CompareTo(this[mindex]) < 0)
                    {
                        mindex = j;
                    }
                }
                Shuffle(i, mindex);
            }
        }



        public void FastSort()
        {
            Node<T> r = MergeSort(head);
            head = r;
        }

        private Node<T> MergeSort(Node<T> h)
        {
            if ((h == null) || (h.next == null)) { return h; }

            Node<T> mid = GetHalfwayPoint(h);
            Node<T> nextToMid = mid.next;
            mid.next = null;

            Node<T> LHS = MergeSort(h);
            Node<T> RHS = MergeSort(nextToMid);

            Node<T> sorted = MergeSorting(LHS, RHS);
            return sorted;
        }


        private Node<T> GetHalfwayPoint(Node<T> start)
        {
            Node<T> sw = start;
            Node<T> fw = head.next;

            while(fw != null)
            {
                fw = fw.next;
                if(fw != null)
                {
                    fw = fw.next;
                    sw = sw.next;
                }
            }
            return sw;
        }

        private Node<T> MergeSorting(Node<T> left, Node<T> right)
        {
            Node<T> r = null;
            if (left == null) { return right; }
            if (right == null) { return left; }

            if(left.data.CompareTo(right.data) <= 0)
            {
                r = left;
                r.next = MergeSorting(left.next, right);
            }
            /*
            else if (left.data.CompareTo(right.data) == 0)
            {
                r = left;
                Node<T> nxt = null;
                nxt = right;
                r.next = nxt;
                nxt.next = MergeSorting(left.next.next, right);
            }
            */
            else
            {
                r = right;
                r.next = MergeSorting(left, right.next);
            }
            return r;
        }

        /*
            =====================
            |    ENUMERATION    |
            |     METHODS       |
            =====================
        */
        public IEnumerator<T> GetEnumerator()
        {
            Node<T> curr = head;
            for(int i = 0; i < count; i++)
            {
                yield return curr.data;
                if(curr.next != null) { curr = curr.next; }
            }
        }


        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        public override string ToString()
        {
            string type = head.data.GetType().Name;
            string msg = $"MyList Object type '{type}' | Length: {count}";
            return msg;
        }
 
 
        public T this[int index]
        {
            get
            {
                Node<T> node = WalkToIndex(index);
                return node.data;
            }
            set
            {
                Node<T> node = WalkToIndex(index);
                node.data = value;
            }

        }

    }
}