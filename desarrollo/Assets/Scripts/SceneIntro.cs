using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

public class SceneIntro : MonoBehaviour, IScene
{
    public void LoadTexts(Dictionary<string, string> texts)
    {
    }

    public void preLoad(float horzExtentCam, float vertExtentCam)
    {
    }

    public bool startScene()
    {
        return true;
    }
}
