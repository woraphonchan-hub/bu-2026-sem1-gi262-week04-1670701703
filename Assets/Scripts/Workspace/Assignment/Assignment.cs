using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assignment
{
    public class Assignment : MonoBehaviour
    {
        public void Start()
        {
            // AS01_CountWords();
            // AS02_CountNumber();
            // AS03_CheckValidBrackets();
            // AS04_PrintReverseLinkedList();
            // AS05_FindMiddleElement();
            // AS06_MergeDictionaries();
            // AS07_RemoveDuplicatesFromLinkedList();
            // AS08_TopFrequentNumber();
            // AS09_PlayerInventory();
            // AS10_GameEventQueue();
            // AS11_PlayerStatsTracker();
        }

        #region Assignment

        [Header("AS01 - Count Words")]
        [SerializeField] private string[] as01Words;

        public void AS01_CountWords()
        {
            Dictionary<string, int> wordCounts = new Dictionary<string, int>();

            for (int i = 0; i < as01Words.Length; i++)
            {
                string currentWord = as01Words[i];

                if (wordCounts.ContainsKey(currentWord))
                {
                    wordCounts[currentWord]++;
                }
                else
                {
                    wordCounts.Add(currentWord, 1);
                }
            }
            string[] keys = new List<string>(wordCounts.Keys).ToArray();
            int[] values = new List<int>(wordCounts.Values).ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"word: '{keys[i]}' count: {values[i]}");
            }
        }

        [Header("AS02 - Count Number")]
        [SerializeField] private int[] as02Numbers;

        public void AS02_CountNumber()
        {
            Dictionary<int, int> numberCounts = new Dictionary<int, int>();

            for (int i = 0; i < as02Numbers.Length; i++)
            {
                int currentNum = as02Numbers[i];

                if (numberCounts.ContainsKey(currentNum))
                {
                    numberCounts[currentNum]++;
                }
                else
                {
                    numberCounts.Add(currentNum, 1);
                }
            }
            int[] keys = new List<int>(numberCounts.Keys).ToArray();
            int[] values = new List<int>(numberCounts.Values).ToArray();

            for (int i = 0; i < keys.Length; i++)
            {
                Debug.Log($"number: {keys[i]} count: {values[i]}");
            }
        }

        [Header("AS03 - Check Valid Brackets")]
        [SerializeField] private string as03Input;

        public void AS03_CheckValidBrackets()
        {
            Dictionary<char, char> bracketPairs = new Dictionary<char, char>();
            bracketPairs.Add(')', '(');
            bracketPairs.Add('}', '{');
            bracketPairs.Add(']', '[');

            LinkedList<char> stack = new LinkedList<char>();

            for (int i = 0; i < as03Input.Length; i++)
            {
                char c = as03Input[i];

                if (c == '(' || c == '{' || c == '[')
                {
                    stack.AddLast(c);
                }
                else if (bracketPairs.ContainsKey(c))
                {
                    if (stack.Count == 0)
                    {
                        Debug.Log("Invalid");
                        return;
                    }

                    if (stack.Last.Value == bracketPairs[c])
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
            LinkedListNode<int> currentNode = list.Last;

            while (currentNode != null)
            {
                Debug.Log(currentNode.Value);
                currentNode = currentNode.Previous;
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
            LinkedListNode<string> slow = list.First;
            LinkedListNode<string> fast = list.First;
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

            Dictionary<string, int> mergedDictionary = new Dictionary<string, int>(dict1);

            foreach (KeyValuePair<string, int> kvp in dict2)
            {
                string key = kvp.Key;
                int value = kvp.Value;

                if (mergedDictionary.ContainsKey(key))
                {
                    mergedDictionary[key] += value;
                }
                else
                {
                    mergedDictionary.Add(key, value);
                }
            }
            foreach (KeyValuePair<string, int> kvp in mergedDictionary)
            {
                Debug.Log($"key: {kvp.Key}, value: {kvp.Value}");
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
            Dictionary<int, bool> seen = new Dictionary<int, bool>();
            LinkedListNode<int> current = list.First;

            while (current != null)
            {
                LinkedListNode<int> nextNode = current.Next;
                if (seen.ContainsKey(current.Value))
                {
                    list.Remove(current);
                }
                else
                {
                    seen.Add(current.Value, true);
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
            if (as08Numbers == null || as08Numbers.Length == 0)
            {
                Debug.Log("Input array is empty");
                return;
            }
            Dictionary<int, int> frequencyDict = new Dictionary<int, int>();

            for (int i = 0; i < as08Numbers.Length; i++)
            {
                int num = as08Numbers[i];
                if (frequencyDict.ContainsKey(num))
                {
                    frequencyDict[num]++;
                }
                else
                {
                    frequencyDict.Add(num, 1);
                }
            }
            int mostFrequentNumber = as08Numbers[0];
            int maxCount = frequencyDict[mostFrequentNumber];

            for (int i = 0; i < as08Numbers.Length; i++)
            {
                int num = as08Numbers[i];
                int count = frequencyDict[num];
                if (count > maxCount)
                {
                    maxCount = count;
                    mostFrequentNumber = num;
                }
            }
            Debug.Log($"{mostFrequentNumber} count: {maxCount}");
        }

        [Header("AS09 - Player Inventory")]
        [SerializeField] private StringIntDictionaryInput as09Inventory = new StringIntDictionaryInput();
        [SerializeField] private string as09ItemName;
        [SerializeField] private int as09Quantity;

        public void AS09_PlayerInventory()
        {
            Dictionary<string, int> inventory = as09Inventory.GetDictionary();
            if (inventory.ContainsKey(as09ItemName))
            {
                inventory[as09ItemName] += as09Quantity;
            }
            else
            {
                inventory.Add(as09ItemName, as09Quantity);
            }
            foreach (KeyValuePair<string, int> kvp in inventory)
            {
                Debug.Log($"{kvp.Key}: {kvp.Value}");
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
                GameEvent currentEvent = eventQueue.First.Value;
                Debug.Log($"Processing event: {currentEvent.EventType}");
                eventQueue.RemoveFirst();
                Debug.Log($"Remaining events in queue: {eventQueue.Count}");
                switch (currentEvent.EventType)
                {
                    case "enemy":
                        Debug.Log($"Enemy event processed - {currentEvent.EventType}");
                        break;
                    case "powerup":
                        Debug.Log($"Power-up event processed - {currentEvent.EventType}");
                        break;
                    case "level":
                        Debug.Log($"Level event processed - {currentEvent.EventType}");
                        break;
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
            if (playerStats.ContainsKey(as11StatName))
            {
                playerStats[as11StatName] += as11Value;
            }
            else
            {
                playerStats.Add(as11StatName, as11Value);
            }
            Debug.Log($"Updated {as11StatName}: {playerStats[as11StatName]}");
            Debug.Log("Current player statistics:");
            foreach (KeyValuePair<string, int> kvp in playerStats)
            {
                Debug.Log($"{kvp.Key}: {kvp.Value}");
            }
        }

        #endregion
    }
}