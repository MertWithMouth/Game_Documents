using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{

    [Range(0.1f,10f)] [SerializeField] float gameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 100;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] bool isAutoPlayEnabled;

    //state variables
    [SerializeField] int currentScore = 0;


    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameStatus>().Length;
        if (gameStatusCount > 1)
        {
            gameObject.SetActive(false); 
            Destroy(gameObject);
        }

        else
        {

            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        ScoreDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = gameSpeed;

    }

    public void AddToScore()
    {

        currentScore = currentScore + pointsPerBlockDestroyed;
        ScoreDisplay();
    }

    public void ScoreDisplay()
    {
        scoreText.text = currentScore.ToString();

    }

    public void Resetgame()
    {
        Destroy(gameObject);
    }


    public bool IsAutoPlayEnabled()
    {
        return isAutoPlayEnabled;


    }
}
