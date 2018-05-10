﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{

    [Header("Basic Dash Requirements")]
    public float dashSpeed = 50;
    public GameObject dashEffect;

    private Rigidbody target;
    private Vector3 directionVector;

    // Use this for initialization
    void Start()
    {
        target = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (StaticPlayerData.stopPlayerMovement)
            return;

        float currentDashes = StaticPlayerData.currentDashes;
        float dashUseRate = StaticPlayerData.dashUseRate;
        if (Input.GetButtonDown("Dash") && currentDashes - dashUseRate >= 0)
        {
            StaticPlayerData.currentDashes -= dashUseRate;
            directionVector = gameObject.transform.forward;
            gameObject.transform.SetParent(null);
            target.AddForce(directionVector * dashSpeed, ForceMode.Impulse);
            Instantiate(dashEffect, gameObject.transform.position, dashEffect.transform.rotation);
        }
    }
}
