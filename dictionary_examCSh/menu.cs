using System;
using System.IO;
using System.Threading;
using static System.Console;

namespace dictionary_examCSh
{
    public class Menu
    {
        string word, word1, word2;
        EnToRu slovar = new EnToRu();
        public Menu()
        {
           
            Start();
        }
        public void case1()
        {
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
        }
        public void case11()
        {
            WriteLine("Введите имя файла <пустой ввод - значение по умолчанию>");
            word = ReadLine();
            if (word == "") word = "dict.txt";
            Console.Clear();
            if (slovar.readFile(word))
            {
                WriteLine($"открываем файл {word}");
                Thread.Sleep(1700);
            }
        }
        public void case2()
        {
            WriteLine("Введите имя файла <пустой ввод - значение по умолчанию>");
            word = ReadLine();
            if (word == "") word = "dict.txt";
            slovar.writeFile(word);
            Console.Clear();
            WriteLine($"пишем файл {word}");
            if (File.Exists(word)) WriteLine($"файл {word} записан");
            Thread.Sleep(1700);
        }
        public void case3()
        {
            WriteLine("Введите слово");
            word = ReadLine();
            Console.Clear();
            slovar.print(word);
            WriteLine("Для продолжения нажмите Ввод");
            Console.ReadLine();
        }
        public void case4()
        {
            WriteLine("Введите слово");
            word = ReadLine();
            WriteLine("Введите перевод");
            word1 = ReadLine();
            slovar.add(word, word1);
            Console.Clear();
            slovar.print(word);
            WriteLine("Для продолжения нажмите Ввод");
            Console.ReadLine();
        }
        public void case5()
        {
            WriteLine("Введите слово");
            word = ReadLine();
            slovar.del(word);
            Console.Clear();
            WriteLine($"Слово {word} удалено со всеми переводами\nДля продолжения нажмите Ввод");
            Console.ReadLine();
        }
        public void case6()
        {
            WriteLine("Введите слово");
            word = ReadLine();
            WriteLine("Введите перевод");
            word1 = ReadLine();
            slovar.del(word, word1);
            Console.Clear();
            WriteLine($"Для слова {word} удален перевод {word1}\nДля продолжения нажмите Ввод");
            WriteLine("Для продолжения нажмите Ввод");
            Console.ReadLine();
        }
        public void case7()
        {
            Console.Clear();
            slovar.print();
            WriteLine("Для продолжения нажмите Ввод");
            Console.ReadLine();
        }
        public void case8()
        {
            WriteLine("Введите слово");
            word = ReadLine();
            WriteLine("Введите старый перевод");
            word1 = ReadLine();
            WriteLine("Введите новый перевод");
            word2 = ReadLine();
            slovar.del(word, word1);
            slovar.add(word, word2);
            Console.Clear();
            WriteLine($"Для слова {word} заменён перевод {word1} на перевод {word2}\nДля продолжения нажмите Ввод");
            Console.ReadLine();
        }
        public void case9()
        {
            WriteLine("Введите имя файла для экспорта <пустой ввод - значение по умолчанию>");
            word = ReadLine();
            if (word == "") word = "export.txt";
            WriteLine("Введите слово");
            word1 = ReadLine();
            if (slovar.export(word1, word))
            {
                Console.Clear();
                slovar.print(word1);
                WriteLine("Для продолжения нажмите Ввод");
                Console.ReadLine();
            }
        }
        public void Start()
        {
            int key;
            slovar.readFile();
            do
            {
                Console.Clear();
                Console.WriteLine("1  - Откыть файл словаря\n" +
                                  "11 - Добавить файл в словарь\n" +
                                  "2  - Сохранить словарь в файл\n" +
                                  "3  - Перевести слово\n" +
                                  "4  - Добавить перевод\n" +
                                  "5  - Удалить все значения перевода\n" +
                                  "6  - Удалить одно значение перевода\n" +
                                  "7  - Вывести весь словарь\n" +
                                  "8  - Заменить перевод\n" +
                                  "9  - Экспорт слова и его перевода(ов) в файл\n" +
                                  "0  - Выход\n");
                key = Convert.ToInt32(Console.ReadLine());               
                switch (key)
                {
                    case 1:
                        case1();
                        
                        break;
                    case 11:
                        case11();
                        
                        break;
                    case 2:
                        case2();
                        
                        break;
                    case 3:
                        case3();
                        
                        break;
                    case 4:
                        case4();

                        break;
                    case 5:
                        case5();
                        
                        break;
                    case 6:
                        case6();
                       
                        break;
                    case 7:
                        case7();
                        
                        break;
                    case 8:
                        case8();
                        
                        break;
                    case 9:
                        case9();
                        
                        break;

                    default:
                        break;
                }
            } while (key >= 1);
        }
    }
}
