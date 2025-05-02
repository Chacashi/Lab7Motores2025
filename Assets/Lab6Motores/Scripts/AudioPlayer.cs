using UnityEngine;
using UnityEngine.Audio;


public class AudioPlayer : MonoBehaviour
{
    [SerializeField] private ChannelPlayer musicPlayer;
    [SerializeField] private ChannelPlayer sfxPlayer;
    [SerializeField] private AudioClip intersectionRoomsClip;
    private void OnEnable()
    {
        InteractableObject.OnCollisionMusic += PlayPlayer;
        InteractableObject.OnPlayNewMusic += PlayOneshoot;
        InteractableObject.OnExitCollisionMusic += PlayOneshoot;

    }

    private void OnDisable()
    {
        InteractableObject.OnCollisionMusic -= PlayPlayer;
        InteractableObject.OnPlayNewMusic -=PlayOneshoot;
        InteractableObject.OnExitCollisionMusic -=PlayOneshoot;
    }

    private void PlayPlayer(AudioMixerGroup currentGroup, AudioClip currentAudioClip)
    {
        if (currentGroup == musicPlayer.PlayerChannel)
        {
            musicPlayer.PlayerClip(currentAudioClip);
        }
        else
        {
            sfxPlayer.PlayerClip(currentAudioClip);
        }
    }


    void PlayOneshoot()
    {
      
        sfxPlayer.AudioSource.PlayOneShot(intersectionRoomsClip);
    }
}







