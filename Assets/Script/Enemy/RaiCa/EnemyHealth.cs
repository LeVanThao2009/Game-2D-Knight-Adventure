using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
    [Header("EnemyHealth")]
    public float maxHealth;
    float currenHealth;
    public Animator anim;
    //private SpriteRenderer spriteRend;
    public GameObject deathEffect;
    public static EnemyHealth instance;

    public Slider enemyHealthSlider;

    // khai bao cac bien khi enemy chet se sinh ra item mau
    public bool drop;
    public GameObject theDrop;

    private void Awake()
    {
        makeInstance();
    }
    void makeInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        currenHealth = maxHealth;// mau hien tai bang tong mau
       enemyHealthSlider.maxValue = maxHealth;// gia tri max cua thanh slider bang mau toi da
        enemyHealthSlider.value = maxHealth;
        //spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        
    }
    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            return;
        currenHealth -= damage;
        enemyHealthSlider.value = currenHealth;
        if (currenHealth <= 0)
        {
            Die();
           
        }
    }
    public void Die()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        if (drop)
        {
            Instantiate(theDrop, transform.position, transform.rotation);
        }
    }
}
