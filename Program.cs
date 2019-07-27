using System;
using System.Collections.Generic;
using System.Text;
using System.IO;//Класс для работы с файлами
namespace Gureev12
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.Write("Command: ");
            string Command = Console.ReadLine();//Ввод команды
            //проверка на ошибку команды
            if (Command.Equals("open file") || Command.Equals("delete file") || Command.Equals("info") || Command.Equals("deleteall dir") || Command.Equals("") || Command.Equals("help") || Command.Equals("clear") || Command.Equals("exit") || Command.Equals("drive info") || Command.Equals("readin dir") || Command.Equals("create dir") || Command.Equals("delete dir") || Command.Equals("read file") || Command.Equals("write file") || Command.Equals("create file") || Command.Equals("move file") || Command.Equals("info file"))
            {//Меню switch
                switch (Command)
                {
                    // инфо-действия
                    case "info": Commands.Info(); Main(); break;
                    case "help": Commands.Helper(); Main(); break;
                    case "drive info": Commands.DiskInfo(); Main(); break;
                    //действия с каталогами
                    case "readin dir": Commands.ReadDir(); Main(); break;
                    case "create dir": Commands.CreatDir(); Main(); break;
                    case "delete dir": Commands.DeleteDir(); Main(); break;
                    case "deleteall dir": Commands.DeleteDirAll(); Main(); break;
                    //действия с файлами
                    case "open file": Commands.OpenFile(); Main(); break;
                    case "read file": Commands.ReadFile(); Main(); break;
                    case "write file": Commands.WriteFile(); Main(); break;
                    case "create file": Commands.CreateFile(); Main(); break;
                    case "delete file": Commands.DeleteFile(); Main(); break;
                    case "info file": Commands.InfoFile(); Main(); break;
                    case "move file": Commands.MoveFile(); Main(); break;
                    //выход и очистка 
                    case "clear": Console.Clear(); Main(); break;
                    case "exit": Environment.Exit(0); Main(); break;
                }
            }
            else Console.WriteLine("Ошибка команды! Описания команд введите help. "); Main();
            if (Console.ReadKey().Key == ConsoleKey.Enter) Main();//Enter
        }
    }
}
