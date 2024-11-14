using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float lifetime = 5f; // เวลาในการทำลายตัวเองหากไม่ชนอะไรเลย

    private void Start()
    {
        // ทำลายกระสุนหลังจากระยะเวลาที่กำหนดเพื่อประหยัดทรัพยากร
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ตรวจสอบว่ากระสุนสัมผัสกับวัตถุที่มีสคริปต์ EnemyScripts หรือไม่
        if (collision.GetComponent<EnemyScripts>() != null)
        {
            // ทำลายวัตถุที่กระสุนสัมผัส (ศัตรู)
            Destroy(collision.gameObject);

            // ทำลายตัวกระสุนเอง
            Destroy(gameObject);
        }
    }
}
