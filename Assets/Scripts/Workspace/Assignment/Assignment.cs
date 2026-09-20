using UnityEngine;
using System.Collections.Generic;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            //AS01_CountWords();
            //AS02_CountNumber();
            //AS03_CheckValidBrackets();
            //AS04_PrintReverseLinkedList();
            //AS05_FindMiddleElement();
            //AS06_MergeDictionaries();
            //AS07_RemoveDuplicatesFromLinkedList();
            //AS08_TopFrequentNumber();
            //AS09_PlayerInventory();
            //AS10_GameEventQueue();
            AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            string[] words = as01Words;

            var wordCount = new Dictionary<string, int>();
            foreach (var word in words)
            {
                if (wordCount.ContainsKey(word))
                {
                    wordCount[word]++;
                }
                else
                {
                    wordCount[word] = 1;
                }
            }

            foreach (var pair in wordCount)
            {
                Debug.Log($"Word: {pair.Key} Count: {pair.Value}");
            }

        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            int[] numbers = as02Numbers;
            var numberCount = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (numberCount.ContainsKey(number))
                {
                    numberCount[number]++;
                }
                else
                {
                    numberCount[number] = 1;
                }
            }

            foreach (var pair in numberCount)
            {
                Debug.Log($"Number: {pair.Key} Count: {pair.Value}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {

            string input = as03Input;
            var bracketPairs = new Dictionary<char, char>()
            {
                { '(', ')' },
                { '[', ']' },
                { '{', '}' }
            };
            LinkedList<char> stack = new LinkedList<char>();
            foreach (var c in input)
            {
                if (bracketPairs.ContainsKey(c))
                {
                    stack.AddLast(c);
                }

                else if (bracketPairs.ContainsValue(c))
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                    var lastOpenBracket = stack.Last.Value;

                    if (bracketPairs[lastOpenBracket] == c)
                    {
                        stack.RemoveLast();
                    }
                    else
                    {
                        Debug.Log("Invalid");
                        return;
                    }
                }
            }

            if (stack.Count == 0)
            {
                Debug.Log("Valid");
            }
            else
            {
                Debug.Log("Invalid");
            }

        }

        [Header("AS04 - Print Reverse Linked List")]
        [SerializeField] private IntLinkedListInput as04List = new IntLinkedListInput();

        public void AS04_PrintReverseLinkedList()
        {
            LinkedList<int> list = as04List.GetLinkedList();

            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            var current = list.Last;

            while (current != null)
            {
                Debug.Log(current.Value);
                current = current.Previous;
            }

        }

        [Header("AS05 - Find Middle Element")]
        [SerializeField] private StringLinkedListInput as05List = new StringLinkedListInput();

        public void AS05_FindMiddleElement()
        {
            LinkedList<string> list = as05List.GetLinkedList();

            if (list.Count == 0)
            {
                Debug.Log("List is empty");
                return;
            }

            var slow = list.First;
            var fast = list.First;

            while (fast != null && fast.Next != null)
            {
                slow = slow.Next;
                fast = fast.Next.Next;
            }

            Debug.Log(slow.Value);
        }

        [Header("AS06 - Merge Dictionaries")]
        [SerializeField] private StringIntDictionaryInput as06FirstDictionary = new StringIntDictionaryInput();
        [SerializeField] private StringIntDictionaryInput as06SecondDictionary = new StringIntDictionaryInput();

        public void AS06_MergeDictionaries()
        {
            Dictionary<string, int> dict1 = as06FirstDictionary.GetDictionary();
            Dictionary<string, int> dict2 = as06SecondDictionary.GetDictionary();

            var mergedDictionary = new Dictionary<string, int>(dict1);

            foreach (var pair in dict2)
            {
                if (mergedDictionary.ContainsKey(pair.Key))
                {
                    mergedDictionary[pair.Key] += pair.Value;
                }
                else
                {
                    mergedDictionary[pair.Key] = pair.Value;
                }
            }

            foreach (var pair in mergedDictionary)
            {
                Debug.Log($"Key: {pair.Key} Value: {pair.Value}");
            }


        }


        [Header("AS07 - Remove Duplicates From Linked List")]
        [SerializeField] private IntLinkedListInput as07List = new IntLinkedListInput();

        public void AS07_RemoveDuplicatesFromLinkedList()
        {
            LinkedList<int> list = as07List.GetLinkedList();

            if (list.Count <= 1)
            {
                foreach (var item in list)
                {
                    Debug.Log(item);
                }
                return;
            }

            var seen = new Dictionary<int, bool>();
            var current = list.First;

            while (current != null)
            {
                var nextNode = current.Next;
                if (seen.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    seen[current.Value] = true;
                }
                current = nextNode;
            }

            foreach (var item in list)
            {
                Debug.Log(item);
            }
        }

        [Header("AS08 - Top Frequent Number")]
        [SerializeField] private int[] as08Numbers;

        public void AS08_TopFrequentNumber()
        {
            int[] numbers = as08Numbers;

            if (numbers == null || numbers.Length == 0)
            {
                Debug.Log("Array is empty");
                return;
            }

            var numberCount = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (numberCount.ContainsKey(number))
                {
                    numberCount[number]++;
                }
                else
                {
                    numberCount[number] = 1;
                }
            }

            var topNumber = numbers[0];
            var maxCount = numberCount[topNumber];

            foreach (var number in numbers)
            {
                var currentCount = numberCount[number];

                if (currentCount > maxCount)
                {
                    topNumber = number;
                    maxCount = currentCount;
                }
            }

            Debug.Log($"{topNumber} count: {maxCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            string itemName = as09ItemName;
            int quantity = as09Quantity;

            if (inventory.ContainsKey(itemName))
            {
                inventory[itemName] += quantity;
            }
            else
            {
                inventory[itemName] = quantity;
            }

            foreach (var pair in inventory)
            {
                Debug.Log($"Item: {pair.Key} Quantity: {pair.Value}");
            }
        }

        [Header("AS10 - Game Event Queue")]
        [SerializeField] private GameEventLinkedListInput as10EventQueue = new GameEventLinkedListInput();

        public void AS10_GameEventQueue()
        {
            LinkedList<GameEvent> eventQueue = as10EventQueue.GetLinkedList();

            if (eventQueue.Count == 0)
            {
                Debug.Log("Event queue is empty");
                return;
            }

            while (eventQueue.Count > 0)
            {
                var gameEvent = eventQueue.First.Value;
                eventQueue.RemoveFirst();

                Debug.Log($"Processing event: {gameEvent.Name}");
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");

                if (gameEvent.EventType == "enemy")
                {
                    Debug.Log($"Enemy event processed - {gameEvent.Name}");
                }
                else if (gameEvent.EventType == "powerup")
                {
                    Debug.Log($"Power-up event processed - {gameEvent.Name}");
                }
                else if (gameEvent.EventType == "level")
                {
                    Debug.Log($"Level event processed - {gameEvent.Name}");
                }
            }
        }

        [Header("AS11 - Player Stats Tracker")]
        [SerializeField] private StringIntDictionaryInput as11PlayerStats = new StringIntDictionaryInput();
        [SerializeField] private string as11StatName;
        [SerializeField] private int as11Value;

        public void AS11_PlayerStatsTracker()
        {
            Dictionary<string, int> playerStats = as11PlayerStats.GetDictionary();
            string statName = as11StatName;
            int value = as11Value;

            if (playerStats.ContainsKey(statName))
            {
                playerStats[statName] += value;
            }
            else
            {
                playerStats[statName] = value;
            }

            Debug.Log($"Updated {statName}: {playerStats[statName]}");
            Debug.Log("Current player statistics:");

            foreach (var pair in playerStats)
            {
                Debug.Log($"{pair.Key}: {pair.Value}");
            }
        }

        #endregion
    }
}