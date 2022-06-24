using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("PlayerHealth")]
    public float maxHealth;
    public float currenHealth;

    [Header("iFrames")]
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfflashes;
    private SpriteRenderer spriteRend;


    public Slider playerHealthSlider;
    // Start is called before the first frame update
    void Start()
    {
        currenHealth = maxHealth;// mau hien tai bang tong mau
        playerHealthSlider.maxValue = maxHealth;// gia tri max cua thanh slider bang mau toi da
        playerHealthSlider.value = maxHealth;
        spriteRend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {
        if (currenHealth <= 0)
        {
            Dead();
        }
    }
    public void TakeDamage(float damage)
    {
        if (damage <= 0)
            return;
        currenHealth -= damage;
        playerHealthSlider.value = currenHealth;
        StartCoroutine(Invunerability());
        
    }
    void Dead()
    {
       
        SceneManager.LoadScene("LoseScenes");

    }

    public void addHealth(float healthAmount)
    {
        currenHealth += healthAmount;
        if (currenHealth > maxHealth)

            currenHealth = maxHealth;
        playerHealthSlider.value = currenHealth;
    }
    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(10, 11, true);
        for(int i =0; i < numberOfflashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfflashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfflashes * 2));
        }
        Physics2D.IgnoreLayerCollision(10, 11, false);
    }
}
