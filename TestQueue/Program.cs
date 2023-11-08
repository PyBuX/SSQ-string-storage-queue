using System;

namespace TestQueue
{
    //класс тестового приложения
    internal class Program
    {
        static void Main(string[] args)
        {
            //тест класса
            int c = 0;
            Queue q = new Queue();
            do
            {
                try
                {
                    Console.WriteLine("1 - Добавить строку");
                    Console.WriteLine("2 - Извлечь строку");
                    Console.WriteLine("3 - Показать все строки");
                    Console.WriteLine("4 - Выход");
                    Console.Write(">> ");
                    c = int.Parse(Console.ReadLine());
                    if (c < 1 || c > 4)
                    {
                        throw new Exception("Ошибка ввода");
                    }
                    switch (c)
                    {
                        case 1:
                            {
                                Console.Write("Укажите строку -> ");
                                string str = Console.ReadLine();
                                q.push(str);
                                Console.WriteLine("Строка успешно добавлена в очередь");
                                break;
                            }
                        case 2:
                            {
                                string str = q.pop();
                                Console.WriteLine("Строка извлечена: " + str);
                                break;
                            }
                        case 3:
                            {
                                q.print();
                                break;
                            }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                Console.WriteLine();
            } while (c != 4);
            Console.WriteLine("\nНажмите на любую клавишу...");
            Console.ReadKey();
        }
    }

    //класс очереди строк на связном списке
    class Queue
    {
        //узел списка
        class Node
        {
            public string str; //строка
            public Node next; //указатель на след. узел
            public Node prev; //указатель на пред. узел

            //конструктор узла
            public Node(string str)
            {
                this.str = str;
                next = prev = null;
            }
        }

        //голова списка
        Node head;

        //хвост
        Node tail;

        //конструктор
        public Queue()
        {
            head = tail = null;
        }

        //вставка строки в очередь
        public void push(string str)
        {
            if (isEmpty())
            {
                head = tail = new Node(str);
            }
            else
            {
                Node t = new Node(str);
                t.prev = tail;
                tail.next = t;
                tail = t;
            }
        }

        //извлечение из очереди
        public string pop()
        {
            if (isEmpty())
            {
                throw new Exception("Очередь пуста");
            }
            string str = head.str;
            head = head.next;
            if (head == null)
            {
                tail = null;
            }
            else
            {
                head.prev = null;
            }
            return str;
        }

        //вывод очереди
        public void print()
        {
            Node cur = head;
            if (isEmpty())
            {
                Console.WriteLine("Очередь пуста");
            }
            while (cur != null)
            {
                Console.WriteLine(cur.str);
                cur = cur.next;
            }
        }

        //проверка очереди на пустоту
        public bool isEmpty()
        {
            return head == null;
        }
    }
}