using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerAware : MonoBehaviour
{
    public bool AwareOfplayer { get; private set; }
    public Vector2 DirectionToPlyer {  get; private set; }
    [SerializeField]
    private float _playerAwareDistance;
    // Start is called before the first frame update
    private Transform _player;
    private void Awake()
    {
        _player = FindObjectOfType<playerMove>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 enemyToPlayerVector = _player.position - transform.position;
        DirectionToPlyer = enemyToPlayerVector.normalized;
        if(enemyToPlayerVector.magnitude <= _playerAwareDistance)
        {
            AwareOfplayer = true;
        }
        else
        {
            AwareOfplayer= false;
        }
    }
}
