/*
 * For VGDC Winter Game Jam
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Rotates an object in local space.
/// </summary>
public class ClockHand : MonoBehaviour
{
    public float speed = 72f;

    private Vector3 pivot = new Vector3(0.0f, 0.0f, 0.0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 worldPivot = transform.TransformPoint(pivot);

        transform.RotateAround(worldPivot, Vector3.up, speed * Time.deltaTime);
    }

    /// <summary>
    /// Increases rotation speed.
    /// </summary>
    /// <param name="amt">The increase amount.</param>
    public void IncreaseSpeed(float amt)
    {
        speed += amt;
    }
}
