using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[ExecuteAlways]
[RequireComponent(typeof(TextMeshPro))]
public class CoordinateLabel : MonoBehaviour
{
    [SerializeField] Color defaultColor = Color.white;
    [SerializeField] Color blockedColor = Color.black;

    TextMeshPro coordinateText;
    Waypoints waypoints;

    void Awake() 
    {
        coordinateText = GetComponent<TextMeshPro>();    
        coordinateText.enabled = false;

        waypoints = GetComponentInParent<Waypoints>();
        DisplayCoordinates();
    }

    void Update() 
    {
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
            coordinateText.enabled = true;
        }

        SetLabelColor();
        ToggleLabels();
    }

    void ToggleLabels()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            coordinateText.enabled = !coordinateText.IsActive();

            //if(coordinateText.enabled == true)
            //{
            //    coordinateText.enabled = false;
            //}
            //if(coordinateText.enabled == false)
            //{
            //    coordinateText.enabled = true;
            //}
        }
    }

    void SetLabelColor()
    {
        if(waypoints.IsPlaceable)
        {
            coordinateText.color = defaultColor;
        }
        else
        {
            coordinateText.color = blockedColor;
        }
    }

    void DisplayCoordinates()
    {
        Vector2Int parentTransform = new Vector2Int();
        parentTransform.x = Mathf.RoundToInt(transform.parent.position.x) / 10;
        parentTransform.y = Mathf.RoundToInt(transform.parent.position.z) / 10;

        coordinateText.text = parentTransform.x + "," + parentTransform.y;
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinateText.text.ToString();
    }
}
