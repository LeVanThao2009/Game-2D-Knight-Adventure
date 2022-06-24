using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] public float shootCooldown;
    [SerializeField] public GameObject[] fireball;
    //public int attackDamage = 10;
    [SerializeField] public Transform firePoint;
    public LayerMask enemyLayers;
    [SerializeField] private AudioSource collectSoundEffect;
    private float cooldownTimer = Mathf.Infinity;
    //public float attactRate = 0.6f;
    //public float attackRange = 1f;
    //private float nextAttactTime = 0.5f;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //if (Time.time >= nextAttactTime)
        //{
        //    if (Input.GetKeyDown(KeyCode.S))
        //    {
        //        Shoot();
        //        nextAttactTime = Time.time + attactRate / attackRange;
        //    }
        //}
        if (Input.GetKeyDown(KeyCode.S) && cooldownTimer > shootCooldown)
        {
            Shoot();

        }
        cooldownTimer += Time.deltaTime;
    }

    void Shoot()
    {
        // Play una animacion
        anim.SetTrigger("Shoot");
        collectSoundEffect.Play();
        cooldownTimer = 0;
        fireball[FindFireball()].transform.position = firePoint.position;
        fireball[FindFireball()].GetComponent<ProjectTitle>().SetDirection(Mathf.Sign(transform.localScale.x));

    }
    //private void OnDrawGizmosSelected()
    //{
    //    if (attackPoint == null)
    //    {
    //        return;
    //    }
    //    Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    //}
    private int FindFireball()
    {
        for (int i = 0; i < fireball.Length; i++)
        {
            if (!fireball[i].activeInHierarchy)
                return i;
        }
        return 0;
    }

    public void ShootButton()
    {
        Shoot();
        // Hace que no se pueda spamear 
        //if (Time.time >= nextAttactTime)
        //{
        //    Shoot();
        //    nextAttactTime = Time.time + attactRate / attackRange;
        //}
    }
}
