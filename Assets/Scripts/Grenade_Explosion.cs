using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grenade_Explosion : MonoBehaviour
{

    public ParticleSystem ExplosionEffect;
    public AudioSource ExplosionSound;
    //private Animator Anim;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy"|| collision.gameObject.tag=="Ground")
        {

            ParticleSystem instantiatedEffect = Instantiate(ExplosionEffect, transform.position, Quaternion.identity);
            instantiatedEffect.Play();
            ExplosionSound.Play();

            // Destroy the particle system after it finishes
            //Destroy(instantiatedEffect.gameObject, instantiatedEffect.main.duration);

            // Destroy the grenade object
            StopSound();
          Destroy(gameObject);
          //  Anim.SetTrigger("DeathTrig");
        }
        
     
    }
    private IEnumerator StopSound()
    {
        yield return new WaitForSeconds(1.3f);
        ExplosionSound.Stop();
    }

}
