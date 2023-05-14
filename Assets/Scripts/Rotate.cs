using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] float SpeedX;
    [SerializeField] float SpeedY;
    [SerializeField] float SpeedZ;
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(360 * SpeedX * Time.deltaTime, 360 * SpeedY * Time.deltaTime, 360 * SpeedZ * Time.deltaTime); 
    }
}
