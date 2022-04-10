using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderBehavior : MovementBehavior
{

    [SerializeField]
    private Transform _moveTarget;
    [SerializeField]
    private float _hideDelayTime = 5.0f;
    [SerializeField]
    private float _speed = 5.0f;

    //Positions
    Vector3 _currentPos;
    Vector3 _startingPos;
    Vector3 _moveDir;

    private GameManager _gameManager;
    private float _timer = 0.0f;
    private bool _isHidden = true;

    private void Awake()
    {
        _gameManager = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        _currentPos = transform.position;
        _startingPos = transform.position;
    }

    /// <summary>
    /// Will increase the score of the gamemanager
    /// </summary>
    private void OnMouseDown()
    {
        _gameManager.Score++;
    }

    public override void Update()
    {
        if (_timer >= _hideDelayTime)
        {
            if (_isHidden)
            {
                _moveDir = _moveTarget.position;
                GetVelocity(_currentPos, _moveDir, _speed);
                base.Update();
                _currentPos = _moveTarget.position;
                _isHidden = false;
                _timer = 0.0f;
            }
            else
            {
                GetVelocity(_currentPos, _startingPos, _speed);
                base.Update();
                _currentPos = _startingPos;
                _isHidden = true;
                _timer = 0.0f;
            }
        }

        _timer += Time.deltaTime;
    }
}
