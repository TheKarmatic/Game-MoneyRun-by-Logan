using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int lives = 3;

    public int score = 0;
    int previousScore = 0;

    public float currentTimer = 0;

    public int currentScene;

    public bool start;

    static GameManager instance;

    // Start is called before the first frame update
    void Start()
    {
        currentScene = SceneManager.GetActiveScene().buildIndex;

        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        GameObject.DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (start)
            Timer();
    }

    void Timer()
    {
        currentTimer += Time.deltaTime;
    }

    void LoadNext()
    {
        previousScore = score;
        start = false;
        currentScene = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void ReloadScene()
    {
        score = previousScore;
        start = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void LoadEndScenePrematurely()
    {
        start = false;
        SceneManager.LoadScene("End");
    }

    public void GoBackToMainMenu()
    {
        SceneManager.LoadScene("Start");
        Destroy(gameObject);
    }
}
