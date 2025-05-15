using UnityEngine;

public class AudioMainMenu : MonoBehaviour
{
    [Header("---- Audio Source ----")]
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource effectsSource;
    
    [Header("---- Audio Clips ----")]
    public AudioClip mainBackground;
    
    public void Start()
    {
        musicSource.PlayOneShot(mainBackground);
    }
}
