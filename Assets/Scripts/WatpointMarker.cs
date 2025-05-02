using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WatpointMarker : MonoBehaviour
{
    public Image waypointImg;
    public Transform targetTransform;
    public TextMeshProUGUI distanceText;
    void Update()
    {
        float minX = waypointImg.GetPixelAdjustedRect().width / 2;
        float maxX = Screen.width - minX;
        float minY = waypointImg.GetPixelAdjustedRect().height / 2;  
        float maxY = Screen.height - minY;
        Vector2 pos = Camera.main.WorldToScreenPoint(targetTransform.position);

        if(Vector3.Dot((targetTransform.position - transform.position) , transform.forward ) < 0)
        {
            if(pos.x < Screen.width / 2)
            {
                pos.x = maxX;
            }
            else
            {
                pos.x = minX;
            }
        }

        pos.x = Mathf.Clamp(pos.x,minX,maxX);
        pos.y = Mathf.Clamp(pos.y,minY,maxY);

        waypointImg.transform.position = pos;
        distanceText.text = ((int)Vector3.Distance(targetTransform.position,transform.position)).ToString() + "m";
    }
}
