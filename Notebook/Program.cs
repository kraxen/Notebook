using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание нового репозитория со случаными записями
            Notepad n1 = new Notepad(30);
            // Проверка, вывод на экран
            Console.WriteLine(n1.ToString());

            Console.ReadKey();
            // Сохранение в файл
            n1.Save("test_db.csv");

            Console.ReadKey();
            Console.Clear();
            // Создание базы на основе данных из файла
            n1 = new Notepad("test_db.csv");
            // Вывод новой базы на экран
            Console.WriteLine(n1.ToString());
            Console.ReadKey();

            // Изменение записи
            n1.Update(10, Note.GenerateRandomNete());
            Console.WriteLine(n1.ToString());
            Console.ReadKey();

            for(int i = 0; i < 40; i++)
            {
                n1.AddNote(Note.GenerateRandomNete());
            }

            //Удаление записи
            n1.Delete(15);
            Console.Clear();
            n1.SortByDataAdded();
            Console.WriteLine("Данные после сортировки");

            // Вывод новой базы на экран
            Console.WriteLine(n1.ToString());
            Console.ReadKey();

            
            Console.Clear();

            n1.Save("test_db.csv", new DateTime(1000, 01, 01), new DateTime(2000,01,01));
            Console.ReadKey();
            // Создание базы на основе данных из файла
            n1 = new Notepad("test_db.csv");
            // Вывод новой базы на экран
            Console.WriteLine(n1.ToString());
            Console.ReadKey();
        }
    }
}
