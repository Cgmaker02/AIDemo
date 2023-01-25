using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIRobot : MonoBehaviour
{
    public enum stateMachine
    {
        Run,
        Hide,
        Death
    }

    private NavMeshAgent _agent;
    private WayPoints _waypoints;
    private stateMachine _machine;
    public int _currentPos = 0;
    private Animator _anim;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        if (_agent == null)
            Debug.Log("NavMesh is null");

        _waypoints = GameObject.Find("Waypoints").GetComponent<WayPoints>();
        if (_waypoints == null)
            Debug.Log("waypoints is null");

        _anim = GetComponent<Animator>();
        if (_anim == null)
            Debug.Log("The animator is null");

        SpawnManager.instance.Spawn();
        _machine = stateMachine.Run;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_agent.destination);
        RobotState();
    }

    void RobotState()
    {
        switch(_machine)
        {
            case stateMachine.Run:
                Run();
                _anim.SetFloat("Speed", 3.1f);
                _anim.SetBool("Hiding", false);
                break;
            case stateMachine.Hide:
                StartCoroutine(Hide());
                _anim.SetBool("Hiding", true);
                break;
            case stateMachine.Death:
                _anim.SetTrigger("Death");
                break;
        }
    }

    private void Run()
    {
        if (_agent.remainingDistance < .01)
        {
            
            if (_currentPos < _waypoints._wayPoints.Count - 1)
            {
                _currentPos++;
            }
            _agent.destination = _waypoints._wayPoints[_currentPos].position;
            _machine = stateMachine.Hide;
        }
    }

    IEnumerator Hide()
    {
        _agent.isStopped = true;
        yield return new WaitForSeconds(Random.Range(2f, 6f));
        _agent.isStopped = false;
        _machine = stateMachine.Run;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "PointB")
            Destroy(this.gameObject);
    }
}
