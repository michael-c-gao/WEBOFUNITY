
using UnityEngine;

public class MoveCamera : MonoBehaviour
{

    public AudioClip backgroundAmbienceSound;
    private AudioSource backgroundAmbienceAudioSource;
    
    public Transform player;

    void Start()
    {
        backgroundAmbienceAudioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!backgroundAmbienceAudioSource.isPlaying)
        {
            backgroundAmbienceAudioSource.volume = 0.1f;
            backgroundAmbienceAudioSource.clip = backgroundAmbienceSound;
            backgroundAmbienceAudioSource.Play();
        }
    }
}
