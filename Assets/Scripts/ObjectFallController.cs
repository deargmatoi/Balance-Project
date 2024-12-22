using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectFallController : MonoBehaviour
{
    float wait = 2.1f;
    public GameObject fallingObject;
    public Transform character; // Karakterin pozisyonu
    public float spawnOffset = 1.5f; // Blokların karakterin sağında ve solunda oluşturulacağı mesafe
    public float redBlockChance = 0.3f; // Kırmızı blok çıkma olasılığı (0.3 = %30)
    public float specialShapeChance = 0.2f; // Özel şekillerin gelme olasılığı (0.2 = %20)
    public float upwardForce = 5f; // Yukarıya uygulanacak kuvvet
    public float horizontalRange = 10f; // Blokların rastgele düşeceği yatay mesafe
    public float upwardDuration = 0.5f; // Yukarı hareket süresi
    public float characterMoveSpeed = 5f; // Karakterin hareket hızı

    private Vector3 nextBlockPosition; // Bir sonraki blok pozisyonu
    
    [SerializeField] private Animator animator;

    public ToySpawner toySpawner;

    void Start()
    {
        nextBlockPosition = GetRandomBlockPosition();
        InvokeRepeating("SpawnBlock", wait, wait);
    }

    void Update()
    {
        // Karakteri bir sonraki blok pozisyonuna doğru hareket ettir
        character.position = Vector3.MoveTowards(character.position, nextBlockPosition, characterMoveSpeed * Time.deltaTime);
    }

    void SpawnBlock()
    {
        // Eğer karakter hedef pozisyona ulaşmışsa blok oluştur
        if (Vector3.Distance(character.position, nextBlockPosition) < 0.1f)
        {
            // Yeni blok pozisyonu hesapla
            nextBlockPosition = GetRandomBlockPosition();

            // Blok oluşturulacak pozisyon
            float randomOffset = Random.Range(-spawnOffset, spawnOffset); // Karakterin sağ ve sol yanına rasgele offset
            Vector3 spawnPosition = new Vector3(character.position.x + randomOffset, character.position.y, 0);

            // Oyuncak spawnlama işlemi
            toySpawner.SpawnToy(spawnPosition);

            // Animator'deki "Spawn" trigger'ını tetikle
            animator.SetTrigger("Spawn");

            /*
            // Yeni blok oluştur
            GameObject block = Instantiate(fallingObject, spawnPosition, Quaternion.identity);

            // Rastgele olasılık kontrolü (renk)
            if (Random.value < redBlockChance)
            {
                // Blok rengi kırmızı yapılıyor
                Renderer blockRenderer = block.GetComponent<Renderer>();
                if (blockRenderer != null)
                {
                    blockRenderer.material.color = Color.red;
                }
            }

            // Rastgele şekil ve boyut kontrolü
            float sizeChance = Random.value;

            if (sizeChance < specialShapeChance * 0.5f)
            {
                // Yarı boyutunda kare
                block.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
            }
            else if (sizeChance < specialShapeChance)
            {
                // Yan şekilde dikdörtgen
                block.transform.localScale = new Vector3(2f, 1f, 1f);
            }
            else
            {
                // Normal kare
                block.transform.localScale = new Vector3(1f, 1f, 1f);
            }

            // Yukarı doğru kuvvet uygula
            Rigidbody2D rb = block.GetComponent<Rigidbody2D>();
            if (rb == null)
            {
                rb = block.AddComponent<Rigidbody2D>();
            }
            rb.gravityScale = 0; // Geçici olarak yerçekimini kapat
            rb.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);

            // Yukarı hareket sonrası rastgele bir yere düşmesini sağla
            */
            //StartCoroutine(ApplyRandomFallForce(rb));
        }
    }

    Vector3 GetRandomBlockPosition()
    {
        // Yeni bir rastgele pozisyon hesapla (karakterin x ekseninde hareket edeceği yer)
        float randomX = Random.Range(-horizontalRange, horizontalRange);
        return new Vector3(randomX, character.position.y, 0);
    }

    IEnumerator ApplyRandomFallForce(Rigidbody2D rb)
    {
        // Yukarı hareket süresi boyunca bekle
        yield return new WaitForSeconds(upwardDuration);

        // Blok yatayda rastgele bir yere doğru hareket etsin
        float randomHorizontalForce = Random.Range(-horizontalRange, horizontalRange);
        rb.velocity = Vector2.zero; // Mevcut hareketi sıfırla
        rb.gravityScale = 1; // Yerçekimini tekrar aktif et
        rb.AddForce(new Vector2(randomHorizontalForce, 0), ForceMode2D.Impulse);
    }
}
