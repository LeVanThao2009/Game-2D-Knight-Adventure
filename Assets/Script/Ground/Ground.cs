using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    public float timeDelay = 3f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Player"))
        {
            StartCoroutine(changeGround());
        }

    }
    IEnumerator changeGround()
    {
        yield return new WaitForSeconds(timeDelay);
        rb.bodyType = RigidbodyType2D.Dynamic;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
