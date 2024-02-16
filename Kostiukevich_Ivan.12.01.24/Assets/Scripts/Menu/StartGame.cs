using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField] private GameObject trailObject;
    public GameObject startScreen;
    public GameObject loseScreen;

    void Start()
    {
        loseScreen.SetActive(false);
        Button myButton = GetComponent<Button>();
        if (myButton != null & startScreen.activeSelf & !loseScreen.activeSelf)
        {
            myButton.onClick.AddListener(Starting);
        }
        if (myButton != null & !startScreen.activeSelf & loseScreen.activeSelf)
        {
            myButton.onClick.AddListener(Restarting);
        }

    }

    public void Starting()
    {
        trailObject.SetActive(true);
        startScreen.SetActive(false);
        PlatformMove[] platformMoves = FindObjectsOfType<PlatformMove>();
        foreach (PlatformMove platformMove in platformMoves)
        {
            platformMove.StartMoving();
        }

    }

    public void Restarting()
    {
        loseScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        startScreen.SetActive(true);
    }

}
