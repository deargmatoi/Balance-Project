using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    public float moveSpeed = 5f; // X ekseni hareket hızı
    public float rotationSpeed = 100f; // Daire dönüş hızı

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // A ve D tuşlarıyla bütün şeklin sağa-sola hareketi
        float move = Input.GetAxis("Horizontal"); // A ve D tuşları için -1 ve 1 döner
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
    }
}
