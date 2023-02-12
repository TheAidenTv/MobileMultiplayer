using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class PlayerController : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject cameraHolder;

    public float moveSpeed, jumpForce;
    public Rigidbody2D rb;
    bool grounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    void Start()
    {
        if(!photonView.IsMine)
        {
            Destroy(GetComponentInChildren<Camera>());
            Destroy(rb);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!photonView.IsMine)
            return;

        MovePlayer();
        Jump();
    }

    void MovePlayer()
    {
        float xMovement = SimpleInput.GetAxis("Horizontal");
        float x = xMovement * moveSpeed * Time.deltaTime;

        if (xMovement < 0)
        {
            transform.localScale = new Vector3(-6, 7, 0);
        }
        else if (xMovement > 0)
        {
            transform.localScale = new Vector3(6, 7, 0);
        }

        transform.Translate(x, 0, 0);
    }

    void Jump()
    {
        if (SimpleInput.GetButton("JumpButton") && rb.velocity.y==0)
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
    }

    public void SetGroundedState(bool _grounded)
    {
        grounded = _grounded;
    }
}
