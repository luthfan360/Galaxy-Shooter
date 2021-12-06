using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    int speed = 5;
    [SerializeField]
    int PowerUpID;
    Player player;
    
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        if (transform.position.y < -10f)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.tag == "Player")
        {
            switch (PowerUpID)
            {
                case 0:
                    player.enableTripleShot();
                    break;
                case 1:
                    player.enableSpeedBoost();
                    break;
                case 2:
                    player.enableShield();
                    break;
            }
            player.PowerUpSound();
            Destroy(this.gameObject);
        }
    }
}
