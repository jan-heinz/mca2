using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

    public static bool isGameOver = false;
    public float levelDuration = 15.0f;
    public string sameLevel;
    public string nextLevel;
    public Text timerText;
    public Text scoreText;
    public Text gameStateText; 
    public AudioClip gameOverSFX;
    public AudioClip gameWonSFX;
    public float countDown;

    GameObject player;


    
    
    // Start is called before the first frame update
    void Start() {
        countDown = levelDuration;
        isGameOver = false;
        player = GameObject.FindGameObjectWithTag("Player");
        
        setTimerText();
        setScoreText();
    }

    // Update is called once per frame
    void Update() {
        if (!isGameOver) {
            if (countDown > 0) {
                countDown -= Time.deltaTime;
            } else {
                LevelLost();
            }

            if (player.transform.position.y <= 0) {
                LevelLost();
            }
        }

        setTimerText();
        setScoreText();
    }

    public void LevelLost() {
        isGameOver = true;
        gameStateText.text = "Game Over";
        gameStateText.gameObject.SetActive(true);

        Camera.main.GetComponent<AudioSource>().pitch = 1;
        AudioSource.PlayClipAtPoint(gameOverSFX, Camera.main.transform.position);
        
        Invoke("LoadSameLevel", 2);
    }

    public void LevelBeat() {
        isGameOver = true;
        gameStateText.text = "Game Won";
        gameStateText.gameObject.SetActive(true);
        
        Camera.main.GetComponent<AudioSource>().pitch = 2;
        AudioSource.PlayClipAtPoint(gameWonSFX, Camera.main.transform.position);
        
        Invoke("LoadNextLevel", 2);

    }

    void LoadSameLevel() {
        SceneManager.LoadScene(sameLevel);
    }
    
    void LoadNextLevel() {
        SceneManager.LoadScene(nextLevel);
    }

    private void setTimerText() {
        timerText.text = "Time Left: " + countDown.ToString("f2");
    }

    private void setScoreText() {
        scoreText.text = "Score: " + PickupBehavior.score.ToString();
    }
}
