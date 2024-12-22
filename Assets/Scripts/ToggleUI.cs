using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject imagePanel; // Görsel ve ona baðlý butonun bulunduðu panel

    public void ShowImagePanel()
    {
        imagePanel.SetActive(true); // Görsel ve butonu aç
    }

    public void HideImagePanel()
    {
        imagePanel.SetActive(false); // Görsel ve butonu kapat
    }
}
