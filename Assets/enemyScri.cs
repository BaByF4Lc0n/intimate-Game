using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyScri : MonoBehaviour
{
    public Transform player;  // เปลี่ยนเป็น Transform
    public float speed;
    public float distanceBetween;
    private float distance;

    void Update()
    {
        // คำนวณระยะห่างระหว่างศัตรูกับผู้เล่น
        distance = Vector2.Distance(transform.position, player.position);

        // คำนวณทิศทางไปยังผู้เล่น
        Vector2 direction = (player.position - transform.position).normalized;

        // คำนวณมุมและหมุนศัตรูไปยังผู้เล่น
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        if (distance < distanceBetween)
        {
            transform.rotation = Quaternion.Euler(Vector3.forward * angle);
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
    }
}
