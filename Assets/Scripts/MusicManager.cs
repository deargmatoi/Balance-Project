using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;  // Singleton örneði

    public AudioSource backgroundMusic;  // Arka plan müziði için AudioSource

    void Awake()
    {
        // Ayný müzik yöneticisinin baþka bir örneði varsa, bu nesneyi sil
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Bu nesneyi sahneler arasýnda taþý
        }
    }

    void Start()
    {
        // Müzik baþlamalýysa, burada baþlatýlýr.
        if (!backgroundMusic.isPlaying)
        {
            backgroundMusic.Play();
        }
    }
}
