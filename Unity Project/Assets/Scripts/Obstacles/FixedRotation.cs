
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedRotation : MonoBehaviour
{
    public Transform Planet;

    void Start()
    {
        Vector3 newPos = (transform.position - Planet.transform.position).normalized;
        Vector3 vectorUp = transform.up;

        Quaternion newRotation = Quaternion.FromToRotation(vectorUp, newPos) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, 100 * Time.deltaTime);
    }

    void Update()
    {
        
    }
}
