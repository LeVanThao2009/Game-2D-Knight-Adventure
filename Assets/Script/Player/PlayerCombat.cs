using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public int attackDamage = 10;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public Animator anim;
    [SerializeField] private AudioSource collectSoundEffect;

    public float attactRate = 0.6f;
    public float attackRange = 1f;
    private float nextAttactTime = 0.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()

    {
        if (Time.time >= nextAttactTime)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                Attack();
                nextAttactTime = Time.time + attactRate / attackRange;
            }
        }
    }
   
    void Attack()
    {
        // Play una animacion
        anim.SetTrigger("Attack");
        collectSoundEffect.Play();
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }
    }
    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }


    public void AttackButton()
    {
        // Hace que no se pueda spamear 
        if (Time.time >= nextAttactTime)
        {
            Attack();
            nextAttactTime = Time.time + attactRate / attackRange;
        }
    }
}
