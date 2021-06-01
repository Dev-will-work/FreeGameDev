using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PersonControllerScript : MonoBehaviour
{
    public Animator animator;
    public GroundCheck groundCheck;
    private int _state;

    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        if (!PV.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>().gameObject);
        }
        animator = GetComponent<Animator>();
    }

    void Reset()
    {
    groundCheck = GetComponentInChildren<GroundCheck>();
    if (!groundCheck) {
      groundCheck = GroundCheck.Create(transform);
    }
    }


    // Update is called once per frame
    private void Update()
    {
        if (PV.IsMine)
        {
            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
            {
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    if (Input.GetButtonDown("Jump"))
                    {
                        _state = 5;
                    }
                    else
                        _state = 2;
                }
                else if (Input.GetButtonDown("Jump"))
                {
                    _state = 5;
                }
                else
                {
                    _state = 1;
                }
            }
            else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _state = 5;
                }
                else
                    _state = -1;
            }
            else if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _state = 5;
                }
                else
                    _state = 3;
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                if (Input.GetButtonDown("Jump"))
                {
                    _state = 5;
                }
                else
                    _state = 4;
            }
            else if (Input.GetButtonDown("Jump"))
            {
                _state = 5;
            }
            else if (groundCheck.isGrounded)
            {
                _state = 0;
            }
            animator.SetInteger("State", _state);
        }
    }
}
