using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDisable : MonoBehaviour
{
    [SerializeField] private float maxDistance;
    [SerializeField] private float refreshRate;
    private Transform playerTransform;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        InvokeRepeating("CheckDist", refreshRate, refreshRate);
    }

    void CheckDist()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            GameObject child = transform.GetChild(i).gameObject;
            if (Vector3.Distance(child.transform.position, playerTransform.position) >= maxDistance)
                Destroy(child);
        }
    }
}
