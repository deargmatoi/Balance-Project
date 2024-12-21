using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f; // X ekseni hareket hızı
    public float rotationSpeed = 100f; // Daire dönüş hızı

    [SerializeField] private Animator animator;

    [SerializeField] private GameObject elf;


    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //animator = elf.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        // A ve D tuşlarıyla bütün şeklin sağa-sola hareketi
        float move = Input.GetAxis("Horizontal"); // A ve D tuşları için -1 ve 1 döner
        if(rb.velocity.x != 0)
        {
            animator.SetBool("isMoving", true);
        } else
        {
            animator.SetBool("isMoving", false);
        }
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        // Sağ ve sol ok tuşlarıyla dairenin kendi etrafında dönmesi
        if (Input.GetKey(KeyCode.RightArrow))
        {
            rb.angularVelocity = -rotationSpeed; // Saat yönünde dönme
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            rb.angularVelocity = rotationSpeed; // Saat yönünün tersine dönme
        }
        else
        {
            rb.angularVelocity = 0; // Ok tuşlarına basılmadığında dönmeyi durdur
        }

        // Yatay hareket
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        // Speed parametresini güncelle
        //animator.SetFloat("Speed", Mathf.Abs(moveInput));

        // Karakteri sağa sola döndürme
        if (moveInput > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else if (moveInput < 0)
            transform.localScale = new Vector3(-1, 1, 1);
    }
}

