using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public AudioSource backgroundMusic;  // Arka plan müziði için AudioSource
    public Button musicToggleButton;     // Müzik aç/kapa butonu

    void Start()
    {
        // Baþlangýçta butonun iþlevini ayarlayýn
        musicToggleButton.onClick.AddListener(ToggleMusic);  // Butona týklandýðýnda ToggleMusic fonksiyonunu çalýþtýr
    }

    // Müzik aç/kapa fonksiyonu
    public void ToggleMusic()
    {
        // Müzik durumu (mute) kontrol edilir
        backgroundMusic.mute = !backgroundMusic.mute;  // mute'ý tersine çevir (Açýk -> Kapalý, Kapalý -> Açýk)

  
    }

    
   
}
