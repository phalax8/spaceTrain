using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;

public class TimeText : MonoBehaviour {

    public int seconds = 180;
    private enum state {STOP, PLAY, PAUSE};
    private state actualState = state.STOP;

    IEnumerator refreshTime()
    {
        TimeSpan timeSpan;

        while (actualState == state.PLAY && seconds >= 0)
        {
            timeSpan = TimeSpan.FromSeconds(seconds);
            GetComponent<Text>().text = string.Format("{0:D1}:{1:D2}", timeSpan.Minutes, timeSpan.Seconds);
            seconds--;
            yield return new WaitForSeconds(1.0f);
        }
    }

    public void play()
    {
        actualState = state.PLAY;
        StartCoroutine(refreshTime());
    }

    public void stop()
    {
        actualState = state.STOP;
    }

    public void pause()
    {
        actualState = state.PAUSE;
    }
}
