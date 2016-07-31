using UnityEngine;
using System.Collections;
using System;

public class Star : MonoBehaviour, IListener
{

    private float velocity;
    private bool pause = false;

    public void OnEvent(EVENT_TYPE Event_Type, Component Sender, System.Object Param = null)
    {
        switch (Event_Type)
        {
            case EVENT_TYPE.GAME_PAUSE:
                pause = true;
                break;
        }
    }

    void Start()
    {
        velocity = UnityEngine.Random.Range(0.5f, 4.0f);
        GetComponent<SpriteRenderer>().sortingOrder = 1;

        EventManager.Instance.AddListener(EVENT_TYPE.GAME_PAUSE, this);
    }

    void Update()
    {
        if (!pause)
        {
            transform.position += Vector3.left * Time.deltaTime * velocity;
        }
    }
}
