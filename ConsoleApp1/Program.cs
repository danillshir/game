﻿
using System;

public class GFG
{

    public static void Main()
    {
        int M = 10, N = 10;
        int[,] grid = {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 1, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 1, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        Console.WriteLine("Original Generation");
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (grid[i, j] == 0)
                    Console.Write(".");
                else
                    Console.Write("*");
            }
            Console.WriteLine();
        }
        Console.WriteLine();
        nextGeneration(grid, M, N);
    }

    static void nextGeneration(int[,] grid,
                               int M, int N)
    {
        int[,] future = new int[M, N];
        for (int l = 1; l < M - 1; l++)
        {
            for (int m = 1; m < N - 1; m++)
            {
                int aliveNeighbours = 0;
                for (int i = -1; i <= 1; i++)
                    for (int j = -1; j <= 1; j++)
                        aliveNeighbours +=
                                grid[l + i, m + j];
                aliveNeighbours -= grid[l, m];
                if ((grid[l, m] == 1) &&
                            (aliveNeighbours < 2))
                    future[l, m] = 0;

                else if ((grid[l, m] == 1) &&
                             (aliveNeighbours > 3))
                    future[l, m] = 0;

                else if ((grid[l, m] == 0) &&
                            (aliveNeighbours == 3))
                    future[l, m] = 1;

                else
                    future[l, m] = grid[l, m];
            }
        }

        Console.WriteLine("Next Generation");
        for (int i = 0; i < M; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (future[i, j] == 0)
                    Console.Write(".");
                else
                    Console.Write("*");
            }
            Console.WriteLine();
        }

        Console.ReadKey();
    }
}