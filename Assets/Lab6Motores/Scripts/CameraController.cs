using Unity.Cinemachine;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    CinemachineCamera cam;
    [SerializeField] Transform playerTransform;
    [SerializeField] Transform enemyTransform;


    private void Awake()
    {
        cam = GetComponent<CinemachineCamera>();
    }

    private void OnEnable()
    {
        PatrolController.OnCanShowMessage += SetTracking;
        UIManager.OnShowMessageFinished += SetTracking;
    }

    private void OnDisable()
    {
        PatrolController.OnCanShowMessage -= SetTracking;
        UIManager.OnShowMessageFinished -= SetTracking;
    }
    public void SetTracking()
    {
        if(cam.Follow == playerTransform)
        {
            cam.Follow = enemyTransform;
        }
        else
        {
            cam.Follow = playerTransform;
        }
        
    }

}
