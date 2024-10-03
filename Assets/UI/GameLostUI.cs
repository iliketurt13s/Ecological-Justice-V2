using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameLostUI : MonoBehaviour
{
    public SpriteRenderer wasteImage;
    public SpriteRenderer logoImage;
    public TMP_Text wasteName;

    public TMP_Text scoreText;
    public TMP_Text highScoreText;
    public LogicManager lm;

    public Sprite aluminumLogo;
    public Sprite compostLogo;
    public Sprite landfillLogo;

    [HideInInspector] public bool animating = false;
    public float animationMoveSpeed;
    public float animationScaleSpeed;

    void FixedUpdate()
    {
        scoreText.text = "Score: " + lm.score;
        if (lm.score >= PlayerPrefs.GetFloat("highscore")){PlayerPrefs.SetFloat("highscore", lm.score);}
        if (PlayerPrefs.HasKey("highscore")){
            highScoreText.text = "High Score: " + PlayerPrefs.GetFloat("highscore");
        } else {
            highScoreText.text = "No high scores logged";
        }
        if (animating){
            float y = Mathf.Lerp(transform.position.y, 0, animationMoveSpeed);
            transform.position = new Vector3(transform.position.x, y, transform.position.x);

            float scale = Mathf.Lerp(transform.localScale.x, 1f, animationScaleSpeed);
            transform.localScale = new Vector3(scale, scale, scale);
        }
    }

    public void setUI(Sprite wasteSprite, string wasteType, string name){
        wasteImage.sprite = wasteSprite;
        wasteName.text = name;
        if (wasteType == "compost"){logoImage.sprite = compostLogo;}
        if (wasteType == "landfill"){logoImage.sprite = landfillLogo;}
        if (wasteType == "aluminum"){logoImage.sprite = aluminumLogo;}
        animating = true;
    }

    public void RESTART(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
