using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrayBalance : MonoBehaviour
{
    public Transform character;      // Karakterin Transform'u
    public float rotationThreshold = 10f; // Denge aralığı (-10° ila 10°)
    public float imbalanceForce = 5f;    // Dengesizlik kuvveti
    public float resetSpeed = 2f;       // Rotasyon sıfırlama hızı

    private Rigidbody2D trayRb;        // Çubuğun Rigidbody'si
    private bool isResetting = false;  // Rotasyon sıfırlama durumu

    private void Start()
    {
        trayRb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        // Çubuğun rotasyonunu al (Z ekseni)
        float currentRotation = transform.localEulerAngles.z;
        if (currentRotation > 180) currentRotation -= 360; // Rotasyonu -180 ile 180 arasında normalize et

        // Eğer rotasyon denge aralığının dışındaysa
        if (Mathf.Abs(currentRotation) > rotationThreshold)
        {
            isResetting = false; // Sıfırlama modundan çık
            float imbalanceDirection = currentRotation > 0 ? -1 : 1; // Rotasyona göre yön
            Vector2 imbalancePosition = new Vector2(
                transform.position.x + imbalanceDirection * 0.5f,
                transform.position.y
            );

            // Çubuğa dengesizlik kuvveti uygula
            trayRb.AddForceAtPosition(new Vector2(0, imbalanceForce * imbalanceDirection), imbalancePosition);
        }
        else
        {
            // Eğer çubuk denge aralığındaysa, sıfırlama işlemini başlat
            if (!isResetting)
            {
                isResetting = true; // Sıfırlama moduna gir
            }

            // Rotasyonu yavaşça sıfırla
            float targetRotation = Mathf.MoveTowardsAngle(currentRotation, 0, resetSpeed * Time.fixedDeltaTime);
            transform.localRotation = Quaternion.Euler(0, 0, targetRotation);

            // Eğer rotasyon sıfırlandıysa sıfırlama modunu kapat
            if (Mathf.Approximately(targetRotation, 0))
            {
                isResetting = false; // Sıfırlama tamamlandı
            }
        }
    }
}
