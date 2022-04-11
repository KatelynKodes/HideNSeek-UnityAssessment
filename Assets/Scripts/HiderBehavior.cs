using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderBehavior : MonoBehaviour
{

    [SerializeField]
    private Transform _moveTarget;
    private float _moveTime = 0.0f;
    private float _moveTimer = 1.0f;

    //Positions
    Vector3 _startingPos;
    Vector3 _targetPos;

    private GameManager _gameManager;
    private bool _isHidden = true;
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

    public void Update()
    {

        //If it can move...
        if (CanMove)
        {
            //If it's hidden
            if (IsHidden)
            {
                //Move Towards the players line of sight
                MovePosition(_startingPos, _targetPos, _moveTime);
            }
            else
            {
                //Move away from the players line of sight
                MovePosition(_targetPos, _startingPos, _moveTime);
            }

            _moveTime += Time.deltaTime;

            if (_moveTime >= _moveTimer)
            {
                CanMove = false;
                _moveTime = 0.0f;
            }
        }
        else
        {
            if (RoundPosition(transform.position) == RoundPosition(_startingPos))
            {
                IsHidden = true;
            }
            else if (RoundPosition(transform.position) == RoundPosition(transform.position))
            {
                IsHidden = false;
            }
        }
    }

    private Vector3 RoundPosition(Vector3 position)
    {
        float posX = Mathf.Round(position.x * 100) / 100;
        float posY = Mathf.Round(position.y * 100) / 100;
        float posZ = Mathf.Round(position.z * 100) / 100;
        return new Vector3(posX, posY, posZ);
    }
}
