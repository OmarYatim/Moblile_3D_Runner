using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{

    #region Public Params
    public float Speed,SpeedRotate;
    #endregion

    #region MonoBehaviour
    void Start()
    {
        Speed = GameManager.Instance.CurrentLevel.SpeedPlayer;
    }

    void Update()
    {
        if(GameManager.Instance.State==GameState.StartGame)
            Move();
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Obstacle")
        {
            GameManager.Instance.GameOver();
        }
    }

    #endregion

    public void Move()
    {
        print("hori " + CrossPlatformInputManager.GetAxis("H"));
        print("Vertical " + CrossPlatformInputManager.GetAxis("Vertical"));

        transform.Translate(Vector3.forward * Speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, CrossPlatformInputManager.GetAxis("H"), 0) * SpeedRotate * Time.deltaTime);
    }

}
