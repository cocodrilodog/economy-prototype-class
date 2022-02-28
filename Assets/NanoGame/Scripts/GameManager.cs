using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{

    #region Public Fields

    // This is our playable character
    public GameObject Player;

    [Header("Texts")]

    // This will render the score in the screen
    public TMP_Text ScoreText;

    // This will show the current time / max time
    public TMP_Text TimeText;


    [Header("Panels")]

    // Show this when we win
    public GameObject WinPanel;

    // This will be shown when we lose
    public GameObject LosePanel;


    [Header("Settings")]

    // The score for collecting 3 emeralds
    public int MaxScore = 30;

    // When this time is over, you lose
    public float MaxTime = 5;

    #endregion


    #region Public Methods

    // This will add score to my current total.
    public void AddScore(int score)
    {
        // Increasing the score
        totalScore = totalScore + score;

        // Showing the score
        ScoreText.text = totalScore.ToString();

        if(totalScore == MaxScore)
        {
            Win();
        }
    }

    public void Lose()
    {
        Player.SetActive(false);
        Time.timeScale = 0;
        LosePanel.SetActive(true);
    }

    #endregion


    #region Unity Methods
    private void Start()
    {
        WinPanel.SetActive(false);
        LosePanel.SetActive(false);

        IEnumerator timer = Timer();
        StartCoroutine(timer);
    }

    private void Update()
    {
        TimeText.text = "Time: " + (int)Time.time + " / " + MaxTime;
    }

    #endregion


    #region Private Fields

    // Accumulated total
    private int totalScore;

    #endregion


    #region Private Methods

    private void Win()
    {
        Time.timeScale = 0;
        WinPanel.SetActive(true);
    }

    private IEnumerator Timer()
    {
        // This debug would be invoked immediatly
        Debug.Log("Coroutine begins: " + Time.time);

        // This will make the method to wait for some seconds (MaxTime)
        yield return new WaitForSeconds(MaxTime);

        // This will happen after we have waited
        Lose();

        Debug.Log("Coroutine ends: " + Time.time);
    }

    #endregion


}
