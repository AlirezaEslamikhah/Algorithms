using System;
using System.Collections.Generic;
using System.Linq;
class QUESTION3
{
    

	public static int ll = 0;
	//public static bool[] visited = new bool[ll];

	private static void dfs(int[,] g, int s,bool []visited)
	{
		visited[s] = true;
		for (int i = 0; i < g.GetLength(0); i++)
		{
			if (g[s, i] > 0 && !visited[i])
			{
				dfs(g, i,visited);
			}
		}
		
	}

	public  static void solve(int[,] graph, int s, int t)
	{
		int u, v;
		ll = graph.Length;
		int l = graph.Length;
		int[,] nGraph = new int[l,l];
		initalize(ref nGraph, graph);
		int[] parent = new int[graph.Length];
		for(;;)
		{
            if (bfs(nGraph, s, t, parent, nGraph.Length))
            {
				int p = int.MaxValue;
				for (v = t; v != s; v = parent[v])
				{
					u = parent[v];
					p = Math.Min(p, nGraph[u, v]);
				}
				for (v = t; v != s; v = parent[v])
				{
					u = parent[v];
					nGraph[u, v] = nGraph[u, v] - p;
					nGraph[v, u] = nGraph[v, u] + p;
				}
			}
            else
            {
				break;
            }
			
		}
		bool[] isVisited = new bool[graph.Length];
		dfs(nGraph, s,isVisited);

		print(graph, isVisited);
	}

    private static void print(int[,] graph, bool[] isVisited)
    {
		for (int i = 0; i < graph.GetLength(0); i++)
		{
			for (int j = 0; j < graph.GetLength(1); j++)
			{
				if (graph[i, j] > 0 &&
					isVisited[i] && !isVisited[j])
				{
					Console.WriteLine(i + " - " + j);
				}
			}
		}
	}
	public static bool bfs(int[,] ngraph, int s, int d, int[] parents, int l)
	{
		bool[] visited = new bool[l];
		LinkedList<int> linked_list = new LinkedList<int>();
		int c = 0;
		visited[s] = true;
		parents[s] = -1;
		linked_list.AddLast(s);
		foreach (var item in visited)
		{
			visited[c] = false;
			c++;
		}
		while (linked_list.Count != 0)
		{
			int ss = linked_list.First();
			linked_list.RemoveFirst();
			int i = 0;
			while (i < ngraph.GetLength(0))
			{
				if (ngraph[ss, i] > 0 && visited[i] == false)
				{
					linked_list.AddLast(i);
					visited[i] = true;
					parents[i] = ss;
				}
				i++;
			}
		}
		return (visited[d] == true);

	}
	private static void initalize(ref int[,] nGraph, int[,] graph)
    {
		for (int i = 0; i < graph.GetLength(0); i++)
		{
			for (int j = 0; j < graph.GetLength(1); j++)
			{
				nGraph[i, j] = graph[i, j];
			}
		}
	}

    public static void Main(String[] args)
	{
		int n = int.Parse(Console.ReadLine());
		int source = int.Parse(Console.ReadLine());
		int destination = int.Parse(Console.ReadLine());
		int[,] graph = new int[n, n];
		bool is_negative = false;
        while (is_negative == false)
        {
			string[] edge = Console.ReadLine().Split();
            if (int.Parse(edge[0]) == -1)
            {
				is_negative = true;
				break;
            }
			int s = int.Parse(edge[0]);
			int d = int.Parse(edge[1]);
			int w = int.Parse(edge[2]);
			graph[s, d] = w;
		}
		solve(graph,source, destination);
		ll = 0;
		//Array.Clear(visited,0,visited.Length);
	}
}
