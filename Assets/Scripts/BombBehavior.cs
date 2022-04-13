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
            if (!PositionPartner.IsHidden || PositionPartner.CanMove)
            {
                CanMove = false;
            }
        }

        base.Update();
    }
}
