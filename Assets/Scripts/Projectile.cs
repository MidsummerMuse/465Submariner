using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private float speed = 1f;

    void Update()
    {
        // move laser left-to-right 
        transform.Translate(Vector3.right * (speed / transform.lossyScale.x) * Time.deltaTime, Space.World);

        //destriy laser
        if (transform.position.x > 20) 
        {
            Destroy(this.gameObject);
        }
    }
}
