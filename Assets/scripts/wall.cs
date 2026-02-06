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
    private void Start() {
        score.color = Color.yellow;
        win.SetActive(false);
    }

    private void Update()
    {
        if (score.fontSize > 36)
        {
            score.fontSize -= 0.01f; 
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        score.fontSize += 3;
    if (side == "right") {
            //Destroy(GameObject.FindGameObjectWithTag("ball"));
            movemnet.leftScore++;
            if (movemnet.rightScore < movemnet.leftScore) {
                score.color = Color.blue;
            }
            if (movemnet.rightScore == movemnet.leftScore) {
                score.color = Color.yellow;
            }
            score.text =  movemnet.leftScore.ToString()+"-" + movemnet.rightScore.ToString();
            Debug.Log($"Left side scored, Score is {movemnet.leftScore}-{movemnet.rightScore}");
            if (movemnet.leftScore >= 11) {
                Destroy(GameObject.FindGameObjectWithTag("ball"));
                movemnet.leftScore = 0;
                movemnet.rightScore = 0;
                win.SetActive(true);
                win.GetComponent<TextMeshProUGUI>().text = "Game Over, Left Paddle Wins";
            }else {
                spawnRandom();
            }
        }
        if (side == "left") {
            //Destroy(GameObject.FindGameObjectWithTag("ball"));
            movemnet.rightScore++;
            if (movemnet.rightScore > movemnet.leftScore) {
                score.color = Color.red;
            }
            if (movemnet.rightScore == movemnet.leftScore) {
                score.color = Color.yellow;
            }
            score.text =  movemnet.leftScore.ToString()+"-" + movemnet.rightScore.ToString();
            Debug.Log($"Right side scored, Score is {movemnet.leftScore}-{movemnet.rightScore}");
            if (movemnet.rightScore >= 11) {
                Destroy(GameObject.FindGameObjectWithTag("ball"));
                movemnet.leftScore = 0;
                movemnet.rightScore = 0;
                win.SetActive(true);
                win.GetComponent<TextMeshProUGUI>().text = "Game Over, Right Paddle Wins";
            }else {
                spawnRandom();
            }
        }
    }

    void spawnRandom(){
        
        Transform ballLocation = startingPoint.GetComponent<Transform>();
        ball.transform.position = new Vector3(ballLocation.position.x,ballLocation.position.y,ballLocation.position.z);
        float min = -5f;
        float max = 5f;
        float z = Random.Range(min,max);
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
