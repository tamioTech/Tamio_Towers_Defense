using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class Coordinates_Labeller : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates;

    private void Awake()
    {
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }


    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
        }
    }

    private void DisplayCoordinates()
    {
        coordinates.x = (int)transform.position.x / (int)UnityEditor.EditorSnapSettings.move.x;
        coordinates.y = (int)transform.position.z / (int)UnityEditor.EditorSnapSettings.move.z;
        label.text = coordinates.x + "," + coordinates.y;
        UpdateObjectName();
    }

    private void UpdateObjectName()
    {
        transform.parent.name = coordinates.x.ToString() + "," + coordinates.y.ToString();
    }
}
