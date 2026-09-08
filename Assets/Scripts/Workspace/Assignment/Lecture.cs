using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Collections;

namespace Assignment
{
    public class Lecture : MonoBehaviour
    {
        public void Start()
        {
            //LCT01_SyntaxList();
            // LCT02_SyntaxLinkedList();
            // LCT03_SyntaxHashTable();
            LCT04_SyntaxDictionary();
        }

        #region Lecture

        public void LCT01_SyntaxList()
        {
            LinkedList<string> linkedList = new LinkedList<string>();

            linkedList.AddLast("Node 1 ");
            linkedList.AddLast("Node 2");
            linkedList.AddLast("Node 0");
            //Node 0 , Node 2 , Node 1

            LinkedListNode<string> node1 = linkedList.Find("Node 1");
            Debug.Log(node1.Value);
            Debug.Log(node1.Next.Value);
            Debug.Log(node1.Previous.Value);
            Debug.Log("--------");

            var firstNode = linkedList.First;
            var lastNode = linkedList.Last;
            Debug.Log(firstNode.Previous);
            Debug.Log(lastNode.Next);

            linkedList.AddAfter(node1, "Node 1.5");
            linkedList.AddBefore(node1, "Node 0.5");

            linkedList.RemoveFirst();
            linkedList.RemoveLast();
            linkedList.Remove("Node 1.5");

            linkedList.Clear();

            foreach (var item in linkedList)
            {
                Debug.Log(item);
            }

            
        }

        public void LCT02_SyntaxLinkedList()
        {
            throw new System.NotImplementedException();
        }

        public void LCT03_SyntaxHashTable()
        {
            Hashtable table = new Hashtable();
            table.Add("Potion", 5);
            table.Add(5, "Potion");
            foreach (var item in table) {
                Debug.Log(item);
                    }

           
        }

        public void LCT04_SyntaxDictionary()
        {
            Dictionary<string, int> inv = new Dictionary<string, int>();

            inv.Add("potion", 5);
            inv.Add("Banana", 1);
            inv.Add("Apple", 10);

            inv["Apple"] = 0;

            inv["Orange"] = 20;


            int potion = inv["potion"];
            Debug.Log(potion);

            //int apple2 = inv["Apple2"];
            //Debug.Log(apple2);

            bool haspotion = inv.ContainsKey("potion");
            Debug.Log(haspotion);

            inv.Remove("Banana");

            foreach(KeyValuePair<string, int> kvp in inv)
            {
                var key = kvp.Key;
                var value = kvp.Value;

                Debug.Log(key + value);
            }

            inv.Clear();
        }

        #endregion
    }
}
