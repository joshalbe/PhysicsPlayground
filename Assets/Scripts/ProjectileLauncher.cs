using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public Transform target;
    public Rigidbody projectile;

    public float projectileTime = 2;

    private Vector3 _displacement = new Vector3();
    private Vector3 _acceleration = new Vector3();
    private float _time = 0.0f;
    private Vector3 _initialVelocity = new Vector3();
    private Vector3 _finalVelocity = new Vector3();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            LaunchProjectile();
        }
    }

    public void LaunchProjectile()
    {
        _displacement = target.position - transform.position;
        _acceleration = Physics.gravity;
        _time = projectileTime;
        _initialVelocity = FindInitialVelocity(_displacement, _acceleration, _time);
        _finalVelocity = FindFinalVelocity(_initialVelocity, _acceleration, _time);

        Rigidbody projectileInstance =  Instantiate(projectile, transform.position, transform.rotation);
        projectileInstance.AddForce(_initialVelocity, ForceMode.VelocityChange);
    }

    private Vector3 FindFinalVelocity(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        //v = v0 + a * t
        Vector3 finalVelocity = initialVelocity + acceleration * time;

        return finalVelocity;
    }

    private Vector3 FindDisplacement(Vector3 initialVelocity, Vector3 acceleration, float time)
    {
        //deltaX = v0*t + (1/2)*a*t^2
        Vector3 displacement = initialVelocity * time + 0.5f * acceleration * time * time;

        return displacement;
    }

    private Vector3 FindInitialVelocity(Vector3 displacement, Vector3 acceleration, float time)
    {
        //deltaX = v0*t + (1/2)*a*t^2
        //deltaX - (1/2)*a*t^2 = v0*t
        //deltaX/t - (1/2)*a*t = v0
        //v0 = deltaX/t - (1/2)*a*t
        Vector3 initialVelocity = displacement / time - 0.5f * acceleration * time;

        return initialVelocity;
    }
}
