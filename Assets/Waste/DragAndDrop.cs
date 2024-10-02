using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool isDragging = false;
    public float followSpeed;

    public string name;

    void Start(){
        float scaleFactor = Random.Range(-0.05f, 0.05f);
        transform.localScale = new Vector3(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor, 1);
    }
    
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (isDragging){
            Vector3 cameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 target = new Vector3(cameraPos.x, cameraPos.y, 0);
            Vector3 dir = target - transform.position;
            Vector3 velToAdd = (dir * followSpeed * Time.deltaTime);
            rb.AddForce(new Vector2(velToAdd.x, velToAdd.y), ForceMode2D.Impulse);
            //rb.gravityScale = 0f;
        } else {
            //rb.gravityScale = 0.025f;
        }
    }

    void OnMouseDown(){
        isDragging = true;
    }
    void OnMouseUp(){
        isDragging = false;
    }
}
