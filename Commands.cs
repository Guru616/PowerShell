using System;
using System.Collections.Generic;
using System.Text;
using System.IO;//Класс для работы с файлами
using System.Diagnostics;//Класс для работы Process
namespace Gureev12
{
class Commands
    {
        public static void Helper()//Функция списка команд
        {
            List<string> helplist = new List<string>();//массив команд
            helplist.Add("Пример написания пути(слеш два раза): ИмяДиска:\\ИмяКаталога\\ИмяФайла.формат\n");


            helplist.Add("Info - Информация о программе");
            helplist.Add("help - Список команд");
            helplist.Add("clear - Очистка экрана");
            helplist.Add("exit - Выход из программы");
            helplist.Add("drive info - Информация о дисках");

            helplist.Add("readin dir - Просмотр каталогов и файлов в катаоге");
            helplist.Add("create dir - Создание нового каталога");
            helplist.Add("deleteall dir - Удаление каталога(вместе с файлами внутри)");
            helplist.Add("delete dir - Удаление каталога");

            helplist.Add("open file - Открывает файл любого типа");
            helplist.Add("read file - Читает текстовые файлы");
            helplist.Add("write file - Записывает в текстовые файлы");
            helplist.Add("create file - Создание нового файла");
            helplist.Add("delete file - Удаляет заданный файл ");
            helplist.Add("move file - Перемещает файл и разрешает переименовать");
            helplist.Add("info file - Выводит информацию о файле");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (string el in helplist)
            {
                Console.WriteLine(el);
            }
            Console.WriteLine();
        }
        public static void DiskInfo()//Функция информации о дисках
        {
            DriveInfo[] Disk = DriveInfo.GetDrives();
            byte DiskCounter = 0;//Счетчик дисков
            foreach (DriveInfo el in Disk)
            {
                Console.ForegroundColor = ConsoleColor.White;
                DiskCounter++;
                Console.WriteLine(el.Name);
                if (el.IsReady)
                {
                    Console.WriteLine("Размер диска: " + el.TotalSize / 1024 / 1024 / 1024 + "Гб");
                    Console.WriteLine("Свободное место: " + el.TotalFreeSpace / 1024 / 1024 / 1024 + "Гб");
                    Console.WriteLine("Тип диска: " + el.DriveType);
                }

            }
            Console.WriteLine("Всего дисков: {0}", DiskCounter);
            Console.WriteLine();
        }
        public static void Info()//Информация о программе
        {
            List<string> info = new List<string>();
            info.Add("Разработчик: Guru616");
            info.Add("Дата создания: 02.09.2017");
            info.Add("Контакты: kasperskiii66@mail.ru");

            Console.ForegroundColor = ConsoleColor.White;
            foreach (string el in info)
                Console.WriteLine(el);

        }

        public static void ReadDir()//Функция чтения содержимого каталога
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Укажите путь: ");
                string path = Console.ReadLine();
                DirectoryInfo a = new DirectoryInfo(path);
                DirectoryInfo[] allDirectjry = a.GetDirectories();

                FileInfo[] allFile = a.GetFiles();
                foreach (DirectoryInfo el in allDirectjry)//вывод каталогов
                {
                    Console.WriteLine(el.Name);
                }
                foreach (FileInfo el in allFile)//вывод файлов
                {
                    Console.WriteLine(el.Name);
                }
                Console.WriteLine();
            }
            catch { Console.WriteLine("Ошибка ввода!"); }
        }
        public static void CreatDir()//Функция создания каталога
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите путь и название каталога: ");
                string path = Console.ReadLine();
                Directory.CreateDirectory(path);
                Console.WriteLine();
            }
            catch { Console.WriteLine("Ошибка ввода!"); }
        }
        public static void DeleteDir()//Функция удаления каталога
        {
            Console.ForegroundColor = ConsoleColor.White;
            try
            {
                Console.Write("Введите путь и название каталога: ");
                string path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    Directory.Delete(path);
                    Console.WriteLine();
                }
                else Console.WriteLine("Ошибка! Каталог не найден");
            }
            catch { Console.WriteLine("В каталоге есть файлы! Воспользуйтесь deleteall dir"); }
        }
        public static void DeleteDirAll()//Функция удаления каталога сместе с содержимым
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите путь и название каталога: ");
                string path = Console.ReadLine();
                if (Directory.Exists(path))
                {
                    Directory.Delete(path, true);
                    Console.WriteLine();
                }
                else Console.WriteLine("Ошибка! Каталог не найден");
            }
            catch { Console.WriteLine("Ошибка ввода!"); }
        }

        public static void ReadFile()//Функция чтения информаций из файла
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите путь и название файла: ");
                string path = Console.ReadLine();
                if (File.Exists(path))//Проверка есть ли файл
                {
                    using (StreamReader read = new StreamReader(path))
                    {
                        string line;
                        while ((line = read.ReadLine()) != null)
                        {
                            Console.WriteLine(line);
                        }
                    }
                    Console.WriteLine();
                }
                else
                {
                    Console.WriteLine("Файл не найден!");
                    Console.WriteLine();
                }
            }
            catch { Console.WriteLine("Ошибка ввода!"); }
        }
        public static void WriteFile()//Функция записи в файл
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите путь и имя файла: ");
                string path = Console.ReadLine();
                Console.Write("Введите текст: ");
                string text = Console.ReadLine();
                using (StreamWriter writer = new StreamWriter(path, true))//Потоковый Писатель
                {
                    writer.Write(text);
                }
                Console.WriteLine();
            }
            catch { Console.WriteLine("Ошибка ввода!"); }
        }
        public static void CreateFile()//Функция создания файла
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите путь, название файла и формат: ");
                string path = Console.ReadLine();
                File.Create(path).Close();//Открытие потока, создание файла и закрытие
                Console.WriteLine();
            }
            catch { Console.WriteLine("Ошибка ввода!"); }
        }
        public static void DeleteFile()//Функция удаления файла
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите путь, название файла и формат: ");
                string path = Console.ReadLine();
                File.Delete(path);
                Console.WriteLine();
            }
            catch { Console.WriteLine("Файл не найден!"); }
        }
        public static void InfoFile()//Функция вывода информации о файле
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("Введите путь, название файла и формат: ");
                string path = Console.ReadLine();
                FileInfo file = new FileInfo(path);

                Console.WriteLine("Полное имя: " + file.FullName);
                Console.WriteLine("Размер файла: " + file.Length + "Байт");
                Console.WriteLine("Родительский каталог: " + file.DirectoryName);
                Console.WriteLine("Дата и время создания файла: " + File.GetCreationTime(path));
                Console.WriteLine("Дата последнего обращения: " + File.GetLastAccessTime(path));
            }
            catch { Console.WriteLine("Файл не найден!"); }

        }
        public static void MoveFile()//Функция перемещения файла
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Введите путь до файла: ");
                string sourseFileName = Console.ReadLine();
                Console.Write("Введите путь куда нужно переместить: ");
                string destFileName = Console.ReadLine();
                if (File.Exists(sourseFileName))
                    File.Move(sourseFileName, destFileName);
                else Console.WriteLine("Конечный файл уже существует или не удалось найти файл!");
            }
            catch { Console.WriteLine("Ошибка ввода!"); }
        }
        public static void OpenFile()//Функция открытия любого файла
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Введите путь и имя файла: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
                Process.Start(path);
            else Console.WriteLine("Ошибка ввода!");
        }
    }
}
