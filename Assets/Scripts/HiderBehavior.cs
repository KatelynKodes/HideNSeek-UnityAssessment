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
        CanMove = true;
    }

    public override void Update()
    {
        if (CanMove && SharesPosition)
        {
            if (PositionPartner.IsHidden|| PositionPartner.CanMove)
            {
                CanMove = false;
            }
        }

        base.Update();
    }
}
