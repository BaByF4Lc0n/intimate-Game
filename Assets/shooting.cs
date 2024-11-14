using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shooting : MonoBehaviour
{
    public Transform Gun;
    // Start is called before the first frame update
    Vector2 direction;
    public GameObject Bullet;
    public float BulletSpeed;
    public Transform ShootPoint;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = mousePos - (Vector2)Gun.position;
        FaceMouse();

        if (Input.GetMouseButtonDown(0))
        {
            shoot();
        }
    }
    void FaceMouse()
    {
        Gun.transform.right = direction;
    }
    void shoot()
    {
        // สร้างกระสุนที่ตำแหน่ง ShootPoint
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);

        // ใช้แรงผลักในทิศทางที่ ShootPoint ชี้ไป
        Rigidbody2D rb = BulletIns.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.right * BulletSpeed, ForceMode2D.Impulse);

        // ตรวจสอบว่ากระสุนไม่ทำให้ตัวละครเคลื่อนที่โดยไม่ได้ตั้งใจ
        Physics2D.IgnoreCollision(BulletIns.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
