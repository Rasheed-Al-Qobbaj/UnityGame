using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{

    private int bananaCount = 0;

    [SerializeField] private Text BananaCountText;
    
    [SerializeField] private AudioSource bananaSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            bananaSound.Play();
            Destroy(collision.gameObject);
            bananaCount++;
            BananaCountText.text = "Bananas: " + bananaCount;
        }
    }
}
