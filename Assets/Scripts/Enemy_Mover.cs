using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Enemy_Mover : MonoBehaviour
{
    [SerializeField] List<Waypoint> list;
    [SerializeField] float waitTime = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MoveEnemyAlongPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator MoveEnemyAlongPath()
    {
        foreach (Waypoint waypoint in list)
        {
            print(waypoint);
            print(waypoint.name);
            yield return new WaitForSeconds(waitTime);
            transform.position = waypoint.transform.position;
        }

        
    }
}
