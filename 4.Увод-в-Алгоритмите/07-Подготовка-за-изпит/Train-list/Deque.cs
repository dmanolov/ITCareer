using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Train
{
    // реализация на дека като динамичен списък
    public class Deque<T> where T: Train
    {
        // един елемент от списъка
        private class Node
        {
            public object Element { get; set; }
            public Node Next { get; set; }
            public Node Prev { get; set; }
            public Node(object element, Node next, Node prev) 
            {
                this.Element = element;
                this.Prev = prev;
                this.Next = next;
            }
        }
        private Node head; // началото на списъка
        private Node tail; // краят на списъка 

        // колко товарни влака сме добавили
        public int BackCount { get; private set; }
        // колко пътнически влака сме добавили
        public int FrontCount { get; private set; }
        // общият брой влакове в гарата
        public int Count
        {
            get
            {
                return BackCount + FrontCount;
            }
        }
        
        public Deque()
        {
            head = tail = null;
            BackCount = 0;
            FrontCount = 0;
        }

        public void AddBack(T item)
        {
            Node newNode = new Node(item, null, tail);
            // ако досега няма елементи, този е първи и последен
            if (tail == null)
                head = tail = newNode;
            else
            {
                // добавяме го след последния и вече той е последен
                tail.Next = newNode;
                tail = newNode;
            }
            BackCount++;
        }

        public void AddFront(T item)
        {
            Node newNode = new Node(item, head, null);
            // ако досега няма елементи, този е първи и последен
            if (head == null)
                head = tail = newNode;
            else
            {
                // добавяме го преди първия и вече той е първи
                head.Prev = newNode;
                head = newNode;
            }
            FrontCount++;
        }

        public T GetFront()
        {
            if (FrontCount > 0)
                // (T) - преобразуваме към типа T
                return (T) head.Element;
            else return null;
        }

        public T GetBack()
        {
            if (BackCount > 0)
                return (T) tail.Element;
            else return null;
        }

        public T RemoveBack()
        {
            if (BackCount == 0)
                throw new System.ArgumentOutOfRangeException("No more items.");
            T item = GetBack();
            tail = tail.Prev;
            // може това да е бил последният елемент
            if (tail == null)
                head = null;
            else tail.Next = null;
            BackCount--;
            return item;
        }

        public T RemoveFront()
        {
            if (FrontCount == 0)
                throw new System.ArgumentOutOfRangeException("No more items.");
            T item = GetFront();
            head = head.Next;
            // може това да е бил последният елемент
            if (head == null)
                tail = null;
            else head.Prev = null;
            FrontCount--;
            return item;
        }
    }
}
