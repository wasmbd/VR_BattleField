using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

/* this script is to handle the enemy chasing player by setting the palyer transform and */
public class AgentFollow : MonoBehaviour
{

    //DeathTrig
    //RunForwardTrig

    public Transform target;
    public Transform AgentPos;
    public GameObject[] Enemies1;
    public GameObject[] Enemies2;
    Vector3 theDestination;
    NavMeshAgent agent;
    private Animator animator;
   
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
      

        animator = GetComponent<Animator>();
        StartCoroutine(DelayedFollow());

       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bullet"))
        {
            animator.SetTrigger("DeathTrig");
            agent.destination = AgentPos.position;
        }
    }

    IEnumerator DelayedFollow()
    {
        yield return new WaitForSeconds(1f);
        if (target != null)
        {
            if (Vector3.Distance(theDestination, target.position) > 5.0f)
            {
                animator.SetTrigger("RunForwardTrig");
                agent.destination = target.position;

            }
        }
        yield return new WaitForSeconds(2f);
        foreach (GameObject go in Enemies1)
        {
            animator.SetTrigger("RunForwardTrig");
            yield return new WaitForSeconds(2f);
        }
    }
}
