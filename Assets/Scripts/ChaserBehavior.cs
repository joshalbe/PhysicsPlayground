using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaserBehavior : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        float currentDistance = Vector3.Distance(target.position, gameObject.transform.position);

        if (currentDistance <= 10.0f)
        {
            Chase();
        }
    }

    public void Chase()
    {

    }
}
