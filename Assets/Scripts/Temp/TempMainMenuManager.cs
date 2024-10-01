using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TempMainMenuManager : MonoBehaviour
{


    [SerializeField] private Text _scoreText;
    [SerializeField] private Text _newBestText;
    [SerializeField] private Text _HighScoreText;

    private void Awake()
    {


        if (GameManager.Instance.IsInitialized)
        {
            StartCoroutine(ShowScore());

        }
        else
        {
            _scoreText.gameObject.SetActive(false);
            _newBestText.gameObject.SetActive(false);
            _HighScoreText.text = GameManager.Instance.HighScore.ToString();
        }
    }

    [SerializeField] private float _animationTime;
    [SerializeField] private AnimationCurve _speedCurve;

    private IEnumerator ShowScore()
    {
        int tempScore = 0;
        _scoreText.text = tempScore.ToString();

        int currentScore = GameManager.Instance.CurrentScore;
        int highScore = GameManager.Instance.HighScore;

        if (highScore < currentScore)
        {
            _newBestText.gameObject.SetActive(true);
            GameManager.Instance.HighScore = currentScore;
        }
        else
        {
            _newBestText.gameObject.SetActive(false);
        }

        _HighScoreText.text = GameManager.Instance.HighScore.ToString();
        float speed = 1 / _animationTime;
        float timeElapsed = 0f;

        while (timeElapsed < 1f)
        {
            timeElapsed += speed * Time.deltaTime;
            tempScore = (int)(_speedCurve.Evaluate(timeElapsed) * currentScore);
            _scoreText.text = tempScore.ToString();
            yield return null;
        }

        tempScore = currentScore;
        _scoreText.text = tempScore.ToString();

    }

    [SerializeField] private AudioClip _clickClip;

    public void ClickedPlay()
    {
      
        GameManager.Instance.GotoGameplay();
    }
}