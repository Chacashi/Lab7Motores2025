using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;


public class InteractableObject : MonoBehaviour
{
    [SerializeField] private AudioData audioData;
    [SerializeField] private AudioSettings audioSettings;

    public static event Action<AudioMixerGroup, AudioClip> OnCollisionMusic;
    public static event Action OnPlayerEnterObject;
    public static event Action OnPlayerExitObject;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (this.gameObject.CompareTag("Untagged"))
            {
                OnCollisionMusic?.Invoke(audioSettings.AudioMixerGroup, audioData.AudioClip);
                OnPlayerEnterObject?.Invoke();
            }

            if (this.gameObject.CompareTag("Portal1"))
            {
                OnCollisionMusic?.Invoke(audioSettings.AudioMixerGroup, audioData.AudioClip);
                StartCoroutine( ChangueScene("World 2"));
                
            }
            if (this.gameObject.CompareTag("Portal2"))
            {
                OnCollisionMusic?.Invoke(audioSettings.AudioMixerGroup, audioData.AudioClip);
                StartCoroutine(ChangueScene("World 1"));
            } 

        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if(this.gameObject.CompareTag("Untagged"))
            {
                OnPlayerExitObject?.Invoke();
            }
            
        }
    }


    IEnumerator ChangueScene(string world)
    {
        yield return new WaitForSeconds(0.5f);
        SceneManager.LoadScene(world);
    }
}

