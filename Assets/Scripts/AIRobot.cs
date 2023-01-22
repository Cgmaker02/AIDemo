using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRobot : MonoBehaviour
{
    private NavMeshAgent _agent;
    private WayPoints _waypoints;
    private Vector3 _endPos;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
            Debug.Log("NavMesh is null");

        _waypoints = GameObject.Find("Waypoints").GetComponent<WayPoints>();
        if (_waypoints == null)
            Debug.Log("waypoints is null");

        SpawnManager.instance.Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _waypoints._wayPoints[1].position;
        _endPos = _agent.destination;
        DestroyRobot();
    }

    void DestroyRobot()
    {
        if (transform.position == _endPos)
        {
            Destroy(this.gameObject);
        }
    }
}
