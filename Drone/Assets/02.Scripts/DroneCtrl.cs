using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneCtrl : MonoBehaviour
{
    public Transform[] wings;
    public float wingSpeed = 3000.0f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    void RotateWings(float speed)
    {
        for(int i=0; i<wings.Length; i++)
        {
            wings[i].Rotate(Vector3.up * Time.deltaTime * speed);
        }
    }
}
