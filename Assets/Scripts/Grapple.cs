using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Pool;

public class Grapple : MonoBehaviour
{
    Rigidbody2D rb;
    LineRenderer lr;
    DistanceJoint2D dj;
    public LayerMask grappleLayer;
    public bool isGrappling;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        dj = GetComponent<DistanceJoint2D>();
        dj.enabled = false;
        lr.enabled = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G))
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (Physics2D.OverlapCircle(point, 0.1f, grappleLayer))
            {
                isGrappling = true;
                dj.enabled = true;
                dj.connectedAnchor = point;
                lr.enabled = true;
                lr.SetPosition(0, transform.position);
                lr.SetPosition(1, point);
            }




        }

        if (Input.GetKeyUp(KeyCode.G))
        {
            dj.enabled = false;
            lr.enabled = false;
            isGrappling = false;
        }

        if(isGrappling)
        {
            Vector3 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            lr.enabled = true;
            lr.SetPosition(0, transform.position);
            lr.SetPosition(1, point);
        }
    }
}
