using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour
{
    #region Public Params
    public float ForceGravity,SpeedRotation;
    public Transform Player;
    #endregion

    #region  MonoBehaviour

    void Start()
    {
        
    }

    void FixedUpdate()
    {
        FixedGravity();
    }

    void FixedGravity()
    {
        Vector3 newPos = (Player.position - transform.position).normalized;
        Player.GetComponent<Rigidbody>().AddForce(newPos * ForceGravity);
        Vector3 PlayerUp = Player.up;

        Quaternion newRotation = Quaternion.FromToRotation(PlayerUp, newPos)*Player.rotation;
        Player.rotation = Quaternion.Slerp(Player.rotation, newRotation, SpeedRotation * Time.deltaTime);
    }

    #endregion
}
