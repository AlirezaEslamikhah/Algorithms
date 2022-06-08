using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp2
{
	public class DNode
	{
		public string Char;
		public DNode prev = null;
		public DNode next = null;
		public DNode(string character) => Char = character;
	}

	public class AlienCharacters
	{
		public AlienCharacters(int k) => MaxChars = k;

		private int MaxChars;
		private DNode head = null;
		private Dictionary<string, DNode> index = new Dictionary<string, DNode>();

		// As we use Dictionary for indexing, the time complexity for inserting
		// characters in order will take O(1)
		// Time: O(1)
		// Space: O(c), where 'c' is the unique character count.
		public bool UpdateCharacterOrdering(string predChar, string succChar)
		{
			DNode pNode = null, sNode = null;
			bool isSNodeNew = false, isPNodeNew = false;
			if (!index.TryGetValue(predChar, out pNode))
			{
				pNode = new DNode(predChar);
				index[predChar] = pNode;
				isPNodeNew = true;
			}
			if (!index.TryGetValue(succChar, out sNode))
			{
				sNode = new DNode(succChar);
				index[succChar] = sNode;
				isSNodeNew = true;
			}

			// before ordering is formed, validate if both the nodes are already present
			if (!isSNodeNew && !isPNodeNew)
			{
				if (!Validate(predChar, succChar))
					return false;
			}
			else if ((isPNodeNew && !isSNodeNew) || (isPNodeNew && isSNodeNew))
				InsertNodeBefore(ref pNode, ref sNode);
			else
				InsertNodeAfter(ref pNode, ref sNode);

			if (pNode.prev == null)
				head = pNode;

			return true;
		}

		// Time: O(1)
		private void InsertNodeAfter(ref DNode pNode, ref DNode sNode)
		{
			sNode.next = pNode?.next;
			if (pNode.next != null)
				pNode.next.prev = sNode;

			pNode.next = sNode;
			sNode.prev = pNode;
		}

		// Time: O(1)
		private void InsertNodeBefore(ref DNode pNode, ref DNode sNode)
		{
			// insert pnode before snode
			pNode.prev = sNode?.prev;

			if (sNode.prev != null)
				sNode.prev.next = pNode;
			sNode.prev = pNode;
			pNode.next = sNode;
		}

		// Time: O(1)
		private bool Validate(string predChar, string succChar)
		{
			// this is the first level of validation
			// validate if predChar node actually occurs before succCharNode.
			DNode sNode = index[succChar];

			while (sNode != null)
			{
				if (sNode.Char != predChar)
					sNode = sNode.prev;
				else
					return true; // validation successful
			}

			// if we have reached the end and not found the predChar before succChar
			// something is not right!
			return false;
		}

		// Time: O(c), where 'c' is the unique character count.
		public override string ToString()
		{
			string res = "";
			int count = 0;
			DNode currNode = head;

			while (currNode != null)
			{
				res += currNode.Char + " ";
				count++;
				currNode = currNode.next;
			}

			// second level of validation
			if (count != MaxChars) // something went wrong!
				res = "ERROR!!! Input words not enough to find all k unique characters.";

			return res;
		}
	}

	class Program
	{
		static int k ;
		static AlienCharacters alienCharacters = new AlienCharacters(k);
		static List<string> vocabulary = new List<string>();

		static void Main3(string[] args)
		{
			int NumberOfWords = int.Parse(Console.ReadLine());
			int NumberOfAlphabets = int.Parse(Console.ReadLine());
			k = NumberOfAlphabets;
			string[] words = Console.ReadLine().Split();
            for (int i = 0; i < words.Length; i++)
            {
				vocabulary.Add(words[i]);
            }

			//ProcessVocabulary(0);

			Console.WriteLine(alienCharacters.ToString());

			Console.ReadLine();
		}

		// Time: O(vocabulary.Count + max(word.Length))
		static void ProcessVocabulary(int startIndex)
		{
			if (startIndex >= vocabulary.Count - 1)
				return;

			var res = GetPredSuccChar(vocabulary.ElementAt(startIndex), vocabulary.ElementAt(startIndex + 1));
			if (res != null)
			{
				if (!alienCharacters.UpdateCharacterOrdering(res.Item1, res.Item2))
				{
					Console.WriteLine("ERROR!!! Invalid input data, the words maybe in wrong order");
					return;
				}
			}

			ProcessVocabulary(startIndex + 1);
		}

		//Time: O(max(str1.Length, str2.Length)
		static Tuple<string, string> GetPredSuccChar(string str1, string str2)
		{
			Tuple<string, string> result = null;

			if (str1.Length == 0 || str2.Length == 0)
				return null; // invalid condition.

			if (str1[0] != str2[0]) // found an ordering
			{
				result = new Tuple<string, string>(str1[0].ToString(), str2[0].ToString());
				return result;
			}

			string s1 = str1.Substring(1, str1.Length - 1);
			string s2 = str2.Substring(1, str2.Length - 1);

			if (s1.Length == 0 || s2.Length == 0)
				return null; // recursion can stop now.

			return GetPredSuccChar(s1, s2);
		}
	}
}

// Contributed by Priyanka Pardesi Ramachander

