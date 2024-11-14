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
        // ���ҧ����ع�����˹� ShootPoint
        GameObject BulletIns = Instantiate(Bullet, ShootPoint.position, ShootPoint.rotation);

        // ���ç��ѡ㹷�ȷҧ��� ShootPoint ����
        Rigidbody2D rb = BulletIns.GetComponent<Rigidbody2D>();
        rb.AddForce(ShootPoint.right * BulletSpeed, ForceMode2D.Impulse);

        // ��Ǩ�ͺ��ҡ���ع����������Ф�����͹�������������
        Physics2D.IgnoreCollision(BulletIns.GetComponent<Collider2D>(), GetComponent<Collider2D>());
    }
}
