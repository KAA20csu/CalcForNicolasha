using System;
using System.Collections.Generic;

namespace InformaticTechnologies
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1.Перевод чисел между системами счисления.");
            sistschisl();

            Console.WriteLine("2.Перевод целых чисел в РСС.");
            RimsSS();

            Console.WriteLine("3.Перевод вещественных чисел.");
            rilnum();

        }

        static void sistschisl()
        {

            Console.WriteLine("Число"); 
            string num = Console.ReadLine();

            Console.WriteLine("Разряд числа\nОт 0 до 50"); 
            int razFirst;
            do 
            {
                razFirst = Convert.ToInt32(Console.ReadLine());

                if (razFirst > 50 || razFirst < 0)
                    Console.WriteLine("Вы ввели некорректный разряд.\nПопробуйте ещё раз.");
                else if(proverkainf(num, razFirst))
                    Console.WriteLine("Разряд не подходит");

            } while (razFirst > 50 || razFirst < 0 || proverkainf(num, razFirst));

            Console.WriteLine("Новый разряд\nОт 0 до 50"); 
            int razSecond;
            do
            {
                razSecond = Convert.ToInt32(Console.ReadLine());

                if (razSecond > 50 || razSecond < 0)
                    Console.WriteLine("Вы ввели некорректный разряд.\nПопробуйте ещё раз.");

            } while (razSecond > 50 || razSecond < 0);

            num = Convert.ToString(deseses(num, razSecond));

            num = Transformation(Convert.ToInt32(num), razSecond);

            Console.WriteLine($"Ответ: {num}");

        }

        static bool proverkainf(string num, int Razn)
        {
            for (int i = num.Length - 1; i >= 0; i--)
            {
                if (num[i] > 65 + Razn - 10)
                    return true;
            }

            return false;
        }

        static double deseses(string num, int razFirst)
        {
            Console.WriteLine("Перевод в 10-ричную систему счисления");

            char[] ch = new char[num.Length];

            for (int i = 0; i < num.Length; i++)
                ch[i] = num[i];
            
            int a = 0;
            double Summa = 0;

            for (int i = num.Length - 1; i >= 0; i--)
            {

                if (ch[i] < 58 && ch[i] > 47)
                    ch[i] -= (char)48;

                if (ch[i] < 91 && ch[i] > 64)
                    ch[i] -= (char)55;

                Console.WriteLine($"{Summa} + {Convert.ToInt32(ch[i])} * {razFirst}^{a} = {ch[i] * Math.Pow(razFirst, a)} ");

                Summa += ch[i] * Math.Pow(razFirst, a);
                a += 1;
            }
            Console.WriteLine($"{num} в 10-ричной системе : {Summa}\n");
            return Summa;

        }

        static string Transformation(int num, int razSecond) 
        {
            Console.WriteLine($"Осуществлённый перевод {razSecond} систему счисления");

            int a = 1;

            for (int i = num; i > razSecond; i /= razSecond)
                a++;
            
            char[] numSec = new char[a];

            string st = "";

            for (int i = 0; num > razSecond; i++)
            {
                int x = num % razSecond;

                if (x >= 10)
                    x += 55;

                if (x <= 9)
                    x += 48;

                numSec[i] = (char)x;

                Console.WriteLine($"{num} / {razSecond} =  {num / razSecond} | остаток {num % razSecond}");
                num /= razSecond;
                st += Convert.ToString(numSec[i]);
            }
            st += num;
            Console.WriteLine($"{num} / {razSecond} = {0} | остаток {num}");

            Console.WriteLine($"Получаем {st} и переворачиваем её");

            return raaevs(st);
        }

        static string raaevs(string NumberTwo) 
        {
            string result = "";
            for (int i = NumberTwo.Length - 1; i >= 0; i--)
            {
                result += NumberTwo[i];
            }
            return result;
        }

        static void RimsSS()
        {

            int[] rims = { 5000, 4000, 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
            List<string> arabnums = new List<string>() { "(!V)", "(!IV)", "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

            Console.WriteLine("Введите число от 0 до 5999");
            int Input;
            do
            {
                Input = Convert.ToInt32(Console.ReadLine());

                if(Input < 0 || Input > 5999)
                    Console.WriteLine("Вы ввели некорректное число\nПопробуйте ещё раз!");

            } while (Input < 0 || Input > 5999);

            int i = 0; string Output = "";

            while (Input > 0)
            {
                if (rims[i] <= Input)
                {
                    Console.WriteLine($"\n{Input} - {rims[i]} = {Input - rims[i]}");
                    Console.WriteLine($"{Output} + {arabnums[i]} = {Output + arabnums[i]}\n");

                    Input = Input - rims[i];
                    Output = Output + arabnums[i];
                }
                else i++;
            }

            Console.WriteLine($"{Input} в РСС = {Output}");
        }

        static void rilnum()
        {
            Console.WriteLine("Введите дробное число");
            string Input = Console.ReadLine();
            string[] namber = Input.Split( ',');

            char ch = ' ';
            if (Input[0] == '-')
                ch = Input[0];
            else
                ch = '+';

            string ChisloOne = namber[0]; string ChisloTwo = namber[1];

            ChisloTwo = searchiingtosus(ChisloOne, Input, ChisloOne.Length);
            ChisloOne = SearchTwoSys(ChisloOne);
            Console.WriteLine($"Получаем {ChisloOne}");

            Console.WriteLine($"\nСоединяем части дроби получаем {ChisloOne + ChisloTwo}");

            string newOneNum = "";
            if (ch == '+' && ChisloOne[0] == '1')
            {
                newOneNum += 0;
                for (int i = 1; i < ChisloOne.Length; i++)
                    newOneNum += ChisloOne[i];
            }
            else
                newOneNum = ChisloOne;

            Console.WriteLine("Если дробь была отрицательной, то первый символ меняем на еденицу");
            Console.WriteLine($"После изменений если они были: {newOneNum},{ChisloTwo}");

            Console.WriteLine($"Передвигаем запятую к 1 сиволу и считаем на сколько сиволов мы перенесли 1\nПеренсли запятую на {newOneNum.Length - 1} символов"); ;
            
            Console.WriteLine($"Находим смещённый порядок (чтоб найти порядок надо 127 ){127 + newOneNum.Length - 1} и переводим в двоичную систему");
            int ordo = 127 + newOneNum.Length - 1;
            string stOrdo = Convert.ToString(ordo);
            stOrdo = SearchTwoSys(stOrdo);

            string jons = newOneNum + ChisloTwo;

            string output = "";
            output += jons[0];

            output += stOrdo;

            for (int i = 1; i < 30 - stOrdo.Length; i++)
                output += jons[i];
            
            Console.WriteLine($"Ответ сокращаем до 31 символа : {output}");

        }

        static string SearchTwoSys(string oneNum) //перевод в 2
        {
            Console.WriteLine($"Переводим {oneNum} в двоичную систему");

            int num = Convert.ToInt32(oneNum);
            string output = "";

            if (num != 0)
            {
                while (num != 1)
                {
                    Console.WriteLine($"{num} / 2 =  {num / 2} | остаток {num % 2}");
                    output += $"{num % 2}";
                    num /= 2;
                }
                Console.WriteLine("Добавляем 1 и переворачиваем");
                output += "1";
                return raaevs(output);
            }
            return "0";
        }

        static string searchiingtosus(string oneNum, string twoNum, int lengthOneNum)
        {
            double num = Convert.ToDouble(twoNum) - Convert.ToDouble(oneNum);

            Console.WriteLine($"Осуществляем перевод {Math.Round(num, 2)} в двоичную систему");

            string output = "";

            for (int i = 0; i < 31 - lengthOneNum; i++)
            {
                Console.Write($"{Math.Round(num, 2)} * 2 = {Math.Round(num * 2, 2)}");
                num *= 2;

                if (num >= 1)
                {
                    output += 1;
                    num -= 1;
                }
                else
                    output += 0;

                Console.WriteLine($"");
            }
            Console.WriteLine($"\nДробная часть в двоичном представлении: {output} \n");
            return output;

        }
    }
}

