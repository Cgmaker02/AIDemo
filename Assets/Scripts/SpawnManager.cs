using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _robotPrefab;
    [SerializeField]
    private AIRobot _robot;
    [SerializeField]
    private WayPoints _waypoints;
    [SerializeField]
    private GameObject _spawnPool;
    private GameObject _robotPool;

    private static SpawnManager _instance;
    public static SpawnManager instance
    {
        get
        {
            if (_instance == null)
                Debug.Log("instance is null");
            return _instance;
        }
    }

    private void Start()
    {
        _instance = this;
        _robotPool = Instantiate(_robotPrefab, _waypoints._wayPoints[0].position, Quaternion.identity);
        _robotPool.transform.parent = _spawnPool.transform;
    }

    IEnumerator SpawnAI()
    {
        yield return new WaitForSeconds(10f);
        _robotPool = Instantiate(_robotPrefab, _waypoints._wayPoints[0].position, Quaternion.identity);
        _robotPool.transform.parent = _spawnPool.transform;
      
    }

    public void Spawn()
    {
        StartCoroutine(SpawnAI());
    }
}
