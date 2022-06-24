using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFllow : MonoBehaviour
{
    //public GameObject player;

    //public float smoothTime;

    //public Vector2 Velocity;
    //// Start is called before the first frame update
    //void Start()
    //{
    //    player = GameObject.FindGameObjectWithTag("Player");
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    float posX = Mathf.SmoothDamp(this.transform.position.x, player.transform.position.x, ref Velocity.x, smoothTime);
    //    float posY = Mathf.SmoothDamp(this.transform.position.y, player.transform.position.x, ref Velocity.y, smoothTime);
    //    this.transform.position = new Vector3(posX, posY, transform.position.z);
    //}
    public Transform target;
    public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    //[HideInInspector]
    public Vector3 minValues, maxValue;
    // Start is called before the first frame update
    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = target.position + offset;
        //Verify if the targetPosition is out of bound or not
        //Limit it to the min and max values
        Vector3 boundPosition = new Vector3(
            Mathf.Clamp(targetPosition.x, minValues.x, maxValue.x),
            Mathf.Clamp(targetPosition.y, minValues.y, maxValue.y),
            Mathf.Clamp(targetPosition.z, minValues.z, maxValue.z));

        Vector3 smoothPosition = Vector3.Lerp(transform.position, boundPosition, smoothFactor * Time.fixedDeltaTime);
        transform.position = smoothPosition;
    }
}
