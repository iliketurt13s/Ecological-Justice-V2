using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteSpawner : MonoBehaviour
{
    public GameObject[] waste;
    public float spawnCooldownStart;
    float spawnCooldown;
    
    void Start()
    {
        spawnCooldown = spawnCooldownStart;
        Invoke("spawn", 5f);
    }

    void spawn()
    {
        Instantiate(waste[Random.Range(0, waste.Length)], new Vector3(Random.Range(-8f, 8f), 7f, 0f), Quaternion.identity);
        Invoke("spawn", spawnCooldown);
    }
}
