using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp3
{
    class Class1
    {
		public static int V;
		public static bool flag = false;
		static void mst(int[,] graph)
		{
			int[] k = new int[V];
			bool[] set = new bool[V];
			initilaize(k, set);
			int sum = 0;
			int[] p = new int[V];
			k[0] = 0;
			p[0] = -1;
			mamad(set, p, k, graph);
			for (int i = 1; i < V; i++)
			{
				if (graph[i, p[i]] != int.MinValue)
				{
					sum += graph[i, p[i]];

				}
			}
			if (flag == false)
			{
				if (sum == 0)
				{
					Console.WriteLine("-1");
				}
				else
					Console.WriteLine(sum);
			}

		}

		private static void initilaize(int[] k, bool[] set)
		{
			for (int i = 0; i < V; i++)
			{
				k[i] = int.MaxValue;
				set[i] = false;
			}
		}
		private static void mamad(bool[] set, int[] p, int[] k, int[,] graph)
		{
			for (int count = 0; count < V - 1; count++)
			{
				int u = min(k, set);
				if (u == -1)
				{
					Console.WriteLine("-1");
					flag = true;
					return;

				}
				set[u] = true;
				for (int v = 0; v < V; v++)
					if (graph[u, v] != 0 && set[v] == false
						&& graph[u, v] < k[v])
					{
						p[v] = u;
						k[v] = graph[u, v];
					}
			}
		}
		static int min(int[] key, bool[] mstSet)
		{
			int min = int.MaxValue, min_index = -1;
			for (int v = 0; v < V; v++)
				if (mstSet[v] == false && key[v] < min)
				{
					min = key[v];
					min_index = v;
				}
			return min_index;
		}
		public static void Main()
        {
			input();

        }
		private static void input()
		{
			int size = int.Parse(Console.ReadLine());
			V = size;
			int[,] graph = new int[size, size];
			Tuple<int, int>[] points = new Tuple<int, int>[V];
			for (int i = 0; i < size; i++)
			{
				string[] inputs = Console.ReadLine().Split();
				//int x = int.Parse(Console.ReadLine());
				//int y = int.Parse(Console.ReadLine());
				points[i] = new Tuple<int, int>(int.Parse(inputs[0]),int.Parse(inputs[1]));
			}
            for (int j = 0; j < V; j++)
            {
                for (int k = 0; k < V; k++)
                {
                    if (k == j)
                    {
						break;
                    }
					int cst = Math.Abs(points[j].Item1 - points[k].Item1) + Math.Abs(points[j].Item2 - points[k].Item2);
					graph[j , k ] = cst;
					graph[k , j ] = cst;
                }
            }
			mst(graph);
			flag = false;
		}
	}
}
