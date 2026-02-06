using UnityEngine;

public class Rotator : MonoBehaviour {

    // Update is called once per frame
    void Update() {
        transform.Rotate (new Vector3 (16, 13, 52) * Time.deltaTime);
    }
}
