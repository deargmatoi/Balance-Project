using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyHolder : MonoBehaviour
{
    public ToyObject toy;

    public void InitializeToy(ToyObject toyObject)
    {
        toy = toyObject;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.sprite = toyObject.sprite;
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.mass = toyObject.mass;
        }
    }
}
