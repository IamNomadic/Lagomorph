using UnityEngine;
using UnityEngine.Tilemaps;
using System;
using System.Collections;
using System.Collections.Generic;

public class WalkerGenerator : MonoBehaviour
{
    public enum Grid
    {
        FLOOR,
        EMPTY,
    }

    public Grid[,] gridHandler;
    public List<WalkerObject> Walkers;
    public Tilemap tilemap;
    public RuleTile Floor;
    public int MapWidth = 30;
    public int MapHeight = 30;
    public int MaximumWalkers;
    public int TileCount = default;
    public float FillPercentage = 0.4f;
    public float WaitTime = 0.05f;

    private void Start()
    {
        InitializeGrid();
    }
    void InitializeGrid()
    {
        gridHandler = new Grid[MapWidth, MapHeight];
        for (int x = 0; x < gridHandler.GetLength(0); x++)
        {
            for (int y = 0; y < gridHandler.GetLength(1); y++)
            {
                gridHandler[x, y] = Grid.EMPTY;
            }

        }
        Walkers = new List<WalkerObject>();

        Vector3Int TileCenter = new Vector3Int(gridHandler.GetLength(0) / 2, gridHandler.GetLength(1) / 2, 0);

        WalkerObject curWalker = new WalkerObject(new Vector2(TileCenter.x, TileCenter.y), GetDirection(), 0.5f);
        gridHandler[TileCenter.x, TileCenter.y] = Grid.FLOOR;
        Walkers.Add(curWalker);
        TileCount++;
        StartCoroutine(CreateFloors());
    }
    Vector2 GetDirection()
    {
        int Choice = Mathf.FloorToInt(UnityEngine.Random.value * 3.99f);
        switch (Choice)
        {
            case 0:
                return Vector2.down;
            case 1:
                return Vector2.left;
            case 2:
                return Vector2.up;
            case 3:
                return Vector2.right;
            default:
                return Vector2.zero;

        }
    }
    IEnumerator CreateFloors()
    {
        while ((float)TileCount / (float)gridHandler.Length < FillPercentage)
        {
            bool hasCreatedFloor = false; 
            foreach(WalkerObject curWalker in Walkers)
            {
                Vector3Int curPos = new Vector3Int((int)curWalker.Position.x, (int)curWalker.Position.y, 0);
                if (gridHandler[curPos.x, curPos.y] != Grid.FLOOR)
                {
                    tilemap.SetTile(curPos, Floor);
                    TileCount++;
                    gridHandler[curPos.x, curPos.y] = Grid.FLOOR;
                    hasCreatedFloor = true;
                }
            }
            ChanceToRemove();
            ChanceToRedirect();
            ChanceToCreate();
            UpdatePosition();
            if (hasCreatedFloor)
            {
                yield return new WaitForSeconds(WaitTime);
            }
        }
        
    }
    void ChanceToRemove()
    {
        int updatedCount = Walkers.Count;
        for (int i = 0; 1< updatedCount; i++)
        {
            if (UnityEngine.Random.value<Walkers[i].ChanceToChange && Walkers.Count>1)
            {
                Walkers.RemoveAt(i);
                break;
            }
        }
    }
    void ChanceToRedirect()
    {
        for (int i = 0; i< Walkers.Count; i++)
            if(UnityEngine.Random.value < Walkers[i].ChanceToChange)
            {
                WalkerObject curWalker = Walkers[i];
                curWalker.Direction = GetDirection();
                Walkers[i] = curWalker;
            }
    }
    void ChanceToCreate()
    {
        int updatedCount = Walkers.Count;
        for (int i = 0; 1 < updatedCount; i++)
        {
            if(UnityEngine.Random.value< Walkers[i].ChanceToChange && Walkers.Count<MaximumWalkers)
            {
                Vector2 newDirection = GetDirection();
                Vector2 newPosition = Walkers[i].Position;

                WalkerObject newWalker = new WalkerObject(newPosition, newDirection, 0.5f);
                Walkers.Add(newWalker);
            }


        }

    }
    void UpdatePosition()
    {
        for (int i = 0;i <Walkers.Count; i++)
        {
            WalkerObject FoundWalker = Walkers[i];
            FoundWalker.Position += FoundWalker.Direction;
            FoundWalker.Position.x = Mathf.Clamp(FoundWalker.Position.x, 1, gridHandler.GetLength(0) - 2);
            FoundWalker.Position.y = Mathf.Clamp(FoundWalker.Position.y, 1, gridHandler.GetLength(1) - 2);
            Walkers[i] = FoundWalker;
        }
    }
}
