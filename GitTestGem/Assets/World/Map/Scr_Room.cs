using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Room : MonoBehaviour
{
    [SerializeField] private GameObject objectParant;
    [Tooltip("Assign in order -> North, East, South, West")]
    [SerializeField] private bool northSpawner, eastSpawner, southSpawner, westSpawner;
    [SerializeField] private float roomLenght;
    [SerializeField] private GameObject[] northRooms, eastRooms, southRooms, westRooms;

    void Start()
    {
        if (northSpawner==true) 
            Instantiate(northRooms[Random.Range(0, northRooms.Length)], new Vector2(transform.position.x, transform.position.x + roomLenght), Quaternion.identity);
        if (eastSpawner == true)
            Instantiate(eastRooms[Random.Range(0, eastRooms.Length)], new Vector2(transform.position.x + roomLenght, transform.position.x), Quaternion.identity);
        if (southSpawner == true)
            Instantiate(southRooms[Random.Range(0, southRooms.Length)], new Vector2(transform.position.x, transform.position.x - roomLenght), Quaternion.identity);
        if (westSpawner == true)
            Instantiate(westRooms[Random.Range(0, westRooms.Length)], new Vector2(transform.position.x - roomLenght, transform.position.x), Quaternion.identity);
    }
}
