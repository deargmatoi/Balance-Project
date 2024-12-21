using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObject : MonoBehaviour
{
    private BoxCollider2D boxCollider2D;

    private void Awake(){
        boxCollider2D = GetComponent<BoxCollider2D>();
    }

    private void LateUpdate(){
        if(transform.position.y > 6){
            boxCollider2D.enabled = false;
        } else {
            boxCollider2D.enabled = true;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.transform.CompareTag("Platform"))
            Destroy(this.gameObject);
    }
}
