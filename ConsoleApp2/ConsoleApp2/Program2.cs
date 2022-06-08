using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp2
{
    class Node
    {
        public string value;
        public List<Node> directed_nodes;
        public bool visited;
        public Node(string value)
        {
            this.value = value;
            directed_nodes = new List<Node>();
            this.visited = false;
        }
    }
    class Program2
    {
        public static List<int> graph_locs = new List<int>();
        public static Node[] graph = new Node[300];
        static void Main(string[] args)
        {
            int NumberOfWords = int.Parse(Console.ReadLine());
            int NumberOfAlphabets =int.Parse( Console.ReadLine());
            string[] words = Console.ReadLine().Split();
            for (int i = 0; i < (NumberOfWords -1); i++)
            {
                string w1 = words[i];
                string w2 = words[i + 1];
                for (int j = 0; j < Math.Min(w1.Length,w2.Length); j++)
                {
                    if (w1[j] != w2[j])
                    {
                        if (graph[(int)w1[j]] == null)
                        {
                            graph[(int)w1[j]] = new Node(w1[j].ToString());
                            graph_locs.Add((int)w1[j]);
                        }
                        if (graph[(int)w2[j]] == null)
                        {
                            graph[(int)w2[j]] = new Node(w2[j].ToString());
                            graph_locs.Add((int)w2[j]);
                        }
                        graph[(int)w1[j]].directed_nodes.Add(graph[(int)w2[j]]);
                        break;
                    }
                }
            }
            TopologicalSort(graph_locs);
            
        }
        
        private static void TopologicalSort(List<int> graph_locs)
        {
            Stack<Node> stack = new Stack<Node>();
            for (int i = 0; i < graph_locs.Count; i++)
            {
                if (graph[graph_locs[i]].visited == false)
                {
                    recursive(graph_locs[i], stack);
                }
            }
            printstack(stack,stack.Count);
        }

        public static void recursive(int i, Stack<Node> stack)
        {
            graph[i].visited = true;
            foreach (var item in graph[i].directed_nodes)
            {
                if (!item.visited)
                {
                    recursive(((int)item.value[0]), stack);
                }
            }
            stack.Push(graph[i]);

        }
        private static void printstack(Stack<Node> stack,int count)
        {
            for (int i = 0; i < count; i++)
            {
                Console.Write($"{stack.Pop().value}" + " ");
            }
        }
    }
} 
