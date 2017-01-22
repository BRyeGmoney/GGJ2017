using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleGeneration {

    List<Puzzle> puzzles = new List<Puzzle>();

    public PuzzleGeneration()
    {
        puzzles.Add(CreatePuzzleOne());
    }

    /// <summary>
    /// yo, this should be a seed for a generator but for now it will be the puzzle number in the pre-designed list of puzzles
    /// </summary>
    /// <param name="difficulty"></param>
    public Puzzle GenerateAPuzzle(int difficulty) 
    {
        return puzzles[difficulty];
    }

    public Puzzle CreatePuzzleOne()
    {
        Puzzle puz1 = new Puzzle() { GameObjectTag = "SingleVillager", Approved = false };

        puz1.Hint1 = GenerateImage(new int[,] { { 0, 1 }, { 1, 0 }, { 1, 0 }, { 0, 1 } });
        puz1.Answer = new int[,] { { 0, 1 }, { 1, 0 }, { 0, 1 }, { 0, 1 } };
        puz1.Hint2 = GenerateImage(new int[,] { { 0, 1 }, { 1, 0 }, { 0, 1 }, { 1, 0 } });
        puz1.Hint3 = GenerateImage(new int[,] { { 1, 0 }, { 1, 0 }, { 0, 1 }, { 1, 0 } });

        return puz1;
    }

    private Texture2D GenerateImage(int[,] imageBlueprint)
    {
        Texture2D texture = new Texture2D(40, 80, TextureFormat.RGBA32, false);

        //create black
        Color blackSquare = new Color(0, 0, 0);
        Color whiteSquare = new Color(255, 255, 255);

        for (int yIndex = 0;yIndex < 4; yIndex++)
        {
            for (int xIndex = 0; xIndex < 2; xIndex++)
            {
                Debug.Log(imageBlueprint[yIndex, xIndex]);
                Color thisSquare = imageBlueprint[yIndex, xIndex] == 0 ? blackSquare : whiteSquare;
                //if (imageBlueprint[xIndex, yIndex] == 0) thisSquare = blackSquare; else thisSquare = whiteSquare;

                for (int y = 0; y < 20; y++)
                {
                    for (int x = 0; x < 20; x++)
                    {
                        texture.SetPixel(xIndex * 20 + x, yIndex * 20 + y, thisSquare);
                    }
                }
                
            }
        }

        //actually paint the stuff
        texture.Apply();

        return texture;
    }
}

public class Puzzle
{
    public string GameObjectTag; //which game object that is a part of the civilization will be giving this challenge
    public bool Approved; //whether the user has correctly solved the puzzle

    public Texture2D Hint1;
    public Texture2D Hint2;
    public Texture2D Hint3;

    public int[,] Answer;
}
