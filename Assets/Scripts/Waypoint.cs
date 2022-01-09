using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool isPlaceable;
    [SerializeField] GameObject ballista;

    private void OnMouseDown()
    {
        if (isPlaceable)
        {
            Vector2 currentTile = new Vector2(this.transform.position.x, this.transform.position.z);
            print(currentTile / 10);
            Instantiate(ballista, transform.position, Quaternion.identity);
            isPlaceable = false;
        }
    }
}
