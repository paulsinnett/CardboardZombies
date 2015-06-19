﻿using UnityEngine;
using System.Collections;

public class Target : MonoBehaviour
{
    public Rigidbody shotPrefab;
    public float shotPower = 100f;

    float timer = 0f;
    Collider currentTarget;

    void Start()
    {
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
    }

    void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward * 100f);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider == currentTarget)
            {
                timer += Time.deltaTime;
            }
            else
            {
                currentTarget = hitInfo.collider;
                timer = 0f;
            }

            if (timer > 1f)
            {
                Rigidbody shot = Instantiate(shotPrefab, transform.position, transform.rotation) as Rigidbody;
                shot.AddForce(transform.forward * shotPower, ForceMode.Impulse);
                timer = 0f;
            }
        }
    }
}
