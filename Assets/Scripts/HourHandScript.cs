using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HourHandScript : MonoBehaviour
{

    private Vector3 pivot = new Vector3(0.0f, 0.0f, 0.0f);
    public float rotationRate = 30.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(pivot, Vector3.up, rotationRate * Time.deltaTime);
    }
}
