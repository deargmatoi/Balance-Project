using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyBehavior : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Eğer çarpılan obje "Zemin" tagine sahipse
        if (collision.collider.CompareTag("Zemin"))
        {
            Destroy(gameObject); // Oyuncağı yok et
        }
    }
}
