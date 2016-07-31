using UnityEngine;
using System.Collections;

public class Tree : MonoBehaviour
{

    private float velocity;

    void Start()
    {
        velocity = Random.Range(0.5f, 2.0f);
        GetComponent<SpriteRenderer>().sortingOrder = 2;
    }

    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * velocity;
    }
}
