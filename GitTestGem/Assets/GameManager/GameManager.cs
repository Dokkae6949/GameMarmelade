using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int randomSeed = 1707;

    [Header("Level Generation")]
    public int maxAmountOfRooms = 12;
    public int currentAmountOfRooms = 0;

    void Awake()
    {
        Random.seed = randomSeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
