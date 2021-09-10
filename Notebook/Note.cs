using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    /// <summary>
    /// Запись записной книжки
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Автор записи
        /// </summary>
        string autor;
        /// <summary>
        /// Текст записи
        /// </summary>
        string text;
        /// <summary>
        /// Выполнена ли задача
        /// </summary>
        bool checkBox;
        /// <summary>
        /// Сроки реализации
        /// </summary>
        DateTime deadline;
        /// <summary>
        /// Дата добавления
        /// </summary>
        public DateTime dateAdded { get; }
        /// <summary>
        /// Новая запись
        /// </summary>
        /// <param name="autor">Автор записи</param>
        /// <param name="text">Тест заметки</param>
        /// <param name="prioroty">Приоритет</param>
        /// <param name="deadline">Сроки реализации</param>
        /// <param name="dateAdded">Дата добавления записи</param>
        public Note(string autor, string text, bool checkBox, DateTime deadline, DateTime dateAdded)
        {
            this.dateAdded = dateAdded;
            this.autor = autor;
            this.text = text;
            this.checkBox = checkBox;
            this.deadline = deadline;
        }
        public override string ToString()
        {
            return ($"{autor,10}\t" +
                $"{text,20}\t" +
                $"{checkBox,10}\t" +
                $"{deadline,15}\t" +
                $"{dateAdded,15}");
        }
        /// <summary>
        /// Возвращает случайную запись
        /// </summary>
        /// <returns>Случайная запись</returns>
        public static Note GenerateRandomNete()
        {
            Random r = new Random();
            string[] names = { "Маша", "Паша", "Денис", "Даша", "Катя" }; // 5 имен
            return new Note(names[r.Next(0, 5)],
                $"Запись {r.Next(0, 30)}",
                true,
                new DateTime(r.Next(0,2020),r.Next(1,12),r.Next(1,28)),
                new DateTime(r.Next(0, 2020), r.Next(1, 12), r.Next(1, 28)));
        }
    }
}
