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
        static void Main(string[] args)
        {
            
            int a; // возраст
            int h; // рост
            int y; //год
            int m; // месяц
            int d; // день

            
            StringBuilder Info = new StringBuilder(1000);



           Console.Write("Просмотр - введите 1\nДобавление - введите 2\n");
           char operation = Console.ReadKey().KeyChar;

            if (operation != '1' && operation != '2')
            {
                Console.WriteLine("\nОшибка ввода, введите номер действия:");
                operation = Console.ReadKey().KeyChar;
            }

            if (operation == '2')
            {

                using (StreamWriter WI = new StreamWriter("WorkersInfo.csv", true, Encoding.Unicode))
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
                        while (int.TryParse(Console.ReadLine(), out a) == false || a < 14 || a > 120)
                        {
                            Console.WriteLine("Ошибка ввода, введите возраст:");
                        }
                        Info.Append($"{a}\t");



                        Console.WriteLine("\nВведите рост в см");
                        while (int.TryParse(Console.ReadLine(), out h) == false || h < 67 || h > 251)
                        {
                            Console.WriteLine("Ошибка ввода, введите рост в см:");
                        }
                        Info.Append($"{h}\t");


                        
                        Console.WriteLine("\nВведите дату рождения:\nВведите день:");
                        while (int.TryParse(Console.ReadLine(), out d) == false || d < 1 || d > 31)
                        {
                            Console.WriteLine("Ошибка ввода, введите день:");
                        }
                        Console.WriteLine("Введите месяц:");
                        while (int.TryParse(Console.ReadLine(), out m) == false || m < 1 || m > 12)
                        {
                            Console.WriteLine("Ошибка ввода, введите месяц:");
                        }
                        Console.WriteLine("Введите год:");
                        while (int.TryParse(Console.ReadLine(), out y) == false || y < 1900 || y > (DateTime.Now.Year - 14))
                        {
                            Console.WriteLine("Ошибка ввода, введите год:");
                        }
                        DateTime DOF = new DateTime(y, m, d);
                        Info.Append($"{DOF.ToShortDateString()}\t");



                        
                        Console.WriteLine("\nВведите место рождения:");
                        Info.Append($"{Console.ReadLine()}\t");


                        WI.WriteLine($"{Info}");



                        Console.WriteLine("\nПродожить н/д");
                        key = Console.ReadKey(true).KeyChar;



                    } while (char.ToLower(key) == 'д');

                }

            }

            if (operation == '1')
            {
                using (StreamReader WIR = new StreamReader("WorkersInfo.csv", Encoding.Unicode)) 
                {
                    string line;
                    Console.WriteLine($"\n\n{"ID",5}{"Время",25} {"Ф.И.О",35}{"Возраст",10}{"Рост",8}{"Дата рождения",18}{"Место рождения",18}");

                    int ID = 1;
                    while ((line = WIR.ReadLine()) != null) 
                    {
                        string[] data = line.Split('\t');
                        Console.WriteLine($"\n{ID++,5}{data[0],25} {data[1],35}{data[2],10}{data[3],8}{data[4],18}{data[5],18}");
                    }
                }
            }

            

           

            

        }


     
    }
}
