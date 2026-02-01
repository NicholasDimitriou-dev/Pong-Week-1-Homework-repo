using System;
using Unity.VisualScripting;
using UnityEngine;

public class movemnet : MonoBehaviour {
    public float startingMovemntRight = 10f;
    public float angle = 1f;
    public static Vector3 velocity;
    public static int leftScore = 0;
    public static int rightScore = 0;
    void Start()
    {
        Vector3 force = new Vector3(startingMovemntRight, 0f,  angle);
        Debug.Log(force);
        Rigidbody rBody = GetComponent<Rigidbody>();
        rBody.AddForce(force,ForceMode.VelocityChange);
    }
    //Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Update() {
        Rigidbody rBody = GetComponent<Rigidbody>();
        velocity = rBody.linearVelocity;
    }

    private void OnCollisionEnter(Collision other)
    {
        // Vector3 velocity = GetComponent<Vector3>();
        // velocity.Scale(new Vector3(-1.2f,-1.2f,-1.2f));
        Rigidbody rBody = GetComponent<Rigidbody>();
        if (other.gameObject.tag == "top" || other.gameObject.tag == "bottom") {
            velocity.Scale(new Vector3(1.2f,-1.2f,-1.2f));
        }else if(other.gameObject.tag == "paddle"){
            velocity.Scale(new Vector3(-1.2f,-1.2f,1.2f));
        }else{
            velocity.Scale(new Vector3(0f,0f,0f));
        }
        
        //velocity.Normalize();
        rBody.linearVelocity = velocity;
    }
}
