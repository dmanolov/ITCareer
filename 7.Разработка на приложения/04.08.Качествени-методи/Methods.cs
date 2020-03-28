using System;

namespace Methods
{
    class Methods
    {
        // изчислява лицето на триъгълника
        static double CalcTriangleArea(double a, double b, double c)
        {
            if (a <= 0 || b <= 0 || c <= 0)
            {
                throw new ArgumentException("Side should be positibe!");
            }
            double s = (a + b + c) / 2;
            bool valid = CheckValidTriangle(a, b, c);
            if (!valid)
            {
                throw new ArgumentException("This is not a valid triangle!");
            }
            double area = Math.Sqrt(s * (s - a) * (s - b) * (s - c));
            return area;
        }

        // проверява валидноста на триъгълника
        static bool CheckValidTriangle(double a, double b, double c)
        {
            if (a + b > c)
            {
                return true;
            }
            else if (a + c > b)
            {
                return true;
            }
            else if (b + c > a)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        // превръща число в неговата текстова форма
        static string NumberToDigit(int number)
        {
            string digit = string.Empty;

            switch (number)
            {
                case 0: digit = "zero"; break;
                case 1: digit = "one";  break;
                case 2: digit = "two";  break;
                case 3: digit = "three"; break;
                case 4: digit = "four"; break;
                case 5: digit = "five"; break;
                case 6: digit = "six"; break;
                case 7: digit = "seven"; break;
                case 8: digit = "eight"; break;
                case 9: digit = "nine"; break;
                default: throw new ArgumentException("Invalid number!");
            }

            return digit;
        }

        // намира максималното число от един масив
        static int FindMax(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentException("No elements!");
            }

            int maxNumber = int.MinValue;
            for (int i = 1; i < elements.Length; i++)
            {
                if (elements[i] > maxNumber)
                {
                    maxNumber = elements[i];
                }
            }
            return maxNumber;
        }

        // принтира число в специален формат
        static void PrintAsNumber(double number, string format)
        {
            if (format == "f")
            {
                Console.WriteLine("{0:f2}", number);
            }
            else if (format == "%")
            {
                Console.WriteLine("{0:p0}", number);
            }
            else if (format == "r")
            {
                Console.WriteLine("{0,8}", number);
            }
            else
            {
                throw new ArgumentException("Invalid format!");
            }
        }

        
        static double CalcDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1));
            return distance;
        }

        static bool IsVertical(double x1, double x2)
        {
            bool isVertical = x1 == x2;
            return isVertical;
        }

        static bool IsHorizontal(double y1, double y2)
        {
            bool isHorizontal = y1 == y2;
            return isHorizontal;
        }

        static void Main()
        {
            Console.WriteLine(CalcTriangleArea(3, 4, 5));
            
            Console.WriteLine(NumberToDigit(5));
            
            Console.WriteLine(FindMax(5, -1, 3, 2, 14, 2, 3));
            
            PrintAsNumber(1.3, "f");
            PrintAsNumber(0.75, "%");
            PrintAsNumber(2.30, "r");

            Console.WriteLine(CalcDistance(3, -1, 3, 2.5));
            Console.WriteLine("Horizontal? " + IsHorizontal(3, 3));
            Console.WriteLine("Vertical? " + IsVertical(-1, 2.5));

            Student peter = new Student("Peter", "Ivanov");
            peter.OtherInfo = "From Sofia, born at 17.03.1992";

            Student stella = new Student("Stella", "Markova");
            stella.OtherInfo = "From Vidin, gamer, high results, born at 03.11.1993";

            Console.WriteLine("{0} older than {1} -> {2}",
                peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}
