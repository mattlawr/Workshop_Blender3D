/*
 * For VGDC Winter Game Jam
 * Author: Matthew Lawrence
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Sets this object's y position to the give value in world space every frame. 
/// </summary>
public class Shadow : MonoBehaviour
{
    [Tooltip("The y position that the object will be set to.")]
    public float yValue = 0.01f;

    public bool lockRotation = false;
    Quaternion startRot;

    private void Start()
    {
        startRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(transform.position.x, yValue, transform.position.z);

        if (lockRotation)
        {
            transform.rotation = startRot;
        }
    }
}
