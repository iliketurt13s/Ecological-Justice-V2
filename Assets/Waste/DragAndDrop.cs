using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DragAndDrop : MonoBehaviour
{
    bool isDragging = false;
    public float followSpeed;

    public string wasteName;

    public RectTransform nameUI;
    public TMP_Text nameText;
    public float nameUIScaleSpeed;

    void Start(){
        float scaleFactor = Random.Range(-0.05f, 0.05f);
        transform.localScale = new Vector3(transform.localScale.x + scaleFactor, transform.localScale.y + scaleFactor, 1);
        nameText.text = wasteName;
    }
    
    void Update()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float lerpedValue = 0;
        if (isDragging){
            Vector3 cameraPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 target = new Vector3(cameraPos.x, cameraPos.y, 0);
            Vector3 dir = target - transform.position;
            Vector3 velToAdd = (dir * followSpeed * Time.deltaTime);
            rb.AddForce(new Vector2(velToAdd.x, velToAdd.y), ForceMode2D.Impulse);
            
            lerpedValue = Mathf.Lerp(nameUI.localScale.x, 1, nameUIScaleSpeed);
        } else {
            lerpedValue = Mathf.Lerp(nameUI.localScale.x, 0, nameUIScaleSpeed);
        }
        nameUI.localScale = new Vector3(lerpedValue, lerpedValue, lerpedValue);
    }

    void OnMouseDown(){
        isDragging = true;
    }
    void OnMouseUp(){
        isDragging = false;
    }
}
