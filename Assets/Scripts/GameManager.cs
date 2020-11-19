using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int best;
    public int score;

    public static int  currentStage = 0;

    public static GameManager singleton;
    // Start is called before the first frame update
    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
            Destroy(gameObject);

        best = PlayerPrefs.GetInt("bestscore1");
    }

    public void NextLevel()
    {
        
        currentStage++;
        if (currentStage == 2) 
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            FindObjectOfType<BallController>().ResetBall();
            FindObjectOfType<HelixController>().LoadStage(currentStage);
            Debug.Log("Next Level Callied!");
        }
        
        
    }

    public void RestartLevel()
    {
        Debug.Log("Game Over");
        //Show ads
        singleton.score = 0;
        FindObjectOfType<BallController>().ResetBall();
        // Reload Stage
        FindObjectOfType<HelixController>().LoadStage(currentStage);
    }

    public void AddScore(int scoreToAdd)
    {
        score += scoreToAdd;

        if(score > best)
        {
            best = score;
            PlayerPrefs.SetInt("bestscore1", score);
        }
    }
    
}
