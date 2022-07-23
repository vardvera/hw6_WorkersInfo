using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace hw6_WorkersInfo
{
    class Program
    {

        static int Check(int min, int max)
        {
            int arg;
            while (int.TryParse(Console.ReadLine(), out arg) == false || arg < min || arg > max)
            {
                Console.WriteLine("Ошибка ввода, введите еще раз:");
            }
            return arg;
        }

        static DateTime CheckDate(string dateEnter) 
        {
            int d;
            int m;
            int y;

            string[] date = dateEnter.Split('.');
            while ((int.TryParse(date [0], out d) == false || d < 1 || d > 31) || (int.TryParse(date[1], out m) == false || m < 1 || m > 12) || (int.TryParse(date[2], out y) == false || y < 1900 || y > DateTime.Now.Year - 14))
            {
                Console.WriteLine("Ошибка ввода, введите еще раз:");
                date  = Console.ReadLine().Split('.');
            }
            DateTime DOF = new DateTime(y, m, d);

            return DOF;
           
        }

        static char CheckOperation(char operation) 
        {
            while (operation != '1' && operation != '2')
            {
                Console.WriteLine("\nОшибка ввода, введите номер действия:");
                operation = Console.ReadKey().KeyChar;
            }
            return operation;
        }

        static void Add(StreamWriter sw)
        {
           
            StringBuilder Info = new StringBuilder(1000);

            using (sw)
            {

                char key;
                do
                {
                    Info.Clear();


                    DateTime timeOfAddition = DateTime.Now;
                    Info.Append($"{timeOfAddition}\t");

                    Console.WriteLine("\n\nВведите имя и фамилию:");
                    Info.Append($"{Console.ReadLine()}\t");


                    Console.WriteLine("\nВведите возраст");
                    Info.Append($"{Check(14,120)}\t");



                    Console.WriteLine("\nВведите рост в см");
                    Info.Append($"{Check(67,251)}\t");



                    Console.WriteLine("\nВведите дату рождения через точку:");
                    Info.Append($"{ CheckDate(Console.ReadLine()).ToShortDateString()}\t");


                    Console.WriteLine("\nВведите место рождения:");
                    Info.Append($"{Console.ReadLine()}\t");


                    sw.WriteLine($"{Info}");



                    Console.WriteLine("\nПродожить н/д");
                    key = Console.ReadKey(true).KeyChar;



                } while (char.ToLower(key) == 'д');

            }

        }

        static void Read(StreamReader sr)
        {
            using (sr)
            {
                string line;
                Console.WriteLine($"\n\n{"ID",5}{"Время",25} {"Ф.И.О",35}{"Возраст",10}{"Рост",8}{"Дата рождения",18}{"Место рождения",18}");

                int ID = 1;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] data = line.Split('\t');
                    Console.WriteLine($"\n{ID++,5}{data[0],25} {data[1],35}{data[2],10}{data[3],8}{data[4],18}{data[5],18}");
                }
            }
        }

        static void Main(string[] args)
        {
            
           Console.Write("Просмотр - введите 1\nДобавление - введите 2\n");
           char operation = CheckOperation(Console.ReadKey().KeyChar);
           
            if (operation == '2')
            {
                StreamWriter WI = new StreamWriter("WorkersInfo.csv", true, Encoding.Unicode);
                Add(WI); 
            }

            else
            {
                StreamReader WIR = new StreamReader("WorkersInfo.csv", Encoding.Unicode);
                Read(WIR);
            }

        }

    }
}
