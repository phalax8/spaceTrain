using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour {

    private bool clicked;

    // Use this for initialization
	void Start()
    {
        clicked = false;
    }

    void Click()
    {
        if (!clicked)
        {
            GetComponent<UnityEngine.UI.Image>().CrossFadeAlpha(0.0f, 1f, false);
            Invoke("goToScene", 1);
        }

        clicked = true;
    }

    void goToScene()
    {
        GameObject.Find("GameController").GetComponent<GameController>().goToScene("Main");
    }
}
