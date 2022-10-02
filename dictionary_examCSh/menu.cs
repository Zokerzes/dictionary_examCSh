using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Console;

namespace dictionary_examCSh
{
    public class Menu
    {
        EnToRu slovar = new EnToRu();
        public Menu()
        {
           
            Start();
        }
        public void Start()
        {
            int key;
            slovar.readFile();
            do
            {
                Console.Clear();
                Console.WriteLine("1 - Откыть файл словаря\n" +
                                  "2 - Сохранить словарь в файл\n" +
                                  "3 - Перевести слово\n" +
                                  "4 - Добавить перевод\n" +
                                  "5 - Удалить все значения перевода\n" +
                                  "6 - Удалить одно значение перевода\n" +
                                  "7 - \n");
                key = Convert.ToInt32(Console.ReadLine());

                string word;
                switch (key)
                {
                    case 1:
                        
                        WriteLine("Введите имя файла <пустой ввод - значение по умолчанию>");
                        word = ReadLine();
                        if (word == "") word = "dict.txt";
                        slovar.readFile(word);
                        Console.Clear();
                        WriteLine($"открываем файл {word}");
                        Thread.Sleep(1700);
                        break;
                    case 2:
                        WriteLine("Введите имя файла <пустой ввод - значение по умолчанию>");
                        word = ReadLine();
                        if (word == "") word = "dict.txt";
                        slovar.writeFile(word);
                        Console.Clear();
                        WriteLine($"пишем файл {word}");
                        Thread.Sleep(1700);
                        break;
                    case 3:
                        WriteLine("Введите слово");
                        word = ReadLine();
                        Console.Clear();
                        slovar.Print(word);
                        WriteLine("Для продолжения нажмите Ввод");
                        Console.ReadLine();
                        break;
                    case 4:
                        WriteLine("Введите слово");
                        word = ReadLine();
                        WriteLine("Введите перевод");
                        string word1 = ReadLine();
                        slovar.Add(word, word1);
                        Console.Clear();
                        slovar.Print(word);
                        WriteLine("Для продолжения нажмите Ввод");
                        Console.ReadLine();

                        break;
                    case 5:

                        break;
                    case 6:

                        break;
                    case 7:

                        break;
                    case 8:

                        break;
                    case 9:

                        break;

                    default:
                        break;
                }
            } while (key >= 1);
        }
    }
}
