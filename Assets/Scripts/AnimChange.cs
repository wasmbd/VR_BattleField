using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimChange : MonoBehaviour
{

    public Animator EnAnim;
    public GameObject Enemy;
    public Animator SolAnim;
   // public GameObject Enemy;
    public float waitTime = 3.0f;
    public float DestroyTime = 1.0f;
    private string[] Sol_animTriggers = { "IdleTrig", "ForwardRightTrig", "TurnLeftTrig", "ShootTrig",
        "ReloadTrig", "walkRIghtTrig" };// Animation triggers for the soldier
    
    private string[] Ene_animTriggers = { "IdleTrig", "TurnLeftTrig", "ReloadTrig", "StandUpTrig"
            , "DeathTrig", "ShootTrig" };// Animation triggers for the enemy
   
    private int currentAnimationIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
       
        /*StartCoroutine(ChangeAnimationState());*/
        StartCoroutine(ChangeAnimationState(SolAnim, Sol_animTriggers, waitTime));//calling
        StartCoroutine(ChangeAnimationState(EnAnim, Ene_animTriggers, waitTime));
    }

    private IEnumerator ChangeAnimationState(Animator animator, string[] animTriggers, float waitTime)
    {
       
        int currentAnimationIndex = 0;//first anim trig

        while (true)
        {
            animator.SetTrigger(animTriggers[currentAnimationIndex]);

            if (animTriggers[currentAnimationIndex] == "DeadTrigger")//to not having the animations play in the background
            {
                if (animator == EnAnim)
                {
                    yield return new WaitForSeconds(0.5f);
                    Destroy(gameObject);
                    Debug.Log("anim destroyed");
                    Destroy(EnAnim.transform.parent.gameObject);
                    Debug.Log("parent destroyed");
                    yield break;// to stop the loop
                }

            }


            currentAnimationIndex = (currentAnimationIndex + 1) % animTriggers.Length;
            yield return new WaitForSeconds(waitTime);

            
        }
      

    }
}
