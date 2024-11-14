using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class minigunSC : MonoBehaviour
{
    public GameObject bulletPrefab; // Prefab �ͧ����ع
    public Transform firePoint; // �ش������ع�ж١�ԧ�͡
    public float fireRate = 0.1f; // �ѵ�ҡ���ԧ (˹���: �Թҷ�)
    public float bulletSpeed = 20f; // �������ǡ���ع

    private float nextFireTime = 0f; // ������ͺ�Ѵ价����ԧ��

    void Update()
    {
        // ��Ǩ�ͺ��һ����������¶١����ҧ����������
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            // �ԧ����ع����ѻവ����
            nextFireTime = Time.time + fireRate;
            Shoot();
        }
    }

    void Shoot()
    {
        // ���ҧ����ع�ҡ Prefab
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // �����ç�Ѻ������ع
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = firePoint.right * bulletSpeed; // ��Ѻ��ȷҧ�������ǵ���ش�ԧ
        }

        // �س����ö�����Ϳ࿡�����§���͡���������͹��������������
    }
}
