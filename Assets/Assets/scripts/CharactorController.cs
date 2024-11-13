using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactorController : MonoBehaviour
{
    public float moveSpeed = 5f; // ความเร็วในการเคลื่อนที่ของผู้เล่น
    public Rigidbody2D rb;
    public Animator animator;

    Vector2 moveMent;

    void Start()
    {
        moveMent.x = Input.GetAxisRaw("Horizontal");
        moveMent.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", moveMent.x);
        animator.SetFloat("Vetical", moveMent.y);
        animator.SetFloat("Speed", moveMent.sqrMagnitude);
    }

    void Update()
    {
        rb.MovePosition(rb.position + moveMent.normalized * moveSpeed * Time.fixedDeltaTime);
    }
    
}
