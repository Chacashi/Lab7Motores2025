using UnityEngine;
using UnityEngine.UI;

public class ButtonOpc : MonoBehaviour
{
    Button myButton;

    private void Awake()
    {
        myButton = GetComponent<Button>();
    }
    private void Start()
    {
        myButton.onClick.AddListener(Interactue);
    }

    void Interactue()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }
}
