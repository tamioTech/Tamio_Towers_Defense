using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class Coordinates_Labeller : MonoBehaviour
{
    TextMeshPro label;
    Vector2Int coordinates;
    GridManager gridmanager;


    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.grey;
    [SerializeField] Color exploredColor = Color.yellow;
    [SerializeField] Color pathColor = Color.magenta;

    bool toggleCoordinates = true;


    private void Awake()
    {
        gridmanager = FindObjectOfType<GridManager>();
        label = GetComponent<TextMeshPro>();
        DisplayCoordinates();
        label.enabled = false;
    }


    // Update is called once per frame
    void Update()
    {
        if(!Application.isPlaying)
        {
                DisplayCoordinates();
            
        }


        SetLabelColor();
        ToggleCoordinates();

    }

    private void SetLabelColor()
    {
        if(gridmanager == null) { return; }

        Node node = gridmanager.GetNode(coordinates);

        if(node == null) { return; }

        if(!node.isWalkable)
        {
            label.color = blockedColor;
        }
        else if(node.isPath)
        {
            label.color = pathColor;
        }
        else if(node.isExplored)
        {
            label.color = exploredColor;
        }
        else
        {
            label.color = defaultColor;
        }
    }

    private void ToggleCoordinates()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            label.enabled = !label.IsActive();
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
