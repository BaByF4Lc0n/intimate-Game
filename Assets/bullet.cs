using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float lifetime = 5f; // ����㹡�÷���µ���ͧ�ҡ��誹�������

    private void Start()
    {
        // ����¡���ع��ѧ�ҡ�������ҷ���˹����ͻ����Ѵ��Ѿ�ҡ�
        Destroy(gameObject, lifetime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // ��Ǩ�ͺ��ҡ���ع�����ʡѺ�ѵ�ط����ʤ�Ի�� EnemyScripts �������
        if (collision.GetComponent<EnemyScripts>() != null)
        {
            // ������ѵ�ط�����ع������ (�ѵ��)
            Destroy(collision.gameObject);

            // ����µ�ǡ���ع�ͧ
            Destroy(gameObject);
        }
    }
}
