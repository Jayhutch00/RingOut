﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
    [SerializeField]
    private BoxCollider hypeAttackHitBox;
    [SerializeField]
    private BoxCollider attackHitBox;
    [SerializeField]
    private BoxCollider torso;
    [SerializeField]
    private BoxCollider blockArea;
    private BoxCollider ground;
    //Player Reference
    private Player player;
   //delay between active attacks
    [SerializeField]
    private WaitForSeconds delay;

    public BoxCollider Torso
    {
        get {return torso; }
        set {torso = value; }
    }

    private void Awake()
    {
        delay = new WaitForSeconds(.50f);
        player = GetComponentInParent<Player>();
        torso.name += player.ID.ToString();
        blockArea.name += player.ID.ToString();
    }
    private void LateUpdate()
    {
        CloseBlockArea();
    }

    #region HitBoxLogic
    private void OpenHitBox()
    {
        
        if (player.IsGrounded)
        {
            attackHitBox.enabled = true;
            player.AttackCounter++;
            
        }
        else
            attackHitBox.enabled = true;
        StartCoroutine("CloseHitBoxes"); // this disables the hitbox incase the animation event did not
        
    }
    private void CloseHitBox()
    {
        attackHitBox.enabled = false;
        hypeAttackHitBox.enabled = false;
        player.CanMove = true;
    }
    private void OpenBlockArea()
    {
        blockArea.enabled = true;
        player.CanMove = false;
    }
    private void CloseBlockArea()
    {
        if(!player.IsDefending)
        blockArea.enabled = false;
        player.CanMove = true;
    }
    private void OpenHypeHitBox()
    {
        if (player.IsGrounded)
        {
            hypeAttackHitBox.enabled = true;
            StartCoroutine("CloseHype"); // this disables the hitbox incase the animation event did not

        }
    }
    private IEnumerator CloseHype()
    {
        yield return delay;
        player.IsHyped = false;
        CloseHitBox();
    }
    private IEnumerator CloseHitBoxes()
    {
        yield return delay;
        CloseHitBox();
    }
    #endregion
}
