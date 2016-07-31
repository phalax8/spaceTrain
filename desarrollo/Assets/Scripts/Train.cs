using UnityEngine;
using UnityEngine.EventSystems;

public class Train : MonoBehaviour
{
    Vector3 offSet;

    void OnMouseDown()
    {
        Vector3 clickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        offSet = transform.position - clickedPos;
        offSet.z = 0.0f;
    }

    void OnMouseDrag()
    {
        Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(mousepos.x, mousepos.y, 0.0f) + offSet;
    }
}