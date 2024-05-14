namespace path_with_maximum_gold
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var sol = new Solution();
            var grid = new int[3][]{ [0, 6, 0], [5, 8, 7], [0, 9, 0] };
            var ans = sol.GetMaximumGold(grid);
            Console.WriteLine(ans);
        }
    }

    public class Solution
    {
        public int GetMaximumGold(int[][] grid)
        {
            var row = grid.Length;
            var column = grid[0].Length;
            int max = int.MinValue;
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < column; j++)
                {
                    if (grid[i][j] > 0)
                    {
                        var currentSum = Dfs(i, j);
                        max = Math.Max(max, currentSum);
                    }
                }
            }

            int Dfs(int r, int c)
            {
                if (r < 0 || c < 0 || r >= row || c >= column || grid[r][c] == 0) 
                {
                    return 0;
                } 
                var temp = grid[r][c];
                grid[r][c] = 0;
                var down = Dfs(r + 1, c);
                var up = Dfs(r - 1, c);
                var right = Dfs(r, c + 1);
                var left = Dfs(r, c - 1);
                var localMax = new int[]{ left, right, up, down }.Max();
                grid[r][c] = temp;
                return localMax + temp;
            }

            return max;
        }
    }
}
