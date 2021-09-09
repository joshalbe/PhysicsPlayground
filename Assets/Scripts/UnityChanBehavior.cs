using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnityChanBehavior : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpStrength = 100.0f;
    public float aircontrol = 1.0f;
    public float gravityModifier = 0.2f;

    private CharacterController _controller;

    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _jumpIsDesired = false;
    private bool _isGrounded = false;
    public bool faceWithCamera = true;

    public Camera playerCamera;

    [SerializeField]
    private Animator _animator;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Get movement input
        float InputForward = Input.GetAxis("Vertical");
        float InputRight = Input.GetAxis("Horizontal");

        //Get camera forward
        Vector3 cameraForward = playerCamera.transform.forward;
        cameraForward.y = 0.0f;
        cameraForward.Normalize();

        //Get camera right
        Vector3 cameraRight = playerCamera.transform.right;

        //Find the desired velocity
        _desiredVelocity = (cameraForward * InputForward) + (cameraRight * InputRight);

        //Get jump input
        _jumpIsDesired = Input.GetButtonDown("Jump");

        //Apply air control


        //Set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //Check for ground
        _isGrounded = _controller.isGrounded;

        //Apply jump strength
        if (_jumpIsDesired && _isGrounded)
        {
            _airVelocity.y = jumpStrength;
            _jumpIsDesired = false;
        }

        //Stop on ground
        if (_isGrounded && _airVelocity.y < 0.0f)
        {
            _airVelocity.y = -1.0f;
        }

        //Apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.deltaTime;

        //Move
        _desiredVelocity += _airVelocity;
        _controller.Move(_desiredVelocity * Time.deltaTime);
    }wddddddddddd
}
