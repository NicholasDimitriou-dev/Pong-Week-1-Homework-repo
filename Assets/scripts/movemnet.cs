using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;
[RequireComponent(typeof(AudioSource))]
public class movemnet : MonoBehaviour {
    public float startingMovemntRight = 10f;
    public float angle = 1f;
    public static Vector3 velocity;
    public static int leftScore = 0;
    public static int rightScore = 0;
    public int cooldownTime;
    public AudioClip soundEffect;
    public AudioClip soundEffect2;
    AudioSource audioSource;
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

    private void OnCollisionEnter(Collision collision)
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        // Vector3 velocity = GetComponent<Vector3>();
        // velocity.Scale(new Vector3(-1.2f,-1.2f,-1.2f));
        Rigidbody rBody = GetComponent<Rigidbody>();
        if (collision.gameObject.tag == "top" ||  collision.gameObject.tag == "bottom") {
            velocity.Scale(new Vector3(1.2f,-1.2f,-1.2f));
            audioSource.volume = Math.Abs(velocity.x) / 100f;
            audioSource.PlayOneShot(soundEffect2);
        }else if(collision.gameObject.tag == "paddle"){
            velocity.Scale(new Vector3(-1.2f,-1.2f,1.8f));
            audioSource.volume = Math.Abs(velocity.x) / 100f;
            audioSource.PlayOneShot(soundEffect);
        }else{
            velocity.Scale(new Vector3(0f,0f,0f));
        }
        
        //velocity.Normalize();
        rBody.linearVelocity = velocity;
    }

    private void OnTriggerEnter(Collider other) {
        Rigidbody rBody = GetComponent<Rigidbody>();
        if (other.gameObject.tag == "angle"){
            float min = -2f;
            float max = 2f;
            float z = Random.Range(min,max)*4;
            Debug.Log(z);
            velocity.Scale(new Vector3(1f,1f,-1f));
            StartCoroutine(Cooldown(other, cooldownTime));
        }else if (other.gameObject.tag == "speed") {
            float min = 0.8f;
            float max = 1.4f;
            float z = Random.Range(min, max);
            Debug.Log(z);
            velocity.Scale(new Vector3(z, 1f, 1f));
            StartCoroutine(Cooldown(other, cooldownTime));
        }

        rBody.linearVelocity = velocity;
    }

    private IEnumerator Cooldown(Collider other, int seconds)
    {
        other.gameObject.SetActive(false);
        yield return new WaitForSeconds(seconds);
        other.gameObject.SetActive(true);
    }
}

