using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoringSystem : MonoBehaviour
{
    public GameObject scoreText;
    public GameObject highscoreText;

    public int score = 0;
    public int highscore = 0;

    // Start is called before the first frame update
    void Start()
    {
        highscore = PlayerPrefs.GetInt("highscore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.GetComponent<Text>().text = score + " LUMENS";
        highscoreText.GetComponent<Text>().text = "HIGHSCORE: " + highscore;
    }

    void AddForce()
    {
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
        }
    }
    public void Highscore()
    {
        PlayerPrefs.SetInt("highscore", highscore);
    }
}
