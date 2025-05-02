using UnityEngine;
using UnityEngine.Audio;


public class ChannelPlayer : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioSettings audioSettings;

    public AudioMixerGroup PlayerChannel => audioSource.outputAudioMixerGroup;
    public AudioSource AudioSource => audioSource;

    private void Awake()
    {
        audioSource.outputAudioMixerGroup = audioSettings.AudioMixerGroup;
    }

    private void OnEnable()
    {
        InteractableObject.OnExitCollisionMusic += StopAudio;
    }

    private void OnDisable()
    {
        InteractableObject.OnExitCollisionMusic -= StopAudio;
    }

    public void PlayerClip(AudioClip clipToPlay)
    {
        audioSource.Stop();

        audioSource.clip = clipToPlay;

        audioSource.Play();
    }

    void StopAudio()
    {
        if (!this.CompareTag("ChannelSfx"))
        {
            audioSource.Stop();
        }
        
    }




}







