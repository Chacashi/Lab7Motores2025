using System;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class InteractableObject : MonoBehaviour
{
    [SerializeField] private AudioData audioData;
    [SerializeField] private AudioSettings audioSettings;

    public static event Action<AudioMixerGroup, AudioClip> OnCollisionMusic;
    public static event Action OnPlayNewMusic;
    public static event Action OnExitCollisionMusic;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            OnCollisionMusic?.Invoke(audioSettings.AudioMixerGroup, audioData.AudioClip);
            OnPlayNewMusic?.Invoke();
            if (this.gameObject.CompareTag("Portal1"))
            {
                SceneManager.LoadScene("World 2");
            }
            if (this.gameObject.CompareTag("Portal2"))
            {
                SceneManager.LoadScene("World 1");
            }

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            OnExitCollisionMusic?.Invoke();
        }
    }
}

   










