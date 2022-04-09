using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    [SerializeField]
    private TextMeshProUGUI _livesText;
    [SerializeField]
    private GameObject _losingPanel;
    [SerializeField]
    private TextMeshProUGUI _losingScoreText;
    
    private int _score = 0;
    private int _lives = 4;
    private bool _gameOver = false;

    public int Score { get{ return _score; } set { _score = value; } }
    public int Lives { get { return _lives; } set { _lives = value; } }

    private void Update()
    {
        if (_gameOver)
        {
            ShowLosingScreen();
        }
        else
        {
            _scoreText.text = "Score: " + Score;
            _livesText.text = "Lives: " + Lives;
        }
    }

    /// <summary>
    /// Displays the losing screen to the player and disables certain scripts;
    /// </summary>
    private void ShowLosingScreen()
    { 
        _losingScoreText.text = "Final Score: " + Score;
        _losingPanel.SetActive(true);
    }

    /// <summary>
    /// Restarts the game
    /// </summary>
    public void RestartGame()
    { 

    }
}
