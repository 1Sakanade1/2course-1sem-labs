using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab9_v6
{
    public class Stack<T>
    {
        private T[] items;
        private int count;
        private T head;
        const int n = 10;
        public Stack()
        {
            items = new T[n];
        }
        public Stack(int length)
        {
            items = new T[length];
        }

        public bool IsEmpty
        {
            get { return count == 0; }
        }
        public int Count
        {
            get { return count; }
        }

        public void Push(T item)
        {
            // увеличиваем стек
            if (count == items.Length)
                Resize(items.Length + 10);
            head = item;
            items[count++] = item;
        }
        public T Pop()
        {
            // если стек пуст, выбрасываем исключение
            if (IsEmpty)
                throw new InvalidOperationException("Стек пуст");
            T item = items[--count];
            items[count] = default(T); // сбрасываем ссылку

            if (count > 0 && count < items.Length - 10)
                Resize(items.Length - 10);

            return item;
        }

        private void Resize(int max)
        {
            T[] tempItems = new T[max];
            for (int i = 0; i < count; i++)
                tempItems[i] = items[i];
            items = tempItems;
        }

        public void GiveHeadElement()
        {
            Console.WriteLine(head);
        }

        public void AllElementsOut()
        {
            foreach(var item in items)
            {
                Console.WriteLine(item);
            }

        }

        public void ElementSearch(T searchelem)
        {
            foreach (var item in items)
            {
               if(item.Equals(searchelem))
                {
                    Console.WriteLine("Найденный элемент: ");
                    Console.WriteLine(searchelem);
                }
            }
        }


    }
}
