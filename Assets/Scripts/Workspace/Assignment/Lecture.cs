using UnityEngine;
using System.Collections.Generic;
using Unity.Properties;
using System.Collections;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            // LCT01_SyntaxList();
            // LCT02_SyntaxLinkedList();
            // LCT03_SyntaxHashTable();
            // LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {
            throw new System.NotImplementedException();
        }

        public void LCT02_SyntaxLinkedList()
        {
            LinkedList<string> linkedlist = new LinkedList<string>();

            linkedlist.AddLast("Node 1");

            linkedlist.AddLast("Node 2");

            linkedlist.AddFirst("Node 0");

            LinkedListNode<string> node1 = linkedlist.Find("Node 1");
            Debug.Log(node1.Value);
            Debug.Log(node1.Next.Value);
            Debug.Log(node1.Previous.Value);

            var firstNode = linkedlist.First;
            var lastNode = linkedlist.Last;

            Debug.Log(firstNode.Previous);
            Debug.Log(lastNode.Next);

            linkedlist.AddAfter(node1, "Node 1.5");
            linkedlist.AddBefore(node1, "Node 0.5");
            linkedlist.RemoveFirst();
            linkedlist.RemoveLast();
            linkedlist.Remove("Node 1.5");

            linkedlist.Clear();

            Debug.Log(" - - - - ");
            foreach (var item in linkedlist)
            {
                Debug.Log(item);
            }
        }

        public void LCT03_SyntaxHashTable()
        {
            Hashtable table = new Hashtable();
            table.Add("Potion", 5);

            foreach (var item in table)
            {
                Debug.Log($"item {item}");
            }
        }

        public void LCT04_SyntaxDictionary()
        {
            Dictionary<string, int> inv = new Dictionary<string, int>();

            inv.Add("Potion", 5);
            inv.Add("Banana", 1);
            inv.Add("Apple", 10);

            inv["Apple"] = 0;
            inv["Apple1"] = 1;

            int potion = inv["Potion"];
            Debug.Log("Potion : " + potion);

            bool hasPotion = inv.ContainsKey("Potion");
            Debug.Log("hasPotion : " + hasPotion);

            inv.Remove("Banana");

            foreach (KeyValuePair<string, int> kvp in inv)
            {
                var key = kvp.Key;
                var value = kvp.Value;
                Debug.Log($"{key} => {value}");
            }

            inv.Clear();
        }

        #endregion
    }
}