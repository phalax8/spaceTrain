using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class SceneMain : MonoBehaviour, IScene, IListener
{
    private bool startSceneDone = false;
    List<GameObject> Stars;
    public GameObject Star;
    public GameObject Tree1;
    public GameObject Tree2;
    public GameObject Tree3;
    public GameObject Tree4;
    public GameObject Tree5;
    public GameObject Tree6;
    public GameObject Character1;
    public GameObject Character2;
    public GameObject Character3;
    public GameObject Character4;
    public GameObject Character5;
    public GameObject Character6;
    public GameObject Character7;
    public GameObject Character8;
    int totalStarts = 50;
    float vertExtent;
    float horzExtent;
    GameObject countDown;
    CountDown scriptCountDown;
    GameObject train;
    int totalTrees = 7;
    List<GameObject> Trees;
    List<GameObject> Characters;

    public void OnEvent(EVENT_TYPE Event_Type, Component Sender, System.Object Param = null)
    {
        switch (Event_Type)
        {
            case EVENT_TYPE.CAM_UPDATE:
                Dictionary<string, float> Coords = (Dictionary<string, float>) Param;
                horzExtent = Coords["horizontal"];
                vertExtent = Coords["vertical"];
                break;

            case EVENT_TYPE.SCENE_TEXTS:
                Dictionary<string, string> Texts = (Dictionary<string, string>)Param;
                LoadTexts(Texts);
                break;
        }
    }

    void Start()
    {
        EventManager.Instance.AddListener(EVENT_TYPE.CAM_UPDATE, this);
        EventManager.Instance.AddListener(EVENT_TYPE.SCENE_TEXTS, this);

        countDown = GameObject.Find("CountDown");
        scriptCountDown = countDown.GetComponent<CountDown>();

        train = GameObject.Find("Train");
        train.SetActive(false);
    }

    void Update()
    {
        if (!startSceneDone)
        {
            if (countDown.activeSelf)
            {
                scriptCountDown.startCountDown();
            }
            else
            {
                createStars();
                createTrees();
                StartCoroutine(createCharaters());
                train.SetActive(true);
                GameObject.Find("Time").GetComponent<TimeText>().play();
                startSceneDone = true;
            }

        }
    }

    public void LoadTexts(Dictionary<string, string> texts)
    {
        GameObject.Find("Passangers").GetComponent<UnityEngine.UI.Text>().text = texts["pasajeros"];
        scriptCountDown.TxtAdelante = texts["adelante"];
    }

    public void createTrees()
    {
        Trees = new List<GameObject>();
        GameObject[] typeTrees = new GameObject[6] { Tree1, Tree2, Tree3, Tree4, Tree5, Tree6 };
        int indexTree = 0;

        GameObject tree;

        for (int i = 0; i < totalTrees; i++)
        {
            Vector3 vector = new Vector3(UnityEngine.Random.Range(vertExtent + 5, vertExtent * 3), UnityEngine.Random.Range(-vertExtent, vertExtent), 0);

            tree = (GameObject)Instantiate(typeTrees[indexTree], vector, Quaternion.identity);
            Trees.Add(tree);
            indexTree = indexTree == 5 ? 0 : indexTree + 1;
        }
    }

    public void createStars()
    {
        Stars = new List<GameObject>();

        GameObject starObject;

        for (int i = 0; i < totalStarts; i++)
        {
            Vector3 vector = new Vector3(UnityEngine.Random.Range(-horzExtent, horzExtent), UnityEngine.Random.Range(-vertExtent, vertExtent), 0);

            starObject = (GameObject)Instantiate(Star, vector, Quaternion.identity);
            Stars.Add(starObject);
        }

    }

    IEnumerator createCharaters()
    {

        GameObject character;
        Characters = new List<GameObject>();
        GameObject[] typeCharacters = new GameObject[8] { Character1, Character2, Character3, Character4, Character5, Character6, Character7, Character8 };
        int indexCharacter = 0;

        while (indexCharacter < 9)
        {
            yield return new WaitForSeconds(13.0f);

            Vector3 vector = new Vector3(vertExtent + 5, UnityEngine.Random.Range(-vertExtent, vertExtent), 0);

            character = (GameObject)Instantiate(typeCharacters[indexCharacter], vector, Quaternion.identity);
            Characters.Add(character);

            indexCharacter++;
        }

    }
}
