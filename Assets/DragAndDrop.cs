using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    bool isDragging = false;
    public float followSpeed;
    
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (isDragging){
            Vector3 cameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 target = new Vector3(cameraPos.x, cameraPos.y, 0);
            Vector3 dir = target - transform.position;
            rb.MovePosition(transform.position + (dir * followSpeed * Time.deltaTime));
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
