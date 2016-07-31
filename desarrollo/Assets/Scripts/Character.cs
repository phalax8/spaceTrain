using UnityEngine;
using System.Collections;
using System;

public class Character : MonoBehaviour, IListener
{

    private float velocity = 1.0f;
    private bool pause = false;

    public void OnEvent(EVENT_TYPE Event_Type, Component Sender, System.Object Param = null)
    {
        switch (Event_Type)
        {
            case EVENT_TYPE.GAME_PAUSE:
                //OnHealthChange(Sender, (int)Param);
                pause = true;
                break;
        }
    }

    void Start()
    {
        GetComponent<SpriteRenderer>().sortingOrder = 3;

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
