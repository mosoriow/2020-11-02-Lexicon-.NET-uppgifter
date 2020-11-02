using System;
using System.Collections.Generic;
using System.Linq;

namespace Matrix_Layer_Rotation_v2
{
    class Program
    {
        static void matrixRotation(List<List<int>> matrix, int r)
        {
            int m = matrix.Count;
            int n = matrix[0].Count;

            int[][] rotated = new int[m][];
            for (int i = 0; i < m; i++)
            {
                rotated[i] = new int[n];
                for (int j = 0; j < n; j++)
                {
                    rotated[i][j] = matrix[i][j];
                }
            }

            int min = m;
            if (n < min) min = n;
            int deep = min / 2;
            for (int d = 0; d < deep; d++)
            {
                int perimeter = 2 * ((m - 2 * d) + (n - 2 * d - 2));

                int revNumber = r % perimeter;
                for (int oneRev = 0; oneRev < revNumber; oneRev++) // one rotation at the time
                {
                    int tmpValue = rotated[d][d];
                    int i;
                    int j;

                    i = d;
                    for (j = d; j < n - d - 1; j++)
                        rotated[i][j] = rotated[i][j + 1];

                    j = n - d - 1;
                    for (i = d; i < m - d - 1; i++)
                        rotated[i][j] = rotated[i + 1][j];

                    i = m - d - 1;
                    for (j = n - d - 1; j > d; j--)
                        rotated[i][j] = rotated[i][j - 1];

                    j = d;
                    for (i = m - d - 1; i > d; i--)
                        rotated[i][j] = rotated[i - 1][j];

                    rotated[i + 1][j] = tmpValue;
                }
            }

            for (int i = 0; i < m; i++)
            {
                Console.Write(rotated[i][0]);
                for (int j = 1; j < n; j++)
                    Console.Write(" {0}", rotated[i][j]);
                Console.WriteLine();
            }
        }


        static void Main(string[] args)
        {
            string[] mnr = Console.ReadLine().TrimEnd().Split(' ');

            int m = Convert.ToInt32(mnr[0]);

            int n = Convert.ToInt32(mnr[1]);

            int r = Convert.ToInt32(mnr[2]);

            List<List<int>> matrix = new List<List<int>>();

            for (int i = 0; i < m; i++)
            {
                matrix.Add(Console.ReadLine().TrimEnd().Split(' ').ToList().Select(matrixTemp => Convert.ToInt32(matrixTemp)).ToList());
            }

            matrixRotation(matrix, r);
        }
    }
}
