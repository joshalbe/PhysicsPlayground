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

    private bool _goingForward = false;
    private bool _goingBack = false;
    private bool _goingRight = false;
    private bool _goingLeft = false;

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

    private HingeJoint[] _tankHingesR = new HingeJoint[7];
    private HingeJoint[] _tankHingesL = new HingeJoint[7];
    private JointMotor[] _tankMotorsR = new JointMotor[7];
    private JointMotor[] _tankMotorsL = new JointMotor[7];

    private void Awake()
    {
        _tankController = GetComponent<CharacterController>();

        //Make a list of all the hinge joints on the body
        _hingeJoints = GetComponents<HingeJoint>();

        //Individually assign each joint to its proper pre-existing partner
        //as well as assign the motors of each joint
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


        //Assign the Hinges and Motors to their arrays for easier access later
        _tankHingesR[0] = _frontRightWheel; _tankHingesR[1] = _1RightWheel; _tankHingesR[2] = _2RightWheel;
        _tankHingesR[3] = _3RightWheel; _tankHingesR[4] = _4RightWheel; _tankHingesR[5] = _5RightWheel;
        _tankHingesR[6] = _upRightWheel;

        _tankHingesL[0] = _frontLeftWheel; _tankHingesL[1] = _1LeftWheel; _tankHingesL[2] = _2LeftWheel;
        _tankHingesL[3] = _3LeftWheel; _tankHingesL[4] = _4LeftWheel; _tankHingesL[5] = _5LeftWheel;
        _tankHingesL[6] = _upLeftWheel;

        _tankMotorsR[0] = _flMotor; _tankMotorsR[1] = _1rMotor; _tankMotorsR[2] = _2rMotor; _tankMotorsR[3] = _3rMotor;
        _tankMotorsR[4] = _4rMotor; _tankMotorsR[5] = _5rMotor; _tankMotorsR[6] = _urMotor;

        _tankMotorsL[0] = _flMotor; _tankMotorsL[1] = _1lMotor; _tankMotorsL[2] = _2lMotor; _tankMotorsL[3] = _3lMotor;
        _tankMotorsL[4] = _4lMotor; _tankMotorsL[5] = _5lMotor; _tankMotorsL[6] = _ulMotor;
    }

    private void Update()
    {
        //GoForward(1000.0f, 300.0f);

        float verticalMovement = Input.GetAxis("Vertical");
        float horizontalMovement = Input.GetAxis("Horizontal");

        if (verticalMovement > 0)
            GoForward(1000.0f, 200.0f);
        else if (verticalMovement < 0)
            GoBackwards(1000.0f, 200.0f);
        else if (horizontalMovement > 0)
            TurnRight(1000.0f, 200.0f);
        else if (horizontalMovement < 0)
            TurnLeft(1000.0f, 200.0f);
        else
            TankStop(100.0f, 100.0f);

    }

    private void TankStop(float stoppingVelocity, float stoppingForce)
    {
        for (int i = 0; i < _tankMotorsR.Length; i++)
        {
            if (_tankMotorsR[i].targetVelocity < 0.0f)
            {
                _tankMotorsR[i].targetVelocity += stoppingVelocity;
                if (_tankMotorsR[i].targetVelocity > 0.0f)
                    _tankMotorsR[i].targetVelocity = 0.0f;
            }
            else if (_tankMotorsR[i].targetVelocity > 0.0f)
            {
                _tankMotorsR[i].targetVelocity -= stoppingVelocity;
                if (_tankMotorsR[i].targetVelocity < 0.0f)
                    _tankMotorsR[i].targetVelocity = 0.0f;
            }
            if (_tankMotorsR[i].force > 0.0f)
            {
                _tankMotorsR[i].force -= stoppingForce;
                if (_tankMotorsR[i].force < 0.0f)
                    _tankMotorsR[i].force = 0.0f;
            }
            _tankHingesR[i].motor = _tankMotorsR[i];
        }
        for (int i = 0; i < _tankMotorsL.Length; i++)
        {
            if (_tankMotorsL[i].targetVelocity < 0.0f)
            {
                _tankMotorsL[i].targetVelocity += stoppingVelocity;
                if (_tankMotorsL[i].targetVelocity > 0.0f)
                    _tankMotorsL[i].targetVelocity = 0.0f;
            }
            else if (_tankMotorsL[i].targetVelocity > 0.0f)
            {
                _tankMotorsL[i].targetVelocity -= stoppingVelocity;
                if (_tankMotorsL[i].targetVelocity < 0.0f)
                    _tankMotorsL[i].targetVelocity = 0.0f;
            }
            if (_tankMotorsL[i].force > 0.0f)
            {
                _tankMotorsL[i].force -= stoppingForce;
                if (_tankMotorsL[i].force < 0.0f)
                    _tankMotorsL[i].force = 0.0f;
            }
            _tankHingesL[i].motor = _tankMotorsL[i];
        }
    }

    private void TurnRight(float velocity, float force)
    {
        for (int i = 0; i < _tankMotorsR.Length; i++)
        {
            _tankMotorsR[i].targetVelocity = velocity;
            _tankMotorsR[i].force = force;
            _tankHingesR[i].motor = _tankMotorsR[i];
        }
        for (int i = 0; i < _tankMotorsL.Length; i++)
        {
            _tankMotorsL[i].targetVelocity = velocity;
            _tankMotorsL[i].force = force;
            _tankHingesL[i].motor = _tankMotorsL[i];
        }
    }

    private void TurnLeft(float velocity, float force)
    {
        for (int i = 0; i < _tankMotorsR.Length; i++)
        {
            _tankMotorsR[i].targetVelocity = -velocity;
            _tankMotorsR[i].force = force;
            _tankHingesR[i].motor = _tankMotorsR[i];
        }
        for (int i = 0; i < _tankMotorsL.Length; i++)
        {
            _tankMotorsL[i].targetVelocity = -velocity;
            _tankMotorsL[i].force = force;
            _tankHingesL[i].motor = _tankMotorsL[i];
        }
    }

    private void GoForward(float velocity, float force)
    {
        for (int i = 0; i < _tankMotorsR.Length; i++)
        {
            _tankMotorsR[i].targetVelocity = -velocity;
            _tankMotorsR[i].force = force;
            _tankHingesR[i].motor = _tankMotorsR[i];
        }
        for (int i = 0; i < _tankMotorsL.Length; i++)
        {
            _tankMotorsL[i].targetVelocity = velocity;
            _tankMotorsL[i].force = force;
            _tankHingesL[i].motor = _tankMotorsL[i];
        }
    }

    private void GoBackwards(float velocity, float force)
    {
        for (int i = 0; i < _tankMotorsR.Length; i++)
        {
            _tankMotorsR[i].targetVelocity = velocity;
            _tankMotorsR[i].force = force;
            _tankHingesR[i].motor = _tankMotorsR[i];
        }
        for (int i = 0; i < _tankMotorsL.Length; i++)
        {
            _tankMotorsL[i].targetVelocity = -velocity;
            _tankMotorsL[i].force = force;
            _tankHingesL[i].motor = _tankMotorsL[i];
        }
    }
}
