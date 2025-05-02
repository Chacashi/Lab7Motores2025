
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
   public static GameManager Instance { get; private set; }
   [SerializeField] private float durationFade;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }

            Instance = this;
            DontDestroyOnLoad(this.gameObject);

    }


    public void Fade(Image image)
    {
        DOTween.Kill(image);
        Sequence fadeSequence = DOTween.Sequence();
        
        fadeSequence.Append(image.DOFade(1f, durationFade));
        fadeSequence.AppendInterval(0.1f);
        fadeSequence.Append(image.DOFade(0f, durationFade));
    }
}
