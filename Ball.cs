using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;


public class Ball : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    Vector2 check;

    public void getPushed(Vector2 dir,float force){
        rb.AddForce(dir*force);
    }

}
