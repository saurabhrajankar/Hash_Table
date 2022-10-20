using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UC3_Remove_Avoidable_Word_From_phrase
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

        public V Get(K key)
        {
            //Get Value Of The Key Given
            int position = GetArrayPosition(key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(key))
                {
                    return item.Value;
                }
            }
            return default(V);
        }

        public void Remove(K Key)
        {
            //For Removing The Element From The HashTable
            int position = GetArrayPosition(Key);
            LinkedList<KeyValue<K, V>> linkedList = GetLinkedList(position);
            KeyValue<K, V> foundItem = default(KeyValue<K, V>);
            bool itemFound = false;
            foreach (KeyValue<K, V> item in linkedList)
            {
                if (item.Key.Equals(Key))
                {
                    itemFound = true;
                    foundItem = item;
                    linkedList.Remove(foundItem);
                }
            }
            Console.WriteLine(Key + ":Value Removed");
        }
    }
    public struct KeyValue<k, v>
    {
        //To Store The Given Key And Value
        public k Key { get; set; }
        public v Value { get; set; }
    }
    internal class HT3
    {
        static void Main(string[] args)
        {
            MyMapNode<string, string> hash = new MyMapNode<string, string>(5);
            string sent = "Paranoids Are Not Paranoid Because They Are Paranoid But Because They Keep Putting Themselves Deliberately Into Paranoid Avoidable Situations";
            string[] result = sent.Split(" ");
            int len = result.Length;
            for (int i = 0; i < len; i++)
            {
                string a = Convert.ToString(i);
                hash.Add(a, result[i]);
            }
            for (int i = 0; i < len; i++)
            {
                if (result[i].Equals("Avoidable"))//Checking Each Value With Given Value To Remove Its Key And Value
                {
                    hash.Remove(result[i]);
                }
            }
        }
    }
}