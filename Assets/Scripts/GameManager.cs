using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
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
    private float _timer = 0.0f;
    [SerializeField]
    private float _roundTime = 5.0f;

    //Refrences to the hiders and bombers
    private GameObject[] _hiders;
    private GameObject[] _bombers;

    public int Score { get{ return _score; } set { _score = value; } }
    public int Lives { get { return _lives; } set { _lives = value; } }

    public bool GameOver { get { return _gameOver; } set { _gameOver = value; } }

    private void Awake()
    {
        _hiders = GameObject.FindGameObjectsWithTag("Hider");
        _bombers = GameObject.FindGameObjectsWithTag("Bomb");
    }

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

            if (_timer >= _roundTime)
            {
                int randomHider = Random.Range(0, _hiders.Length);
                int randomBomb = Random.Range(0, _hiders.Length);

                //Select a random hider and bomb, set their CanMove to true
                _hiders[randomHider].GetComponent<HiderBehavior>().CanMove = true;
                _bombers[randomBomb].GetComponent<BombBehavior>().CanMove = true;

                _timer = 0.0f;
            }
            _timer += Time.deltaTime;

            if (Lives == 0)
            {
                GameOver = true;
            }
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
        Score = 0;
        Lives = 4;
        GameOver = false;

        SceneManager.LoadScene("SampleScene");
    }
}
