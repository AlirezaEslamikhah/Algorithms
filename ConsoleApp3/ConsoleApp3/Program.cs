using System;

namespace ConsoleApp3
{
	class question3
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
			mamad(set, p, k,graph);
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

        private static void mamad(bool[] set, int[] p, int[] k,int[,] graph)
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

        public static void Main2()
		{
			input();
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

		private static void input()
        {
			string[] sizes = Console.ReadLine().Split();
			V = int.Parse(sizes[0].ToString());
			int[,] graph = new int[int.Parse(sizes[0].ToString()), int.Parse(sizes[0].ToString())];
			for (int i = 0; i < int.Parse(sizes[1]); i++)
			{
				string[] graphh = Console.ReadLine().Split();
				int src = int.Parse(graphh[0]);
				int dst = int.Parse(graphh[1]);
				int cst = int.Parse(graphh[2]);
				graph[src - 1, dst - 1] = cst; graph[dst - 1, src - 1] = cst;
			}
			for (int j = 0; j < int.Parse(sizes[2]); j++)
			{
				string[] graphh = Console.ReadLine().Split();
				int src = int.Parse(graphh[0]);
				int dst = int.Parse(graphh[1]);
				graph[src - 1, dst - 1] = int.MinValue; graph[dst - 1, src - 1] = int.MinValue;
			}
			mst(graph);
			flag = false;
		}
    }

}
