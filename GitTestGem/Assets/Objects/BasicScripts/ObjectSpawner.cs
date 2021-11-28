using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] prefabs;
    [SerializeField] private Transform[] spawnPositions;
    private Transform parent;

    private void Start()
    {
        if (prefabs.Length != spawnPositions.Length)
        {
            Debug.LogWarning(this + " ObjectSpawner settings not set up properly!");
            return;
        }
        
        parent = GameObject.FindGameObjectWithTag("ObjectParents").GetComponent<Transform>();

        for (int i = 0; i < spawnPositions.Length-1; i++)
        {
            Instantiate(prefabs[i], spawnPositions[i].position, prefabs[i].transform.rotation, parent);
        }
    }
}