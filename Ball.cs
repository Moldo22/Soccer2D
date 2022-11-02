using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    public void getPushed(Vector2 dir,float force){
        rb.AddForce(dir*force);
    }

}
