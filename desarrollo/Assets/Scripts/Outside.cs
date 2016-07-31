using UnityEngine;
using System.Collections;

public class Outside : MonoBehaviour {

    float vertExtent;
    float horzExtent;

    void Awake()
    {
        Camera MainCam = Camera.main;

        vertExtent = MainCam.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;

        transform.position = new Vector3(-horzExtent - 3, transform.position.y, transform.position.z);
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Character")
        {
            Destroy(other);
        }else
        {
            other.transform.position = new Vector3(horzExtent + 3, Random.Range(-vertExtent, vertExtent), 0);
        }
    }
}
