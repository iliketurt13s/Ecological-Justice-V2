using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroyer : MonoBehaviour
{
    public float waitTime;
    void Start()
    {
        Invoke("destroy", waitTime);
    }

    void destroy()
    {
        Destroy(gameObject);
    }
}
