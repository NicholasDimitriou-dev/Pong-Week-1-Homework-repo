using System;
using UnityEngine;
using TMPro;
using Random = UnityEngine.Random;

public class wall : MonoBehaviour
{
    public string side;
    public TextMeshProUGUI score;
    public GameObject win;
    public GameObject ball;
    public GameObject startingPoint;

    public float startingMovemntRight = 10f;
    public float angle = 1f;
    // Update is called once per frame
    private void Start()
    {
        win.SetActive(false);
    }

    private void OnCollisionEnter(Collision other)
    {
    if (side == "right") {
            //Destroy(GameObject.FindGameObjectWithTag("ball"));
            movemnet.leftScore++;
            score.text =  movemnet.leftScore.ToString()+"-" + movemnet.rightScore.ToString();
            Debug.Log($"Left side scored, Score is {movemnet.leftScore}-{movemnet.rightScore}");
            if (movemnet.leftScore >= 11) {
                Destroy(GameObject.FindGameObjectWithTag("ball"));
                win.SetActive(true);
                win.GetComponent<TextMeshProUGUI>().text = "Game Over, Left Paddle Wins";
            }else {
                spawnRandom();
            }
        }
        if (side == "left") {
            //Destroy(GameObject.FindGameObjectWithTag("ball"));
            movemnet.rightScore++;
            score.text =  movemnet.leftScore.ToString()+"-" + movemnet.rightScore.ToString();
            Debug.Log($"Right side scored, Score is {movemnet.leftScore}-{movemnet.rightScore}");
            if (movemnet.rightScore >= 11) {
                Destroy(GameObject.FindGameObjectWithTag("ball"));
                win.SetActive(true);
                win.GetComponent<TextMeshProUGUI>().text = "Game Over, Right Paddle Wins";
            }else {
                spawnRandom();
            }
        }
    }

    void spawnRandom(){
        float min = -2.1f;
        float max = 3.33f;
        float z = Random.Range(min,max)*3;
        //Debug.Log(z);
        Transform ballLocation = startingPoint.GetComponent<Transform>();
        ball.transform.position = new Vector3(ballLocation.position.x,ballLocation.position.y,z);
        min = -1;
        max = 1;
        z = Random.Range(min,max);
        if (side == "right")
        {
            Vector3 force = new Vector3(startingMovemntRight, 0f,z);
            Rigidbody rBody = ball.GetComponent<Rigidbody>();
            rBody.AddForce(force,ForceMode.VelocityChange); 
        }

        if (side == "left")
        {
            Vector3 force = new Vector3(-startingMovemntRight, 0f, z);
            Rigidbody rBody = ball.GetComponent<Rigidbody>();
            rBody.AddForce(force,ForceMode.VelocityChange); 
        }
    }
}
