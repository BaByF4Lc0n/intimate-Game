using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemySpw : MonoBehaviour
{
    [SerializeField]
    public GameObject _enemyPrefab;
    [SerializeField]
    private float _minimum;
    [SerializeField]
    private float _maximum;
    private float _timeUntilSpawn;
    // Start is called before the first frame update
    void Awake()
    {
        SetTimeUntilSpawn();
    }

    // Update is called once per frame
    void Update()
    {
        _timeUntilSpawn -= Time.deltaTime;
        if(_timeUntilSpawn <= 0)
        {
            Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
            SetTimeUntilSpawn();
        }
    }
    private void SetTimeUntilSpawn()
    {
        _timeUntilSpawn = Random.Range(_minimum, _maximum);
    }
}
