using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;

public class ObjectFallController : MonoBehaviour
{
    float wait = 2.1f;
    public GameObject fallingObject;
    public float redBlockChance = 0.3f; //Kırmızı block çıkma olasılığı (0.3 = %30)
    public float specialShapeChance = 0.2f; //Özel şekillerin gelme olasılığı (0.2 = %20)
    public float upwardForce = 5f; //yukarıya uygulanacak kuvvet
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fall", wait, wait);
        
    }

   void Fall()
   {
    //Yeni block oluştur
    GameObject block = Instantiate(fallingObject, new UnityEngine.Vector3(Random.Range(-10, 10), 10, 0), UnityEngine.Quaternion.identity);

    //Rastgele olasılık kontrolü (renk)
    if (Random.value < redBlockChance)
    {
        //block rengi kırmızı yapılıyor
        block.GetComponent<Renderer>().material.color = Color.red;
    }
    //Rastgele şekil ve boyut kontrolü
    float sizeChance = Random.value;

    if (sizeChance < specialShapeChance * 0.5f)
    {
        //Yarı boyutunda kare
        block.transform.localScale = new UnityEngine.Vector3(0.5f, 0.5f, 1f);
    }
    else if (sizeChance < specialShapeChance)
    {
        //Yan şekilde dikdörtgen
        block.transform.localScale = new UnityEngine.Vector3(2f, 1f, 1f);
    }
    else
    {
        //Normal kare
        block.transform.localScale = new UnityEngine.Vector3(1f, 1f, 1f);
    }
    
    //yukarı doğru kuvvet uygula 
    Rigidbody2D rb = block.GetComponent<Rigidbody2D>();
    rb.AddForce(UnityEngine.Vector3.up * upwardForce, ForceMode2D.Impulse);
   }
}
