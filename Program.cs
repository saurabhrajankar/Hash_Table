using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC2_Find_Frequency_Of_Words_In_A_Large
{
    class MyMapNode<K, V>
    {
        private readonly int size;
        private readonly LinkedList<KeyValue<K, V>>[] items;
        public MyMapNode(int size)
        {
            this.size = size;
            this.items = new LinkedList<KeyValue<K, V>>[size];
        }
        public void Add(K key, V value)
        {
            //for Adding Elements In HashTable
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> item = new KeyValue<K, V>() { Key = key, Value = value };
            linkedList.AddLast(item);//will add elements in linkedlist of key value pair
        }
        protected int GetArrayPosition(K key)
        {
            int position = key.GetHashCode() % size;
            return Math.Abs(position);
        }
        protected LinkedList<KeyValue<K, V>> GetLinkedList(int position)
        {
            LinkedList<KeyValue<K, V>> linkedList = items[position];
            if (linkedList == null)
            {
                linkedList = new LinkedList<KeyValue<K, V>>();
                items[position] = linkedList;
            }
            return linkedList;
        }
        public void GetFrequencyOfWords(V Values)
        {
            //To Find The Frequency Of Word Given
            int count = 0;
            foreach (LinkedList<KeyValue<K, V>> list in items)
            {
                if (list == null)
                {
                    continue;
                }
                foreach (KeyValue<K, V> item in list)
                {
                    if (item.Value.Equals(Values))
                    {
                        //Count Increments If Value Is Found
                        count++;
                    }
                }
            }
            Console.WriteLine("Value:" + Values + "                         Frequency:" + count);
        }

    }
    public struct KeyValue<k, v>
    {
        //To Store The Given Key And Value
        public k Key { get; set; }
        public v Value { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            MyMapNode<string, string> hash = new MyMapNode<string, string>(10);
            string sent = "Paranoids Are Not Paranoid Because They Are Paranoid But Because They Keep Putting Themselves Deliberately Into Paranoid Avoidable Situations";
            string[] result = sent.Split(" ");
            int len = result.Length;
            for (int i = 0; i < len; i++)
            {
                string a = Convert.ToString(i);
                hash.Add(a, result[i]);
            }
            foreach (string word in result)
            {
                hash.GetFrequencyOfWords(word);

            }
        }
    }
}
