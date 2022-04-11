using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderBehavior : MovementBehavior
{

    [SerializeField]
    private Transform _moveTarget;
    private float _moveTime = 0.0f;
    private float _moveTimer = 1.0f;

    //Positions
    Vector3 _startingPos;
    Vector3 _targetPos;

    private GameManager _gameManager;
    private bool _isHidden;
    private bool _canMove = false;

    public bool IsHidden { get { return _isHidden; } set { _isHidden = value; } }
    public bool CanMove { get { return _canMove; } set { _canMove = value; } }

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _startingPos = transform.position;
        _targetPos = _moveTarget.position;
    }

    /// <summary>
    /// Will increase the score of the gamemanager
    /// </summary>
    private void OnMouseDown()
    {
        _gameManager.Score++;
    }

    /// <summary>
    /// Moves the position of the hider
    /// </summary>
    /// <param name="startPos"> the starting position </param>
    /// <param name="endPos"> the ending position </param>
    /// <param name="time"> the amount of time the joruney takes </param>
    public void MovePosition(Vector3 startPos, Vector3 endPos, float time)
    {
        transform.position = Vector3.Lerp(startPos, endPos, time);
    }

    public override void Update()
    {
        if (CanMove)
        {
            if (IsHidden)
            {
                MovePosition(_startingPos, _targetPos, _moveTime);
            }
            else
            {
                MovePosition(_targetPos, _startingPos, _moveTime);
            }

            _moveTime += Time.deltaTime;

            if (_moveTime >= _moveTimer)
            {
                CanMove = false;
                _moveTime = 0.0f;
            }
        }
    }
}
