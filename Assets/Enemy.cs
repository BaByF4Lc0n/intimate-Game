using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    // Start is called before the first frame update
    private GameObject _enemyPrefab;
    [SerializeField]
    private float _minimumSpawnTime;
    [SerializeField]
    private float _maximumSpawnTime;
    [SerializeField]
    private float _timeUnitSpawn;
    void Start()
    {
        SetTime();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUnitSpawn -= Time.deltaTime;
        if (_timeUnitSpawn <= 0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTime();
        }
    }
    private void SetTime()
    {
        _timeUnitSpawn = Random.Range(_minimumSpawnTime, _maximumSpawnTime);
    }
}
