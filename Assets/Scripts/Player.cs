using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    int speed = 5;
    [SerializeField]
    int lives = 3;
    [SerializeField]
    public int score = 0;
    [SerializeField]
    float fireRate = 0.25f;
    [SerializeField]
    float laserShot = 0f;
    [SerializeField]
    bool tripleShotEnabled = false;
    [SerializeField]
    public bool shieldEnabled = false;
    [SerializeField]
    GameObject tripleShotPrefab;
    [SerializeField]
    GameObject laserPrefab;
    [SerializeField]
    GameObject playerShield;
    SpawnManager spawnManager; 
    UIManager UIManager;
    GameManager gameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        UIManager = GameObject.Find("UIManager").GetComponent<UIManager>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>(); 
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
        Shoot();
    }

    void CalculateMovement()
    {
        float xInput = Input.GetAxis("Horizontal");
        float yInput = Input.GetAxis("Vertical");

        Vector3 direction = new Vector3(xInput, yInput, 0);

        transform.Translate(direction * speed * Time.deltaTime);

        if (transform.position.x > 9.3f)
        {
            transform.position = new Vector3(9.3f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.3f)
        {
            transform.position = new Vector3(-9.3f, transform.position.y, 0);
        }

        if (transform.position.y > 5f)
        {
            transform.position = new Vector3(transform.position.x, 5f, 0);
        }
        else if (transform.position.y < -5f)
        {
            transform.position = new Vector3(transform.position.x, -5f, 0);
        }
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space) && tripleShotEnabled == true)
        {
            Instantiate(tripleShotPrefab, transform.position, Quaternion.identity);
        }
        else if (Input.GetKeyDown(KeyCode.Space) && Time.time > laserShot)
        {
            laserShot = Time.time + fireRate;
            Instantiate(laserPrefab, transform.position, Quaternion.identity);
        }
    }

    public void addScore()
    {
        score += 10;
    }

    public void Damaged()
    {
        if (shieldEnabled == true)
        {
            shieldEnabled = false;
            playerShield.SetActive(false);
            return;
        }
        
        lives -= 1;

        UIManager.updateLives(lives);

        if (lives < 1)
        {
            Destroy(this.gameObject);
            spawnManager.gameOver = true;
            gameManager.GameOver();
        }
    }

    public void enableTripleShot()
    {
        tripleShotEnabled = true;
        StartCoroutine(disableTripleShot());
    }

    IEnumerator disableTripleShot()
    {
        yield return new WaitForSeconds(5);
        tripleShotEnabled = false;
    }

    public void enableSpeedBoost()
    {
        speed *= 2;
        StartCoroutine(disableSpeedBoost());
    }

    IEnumerator disableSpeedBoost()
    {
        yield return new WaitForSeconds(5);
        speed /= 2;
    }

    public void enableShield()
    {
        shieldEnabled = true;
        playerShield.SetActive(true);
    }
}
