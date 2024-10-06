using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bin : MonoBehaviour
{
    public LogicManager lm;
    public GameLostUI glui;
    public GameObject sortedParticle;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == gameObject.tag){
            lm.addPoints();
            Instantiate(sortedParticle, new Vector3(collision.transform.position.x, -6f, 0f), Quaternion.identity);
            Destroy(collision.gameObject);
        } else {
            if (collision.tag == "compost" || collision.tag == "aluminum" || collision.tag == "landfill"){
                if (!glui.animating){
                    glui.setUI(collision.GetComponent<SpriteRenderer>().sprite, collision.tag, collision.GetComponent<DragAndDrop>().wasteName);
                    lm.gameLost();
                }
            }
        }
    }
}
