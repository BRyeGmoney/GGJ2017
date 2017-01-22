using System.Collections;
using System.Collections.Generic;

public class PuzzleGeneration {
    int[,] puzzle1 = new int[2, 2] { { 0, 1 },
                                     { 1, 0 }};

    int[,] puzzle2 = new int[3, 2] { { 1, 0 },
                                     { 1, 0 },
                                     { 0, 1 }};

    List<int[,]> puzzles = new List<int[,]>();

    public PuzzleGeneration()
    {
        puzzles.Add(puzzle1);
        puzzles.Add(puzzle2);
    }

    /// <summary>
    /// yo, this should be a seed for a generator but for now it will be the puzzle number in the pre-designed list of puzzles
    /// </summary>
    /// <param name="difficulty"></param>
    public int[,] GenerateAPuzzle(int difficulty) 
    {
        return puzzles[difficulty];
    }
}
