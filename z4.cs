using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3_z4
{
    public class DoublyNode<T>
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }
    public class Deque<T>
    {
        private DoublyNode<T> head;
        private DoublyNode<T> tail;
        private int countt;
        public Deque()
        {
            countt = 0;
        }
        public bool IsEmpty()
        {
            return countt == 0;
        }
        public int Size()
        {
            return countt;
        }
        public int Find(T value) 
        {
            if (countt == 0)
                throw new InvalidOperationException();
            DoublyNode<T> tempDNode = head;
            for (int i = 0; i < countt; i++)
            {
                if (tempDNode.Data.Equals(value))
                    Console.WriteLine("Поиск нужного элемента имеет индекс {0} в списке", i);
                tempDNode = tempDNode.Next;
            }
            return -1;
        }
        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (countt == 0)
                tail = head;
            else
                temp.Previous = node;
            countt++;
        }
        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            countt++;
        }
        public T RemoveFirst()
        {
            if (countt == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            if (countt == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            countt--;
            return output;
        }
        public T RemoveLast()
        {
            if (countt == 0)
                throw new InvalidOperationException();
            T output = tail.Data;
            if (countt == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            countt--;
            return output;
        }
        public void pechat()
        {
            DoublyNode<T> tempDNode = head;
            for (int i = 0; i < countt; i++)
            {
                Console.Write(tempDNode.Data + " ");
                tempDNode = tempDNode.Next;
            }
            Console.WriteLine();
        }
        public void RemoveFind(T data)
        {
            if (countt == 0)
                throw new InvalidOperationException();
            DoublyNode<T> tempDNode = head;
            for (int i = 0; i < countt; i++)
            {
                if (tempDNode.Data.Equals(data))
                {
                    if (i == 0)
                    {
                        if (countt == 1)
                        {
                            head = tail = null;
                        }
                        else
                        {
                            head = head.Next;
                            head.Previous = null;
                        }
                        countt--;
                        i = -1;
                    }
                    else if (i == countt - 1)
                    {
                        if (countt == 1)
                        {
                            head = tail = null;
                        }
                        else
                        {
                            tail = tail.Previous;
                            tail.Next = null;
                        }
                        countt--;
                    }
                    else
                    {
                        tempDNode.Previous.Next = tempDNode.Next;
                        tempDNode.Next.Previous = tempDNode.Previous;
                        countt--;
                        i--;
                    }
                }
                    tempDNode = tempDNode.Next;

                
                    
            }
        }


    }
    internal class z4
    {
        static void Main()
        {
            Deque<int> deque = new Deque<int>();
            deque.AddFirst(5);
            deque.AddFirst(6);
            deque.AddFirst(7);
            deque.AddLast(8);
            deque.AddLast(5);
            deque.AddLast(10);
            deque.pechat();

            deque.RemoveFirst();
            deque.pechat();
            deque.Find(5);

            deque.RemoveLast();
            deque.pechat();

            deque.RemoveFind(5);
            deque.pechat();
        }
    }
}
