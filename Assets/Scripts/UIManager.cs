using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Player player;
    [SerializeField]
    Text scoreText, bestScoreText;
    [SerializeField]
    Image livesImage;
    [SerializeField]
    Sprite[] liveSprites;
    [SerializeField]
    Text gameOverText;
    [SerializeField]
    Text restartHint;
    int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        bestScore = PlayerPrefs.GetInt("HighScore", 0);
    }

    // Update is called once per frame
    void Update()
    {
        int score = player.score;
        scoreText.text = $"SCORE : {score}";
        bestScoreText.text = $"BEST : {bestScore}";

        checkBestScore();
    }

    public void updateLives(int currentLives)
    {
        livesImage.sprite = liveSprites[currentLives];

        if (currentLives < 1)
        {
            restartHint.gameObject.SetActive(true);
            StartCoroutine(gameOverFlicker());
        }
    }

    void checkBestScore()
    {
        if (player.score > bestScore)
        {
            bestScore = player.score;
            PlayerPrefs.SetInt("HighScore", bestScore);
        }
    }

    IEnumerator gameOverFlicker()
    {
        while (true)
        {
            gameOverText.gameObject.SetActive(true);
            yield return new WaitForSeconds(0.5f);
            gameOverText.gameObject.SetActive(false);
            yield return new WaitForSeconds(0.5f);
        }
    }
}
