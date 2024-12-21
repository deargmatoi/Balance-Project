using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Hareket hızı

    private void Update()
    {
        // A ve D tuşlarıyla hareket girdisi al
        float horizontalInput = Input.GetAxis("Horizontal");

        // Hareketi gerçekleştir (transform üzerinden)
        transform.position += new Vector3(horizontalInput * moveSpeed * Time.deltaTime, 0, 0);
    }
}



