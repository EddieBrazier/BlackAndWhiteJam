﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyScript : MonoBehaviour
{
    #region Fields
    protected int health;
    [SerializeField] protected int MAX_HEALTH;

    protected float attackCooldown;
    [SerializeField] protected float MAX_CD;

    protected bool OnScreen;

    //Position
    protected Vector3 position;

    #endregion

    #region References
    [SerializeReference] protected Player player;
    protected Camera cam;
    protected float camHalfWidth;
    protected float camHalfHeight;
    #endregion


    #region Properties
    public int Health { get { return health; } set { health = value; } }
    #endregion

    // Start is called before the first frame update
    protected virtual void Start()
    {
        cam = Camera.main;
        camHalfHeight = cam.orthographicSize;
        camHalfWidth = camHalfHeight * cam.aspect;
        position = transform.position;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        transform.position = position;
        WithinCamera();
    }

    private void FixedUpdate()
    {
        
    }

    /// <summary>
    /// Abstract method used to attack the player.
    /// </summary>
    public virtual void Attack()
    {
        Debug.Log("Attack method in " + this.gameObject + " is not overwritten.");
    }

    /// <summary>
    /// Abstract method that dictates this character's movement pattern.
    /// </summary>
    public virtual void Movement()
    {
        Debug.Log("Movement method in " + this.gameObject + " is not overwritten.");
    }

    /// <summary>
    /// Method called when this character takes damage.
    /// </summary>
    public virtual void TakeDamage(int damage)
    {
        health -= damage;
    }


    #region HelperMethods
    protected void WithinCamera()
    {
        //Testing if the enemy position is within the screen bounds
        if(position.x > cam.transform.position.x - camHalfWidth && position.x < cam.transform.position.x + camHalfWidth &&
            position.y > cam.transform.position.y - camHalfHeight && position.y < cam.transform.position.y + camHalfHeight)
        {
            OnScreen = true;
        }
        else
        {
            OnScreen = false;
        }
    }
    #endregion

}
