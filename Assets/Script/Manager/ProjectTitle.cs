using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectTitle : MonoBehaviour
{
    public float weaponDamage;
    [SerializeField] private float speed;
    private bool hit;
    private float direction;
    private Animator anim;
    private BoxCollider2D boxCollider;
    // private EnemyHealth enemy;
   
    public LayerMask enemyLayers;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    private void Update()
    {
        if (hit) return;
        float movementSpeed = speed * Time.deltaTime * direction;
        transform.Translate(movementSpeed, 0, 0);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        hit = true;
        boxCollider.enabled = false;
        anim.SetTrigger("explode");

        if (collision.gameObject.tag == "Enemy")
        {
            
            if (collision.gameObject.layer == LayerMask.NameToLayer("Enemy"))
            {
                EnemyHealth hurtEnemy = collision.gameObject.GetComponent<EnemyHealth>();
                hurtEnemy.TakeDamage(weaponDamage);

            }
        }
    }
    
    public void SetDirection(float d)
    {
        direction = d;
        gameObject.SetActive(true);
        hit = false;
        boxCollider.enabled = true;

        float local = transform.localScale.x;
        if (Mathf.Sign(local) != d)
        {
            local = -local;
        }
        transform.localScale = new Vector3(local, transform.localScale.y, transform.localScale.z);
    }
    private void DeActivate()
    {
        gameObject.SetActive(false);
    }
    
}
