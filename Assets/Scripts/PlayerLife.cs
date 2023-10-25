using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    [SerializeField] private AudioSource deathSound;

    private void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            
        }
    }
   
   private void Die()
   {
       anim.SetTrigger("death");
       Debug.Log("You died!");
       rb.bodyType = RigidbodyType2D.Static;
       deathSound.Play();
   }

   private void Restart()
   {
       SceneManager.LoadScene(SceneManager.GetActiveScene().name);
   }
}
