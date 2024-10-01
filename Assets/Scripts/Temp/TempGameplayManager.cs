using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TempGameplayManager : MonoBehaviour
{
    private int score;  // Changed to int
    private bool hasGameFinished;
    [SerializeField] private Text _scoreText;

    private void Awake()
    {
        GameManager.Instance.IsInitialized = true;
        hasGameFinished = false;
        score = 0;
        _scoreText.text = score.ToString();  // No need to cast to int
    }

    private void Update()
    {
        if (hasGameFinished) return;
        //_scoreText.text = score.ToString();  // No need to cast to int
    }

    public void GameEnded()
    {
        hasGameFinished = true;
        GameManager.Instance.CurrentScore = score;
        StartCoroutine(GameOver());
    }

    private IEnumerator GameOver()
    {
        yield return new WaitForSeconds(2f);
        GameManager.Instance.GotoMainMenu();
    }

    // Method to update the score
    public void UpdateScore(int newScore)
    {
        score = newScore;
        _scoreText.text = score.ToString();
    }

    // Method to get the current score
    public int GetScore()
    {
        return score;
    }
}
