using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item_Gold : MonoBehaviour
{
   
    private int golds = 0;
    [SerializeField] private Text TextGold;
    [SerializeField] private AudioSource collectSoundEffect;
    data a;

    private void Start()
    {
        a = FindObjectOfType<data>();
      
    }

    //private void Update()
    //{
    //    golds = a.getGold();
    //    TextGold.text = golds.ToString();
    //}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gold"))
        {
            
            collectSoundEffect.Play();
            Destroy(collision.gameObject);

            golds++;
            TextGold.text ="" +golds;
            //TextGold.text = "x" + golds;
        }
    }
   
}
