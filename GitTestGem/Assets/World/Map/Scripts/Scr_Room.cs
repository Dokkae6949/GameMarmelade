using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scr_Room : MonoBehaviour
{
    [SerializeField] private LayerMask roomLayermask;
    [SerializeField] private float roomLenght;
    [SerializeField] private bool topSpawner, rightSpawner, bottomSpawner, leftSpawner;

    private Transform playerTransform;
    private Transform objectParant;
    private LevelGenerator levelGenerator;



    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        objectParant = GameObject.FindGameObjectWithTag("LevelGenerator").GetComponent<Transform>();
        levelGenerator = objectParant.GetComponent<LevelGenerator>();

        InvokeRepeating("Spawn", levelGenerator.spawnDelay, levelGenerator.refreshRate);
    }

    void Spawn()
    {
        float distance = Vector3.Distance(transform.position, playerTransform.position);

        if (distance+roomLenght <= levelGenerator.maxDistanceToPlayer)
        {
            bool isRoom = false;

            if (topSpawner == true)
            {
                isRoom = false;
                Vector3 spawn = new Vector3(transform.position.x, transform.position.y, transform.position.z + roomLenght);
                if (spawn.z <= 4500)
                {
                    Collider[] hitColliders = Physics.OverlapBox(spawn, new Vector3(1f, 1f, 1f), Quaternion.identity, roomLayermask, QueryTriggerInteraction.Collide);
                    foreach (var collider in hitColliders)
                        if (collider.CompareTag("Room")) isRoom = true;
                    GameObject prefab = levelGenerator.bottomRooms[levelGenerator.randomRoomsValue[(int)transform.position.x / 20 + 4500, (int)(transform.position.z + 20) / 20 + 4500]];
                    if (isRoom != true) Instantiate(prefab, spawn, prefab.transform.rotation, objectParant);
                }
            }

            if (rightSpawner == true)
            {
                isRoom = false;
                Vector3 spawn = new Vector3(transform.position.x + roomLenght, transform.position.y, transform.position.z);
                if (spawn.x <= 4500)
                {
                    Collider[] hitColliders = Physics.OverlapBox(spawn, new Vector3(1f, 1f, 1f), Quaternion.identity, roomLayermask, QueryTriggerInteraction.Collide);
                    foreach (var collider in hitColliders)
                        if (collider.CompareTag("Room")) isRoom = true;
                    GameObject prefab = levelGenerator.leftRooms[levelGenerator.randomRoomsValue[(int)(transform.position.x + 20) / 20 + 4500, (int)transform.position.z / 20 + 4500]];
                    if (isRoom != true) Instantiate(prefab, spawn, prefab.transform.rotation, objectParant);
                }
            }

            if (bottomSpawner == true)
            {
                isRoom = false;
                Vector3 spawn = new Vector3(transform.position.x, transform.position.y, transform.position.z - roomLenght);
                if (spawn.z >= -4500)
                {
                    Collider[] hitColliders = Physics.OverlapBox(spawn, new Vector3(1f, 1f, 1f), Quaternion.identity, roomLayermask, QueryTriggerInteraction.Collide);
                    foreach (var collider in hitColliders)
                        if (collider.CompareTag("Room")) isRoom = true;
                    GameObject prefab = levelGenerator.topRooms[levelGenerator.randomRoomsValue[(int)transform.position.x / 20 + 4500, (int)(transform.position.z - 20) / 20 + 4500]];
                    if (isRoom != true) Instantiate(prefab, spawn, prefab.transform.rotation, objectParant);
                }
            }

            if (leftSpawner == true)
            {
                isRoom = false;
                Vector3 spawn = new Vector3(transform.position.x - roomLenght, transform.position.y, transform.position.z);
                if (spawn.x >= -4500)
                {
                    Collider[] hitColliders = Physics.OverlapBox(spawn, new Vector3(1f, 1f, 1f), Quaternion.identity, roomLayermask, QueryTriggerInteraction.Collide);
                    foreach (var collider in hitColliders)
                        if (collider.CompareTag("Room")) isRoom = true;
                    GameObject prefab = levelGenerator.rightRooms[levelGenerator.randomRoomsValue[(int)(transform.position.x - 20) / 20 + 4500, (int)(transform.position.z) / 20 + 4500]];
                    if (isRoom != true) Instantiate(prefab, spawn, prefab.transform.rotation, objectParant);
                }
            }
        }
        else Destroy(this.gameObject);
    }
}
