using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;

    [Tooltip("Destroys bullet after time")]
    [SerializeField] private float destroyDelay;

    /// <summary>
    /// Sent when another object enters a trigger collider attached to this
    /// object (2D physics only).
    /// </summary>
    /// <param name="other">The other Collider2D involved in this collison.</param>

    void Start()
    {
        StartCoroutine("DestroyAfterTime", destroyDelay);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        switch(other.gameObject.tag)
        {
            case "structure":
            Destroy(gameObject);
            break;
        }
    }

    IEnumerator DestroyAfterTime(float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(gameObject);
    }
}
