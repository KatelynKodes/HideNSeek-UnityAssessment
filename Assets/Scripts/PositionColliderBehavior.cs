using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionColliderBehavior : MonoBehaviour
{
    private bool _isfull;

    public bool IsFull { get { return _isfull; } set { _isfull = value; } }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hider"))
        {
            other.gameObject.GetComponent<HiderBehavior>().IsHidden = false;
            IsFull = true;
        }
        else if(other.gameObject.CompareTag("Bomb"))
        {
        }
    }
}
