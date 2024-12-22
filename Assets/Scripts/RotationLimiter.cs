using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationLimiter : MonoBehaviour
{
    public float minRotation = -45f;
    public float maxRotation = 45f;

    void Update()
    {
        // Mevcut rotasyonu al
        float currentRotation = transform.eulerAngles.z;

        // 0-360 arasında hesaplanan açıyı -180 ile 180 arasına dönüştür
        if (currentRotation > 180)
        {
            currentRotation -= 360;
        }

        // Rotasyonu sınırla
        currentRotation = Mathf.Clamp(currentRotation, minRotation, maxRotation);

        // Yeni rotasyonu uygula
        transform.rotation = Quaternion.Euler(0, 0, currentRotation);
    }
}
