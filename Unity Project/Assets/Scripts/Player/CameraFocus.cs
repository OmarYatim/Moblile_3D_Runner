using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocus : MonoBehaviour
{
    public Transform Target;
    public float Speed,SpeedRotation;

    void Start()
    {
        
    }

    void Update()
    {
        if (GameManager.Instance.State == GameState.StartGame)
            Follow();
    }

    public void Follow()
    {
        transform.position = Vector3.Lerp(transform.position, Target.position, Speed * Time.deltaTime);
        transform.rotation = Quaternion.Lerp(transform.rotation, Target.rotation, SpeedRotation * Time.deltaTime);
    }
}
