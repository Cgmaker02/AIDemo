using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRobot : MonoBehaviour
{
    private NavMeshAgent _agent;
    [SerializeField]
    private List<Transform> _wayPoints;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
            Debug.Log("NavMesh is null");
    }

    // Update is called once per frame
    void Update()
    {
        _agent.destination = _wayPoints[1].position;
    }
}
