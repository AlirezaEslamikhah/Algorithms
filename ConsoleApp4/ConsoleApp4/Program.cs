using System;
using System.Linq;
namespace ConsoleApp4
{
    class Program
    {
        static void Main222(string[] args)
        {
            string[] first = Console.ReadLine().Split();
            int vn =int.Parse( first[0]);
            int signal = int.Parse(first[1]);
            int edges = int.Parse(first[2]);
            Tuple<int,bool>[] result = new Tuple<int, bool>[vn];
            for (int i = 0; i < result.Length; i++)
            {
                Tuple<int, bool> a = new Tuple<int, bool>(int.MaxValue, false);
                result[i] = a;
            }
            int[,] graph = new int[vn, vn];
            for (int i = 0; i < edges; i++)
            {
                string[] a = Console.ReadLine().Split();
                int src = int.Parse(a[0]);
                int des = int.Parse(a[1]);
                int weight = int.Parse(a[2]);
                if (src == signal)
                {
                    Tuple<int, bool> b = new Tuple<int, bool>(weight, false);
                    result[des - 1] = b;
                    //result[des - 1] = weight;
                }
                graph[src-1, des-1] = weight;
            }
            dijkstra(graph, result, vn, signal, edges);
        }

        private static void dijkstra(int[,] graph, Tuple<int, bool>[] result, int vn, int signal, int edges)
        {
            bool flag = true;
            int max = 0;
            for (int i = 0; i < result.Length-1; i++)
            {
                int min = min_result(result, signal);
                if (min == -1)
                {
                    max = -1;
                    flag = false;
                    break;
                }
                result[min] = new Tuple<int, bool>(result[min].Item1, true);
                for (int j = 0; j < vn; j++)
                {
                    if (graph[min,j] != 0 && result[min].Item1 + graph[min,j] < result[j].Item1 && !result[j].Item2 )
                    {
                        //result[j].Item1 = result[i].Item1 + graph[min, j];
                        result[j] = new Tuple<int, bool>(result[min].Item1 + graph[min, j], false);
                    }
                }
            }
            if (flag == true)
            {
                for (int i = 0; i < result.Length; i++)
                {
                    if (result[i].Item1 >= max && result[i].Item2 == true)
                    {
                        max = result[i].Item1;
                    }
                }
            }
            Console.WriteLine(max);
        }

        private static int min_result(Tuple<int, bool>[] result, int signal)
        {
            int ans = int.MaxValue;
            int min_index = -1;
            //result[0] = new Tuple<int, bool>(result[0].Item1, true);
            for (int i = 0; i < result.Length; i++)
            {
                if (result[i].Item1 < ans && result[i].Item2 == false && i+1 !=signal)
                {

                    min_index = i;
                    ans = result[i].Item1;
                    //ans = result[i].Item1;
                    //result[i].Item2 = true;
                }
            }
            //result[min_index] = new Tuple<int, bool>(result[min_index].Item1, true);
            if (ans == int.MaxValue)
            {
                return -1;
            }
            return min_index;
        }
    }
}
