using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvalidSpotBehavior : MonoBehaviour
{
    private GameManager _gameManager;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        _gameManager.Lives--;
    }
}
