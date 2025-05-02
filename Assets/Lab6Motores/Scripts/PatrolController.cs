using System.Collections;
using UnityEngine;

public class PatrolController : MonoBehaviour
{
    [SerializeField] private Transform[] pointsPatrol;
    [SerializeField] private float speed;
    [SerializeField] private int currentDirectionPatrol= 0;
    private bool canMoving = true;


    private void Update()
    {
        if(canMoving)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointsPatrol[currentDirectionPatrol].position, speed * Time.deltaTime);
        }
        if (Vector3.Distance(transform.position, pointsPatrol[currentDirectionPatrol].position) < 0.1f)
        {
            canMoving = false;
            StartCoroutine(ChanguePatrolPoint());

        }

    }
    IEnumerator ChanguePatrolPoint()
    {
        currentDirectionPatrol++;
        if (currentDirectionPatrol >= pointsPatrol.Length)
        {
            currentDirectionPatrol = 0;
        }
        transform.position = Vector3.MoveTowards(transform.position, pointsPatrol[currentDirectionPatrol].position, speed * Time.deltaTime);
        yield return new WaitForSeconds(1f);
        canMoving = true;
    }
   





}
