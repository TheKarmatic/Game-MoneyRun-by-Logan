using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class EndScreenMenu : MonoBehaviour
{
    GameManager manager;

    public GameObject panel, title, explanation, scoreboard, quitButton;

    void Start()
    {
        manager = GameObject.Find("GameManager").GetComponent<GameManager>();

        //Victory changes
        if (manager.lives != 0)
        {
            //Panel changes
            panel.GetComponent<Image>().color = Color.yellow;

            //Title changes
            title.GetComponent<TextMeshProUGUI>().text = "Victory!";

            //Explanation changes
            explanation.GetComponent<TextMeshProUGUI>().text = "You made it to your flat! Hell of a run to get here isn't it!? Blame that dahm game designer. Anyway, thanks for playing! Try to make me arrive earlier next time... if you can that is... noob.";

            //Scoreboard changes
            scoreboard.GetComponent<TextMeshProUGUI>().text = "Time: " + manager.currentTimer.ToString("f2") + "     Score: " + manager.score + "     Deaths: " + (3 - manager.lives);
        }

        else
        {
            //Panel changes
            panel.GetComponent<Image>().color = Color.red;

            //Title changes
            title.GetComponent<TextMeshProUGUI>().text = "Defeat!";

            //Explanation changes
            explanation.GetComponent<TextMeshProUGUI>().text = "Dahm, you really suck. You didn't know you could press escape to skip levels? That's pathetic. Try again idiot or forever know that you can't beat this simple game...";

            //Scoreboard changes
            scoreboard.GetComponent<TextMeshProUGUI>().text = "Time: " + manager.currentTimer.ToString("f2") + "     Score: " + manager.score + "     Deaths: " + (3 - manager.lives);
        }
    }

    //Quit button
    public void GoBackToMainMenu()
    {
        manager.Invoke("GoBackToMainMenu", 0f);
    }
}
