using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiderBehavior : MovementBehavior
{
    /// <summary>
    /// Will increase the score of the gamemanager
    /// </summary>
    private void OnMouseDown()
    {
        Manager.Score++; 
    }

    public override void Update()
    {
        if (CanMove && SharesPosition)
        {
            if (PositionPartner.RoundPosition(transform.position) == RoundPosition(MoveTarget.position))
            {
                CanMove = false;
            }
            else if (PositionPartner.CanMove == true)
            {
                CanMove = false;
            }
        }

        base.Update();
    }
}
