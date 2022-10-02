using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
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
                                  "11 - Добавить файл в словарь\n" +
                                  "2 - Сохранить словарь в файл\n" +
                                  "3 - Перевести слово\n" +
                                  "4 - Добавить перевод\n" +
                                  "5 - Удалить все значения перевода\n" +
                                  "6 - Удалить одно значение перевода\n" +
                                  "7 - Вывести весь словарь\n" +
                                  "8 - Заменить перевод\n" +
                                  "9 - Экспорт слова и его перевода(ов) в файл\n");
                key = Convert.ToInt32(Console.ReadLine());

                string word,word1,word2;
                switch (key)
                {
                    case 1:
                        
                        WriteLine("Введите имя файла <пустой ввод - значение по умолчанию>");
                        word = ReadLine();
                        if (word == "") word = "dict.txt";
                        
                        slovar = new EnToRu();
                        Console.Clear();
                        if (slovar.readFile(word))
                        {
                            WriteLine($"открываем файл {word}");
                            Thread.Sleep(1700);
                        }
                        break;
                    case 11:

                        WriteLine("Введите имя файла <пустой ввод - значение по умолчанию>");
                        word = ReadLine();
                        if (word == "") word = "dict.txt";
                        Console.Clear();
                        if (slovar.readFile(word))
                        {
                            WriteLine($"открываем файл {word}");
                            Thread.Sleep(1700);
                        }
                        break;
                    case 2:
                        WriteLine("Введите имя файла <пустой ввод - значение по умолчанию>");
                        word = ReadLine();
                        if (word == "") word = "dict.txt";
                        slovar.writeFile(word);
                        Console.Clear();
                        WriteLine($"пишем файл {word}");
                        if(File.Exists(word)) WriteLine($"файл {word} записан");
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
                        word1 = ReadLine();
                        slovar.Add(word, word1);
                        Console.Clear();
                        slovar.Print(word);
                        WriteLine("Для продолжения нажмите Ввод");
                        Console.ReadLine();

                        break;
                    case 5:
                        WriteLine("Введите слово");
                        word = ReadLine();
                        slovar.Del(word);
                        Console.Clear();
                        WriteLine($"Слово {word} удалено со всеми переводами\nДля продолжения нажмите Ввод");
                        Console.ReadLine();
                        break;
                    case 6:
                        WriteLine("Введите слово");
                        word = ReadLine();
                        WriteLine("Введите перевод");
                        word1 = ReadLine();
                        slovar.Del(word, word1);
                        Console.Clear();
                        WriteLine($"Для слова {word} удален перевод {word1}\nДля продолжения нажмите Ввод");
                        WriteLine("Для продолжения нажмите Ввод");
                        Console.ReadLine();
                        break;
                    case 7:
                        Console.Clear();
                        slovar.Print();
                        WriteLine("Для продолжения нажмите Ввод");
                        Console.ReadLine();
                        break;
                    case 8:
                        WriteLine("Введите слово");
                        word = ReadLine();
                        WriteLine("Введите старый перевод");
                        word1 = ReadLine();
                        WriteLine("Введите новый перевод");
                        word2 = ReadLine();
                        slovar.Del(word, word1);
                        slovar.Add(word, word2);
                        Console.Clear();
                        WriteLine($"Для слова {word} заменён перевод {word1} на перевод {word2}\nДля продолжения нажмите Ввод");
                        Console.ReadLine();
                        break;
                    case 9:
                        WriteLine("Введите имя файла для экспорта <пустой ввод - значение по умолчанию>");
                        word = ReadLine();
                        if (word == "") word = "export.txt";
                        WriteLine("Введите слово");
                        word1 = ReadLine();
                        if (slovar.export(word1, word))
                        {
                            Console.Clear();
                            slovar.Print(word1);
                            WriteLine("Для продолжения нажмите Ввод");
                            Console.ReadLine();
                        }
                        break;

                    default:
                        break;
                }
            } while (key >= 1);
        }
    }
}
