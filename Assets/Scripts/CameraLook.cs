using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraLook : MonoBehaviour
{
    public Joystick joysticklook;
    public Transform position;
    public float camspeed;
    public PhotonView view;
    float updown = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            float x = joysticklook.Horizontal * camspeed * Time.deltaTime;
            float y = joysticklook.Vertical * camspeed * Time.deltaTime;

            position.Rotate(Vector3.up, x);
            updown -= y;
            updown = Mathf.Clamp(updown, -90, 90);

            transform.localRotation = Quaternion.Euler(updown, 0.0f, 0.0f);
        }
    }
}
