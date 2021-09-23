using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChaserBehavior : MonoBehaviour
{
    [SerializeField]
    public GameObject target;
    private Vector3 _pastPosition;
    private NavMeshAgent _agent;
    private Vector3 _chaseDestination;

    private void Start()
    {
        _agent = GetComponent<NavMeshAgent>();

        StartCoroutine(PastPositionUpdate());
    }

    private void Update()
    {
        if (!target)
        {
            return;
        }

        float currentDistance = Vector3.Distance(target.transform.position, _agent.transform.position);
        _chaseDestination = target.transform.position;
        if (currentDistance <= 85.0f)
        {
            Chase();
        }
    }

    public void Chase()
    {
        _agent.SetDestination(_chaseDestination);
    }

    private IEnumerator PastPositionUpdate()
    {
        //Drop a waypoint of the target's location
        _pastPosition = target.transform.position;
        //Wait 1.5 seconds to drop a new waypoint
        yield return new WaitForSeconds(1.5f);
    }
}
