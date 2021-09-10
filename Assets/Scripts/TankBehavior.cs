using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankBehavior : MonoBehaviour
{
    [SerializeField]
    public float tankMass = 500;
    [SerializeField]
    public float tankSpeed;
    [SerializeField]
    public float tankTurnSpeed;

    private CharacterController _tankController;

    private bool _goingForward;
    private bool _goingBack;
    private bool _goingRight;
    private bool _goingLeft;

    //List of Hinge Joints
    private HingeJoint[] _hingeJoints;

    //Hinge joints connected to each wheel
    private HingeJoint _frontRightWheel;
    private HingeJoint _frontLeftWheel;
    private HingeJoint _1RightWheel;
    private HingeJoint _1LeftWheel;
    private HingeJoint _2RightWheel;
    private HingeJoint _2LeftWheel;
    private HingeJoint _3RightWheel;
    private HingeJoint _3LeftWheel;
    private HingeJoint _4RightWheel;
    private HingeJoint _4LeftWheel;
    private HingeJoint _5RightWheel;
    private HingeJoint _5LeftWheel;
    private HingeJoint _upRightWheel;
    private HingeJoint _upLeftWheel;

    //The joint motors of each wheel
    private JointMotor _frMotor;
    private JointMotor _flMotor;
    private JointMotor _1rMotor;
    private JointMotor _1lMotor;
    private JointMotor _2rMotor;
    private JointMotor _2lMotor;
    private JointMotor _3rMotor;
    private JointMotor _3lMotor;
    private JointMotor _4rMotor;
    private JointMotor _4lMotor;
    private JointMotor _5rMotor;
    private JointMotor _5lMotor;
    private JointMotor _urMotor;
    private JointMotor _ulMotor;

    private void Awake()
    {
        _tankController = GetComponent<CharacterController>();

        //Make a list of all the hinge joints on the body
        _hingeJoints = GetComponents<HingeJoint>();

        //Individually assign each joint to its proper pre-existing partner
        //as well as assing the motors of each joint
        _1RightWheel = _hingeJoints[0];
        _1rMotor = _1RightWheel.motor;

        _5RightWheel = _hingeJoints[1];
        _5rMotor = _5RightWheel.motor;

        _1LeftWheel = _hingeJoints[2];
        _1lMotor = _1LeftWheel.motor;

        _5LeftWheel = _hingeJoints[3];
        _5lMotor = _5LeftWheel.motor;

        _2RightWheel = _hingeJoints[4];
        _2rMotor = _2RightWheel.motor;

        _2LeftWheel = _hingeJoints[5];
        _2lMotor = _2LeftWheel.motor;

        _3RightWheel = _hingeJoints[6];
        _3rMotor = _3RightWheel.motor;

        _3LeftWheel = _hingeJoints[7];
        _3lMotor = _3LeftWheel.motor;

        _4RightWheel = _hingeJoints[8];
        _4rMotor = _4RightWheel.motor;

        _4LeftWheel = _hingeJoints[9];
        _4lMotor = _4LeftWheel.motor;

        _frontRightWheel = _hingeJoints[10];
        _frMotor = _frontRightWheel.motor;

        _frontLeftWheel = _hingeJoints[11];
        _flMotor = _frontLeftWheel.motor;

        _upRightWheel = _hingeJoints[12];
        _urMotor = _upRightWheel.motor;

        _upLeftWheel = _hingeJoints[13];
        _ulMotor = _upLeftWheel.motor;

    }

    private void Update()
    {
        //if (Input.GetKeyDown(""))

        if (_goingForward) 
        {
            GoForward();
        } 
        else if (_goingBack)
        {
            GoBackwards();
        } 
        else if (_goingRight)
        {
            TurnRight();
        } 
        else if (_goingLeft)
        {
            TurnLeft();
        }
    }

    private void TurnRight()
    {
        _frMotor.targetVelocity = 1000.0f;
        _1rMotor.targetVelocity = 1000.0f;
        _2rMotor.targetVelocity = 1000.0f;
        _3rMotor.targetVelocity = 1000.0f;
        _4rMotor.targetVelocity = 1000.0f;
        _5rMotor.targetVelocity = 1000.0f;
        _urMotor.targetVelocity = 1000.0f;

        _flMotor.targetVelocity = 1000.0f;
        _1lMotor.targetVelocity = 1000.0f;
        _2lMotor.targetVelocity = 1000.0f;
        _3lMotor.targetVelocity = 1000.0f;
        _4lMotor.targetVelocity = 1000.0f;
        _5lMotor.targetVelocity = 1000.0f;
        _ulMotor.targetVelocity = 1000.0f;
    }

    private void TurnLeft()
    {
        _frMotor.targetVelocity = -1000.0f;
        _1rMotor.targetVelocity = -1000.0f;
        _2rMotor.targetVelocity = -1000.0f;
        _3rMotor.targetVelocity = -1000.0f;
        _4rMotor.targetVelocity = -1000.0f;
        _5rMotor.targetVelocity = -1000.0f;
        _urMotor.targetVelocity = -1000.0f;

        _flMotor.targetVelocity = -1000.0f;
        _1lMotor.targetVelocity = -1000.0f;
        _2lMotor.targetVelocity = -1000.0f;
        _3lMotor.targetVelocity = -1000.0f;
        _4lMotor.targetVelocity = -1000.0f;
        _5lMotor.targetVelocity = -1000.0f;
        _ulMotor.targetVelocity = -1000.0f;
    }

    private void GoForward()
    {
        _frMotor.targetVelocity = -1000.0f;
        _1rMotor.targetVelocity = -1000.0f;
        _2rMotor.targetVelocity = -1000.0f;
        _3rMotor.targetVelocity = -1000.0f;
        _4rMotor.targetVelocity = -1000.0f;
        _5rMotor.targetVelocity = -1000.0f;
        _urMotor.targetVelocity = -1000.0f;

        _flMotor.targetVelocity = 1000.0f;
        _1lMotor.targetVelocity = 1000.0f;
        _2lMotor.targetVelocity = 1000.0f;
        _3lMotor.targetVelocity = 1000.0f;
        _4lMotor.targetVelocity = 1000.0f;
        _5lMotor.targetVelocity = 1000.0f;
        _ulMotor.targetVelocity = 1000.0f;
    }

    private void GoBackwards()
    {
        _frMotor.targetVelocity = 1000.0f;
        _1rMotor.targetVelocity = 1000.0f;
        _2rMotor.targetVelocity = 1000.0f;
        _3rMotor.targetVelocity = 1000.0f;
        _4rMotor.targetVelocity = 1000.0f;
        _5rMotor.targetVelocity = 1000.0f;
        _urMotor.targetVelocity = 1000.0f;

        _flMotor.targetVelocity = -1000.0f;
        _1lMotor.targetVelocity = -1000.0f;
        _2lMotor.targetVelocity = -1000.0f;
        _3lMotor.targetVelocity = -1000.0f;
        _4lMotor.targetVelocity = -1000.0f;
        _5lMotor.targetVelocity = -1000.0f;
        _ulMotor.targetVelocity = -1000.0f;
    }
}
