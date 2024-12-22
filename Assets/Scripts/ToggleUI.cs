using UnityEngine;

public class ToggleUI : MonoBehaviour
{
    public GameObject imagePanel; // G�rsel ve ona ba�l� butonun bulundu�u panel

    public void ShowImagePanel()
    {
        imagePanel.SetActive(true); // G�rsel ve butonu a�
    }

    public void HideImagePanel()
    {
        imagePanel.SetActive(false); // G�rsel ve butonu kapat
    }
}
