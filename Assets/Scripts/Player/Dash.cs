﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    public float dashSpeed = 50;
    public float startDashTime = 0.3f;
    public GameObject dashEffect;

    private float currentDashTime;
    private Rigidbody target;
    private bool dashStarted;
    private Vector3 directionVector;

    // Use this for initialization
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
        dashStarted = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D) && !dashStarted)
        {
            dashStarted = true;
            currentDashTime = startDashTime;
            directionVector = gameObject.transform.forward;
            gameObject.transform.SetParent(null);
            Instantiate(dashEffect, gameObject.transform.position, dashEffect.transform.rotation);
        }
        else if (dashStarted)
        {
            if (currentDashTime <= 0)
            {
                dashStarted = false;
                target.velocity = Vector3.zero;
                directionVector = Vector3.zero;
            }
            else
            {
                currentDashTime -= Time.deltaTime;
                target.velocity = directionVector * dashSpeed;
            }
        }
    }
}
