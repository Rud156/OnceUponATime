﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EZCameraShake;

public class ShakeCameraOnTrigger : MonoBehaviour
{
    [Header("Camera Shake Elements")]
    public float magnitude;
    public float roughness;
    public float fadeInTime = 0.1f;
    public float fadeOutTime = 2;

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        Rigidbody target = other.GetComponent<Rigidbody>();
        if (!target || !other.CompareTag("Player"))
            return;

        CameraShaker.Instance.ShakeOnce(magnitude, roughness, fadeInTime, fadeOutTime);
		gameObject.SetActive(false);
    }
}
