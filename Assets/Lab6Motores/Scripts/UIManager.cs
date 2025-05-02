using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image imageFade;


    private void OnEnable()
    {
        InteractableObject.OnPlayerEnterObject += DoFade;
        InteractableObject.OnPlayerExitObject += DoFade;
    }

  
    private void OnDisable()
    {
        InteractableObject.OnPlayerEnterObject -= DoFade;
        InteractableObject.OnPlayerExitObject -= DoFade;
    }
    void DoFade()
    {
        GameManager.Instance.Fade(imageFade);
    }
}
