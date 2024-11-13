using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScri : MonoBehaviour
{
    public Transform player;  // ����¹�� Transform
    public float speed;
    public float distanceBetween;
    private float distance;

    void Update()
    {
        // �ӹǳ������ҧ�����ҧ�ѵ�١Ѻ������
        distance = Vector2.Distance(transform.position, player.position);

        // �ӹǳ��ȷҧ��ѧ������
        Vector2 direction = (player.position - transform.position).normalized;

        // �ӹǳ��������ع�ѵ����ѧ������
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (distance < distanceBetween)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
