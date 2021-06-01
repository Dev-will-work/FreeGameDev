using Photon.Pun;
using UnityEngine;

public class FirstPersonMovement : MonoBehaviour
{
    public float speed = 5;
    Vector2 velocity;
    PhotonView PV;

    void Awake()
    {
        PV = GetComponent<PhotonView>();
    }

    void FixedUpdate()
    {
        if (!PV.IsMine)
            return;
        velocity.y = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        velocity.x = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(velocity.x, 0, velocity.y);
    }
}
