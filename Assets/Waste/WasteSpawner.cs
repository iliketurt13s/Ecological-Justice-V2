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
        Invoke("spawn", 3f);
    }

    void spawn()
    {
        if (!lm.gameOver){
            Instantiate(waste[Random.Range(0, waste.Length)], new Vector3(Random.Range(-8f, 8f), 8f, 0f), Quaternion.identity);
            if (spawnCooldown > 1f){spawnCooldown -= 0.015f;}
            else if (spawnCooldown > 0.5f){spawnCooldown -= 0.005f;}
            print(spawnCooldown);
            Invoke("spawn", spawnCooldown);
        }
    }
}
