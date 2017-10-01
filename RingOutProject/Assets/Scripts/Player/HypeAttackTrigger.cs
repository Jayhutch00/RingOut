﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HypeAttackTrigger : TriggerManager
{

    protected override void ActivateTriggers(Collider hitbox)
    {
        if(hitbox.name == opponentsHitbox)
        {
            if (player.IsHyped && !player.Opponent.IsDefending)
            {
                 player.Opponent.IsHypeHit = true;
                 Debug.Log(player.Opponent.name + " was hype hit!");
            }
        }

    }
}
