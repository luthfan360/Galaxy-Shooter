using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    Player player;
    [SerializeField]
    Text scoreText;
    [SerializeField]
    Image livesImage;
    [SerializeField]
    Sprite[] liveSprites;
    [SerializeField]
    Text gameOverText;
    [SerializeField]
    Text restartHint;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        int score = player.score;
        scoreText.text = $"SCORE : {score}";
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
