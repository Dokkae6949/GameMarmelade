using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public float maxDistanceToPlayer;
    public float spawnDelay;
    public float refreshRate;
    public GameObject[] topRooms, rightRooms, bottomRooms, leftRooms;
    public int[,] randomRoomsValue = new int[9000,9000];

    [Header("Special Room Settings")]
    [SerializeField] private int shopRoomIndex;

    private void Awake()
    {
        for (int x = 0; x < 9000; x++)
        {
            for (int y = 0; y < 9000; y++)
            {
                if (x == 4500 && y == 4500) {
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
