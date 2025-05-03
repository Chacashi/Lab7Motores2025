using DG.Tweening;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Image imageFade;
    [SerializeField] private Canvas dialogueEnemy;
    public static event Action OnShowMessageFinished;
    Action showDialogue;

    private void OnEnable()
    {
        InteractableObject.OnPlayerEnterObject += DoFade;
        InteractableObject.OnPlayerExitObject += DoFade;
        showDialogue = () => StartCoroutine(ShowDialogue());
        PatrolController.OnCanShowMessage += showDialogue;
    }

  
    private void OnDisable()
    {
        InteractableObject.OnPlayerEnterObject -= DoFade;
        InteractableObject.OnPlayerExitObject -= DoFade;
        PatrolController.OnCanShowMessage -= showDialogue;
    }
    void DoFade()
    {
        GameManager.Instance.Fade(imageFade);
    }

    IEnumerator ShowDialogue()
    {


        dialogueEnemy.gameObject.SetActive(true);

        yield return new WaitForSeconds(2f);
        dialogueEnemy.gameObject.SetActive(false);
        OnShowMessageFinished?.Invoke();


    }
}
