using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    GameManager gameManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameManagerScript = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<TextMeshProUGUI>().text = "Level: " + gameManagerScript.currentScene + "     Time: " + gameManagerScript.currentTimer.ToString("f2") + "     Score: " + gameManagerScript.score + "     Lives: " + gameManagerScript.lives;
    }
}
