using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBehavior : MonoBehaviour
{
    private float _degree = 0.1f;

    // Update is called once per frame
    void Update()
    {
        Vector3 rotate = new Vector3(0, _degree, 0);
        transform.eulerAngles = rotate;
        _degree += 0.1f;
    }
}
