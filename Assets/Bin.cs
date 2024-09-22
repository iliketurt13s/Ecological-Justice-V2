using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public LogicManager lm;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == gameObject.tag){
            lm.addPoints();
            Destroy(collision.gameObject);
        } else {
            if (collision.tag == "compost" || collision.tag == "aluminum" || collision.tag == "landfill"){
                lm.gameLost();
            }
        }
    }
}
