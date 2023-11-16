using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Lab13_v6
{
    internal class Serializator
    {
        public static void binser(string path, Book book)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, book);

                Console.WriteLine("Объект сериализован");
            }
        }

        public static void bindeser(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();

            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Book newBook = (Book)formatter.Deserialize(fs);

                Console.WriteLine("Объект десериализован");
                Console.WriteLine($"Название: {newBook.name} --- жанр: {newBook.type}");
            }

        }

        // ----------------------------------------------------------------------------------------


        public static void xmlser(string path, Book book)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Book));

            // получаем поток, куда будем записывать сериализованный объект
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                xmlSerializer.Serialize(fs, book);

                Console.WriteLine("Object has been serialized");
            }
        }


        public static void xmldeser(string path)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Book));

            using (FileStream fs = new FileStream("Book.xml", FileMode.OpenOrCreate))
            {
                Book? book = xmlSerializer.Deserialize(fs) as Book;
                Console.WriteLine($"Name: {book?.name}  Type: {book?.type}");
            }


        }


        // ------------------------------------------------------------------------------------------

        public static async void jsonser(string path, Book book)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<Book>(fs, book);
                Console.WriteLine("Data has been saved to file");
            }
        }

        public static async void jsondeser(string path)
        {
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Book newbook = JsonSerializer.Deserialize<Book>(fs);
                Console.WriteLine($"Name: {newbook?.name}  Type: {newbook?.type}");
            }
        }

        // ------------------------------------------------------------------------------------------




        public static void binwork(string path,Book[] books)
        {
            BinaryFormatter binary = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                binary.Serialize(fs, books);
                Console.WriteLine("Объект сериализован");
            }
            using (FileStream fs = new FileStream(path, FileMode.OpenOrCreate))
            {
                Book[] deserilizePeople = (Book[])binary.Deserialize(fs);
                foreach (Book p in deserilizePeople)
                {
                    Console.WriteLine($"Name: {p.name} --- Age: {p.type}");
                }
            }
        }



    }
}
