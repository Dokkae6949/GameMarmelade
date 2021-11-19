using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Room : MonoBehaviour
{
    [SerializeField] private Transform playerTransform;
    [SerializeField] private float maxDistanceToPlayer;
    [SerializeField] private GameObject objectParant;
    [Tooltip("Assign in order -> North, East, South, West")]
    [SerializeField] private bool northSpawner, eastSpawner, southSpawner, westSpawner;
    [SerializeField] private float roomLenght;
    [SerializeField] private GameObject[] northRooms, eastRooms, southRooms, westRooms;

    void Start()
    {
        if (Vector3.Distance(transform.position, playerTransform.position) > maxDistanceToPlayer) Destroy(gameObject);
        else 
        {
            if (northSpawner == true)
                Instantiate(northRooms[Random.Range(0, northRooms.Length)], new Vector3(transform.position.x + roomLenght, transform.position.y, transform.position.z), Quaternion.identity, objectParant.transform);
            if (eastSpawner == true)
                Instantiate(eastRooms[Random.Range(0, eastRooms.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z - roomLenght), Quaternion.identity, objectParant.transform);
            if (southSpawner == true)
                Instantiate(southRooms[Random.Range(0, southRooms.Length)], new Vector3(transform.position.x - roomLenght, transform.position.y, transform.position.z), Quaternion.identity, objectParant.transform);
            if (westSpawner == true)
                Instantiate(westRooms[Random.Range(0, westRooms.Length)], new Vector3(transform.position.x, transform.position.y, transform.position.z + roomLenght), Quaternion.identity, objectParant.transform);
        }
    }
}
