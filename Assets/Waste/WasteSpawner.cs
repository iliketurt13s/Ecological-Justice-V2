using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteSpawner : MonoBehaviour
{
    public GameObject[] waste;
    public float spawnCooldownStart;
    float spawnCooldown;
    public LogicManager lm;
    
    void Start()
    {
        spawnCooldown = spawnCooldownStart;
        Invoke("spawn", 5f);
    }

    void spawn()
    {
        if (!lm.gameOver){
            Instantiate(waste[Random.Range(0, waste.Length)], new Vector3(Random.Range(-8f, 8f), 8f, 0f), Quaternion.identity);
            if (spawnCooldown > 0.5) spawnCooldown -= 0.015f;
            Invoke("spawn", spawnCooldown);
        }
    }
}
