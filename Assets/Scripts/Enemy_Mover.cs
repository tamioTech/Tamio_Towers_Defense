using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//[ExecuteAlways]
public class Enemy_Mover : MonoBehaviour
{
    [SerializeField] List<Waypoint> list;
    [SerializeField] float ramSpeed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FollowPath()
    {
        foreach (Waypoint waypoint in list)
        {
            
            Vector3 currentPosition = transform.position;
            Vector3 nextPosition = waypoint.transform.position;
            float travelPercent = 0f;

            transform.LookAt(nextPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * ramSpeed;
                transform.position = Vector3.Lerp(currentPosition, nextPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }

        
    }
}
