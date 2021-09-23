using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Projectile")
            Destroy(gameObject);
        else if (collision.gameObject.tag == "Chaser")
            collision.gameObject.SetActive(false);
    }
}
