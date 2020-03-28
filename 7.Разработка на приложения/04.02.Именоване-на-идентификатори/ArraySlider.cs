using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApplication3
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            BigInteger[] numbers = Regex.Split(input, "\\s+").Where(n=> n!="").Select(n => BigInteger.Parse(n)).ToArray();
            var commandLine = Console.ReadLine();
            long baseNumberIndex = 0;
            while (commandLine != "stop")
            {
                // ��������� ������� �� ���������
                var commandParts = commandLine.Split(' ');
                var operationIndexOffset = long.Parse(commandParts[0]);
                var operation = commandParts[1];
                var operand = long.Parse(commandParts[2]);

                // ��� ������� � ���� ����, ������� �� � �������� �� ������
                operationIndexOffset = operationIndexOffset % numbers.Length;
                // ������� �� ���������� �����, � ����� �� �������
                baseNumberIndex += operationIndexOffset;
                var operationNumberIndex = baseNumberIndex % numbers.Length;
                if (operationNumberIndex < 0)
                {
                    operationNumberIndex += numbers.Length;
                }
                if (operationNumberIndex >= numbers.Length)
                {
                    operationNumberIndex -= numbers.Length;
                }
                // ����������� ����������� ��������
                switch (operation)
                {
                    case "+":
                        if ((numbers[operationNumberIndex] + operand) < 0)
                        {
                            numbers[operationNumberIndex] = 0;
                        }
                        else numbers[operationNumberIndex] = numbers[operationNumberIndex] + operand;
                        break;
                    case "-":
                        if (numbers[operationNumberIndex] < operand)
                        {
                            numbers[operationNumberIndex] = 0;
                        }
                        else numbers[operationNumberIndex] = numbers[operationNumberIndex] - operand;
                        break;
                    case "*":
                         if ((numbers[operationNumberIndex] * operand) < 0)
                        {
                            numbers[operationNumberIndex] = 0;
                        }
                        else numbers[operationNumberIndex] = numbers[operationNumberIndex] * operand;
                        break;
                    case "/": 
                        if ((numbers[operationNumberIndex] / operand) < 0)
                        {
                            numbers[operationNumberIndex] = 0;
                        }
                        else numbers[operationNumberIndex] = numbers[operationNumberIndex] / operand;
                        break;
                    case "&":
                         if ((numbers[operationNumberIndex] & operand) < 0)
                        {
                            numbers[operationNumberIndex] = 0;
                        }
                        else numbers[operationNumberIndex] = numbers[operationNumberIndex] & operand;
                        break;
                    case "|":
                        if ((numbers[operationNumberIndex] | operand) < 0)
                        {
                            numbers[operationNumberIndex] = 0;
                        }
                        else numbers[operationNumberIndex] = numbers[operationNumberIndex] | operand;
                        break;
                    case "^": 
                        if ((numbers[operationNumberIndex] ^ operand) < 0)
                        {
                            numbers[operationNumberIndex] = 0;
                        }
                        else numbers[operationNumberIndex] = numbers[operationNumberIndex] ^ operand;
                        break;
                }
                // ����� ���������� �������
                commandLine = Console.ReadLine();
            }
            // ��� ��� ��� ��� ����������� �����, �������� ��
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < 0)
                {
                    numbers[i] = 0;
                }
            }
            // ��������� ���������
            Console.WriteLine("[" + string.Join(", ", numbers) + "]");
        }
    }
}