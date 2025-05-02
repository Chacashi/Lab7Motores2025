using UnityEngine;



public class AudioManager : MonoBehaviour
{
    [SerializeField] private AudioSettings[] audioSettings;
    [SerializeField] private AudioSource ChannelMusic;
    
 

    private float[] _savedVolumes;
    private int _dataLength;

    private void Awake()
    {
        _dataLength = audioSettings.Length;

        _savedVolumes = new float[_dataLength];
    }

    private void OnEnable()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            _savedVolumes[i] = audioSettings[i].VolumeScaled;
        }


        InteractableObject.OnPlayNewMusic += StopAudio;
        InteractableObject.OnExitCollisionMusic += PlayAudio;
    }

    private void OnDisable()
    {
        InteractableObject.OnPlayNewMusic -= StopAudio;
        InteractableObject.OnExitCollisionMusic -= PlayAudio;
    }

    public void RevertChanges()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            audioSettings[i].UpdateVolume(_savedVolumes[i]);
        }
    }

    public void ApplyChange()
    {
        for (int i = 0; i < _dataLength; i++)
        {
            audioSettings[i].SaveDataFile();

            _savedVolumes[i] = audioSettings[i].VolumeScaled;
        }
    }

    void PlayAudio()
    {
        ChannelMusic.UnPause();
    }

    void StopAudio()
    {
        ChannelMusic.Pause();
    }
}

