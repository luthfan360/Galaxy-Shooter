using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    int speed = 5;
    Player player;
    Animator anim;
    BoxCollider2D enemyCollider;
    AudioSource audioSource;
    [SerializeField]
    GameObject enemyLaserPrefab;
    [SerializeField]
    AudioClip explosionSound;
    [SerializeField]
    AudioClip laserSound;
    [SerializeField]
    bool enemyAlive = true;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        anim = GetComponent<Animator>();
        enemyCollider = GetComponent<BoxCollider2D>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(ShootLaser());
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
            EnemyDestroyed();
            Destroy(other.gameObject);
        }
        if (other.tag == "Player")
        {
            EnemyDestroyed();
            player.Damaged();
        }
    }

    void EnemyDestroyed()
    {
        enemyAlive = false;
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        Destroy(this.gameObject, 2.7f); 
        player.addScore();
        anim.SetTrigger("EnemyHit");
        enemyCollider.enabled = false;
        audioSource.clip = explosionSound;
        audioSource.Play();
    }

    IEnumerator ShootLaser()
    {
        while (enemyAlive == true)
        {
            float randomInterval = Random.Range(1f, 3f);
            yield return new WaitForSeconds(randomInterval);

            if (enemyAlive == true)
            {
                Instantiate(enemyLaserPrefab, transform.position, Quaternion.identity);
                audioSource.clip = laserSound;
                audioSource.Play();
            }
        }
    }
}
