using System;
using System.Collections.Generic;
namespace ConsoleApp2
{
    class node
    {

        public char value;
        public int number;
        public bool visited;
        public int answer;
        public node(char value, int number,bool visited)
        {
            this.value = value;
            this.number = number;
            this.visited = visited;
        }
    }
    class Program3
    {
        public static int rows;
        public static int columns;
        static void Main2(string[] args)
        {
            int counter = 0;
            List<node> mm = new List<node>();
            string[] two = Console.ReadLine().Split();
            rows = int.Parse(two[0]);
            columns = int.Parse(two[1]);
            for (int i = 0; i < rows; i++)
            {
                var tmp = (Console.ReadLine()).ToCharArray();
                for (int j = 0; j < tmp.Length; j++)
                {
                    node n = new node(tmp[j], counter,false);
                    counter++;
                    mm.Add(n);
                }
            }
            //solve(mm,0);
            for (int i = 0; i < rows*columns; i++)
            {
                if (mm[i].value == '*')
                {
                    int ans = solve(mm, i);
                    false_visit(mm);

                    mm[i].answer = ans % 10;
                    cnt = 0;
                }
            }
            for (int i = 0; i < rows * columns; i++)
            {

                if ((i) % columns == 0)
                {
                    Console.Write("\n");
                }
                if(mm[i].value == '*')
                {
                    Console.Write(mm[i].answer);
                }
                else{

                    Console.Write('.');
                }
            }

        }
        public static int cnt ;
        private static int solve(List<node> mm, int v)
        {
            if (mm[v].visited == false)
            {
                cnt++;

            }
            mm[v].visited = true; 
            List<int> neighbors = new List<int>();
            neighbors = set_neighbors(mm,v);
            if (neighbors.Count == 0)
            {
                return cnt;
            }
            for (int i = 0; i < neighbors.Count; i++)
            {
                solve(mm, neighbors[i]);
            }
            return cnt;
        }

        private static void false_visit(List<node> mm)
        {
            for (int i = 0; i < mm.Count; i++)
            {
                if (mm[i].value != '*')
                {
                    mm[i].visited = false;
                }
            }
        }

        private static List<int> set_neighbors(List<node> mm,int v)
        {
            int left;
            int right;
            int up;
            int down;
            List<int> tmp_neighbors = new List<int>();
            if ((v+1) % columns == 0)
            {

            }
            else  
            {
                right = v + 1;
                if(mm[right].visited == false && mm[right].value != '*')
                {
                    tmp_neighbors.Add(right);

                }
            }
            if ((v /*- 1*/) % columns == 0 || v == 0)
            {

            }
            else
            {
                left = v - 1;
                if (mm[left].visited == false && mm[left].value != '*')
                {
                    tmp_neighbors.Add(left);
                }
            }
            if (v < columns)
            {

            }
            else
            {
                up = v - columns;
                if (mm[up].visited == false && mm[up].value != '*')
                {
                    tmp_neighbors.Add(up);
                }
            }
            if (v >= (rows * columns) - columns)
            {

            }
            else
            {
                down = v + columns;
                if (mm[down].visited == false && mm[down].value != '*')
                {
                    tmp_neighbors.Add(down);
                }
            }
            return tmp_neighbors;
        }
    }
}
