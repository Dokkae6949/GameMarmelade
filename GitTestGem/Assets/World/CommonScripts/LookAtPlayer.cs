using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    private Transform targetTransform;

    private void Awake()
    {
        targetTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        Vector3 target = new Vector3(targetTransform.position.x, transform.position.y, targetTransform.position.z);
        transform.LookAt(target, Vector3.up);
    }
}
