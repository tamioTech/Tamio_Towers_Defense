using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] float timeBetweenEnemySpawn = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewEnemy());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnNewEnemy()
    {
        while (true)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenEnemySpawn);
        }

    }
}
