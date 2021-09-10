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

    //List of Hinge Joints
    private HingeJoint[] _hingeJoints;

    //Hinge joints connected to each wheel
    private HingeJoint _tankFrontRightWheel;
    private HingeJoint _tankFrontLeftWheel;
    private HingeJoint _tank1RightWheel;
    private HingeJoint _tank1LeftWheel;
    private HingeJoint _tank2RightWheel;
    private HingeJoint _tank2LeftWheel;
    private HingeJoint _tank3RightWheel;
    private HingeJoint _tank3LeftWheel;
    private HingeJoint _tank4RightWheel;
    private HingeJoint _tank4LeftWheel;
    private HingeJoint _tank5RightWheel;
    private HingeJoint _tank5LeftWheel;
    private HingeJoint _tankUpRightWheel;
    private HingeJoint _tankUpLeftWheel;

    private void Awake()
    {
        //Make a list of all the hinge joints on the 
        _hingeJoints = GetComponents<HingeJoint>();

        //Individually assign each joint to its proper pre-existing partner
        _tank1RightWheel = _hingeJoints[0];
        _tank5RightWheel = _hingeJoints[1];
        _tank1LeftWheel = _hingeJoints[2];
        _tank5LeftWheel = _hingeJoints[3];
        _tank2RightWheel = _hingeJoints[4];
        _tank2LeftWheel = _hingeJoints[5];
        _tank3RightWheel = _hingeJoints[6];
        _tank3LeftWheel = _hingeJoints[7];
        _tank4RightWheel = _hingeJoints[8];
        _tank4LeftWheel = _hingeJoints[9];
        _tankFrontRightWheel = _hingeJoints[10];
        _tankFrontLeftWheel = _hingeJoints[11];
        _tankUpRightWheel = _hingeJoints[12];
        _tankUpLeftWheel = _hingeJoints[13];
    }
}
