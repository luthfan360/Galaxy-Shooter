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
}
