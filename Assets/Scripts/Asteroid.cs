using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    [SerializeField]
    int rotationSpeed = 5;
    [SerializeField]
    GameObject explosionPrefab;
    [SerializeField]
    SpawnManager spawnManager;

    // Start is called before the first frame update
    void Start()
    {
        spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            Destroy(this.gameObject, 1f);
            Destroy(other.gameObject);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            spawnManager.StartSpawning();
        }
        else if (other.tag == "Player")
        {
            Destroy(this.gameObject, 1f);
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Player player = other.GetComponent<Player>();
            player.Damaged();
            spawnManager.StartSpawning();
        }
    }
}
