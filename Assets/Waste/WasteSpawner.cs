using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WasteSpawner : MonoBehaviour
{
    public GameObject[] waste;
    public float spawnCooldownStart;
    public float spawnCooldown;
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
            if (spawnCooldown > 1.25f){spawnCooldown -= 0.75f;}
            else if (spawnCooldown > 0.75f){spawnCooldown -= 0.005f;}
            print(spawnCooldown);
            Invoke("spawn", spawnCooldown);
        }
    }
}
