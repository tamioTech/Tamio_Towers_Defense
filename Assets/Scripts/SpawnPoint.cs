using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenenemyPrefabSpawn = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnNewenemyPrefab());
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnNewenemyPrefab()
    {
        while (true)
        {
            Instantiate(enemyPrefab, transform.position, Quaternion.identity);
            yield return new WaitForSeconds(timeBetweenenemyPrefabSpawn);
        }

    }
}
