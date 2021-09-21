using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public float distanceFromTarget = 10.0f;
    public float sensitivity = 1000.0f;
    public bool invertY = false;

    private void Update()
    {
        if (target)
        {
            //Rotate the camera
            if (Input.GetMouseButton(1))
            {
                Vector3 angles = transform.eulerAngles;
                Vector2 rotation;
                rotation.x = Input.GetAxis("Mouse Y") * (invertY ? 1.0f : -1.0f);
                rotation.y = Input.GetAxis("Mouse X");
                //Look up and down by rotating around X-axis
                angles.x = Mathf.Clamp(angles.x + rotation.x * sensitivity * Time.deltaTime, 0.0f, 70.0f);
                //Look left and right by rotating around the Y-axis
                angles.y += rotation.y * sensitivity * Time.deltaTime;
                //Set the angles
                transform.eulerAngles = angles;
            }

            //Move the camera
            transform.position = target.position + (distanceFromTarget * -transform.forward);
        }
    }
}
