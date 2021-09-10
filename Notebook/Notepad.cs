using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Notebook
{
    /// <summary>
    /// Записная книжка
    /// </summary>
    public class Notepad
    {
        /// <summary>
        /// Массив записей
        /// </summary>
        Note[] notes = new Note[10];
        /// <summary>
        /// Индекс для понимания в какой элемент массива нужно присваивать данные
        /// </summary>
        int index = 0;
        /// <summary>
        /// Индексатор для доступа к записям книжки по интексу
        /// </summary>
        /// <param name="index">индекс</param>
        /// <returns></returns>
        public Note this[int index]
        {
            get { return this.notes[index]; }
            set { this.notes[index] = value; }
        }
        /// <summary>
        /// Создание записной книжки из файла
        /// </summary>
        /// <param name="path">путь к файлу</param>
        public Notepad(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                while (!sr.EndOfStream)
                {
                    string[] args = sr.ReadLine().Split('\t');
                    AddNote(new Note(args[0],args[1],Convert.ToBoolean(args[2]), Convert.ToDateTime(args[3]), Convert.ToDateTime(args[4])));
                }
            }
        }
        /// <summary>
        /// Метод добавления новой записи
        /// </summary>
        /// <param name="note"></param>
        public void AddNote(Note note)
        {
            // Увеличиваем размер массива в 2 раза, если index выходит за границы текущей длины массива
            CheckArraySize(notes.Length == index);
            this[index] = note;
            index++;
        }
        /// <summary>
        /// Увеличивает длину массива в 2 раза, если истина
        /// </summary>
        /// <param name="flag"></param>
        void CheckArraySize(bool flag)
        {
            if (flag)
            {
                Array.Resize(ref notes, notes.Length * 2 + 1);
            }
        }
        /// <summary>
        /// Сохранение данных в файл
        /// </summary>
        /// <param name="path"></param>
        public void Save(string path)
        {
            using(StreamWriter sr = File.CreateText(path))
            {
                for(int i = 0; i < index; i++)
                {
                    sr.WriteLine(this[i].ToString());
                }
                Console.WriteLine("Запись успешно выполнена.");
            }
        }
        public override string ToString()
        {
            string text = ($"{"Номер",4}{"Автор",10}{"Запись",20}{"Проверка",10}{"Срок",15}{"Дата создания",15}\n");
            for (int i = 0; i < index; i++)
            {
                text += i+1 + " " + this[i].ToString() + "\n";
            }
            return text;
        }
        /// <summary>
        /// Создает записную книжку со случайными записями
        /// </summary>
        /// <param name="count">Количество записей</param>
        public Notepad(int count)
        {
            for(int i = 0; i < count; i++)
            {
                AddNote(Note.GenerateRandomNete());
            }
        }
        /// <summary>
        /// Удаление записи
        /// </summary>
        /// <param name="idx">номер записи</param>
        public void Delete(int idx)
        {
            if (this[idx - 1] != null)
            {
                for (int i = idx; i < index; i++)
                {
                    this[i - 1] = this[i];
                }
                this[index] = null;
                this.index--;
            }
        }
        /// <summary>
        /// Метод обновления записи
        /// </summary>
        /// <param name="idx">номер записи</param>
        /// <param name="newNote">новая запись</param>
        public void Update(int idx, Note newNote)
        {
            if(this[idx-1] != null)
            {
                this[idx-1] = newNote;
            }
        }

        /// <summary>
        /// Сохранение данных в файл по интервалу дат
        /// </summary>
        /// <param name="path">путь к файлу</param>
        /// <param name="startDate">дата начала периода</param>
        /// <param name="finishDate">дата окончания периода</param>
        public void Save(string path,DateTime startDate,DateTime finishDate)
        {
            using (StreamWriter sr = File.CreateText(path))
            {
                for (int i = 0; i < index; i++)
                {
                    // Подходит ли по интервалу дат
                    if((this[i].dateAdded < finishDate)&&(this[i].dateAdded > startDate))
                    sr.WriteLine(this[i].ToString());
                }
                Console.WriteLine("Запись успешно выполнена.");
            }
        }
        /// <summary>
        /// Сортировка структуры по дате
        /// </summary>
        public void SortByDataAdded()
        {
            for(int i = 0; i < index; i++)
            {
                for(int j= i+1; j < index; j++)
                {
                    if(this[i].dateAdded > this[j].dateAdded)
                    {
                        var temp = this[i];
                        this[i] = this[j];
                        this[j] = temp;
                    }
                }
            }
        }
    }
}
