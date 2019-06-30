using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restorant
{
    class Fridge
    {
        private Product head;
        private Product tail;
        private int count;

        public Fridge()
        {
            head = tail = null;
            count = 0;
        }

        public int Count
        {
            get => count;
        }

        public void AddProduct(string ProductName)
        {
            Product newProduct = new Product(ProductName);
            if(Count == 0)
            {
                head = tail = newProduct;
            }
            else
            {
                tail.Next = newProduct;
                tail = newProduct;
            }
            count++;
        }

        public string[] CookMeal(int start, int end)
        {
            // създаваме си списък за резултата
            List<string> result = new List<string>();
            Product current = head;
            // пропускаме тези до start, като внимаваме да не излезем от списъка
            for (int i = 0; (i < start) && (current != null); i++)
                current = current.Next;
            // записваме тези до end, като внимаваме да не излезем от списъка
            for (int i = start; (i <= end) && (current != null); i++)
            {
                result.Add(current.Name);
                current = current.Next;
            }
            return result.ToArray<string>();
        }

        public string RemoveProductByIndex(int index)
        {
            // проверяваме всички проблемни случаи
            if (index < 0 || index >= Count)
                return null;
            if(index == 0)
            {
                Product removed = head;
                head = head.Next;
                removed.Next = null;
                count--;
                return removed.Name;
            }
            else
            {
                // намираме предишния на премахвания
                Product current = head;
                for (int i = 0; i < (index-1); i++)
                    current = current.Next;
                Product removed = current.Next;
                // пропускаме премахвания и сочим към следващия след него
                current.Next = removed.Next;
                // ако е бил последен, новият последен е и опашка
                if (removed.Next == null)
                    tail = current;
                removed.Next = null;
                count--;
                return removed.Name;
            }
        }

        public string RemoveProductByName(string name)
        {
            if (Count == 0)
                return null;
            // ако първият е с търсеното име
            if (head.Name == name)
            {
                Product removed = head;
                head = head.Next;
                removed.Next = null;
                count--;
                return removed.Name;
            }
            else
            {
                // намираме предишния на този с търсеното име
                Product current = head;
                while (current.Next != null && current.Next.Name != name)
                    current = current.Next;
                // ако сме стигнали до края, значи няма такъв продукт
                if (current.Next == null)
                    return null;
                // или следващият е продуктът, който ще премахваме
                Product removed = current.Next;
                // пропускаме премахвания и сочим към следващия след него
                current.Next = removed.Next;
                // ако е бил последен, новият последен е и опашка
                if (removed.Next == null)
                    tail = current;
                removed.Next = null;
                count--;
                return removed.Name;
            }
        }

        public bool CheckProductIsInStock(string name)
        {
            bool found = false;
            Product current = head;
            while(current != null)
            {
                if(name == current.Name)
                {
                    found = true;
                    break;
                }
                current = current.Next;
            }
            return found;
        }

        public string[] ProvideInformationAboutAllProducts()
        {
            string[] result = new string[Count];
            Product current = head;
            for (int i = 0; i < Count; i++)
            {
                result[i] = current.ToString();
                current = current.Next;
            }
            return result;
        }
    }
}
