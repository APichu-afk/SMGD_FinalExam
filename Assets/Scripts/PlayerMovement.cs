using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    public Joystick movementjoystick;
    public CharacterController player;
    public PhotonView view;
    Vector3 move;
    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            float horizontal = movementjoystick.Horizontal;
            float vertical = movementjoystick.Vertical;

            move = new Vector3(horizontal, 0.0f, vertical);

            move = transform.TransformDirection(move);
            move *= speed;

            player.Move(move * Time.deltaTime);
        }
    }
}
