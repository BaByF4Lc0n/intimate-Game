using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigunSC : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab ของกระสุน
    public Transform firePoint; // จุดที่กระสุนจะถูกยิงออก
    public float fireRate = 0.1f; // อัตราการยิง (หน่วย: วินาที)
    public float bulletSpeed = 20f; // ความเร็วกระสุน

    private float nextFireTime = 0f; // เวลาในรอบถัดไปที่จะยิงได้

    void Update()
    {
        // ตรวจสอบว่าปุ่มเมาส์ซ้ายถูกกดค้างไว้หรือไม่
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            // ยิงกระสุนและอัปเดตเวลา
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // สร้างกระสุนจาก Prefab
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // เพิ่มแรงขับให้กระสุน
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed; // ปรับทิศทางความเร็วตามจุดยิง
        }

        // คุณสามารถเพิ่มเอฟเฟกต์เสียงหรือการสั่นสะเทือนเพิ่มเติมที่นี่ได้
    }
}
