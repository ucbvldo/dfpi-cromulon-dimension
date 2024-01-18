using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpaceship : MonoBehaviour
{
    // Speed Multipliers
    [SerializeField] float speedMult = 1f;
    [SerializeField] float speedMultAngle = 0.5f;
    [SerializeField] float speedRollMultAngle = 0.05f;

    private Rigidbody spaceshipRB;

    // Inputs
    private float verticalMove;
    private float horizontalMove;
    private float mouseInputX;
    private float mouseInputY;
    private float rollInput;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        spaceshipRB = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        verticalMove = Input.GetAxis("Vertical");
        horizontalMove = Input.GetAxis("Horizontal");
        rollInput = Input.GetAxis("Roll");

        mouseInputX = Input.GetAxis("Mouse X");
        mouseInputY = Input.GetAxis("Mouse Y");
    }

    void FixedUpdate()
    {
        spaceshipRB.AddForce(spaceshipRB.transform.TransformDirection(Vector3.forward) * verticalMove * speedMult, ForceMode.VelocityChange);
        spaceshipRB.AddForce(spaceshipRB.transform.TransformDirection(Vector3.right) * horizontalMove * speedMult, ForceMode.VelocityChange);

        spaceshipRB.AddTorque(spaceshipRB.transform.right * speedMultAngle * mouseInputY * -1, ForceMode.VelocityChange);
        spaceshipRB.AddTorque(spaceshipRB.transform.up * speedMultAngle * mouseInputX, ForceMode.VelocityChange);

        spaceshipRB.AddTorque(spaceshipRB.transform.forward * speedRollMultAngle * rollInput, ForceMode.VelocityChange);
    }
}
