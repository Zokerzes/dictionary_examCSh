using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace dictionary_examCSh
{
    public class EnToRu
    {
        private Dictionary<string, List<string>> slovar;
        public EnToRu()
        {
            slovar = new Dictionary<string, List<string>>();
        }
        public void Add(string str1, string str2)
        {
            if (slovar.ContainsKey(str1)) slovar[str1].Add(str2);
            else slovar.Add(str1, new List<string> { str2 });
        }
        public void Del(string str)
        {
            if (slovar.ContainsKey(str)) slovar.Remove(str);
        }
        public void Del(string str1, string str2)
        {
            if (slovar.ContainsKey(str1) && slovar[str1].Contains(str2)) slovar[str1].Remove(str2);
        }
        public void Print(string str = " ")
        {
            if (str == " ")
            {
                foreach (var item in slovar)
                {
                    Console.WriteLine($"{item.Key}");
                    foreach (var item2 in item.Value)
                    {
                        Console.WriteLine($"\t{item2}"); 
                    }
                }
            }
            else if (slovar.ContainsKey(str))
            {
                Console.Write(str + " = ");
                Console.WriteLine(string.Join(" ", slovar[str]));
            }
            else Console.WriteLine("не знаю такого слова " + str);
        }
        public void writeFile(string patch = "dict.txt")
        {
            using (var writer = new StreamWriter(patch))
            {
                foreach (var item in slovar)
                {
                    
                    foreach (var item2 in item.Value)
                    {
                        //Console.WriteLine($"{item.Key}\t{item2}");
                        writer.WriteLine($"{item.Key}\t{item2}");
                    }
                }
            }
        }
        public bool export(string word, string patch = "export.txt")
        {
            try
            {
                using (var writer = new StreamWriter(patch))
                {
                    if (slovar.ContainsKey(word))
                    {
                        writer.Write(word + " = ");
                        writer.WriteLine(string.Join(" ", slovar[word]));
                    }
                    else
                    {

                        throw new Exception("Ошибка экспорта");
                  
                    }
                }
                return true;
            }
            catch
            {
                File.Delete(patch);
                Console.WriteLine("Ошибка экспорта");
                Thread.Sleep(1000);
                return false;
            }

        }

        public bool readFile(string patch = "dict.txt")
        {
            try
            {
                using (var reader = new StreamReader(patch))
                {
                    while (!reader.EndOfStream)
                    {
                        string temp = reader.ReadLine();
                        string[] str = temp.Split('\t');
                        Add(str[0], str[1]);
                    }
                    return true;
                }
            }
            catch
            {
                Console.WriteLine("Файл не найден");
                Thread.Sleep(1700);
                return false;
            }
        }  
    }
}
