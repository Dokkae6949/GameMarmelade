using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float maxDistanceToPlayer;
    public int worldSizeX, worldSizeY;
    public float spawnDelay;
    public float refreshRate;
    public GameObject[] topRooms, rightRooms, bottomRooms, leftRooms;
    public int[,] randomRoomsValue;

    [Header("Special Room Settings")]
    [SerializeField] private int shopRoomIndex;

    private void Awake()
    {
        randomRoomsValue = new int[worldSizeX, worldSizeY];

        for (int x = 0; x < worldSizeX; x++)
        {
            for (int y = 0; y < worldSizeY; y++)
            {
                if (x == worldSizeX/2 && y == worldSizeY/2) {
                    randomRoomsValue[x, y] = 7; // start room is tyoe TBLR
                    continue;
                } 
                if (Random.value < .98f) // 2% chance of special room
                    randomRoomsValue[x, y] = Random.Range(0, topRooms.Length - 1); // random index for basic room
                else
                    randomRoomsValue[x, y] = shopRoomIndex; // shop index
            }
        }
    }
}