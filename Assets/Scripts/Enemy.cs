using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    // Update is called once per frame
    void Update() {
        transform.Translate(4 * Time.deltaTime * Vector3.down);

        if (transform.position.y < -6) {
            transform.position = new Vector3(Random.Range(-10, 10), 7, 0);
        }
    }
}
