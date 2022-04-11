using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HidingSpotBehavior : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Hider"))
        {
            other.gameObject.GetComponent<HiderBehavior>().IsHidden = true;
        }
    }
}
