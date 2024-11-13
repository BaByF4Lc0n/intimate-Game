using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptsCamera : MonoBehaviour
{
    public Transform target;  // ตัวละครที่เราจะให้กล้องติดตาม
    public float smoothing = 5f;  // ความราบรื่นของการเคลื่อนที่กล้อง

    Vector3 offset;  // ระยะห่างระหว่างกล้องกับตัวละคร

    void Start()
    {
        // คำนวณระยะห่างระหว่างกล้องกับตัวละครในตอนเริ่มต้น
        offset = transform.position - target.position;
    }

    void FixedUpdate()
    {
        // ตำแหน่งเป้าหมายใหม่ของกล้อง
        Vector3 targetCamPos = target.position + offset;

        // เลื่อนกล้องไปยังตำแหน่งเป้าหมายอย่างราบรื่น
        transform.position = Vector3.Lerp(transform.position, targetCamPos, smoothing * Time.deltaTime);
    }
}
