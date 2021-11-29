using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int speed = 5;
    Player player;
    Animator anim;
    BoxCollider2D collider;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        collider = GetComponent<BoxCollider2D>();
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
        if (other.tag == "Laser")
        {
            Destroy(this.gameObject, 2.7f);
            Destroy(other.gameObject);
            player.addScore();
            anim.SetTrigger("EnemyHit");
            collider.enabled = false;
        }
        if (other.tag == "Player")
        {
            Destroy(this.gameObject, 2.7f);
            player.Damaged();
            player.addScore();
            anim.SetTrigger("EnemyHit");
            collider.enabled = false;
        }
    }
}
