﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recursion46
{
    class Program
    {
        static int neighboors(char[,] map, int row, int col)
        {
            int temp = neighboorsRecursion(map, row, col);
            for (int i = 0; i < map.GetLength(0); ++i)
                for (int j = 0; j < map.GetLength(1); ++j)
                    if (map[i, j] == 'y')
                        map[i, j] = 'x';
            return temp;
        }
        static int neighboorsRecursion(char[,] map, int row, int col)
        {
            if (row < 0 || row >= map.GetLength(0) ||
                col < 0 || col >= map.GetLength(1))
                return 0;
            if (map[row, col] != 'x')
                return 0;
            map[row, col] = 'y';
            return 1 +
                neighboorsRecursion(map, row - 1, col) + // Up
                neighboorsRecursion(map, row + 1, col) + // Down
                neighboorsRecursion(map, row, col - 1) + // Left
                neighboorsRecursion(map, row, col + 1);  // Right
            /*
            int sum = 1;
            map[row, col] = 'y';
            // Up
            if (row > 0)
                sum += neighboors(map, row - 1, col);
            // Down
            if (row < map.GetUpperBound(0))
                sum += neighboors(map, row + 1, col);
            // Left
            if (col > 0)
                sum += neighboors(map, row, col - 1);
            // Right
            if (col < map.GetUpperBound(1))
                sum += neighboors(map, row, col + 1);
            return sum;
            */
        }

        static void print(char[,]map)
        {
            for (int i = 0; i < map.GetLength(0); ++i)
            {
                for (int j = 0; j < map.GetLength(1); ++j)
                    Console.Write(" " + map[i, j]);
                Console.WriteLine();
            }
        }

        static void Main(string[] args)
        {
            char[,] yards = {
                    { ' ', ' ', ' ', 'x', 'x', ' ', ' ' },
                    { 'x', ' ', ' ', 'x', 'x', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', 'x', 'x', ' ' },
                    { ' ', ' ', ' ', ' ', 'x', ' ', ' ' },
                    { ' ', ' ', ' ', ' ', ' ', ' ', ' ' },
                    { ' ', 'x', 'x', 'x', 'x', ' ', ' ' },
                    { 'x', ' ', ' ', 'x', ' ', ' ', ' ' }
                };

            // char[,] matrix = new char[7, 6];
            while (true)
            {
                Console.WriteLine("Please enter row and column number:");
                int col = 0, row = 0;
                try
                {
                    row = int.Parse(Console.ReadLine());
                    if (row == -1)
                        return;
                    col = int.Parse(Console.ReadLine());
                    if (col == -1)
                        return;
                }
                catch (Exception)
                {
                    Console.WriteLine("Bad input!");
                    continue;
                }
                Console.WriteLine("For yard {1}-{2} there are {0} total neighboors",
                    neighboors(yards, row, col), row, col);
            }
        }

    }
}
