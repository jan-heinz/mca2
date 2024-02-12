using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public float levelDuration = 15.0f;
    public float countDown;
    public string nextLevel;
    public Text timerText;
    public Text scoreText;

    
    
    // Start is called before the first frame update
    void Start() {
        countDown = levelDuration;
        
        setTimerText();
        setScoreText();
    }

    // Update is called once per frame
    void Update()
    {
        // if game not over
        if (countDown > 0) {
            countDown -= Time.deltaTime;
        }
        else {
            countDown = 0.0f;
            // level lost
        }
        setTimerText();
        setScoreText();
    }

    private void setTimerText() {
        timerText.text = "Time Left: " + countDown.ToString("f2");
    }

    private void setScoreText() {
        scoreText.text = "Score: " + PickupBehavior.score.ToString();
    }
}
