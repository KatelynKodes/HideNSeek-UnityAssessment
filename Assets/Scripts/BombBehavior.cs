using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombBehavior : MovementBehavior
{
    /// <summary>
    /// Will end the game
    /// </summary>
    private void OnMouseDown()
    {
        Manager.GameOver = true;
    }

    public override void Update()
    {
        if (CanMove == true && SharesPosition)
        {
            if (PositionPartner.RoundPosition(transform.position) == RoundPosition(MoveTarget.position))
            {
                PositionPartner.CanMove = true;
            }
            else if (PositionPartner.CanMove == true)
            {
                CanMove = false;
            }
        }

        base.Update();
    }
}
