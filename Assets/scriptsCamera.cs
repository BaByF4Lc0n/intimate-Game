using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptsCamera : MonoBehaviour
{
    public Transform target;  // ����Ф÷����Ҩ������ͧ�Դ���
    public float smoothing = 5f;  // �����Һ��蹢ͧ�������͹�����ͧ

    Vector3 offset;  // ������ҧ�����ҧ���ͧ�Ѻ����Ф�

    void Start()
    {
        // �ӹǳ������ҧ�����ҧ���ͧ�Ѻ����Ф�㹵͹�������
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // ���˹������������ͧ���ͧ
        Vector3 targetCamPos = target.position + offset;

        // ����͹���ͧ��ѧ���˹�����������ҧ�Һ���
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
