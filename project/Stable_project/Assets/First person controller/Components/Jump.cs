using UnityEngine;
using Photon.Pun;
public class Jump : MonoBehaviour
{
    [SerializeField]
    GroundCheck groundCheck;
    Rigidbody rigidbody;
    public float jumpStrength = 2;
    public event System.Action Jumped;
    PhotonView PV;

    void Reset()
    {
        groundCheck = GetComponentInChildren<GroundCheck>();
        if (!groundCheck)
            groundCheck = GroundCheck.Create(transform);
    }

    void Awake()
    {
        PV = GetComponent<PhotonView>();
        rigidbody = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (!PV.IsMine)
            return;
        if (Input.GetButtonDown("Jump") && groundCheck.isGrounded)
        {
            rigidbody.AddForce(Vector3.up * 100 * jumpStrength);
            Jumped?.Invoke();
        }
    }
}
