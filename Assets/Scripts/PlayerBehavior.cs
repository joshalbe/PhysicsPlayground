using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpStrength = 100.0f;
    public float gravityModifier = 0.2f;

    private CharacterController _controller;

    private Vector3 _desiredVelocity;
    private Vector3 _airVelocity;
    private bool _jumpIsDesired;

    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        //Get movement input
        _desiredVelocity.x = Input.GetAxis("Horizontal");
        _desiredVelocity.y = 0.0f;
        _desiredVelocity.z = Input.GetAxis("Vertical");

        //Get jump input
        _jumpIsDesired = Input.GetButtonDown("Jump");

        //Set movement magnitude
        _desiredVelocity.Normalize();
        _desiredVelocity *= speed;

        //Apply jump strength
        if (_jumpIsDesired)
        {
            _airVelocity.y = jumpStrength;
            _jumpIsDesired = false;
        }

        //Apply gravity
        _airVelocity += Physics.gravity * gravityModifier * Time.deltaTime;


        //Move
        _desiredVelocity += _airVelocity;
        _controller.Move(_desiredVelocity * Time.deltaTime);
    }
}
