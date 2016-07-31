using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Xml;
using System.IO;
using System;

public class GameController : MonoBehaviour {

    Dictionary<string, string> Texts;
    private float _vertExtent;
    private float _horzExtent;
    public float vertExtent {
        get { return _vertExtent; }
        set {
            _vertExtent = value;
        }
    }
    public float horzExtent
    {
        get { return _horzExtent; }
        set {
            _horzExtent = value;  
        }
    }

    void Start()
    {
        Camera MainCam = Camera.main;
        Dictionary<string, float> Coords = new Dictionary<string, float>();

        vertExtent = MainCam.orthographicSize;
        horzExtent = vertExtent * Screen.width / Screen.height;

        Coords.Add("horizontal", horzExtent);
        Coords.Add("vertical", vertExtent);

        EventManager.Instance.PostNotification(EVENT_TYPE.CAM_UPDATE, this, Coords);

        LoadTexts(SceneManager.GetActiveScene().name);
    }

    public void goToScene(string nameScene)
    { 
        SceneManager.LoadScene(nameScene);
    }

    public void LoadTexts(string sceneName)
    {
        
        if (loadTextsFromXML(sceneName))
        {
            EventManager.Instance.PostNotification(EVENT_TYPE.SCENE_TEXTS, this, Texts);
        }
    }

    private bool loadTextsFromXML(string sceneName)
    {
        XmlDocument xmlDoc = new XmlDocument();

        TextAsset textAsset = (TextAsset) Resources.Load("Texts/" + sceneName, typeof(TextAsset));

        xmlDoc.LoadXml(textAsset.text);

        Texts = new Dictionary<string, string>();

        XmlNodeList textList = xmlDoc.GetElementsByTagName("text");

        foreach (XmlNode textItem in textList)
        {
            Texts.Add(textItem.Attributes["name"].Value, textItem.InnerText);
        }

        return true;
    }
}
