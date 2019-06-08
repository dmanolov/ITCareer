using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03._02._00.Обединение_на_множества
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = new List<int> { 1, 2, 3, 4, 5 };
            List<int> secondList = new List<int> { 2, 4, 6 };

            // отпечатваме двата списъка
            Console.Write("firstList: ");
            PrintList(firstList);
            Console.Write("secondList: ");
            PrintList(secondList);

            // първи начин - добавяме първия и тези от втория, които ги няма в първия
            Console.Write("union1: ");
            PrintList(Union1(firstList, secondList));
            // втори нчаин - добавяме първия, изтиваме общите от втория и го добавяме
            Console.Write("union2: ");
            PrintList(Union2(firstList, secondList));
            // трети начин - на Ники - добавяме двата и махаме повтарящите се
            List<int> union3 = new List<int>();
            union3.AddRange(firstList);
            union3.AddRange(secondList);
            union3 = union3.Distinct().ToList();
            Console.Write("union3: ");
            PrintList(union3);

            // първи начин - добавяме само тези от първия, които ги има и във втория
            Console.Write("intersect1: ");
            PrintList(Intersect1(firstList, secondList));
            // втори нчаин - добавяме първия и изтриваме липсващите във втория
            Console.Write("intersect2: ");
            PrintList(Intersect2(firstList, secondList));
            // трети начин - на Ники - като първия, но с Ламбда
            List<int> intersect3 = new List<int>();
            intersect3 = firstList.Where(n => secondList.Contains(n)).ToList();
            Console.Write("Intersect3: ");
            PrintList(intersect3);

            // сечение и обединение на три списъка
            List<int> thirdList = new List<int> { 2, 8 };
            Console.Write("thirdList: ");
            PrintList(thirdList);
            Console.Write("union of 3 sets: ");
            PrintList(Union1(Union1(firstList, secondList), thirdList));
            Console.Write("intersect of 3 sets: ");
            PrintList(Intersect1(Intersect1(firstList, secondList), thirdList));
        }

        public static List<int> Union1(List<int> firstList, List<int> secondList)
        {
            // създаваме си списък с обединението
            List<int> union = new List<int>();
            // добавяме целия първи списък
            union.AddRange(firstList);
            // обхождаме втория и което го няма в обединението го добавяме
            foreach (var item in secondList)
            {
                if(!union.Contains(item))
                {
                    union.Add(item);
                }
            }
            // връщаме обединението
            return union;
        }

        public static List<int> Union2(List<int> firstList, List<int> secondList)
        {
            // създаваме си списък с обединението
            List<int> union = new List<int>();
            // добавяме целия първи списък в него
            union.AddRange(firstList);
            // обхождаме втория и ако съдържа елемент от множеството го махаме
            foreach (var item in secondList)
            {
                if (union.Contains(item))
                    union.Remove(item);
            }
            // записваме целия втори списък (каквото е останало от него)
            union.AddRange(secondList);
            // връщаме обединението
            return union;
        }

        public static List<int> Intersect1(List<int> firstList, List<int> secondList)
        {
            // създаваме си списък за сечението
            List<int> intersect = new List<int>();
            // обхождаме първия и ако се съдържа във втория, го записваме в сечението
            foreach (var item in firstList)
            {
                if (secondList.Contains(item))
                {
                    intersect.Add(item);
                }
            }
            // връщаме сечението
            return intersect;
        }

        public static List<int> Intersect2(List<int> firstList, List<int> secondList)
        {
            // създаваме си списък за сечението
            List<int> intersect = new List<int>();
            // добавяме целия първи списък в него
            intersect.AddRange(firstList);
            // обхождаме сечението и изтриваме тези, които не са в втория
            for (int i = intersect.Count-1; i>=0; i--)
            {
                if (!secondList.Contains(intersect[i]))
                    intersect.RemoveAt(i);
            }
            // връщаме сечението
            return intersect;
        }

        public static void PrintList(List<int> list)
        {
            Console.Write("{");
            foreach (var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine("}");
        }
    }
}
