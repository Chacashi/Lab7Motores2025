using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    public enum PatrolState { Moving, Stopped, Speaking}
    private PatrolState currentState = PatrolState.Moving;
    [SerializeField] private Transform[] pointsPatrol;
    [SerializeField] private float speed;
    [SerializeField] private int currentDirectionPatrol= 0;                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                

    private bool playerTaking = false;
    public static event Action OnCanShowMessage;
    public static event Action OnEnemySpeaking;
    public static event Action OnEnemyFinishSpeaking;


    private void OnEnable()
    {
        InputReader.OnPressedE += SendActiveMessage;
        UIManager.OnShowMessageFinished += AfterSpeaking;
    }
    private void OnDisable()
    {
        InputReader.OnPressedE -= SendActiveMessage;
        UIManager.OnShowMessageFinished -= AfterSpeaking;
    }


    private void Update()
    {
        if( currentState == PatrolState.Moving)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointsPatrol[currentDirectionPatrol].position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, pointsPatrol[currentDirectionPatrol].position) < 0.1f)
            {
                currentState = PatrolState.Stopped;
                StartCoroutine(ChanguePatrolPoint());

            }
        }
        

    }
    IEnumerator ChanguePatrolPoint()
    {
        currentDirectionPatrol++;
        if (currentDirectionPatrol >= pointsPatrol.Length)
        {
            currentDirectionPatrol = 0;
        }
        yield return new WaitForSeconds(1f);
        if(currentState != PatrolState.Speaking)
        {
            currentState = PatrolState.Moving;
        }
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            playerTaking = true;
   
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerTaking = false;
        }
    }

    void SendActiveMessage(bool pressedE)
    {
        if(playerTaking && pressedE)
        {
            currentState = PatrolState.Speaking;
            OnCanShowMessage?.Invoke();
            OnEnemySpeaking?.Invoke();
        }
    }


    void AfterSpeaking()
    {
        currentState = PatrolState.Moving;
        OnEnemyFinishSpeaking?.Invoke();
    }

}