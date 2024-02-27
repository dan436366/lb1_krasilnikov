using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lb1._4
{
    internal class Program
    {
        delegate double Calculation(double x);

        static void Main(string[] args)
        {
            Console.WriteLine("Вводьте рядки послiдовно один за одним.\r\n" +
                "Поки вони матимуть вигляд 0 x чи 1 x чи 2 x\r\n" +
                "(тобто, цифра в?д 0 до 2, а пiсля неї запис конкретного дiйсного числа)," +
                "\r\nпрограма обчислюватиме одну з трьох функц?й\r\n        " +
                "0 -- sqrt(abs(x))\r\n        " +
                "1 -- x^3 (?накше кажучи, x*x*x)\r\n        " +
                "2 -- x + 3,5\r\n(зг?дно цифри на початку) ? виводитиме результат.\r\n\r\n" +
                "Якщо вх?дний рядок не задовольнятиме цей формат, програма завершить роботу.");

            Calculation[] calculations = {
                x => Math.Sqrt(Math.Abs(x)),
                x => Math.Pow(x, 3),
                x => x + 3.5
            };

            while (true)
            {
                try
                {
                    Console.Write("Введiть рядок: ");
                    string input = Console.ReadLine();
                    string[] parts = input.Split(' ');

                    int functionIndex = int.Parse(parts[0]);
                    double x = double.Parse(parts[1]);

                    Calculation calculation = calculations[functionIndex];
                    double result = calculation(x);

                    Console.WriteLine($"Результат: {result}");
                }
                catch (Exception ex) when (ex is IndexOutOfRangeException || ex is FormatException)
                {
                    Console.WriteLine("Некоректний формат вхiдних даних.");
                    break;
                }
                catch (IndexOutOfRangeException)
                {
                    Console.WriteLine("Некоректний iндекс функцiї.");
                    break;
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка: {ex.Message}");
                    break;
                }
            }

            Console.WriteLine("Натиснiть будь-яку клавiшу для остаточного виходу");
        }
    }
}
