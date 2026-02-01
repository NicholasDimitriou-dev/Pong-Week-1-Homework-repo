using UnityEngine;
using UnityEngine.InputSystem;

public class Paddlebehavior : MonoBehaviour
{
    public string paddleName;

    private float setForce = 5f;

    private InputAction up;
    private InputAction down;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start() {
        if (paddleName == "right") {
            up = new InputAction(binding: "<Keyboard>/o");
            down  = new InputAction(binding: "<Keyboard>/l");
        }

        if (paddleName == "left") {
            up = new InputAction(binding: "<Keyboard>/w");
            down  = new InputAction(binding: "<Keyboard>/s");
        }
        up.Enable();
        down.Enable();
    }

    // Update is called once per frame
    void Update(){
        if (up.IsPressed())
        {
            Vector3 force = new Vector3(0f, 0f,setForce);
            Rigidbody rBody = GetComponent<Rigidbody>();
            rBody.AddForce(force,ForceMode.Force);
            // transform.position += new Vector3(0f, 0f, 1f) * Time.deltaTime;
        }

        if (down.IsPressed()) {
            Vector3 force = new Vector3(0f, 0f, -setForce);
            Rigidbody rBody = GetComponent<Rigidbody>();
            rBody.AddForce(force,ForceMode.Force);
            //transform.position += new Vector3(0f, 0f, -1f) * Time.deltaTime;
        } 
        
    }
}
