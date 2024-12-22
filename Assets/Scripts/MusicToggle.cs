using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public AudioSource backgroundMusic;  // Arka plan m�zi�i i�in AudioSource
    public Button musicToggleButton;     // M�zik a�/kapa butonu

    void Start()
    {
        // Ba�lang��ta butonun i�levini ayarlay�n
        musicToggleButton.onClick.AddListener(ToggleMusic);  // Butona t�kland���nda ToggleMusic fonksiyonunu �al��t�r
    }

    // M�zik a�/kapa fonksiyonu
    public void ToggleMusic()
    {
        // M�zik durumu (mute) kontrol edilir
        backgroundMusic.mute = !backgroundMusic.mute;  // mute'� tersine �evir (A��k -> Kapal�, Kapal� -> A��k)

  
    }

    
   
}
