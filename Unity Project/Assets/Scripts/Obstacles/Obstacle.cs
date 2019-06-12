using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public Transform Planet;
    public float ForceGravity=-12,SpeedRotation=50;
    public bool RandomPostion;
    public float TimeDestroyObstacle;
    void Start()
    {
        Planet = GameManager.Instance.MyPlanet;
        if(RandomPostion)
            transform.position = Random.insideUnitSphere * 50;
        Destroy(this.gameObject, TimeDestroyObstacle);
    }

    void Update()
    {
                   
    }

    void FixedUpdate()
    {
        FixedGravity();
    }

    void FixedGravity()
    {
        Vector3 newPos = (transform.position - Planet.position).normalized;
        transform.GetComponent<Rigidbody>().AddForce(newPos * ForceGravity);
        Vector3 vectorUp = transform.up;

        Quaternion newRotation = Quaternion.FromToRotation(vectorUp, newPos) * transform.rotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, newRotation, SpeedRotation * Time.deltaTime);
    }
}
