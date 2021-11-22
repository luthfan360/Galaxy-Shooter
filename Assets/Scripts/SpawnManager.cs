using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    GameObject enemyPrefab;
    [SerializeField]
    GameObject[] powerUpPrefab;
    public bool gameOver = false;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(spawnEnemy());
        StartCoroutine(spawnPowerUp());
    }

    // Update is called once per frame
    void Update()
    {
    
    }

    int randomizer()
    {
        int random = Random.Range(0, 150);
        if (random % 3 == 0)
        {
            return 2;
        }
        else if (random % 2 == 0)
        {
            return 1;
        }
        else
        {
            return 0;
        }
    }

    IEnumerator spawnEnemy()
    {
        while (gameOver == false)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9f, 9f), 10, 0);
            Instantiate(enemyPrefab, spawnPosition, Quaternion.identity);
            int randomInterval = Random.Range(3, 7);
            yield return new WaitForSeconds(randomInterval);
        }
    }

    IEnumerator spawnPowerUp()
    {
        while (gameOver == false)
        {
            Vector3 spawnPosition = new Vector3(Random.Range(-9f, 9f), 10, 0);
            Instantiate(powerUpPrefab[randomizer()], spawnPosition, Quaternion.identity);
            int randomInterval = Random.Range(7, 10);
            yield return new WaitForSeconds(randomInterval);
        }
    }


}
