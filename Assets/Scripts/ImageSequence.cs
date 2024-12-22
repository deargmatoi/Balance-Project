using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ImageSequence : MonoBehaviour
{
    public Sprite[] images; // S�rayla g�sterilecek g�rseller
    public Image displayImage; // UI'deki Image bile�eni
    public string nextSceneName; // Ge�ilecek sahne ad�

    private int currentIndex = 0; // �u anda g�sterilen g�rselin indeksi

    void Start()
    {
        if (images.Length > 0)
        {
            displayImage.sprite = images[currentIndex]; // �lk g�rseli g�ster
        }
        else
        {
            Debug.LogError("G�rseller atanmad�!");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return)) // Enter tu�una bas�ld���nda
        {
            ShowNextImage();
        }
    }

    void ShowNextImage()
    {
        currentIndex++; // Bir sonraki g�rsele ge�

        if (currentIndex < images.Length)
        {
            displayImage.sprite = images[currentIndex]; // Yeni g�rseli g�ster
        }
        else
        {
            SceneManager.LoadScene(nextSceneName); // Son g�rselden sonra sahneye ge�
        }
    }
}
