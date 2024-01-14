using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public float laserSpeed = 15f;
    // Update is called once per frame
    void Update() {
        transform.Translate(laserSpeed * Time.deltaTime * Vector3.up);
        if (transform.position.y >= 10) {
            Destroy(gameObject);
        }
    }
}
