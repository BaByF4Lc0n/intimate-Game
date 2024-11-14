using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScripts : MonoBehaviour
{
    [SerializeField]
    private float _speed;
    [SerializeField]
    private float _rotationSpeed;
    [SerializeField]
    private int _health = 3; // จำนวนเลือดของศัตรู

    private Rigidbody2D _rigidbody; // ใช้ Rigidbody2D สำหรับเกม 2D
    private playerAware _playerAware;
    private Vector2 _targetDirection;

    // Start is called before the first frame update
    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerAware = GetComponent<playerAware>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        UpdateTargetDirection();
        RotateTowardsTarget();
        SetVelocity();
    }

    private void UpdateTargetDirection()
    {
        if (_playerAware.AwareOfplayer)
        {
            _targetDirection = _playerAware.DirectionToPlyer;
        }
        else
        {
            _targetDirection = Vector2.zero;
        }
    }

    private void RotateTowardsTarget()
    {
        if (_targetDirection == Vector2.zero)
        {
            return;
        }

        // คำนวณมุมในระนาบ 2D
        float angle = Mathf.Atan2(_targetDirection.y, _targetDirection.x) * Mathf.Rad2Deg - 90f;
        float rotation = Mathf.LerpAngle(_rigidbody.rotation, angle, _rotationSpeed * Time.deltaTime);

        _rigidbody.rotation = rotation; // ตั้งค่ามุมหมุนใน 2D
    }

    private void SetVelocity()
    {
        if (_targetDirection == Vector2.zero)
        {
            _rigidbody.velocity = Vector2.zero;
        }
        else
        {
            _rigidbody.velocity = transform.up * _speed;
        }
    }

    // ฟังก์ชันสำหรับลดเลือด
    public void TakeDamage(int damage)
    {
        _health -= damage;
        if (_health <= 0)
        {
            Die();
        }
    }

    // ฟังก์ชันเมื่อศัตรูตาย
    private void Die()
    {
        Destroy(gameObject);
    }
}
