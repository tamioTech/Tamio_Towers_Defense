using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class Enemy_Mover : MonoBehaviour
{
    [SerializeField] float ramSpeed = 1.0f;

    List<Node> path = new List<Node>();

    Enemy enemy;
    GridManager gridManager;
    PathFinding pathFinding;

    void OnEnable()
    {
        ReturnToStart();
        RecalculatePath(true);
        
        
    }

    private void Awake()
    {
        enemy = GetComponent<Enemy>();
        gridManager = FindObjectOfType<GridManager>();
        pathFinding = FindObjectOfType<PathFinding>();

    }

    private void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void RecalculatePath(bool resetPath)
    {
        Vector2Int coordinates = new Vector2Int();

        if(resetPath)
        {
            coordinates = pathFinding.StartCoordinates;
        }
        else
        {
            coordinates = gridManager.GetCoordinatesFromPosition(transform.position);
        }

        StopAllCoroutines();
        path.Clear();
        path = pathFinding.GetNewPath(coordinates);
        StartCoroutine(FollowPath());

    }

    void ReturnToStart()
    {
        transform.position = gridManager.GetPositionFromCoordinates(pathFinding.StartCoordinates);
    }

    private void FinishPath()
    {
        enemy.StealGold();
        gameObject.SetActive(false);
    }

    IEnumerator FollowPath()
    {
        for(int i = 1; i < path.Count; i++)
        {

            Vector3 currentPosition = transform.position;
            Vector3 nextPosition = gridManager.GetPositionFromCoordinates(path[i].coordinates);
            float travelPercent = 0f;

            transform.LookAt(nextPosition);

            while (travelPercent < 1f)
            {
                travelPercent += Time.deltaTime * ramSpeed;
                transform.position = Vector3.Lerp(currentPosition, nextPosition, travelPercent);
                yield return new WaitForEndOfFrame();
            }

        }

        FinishPath();

    }

}
