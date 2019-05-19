using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02._2.Списък._02
{
    public class DynamicList
    {
        private class Node
        {
            private object element;
            private Node next;

            public object Element
            {
                get { return element; }
                set { element = value; }
            }

            public Node Next
            {
                get { return next; }
                set { next = value; }
            }

            public Node(object element, Node prevNode)
            {
                this.Element = element;
                prevNode.Next = this;
                this.Next = null;
            }

            public Node(object element)
            {
                this.Element = element;
                this.Next = null;
            }
        }

        private Node head;
        private Node tail;
        private int count;

        public DynamicList()
        {
            this.head = null;
            this.tail = null;
            this.count = 0;
        }

        public void Add(object item)
        {
            Node newNode;
            if (head == null)
            {
                newNode = new Node(item);
                this.head = newNode;
            }
            else
            {
                newNode = new Node(item, tail);
            }
            this.tail = newNode;
            count++;
        }

        private Node NodeAt(int index)
        {
            // проверка дали индекса е валиден
            if (index >= Count || index < 0)
                throw new ArgumentOutOfRangeException();
            // обхождаме до дадения елемент и връщаме стойността
            int i = 0;
            Node current = head;
            while (current != null)
            {
                if (i == index) break;
                current = current.Next;
                i++;
            }
            return current;
        }

        public object Remove(int index)
        {
            // проверка дали индекса е валиден
            if(index>=Count || index<0)
                throw new ArgumentOutOfRangeException();
            // ако ще махаме махаме първия
            Node current;
            object result;
            if (index==0)
            {
                result = head.Element;
                head = head.Next;
                current = head;
            }
            else
            {
                // намираме елемента, на съответния индекс
                current = NodeAt(index - 1);
                result = current.Next.Element;
                current.Next = current.Next.Next;
            }
            // намаляме Count и изтриваме елемента
            count--;
            // намираме новият последен елемент за tail
            if (current == null)
            {
                tail = null;
            }
            else if (current.Next == null)
            {
                tail = current;
            }
            // връщаме стойността на изтрития елемент
            return result;
        }

        public int Remove(object item)
        {
            int index = IndexOf(item);
            if (index >= 0)
                Remove(index);
            return index;
        }

        public int IndexOf(object item)
        {
            int i = 0;
            Node current = head;
            while (current != null)
            {
                if (current.Element.Equals(item))
                    return i;
                current = current.Next;
                i++;
            }
            return -1;
        }

        public bool Contains(object item)
        {
            if (IndexOf(item) < 0)
                return false;
            return true;
        }

        public object this[int index]
        {
            get
            {
                return NodeAt(index).Element;
            }
            set
            {
                NodeAt(index).Element = value;  
            }
        }

        public int Count
        {
            get
            {
                return count;
            }
        }

    }
}
