using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.UIElements;

public class Player : MonoBehaviour {
    // Start is called before the first frame update

    private float playerSpeed = 5f;

    private float fireRate = 0.5f;

    private float nextFire;

    public GameObject laserPrefab;

    void Start(){
        transform.position = new Vector3(0, -4, 0);
    }

    // Update is called once per frame
    void Update(){
        if (Input.GetKey(KeyCode.Mouse0) && Time.time > nextFire) {
            Instantiate(laserPrefab, new Vector3(transform.position.x, (transform.position.y + 0.5f)), Quaternion.identity);
            nextFire = Time.time + fireRate;
        }

        TrackPlayerMovement();
    }

    void WrapXBounds(){
        if (transform.position.x > 11.3f) {
            transform.position = new Vector3(-11.3f, transform.position.y);
        }
        else if (transform.position.x < -11.3f) {
            transform.position = new Vector3(11.3f, transform.position.y);
        }
    }

    void ClampYBounds() {
        float positionY = Mathf.Clamp(transform.position.y, -5, 0);
        transform.position = new Vector3(transform.position.x, positionY);
    }

    void TrackPlayerMovement() {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 playerDirection = new Vector3(horizontalInput, verticalInput, 0);

        transform.Translate(playerSpeed * Time.deltaTime * playerDirection);

        ClampYBounds();
        WrapXBounds();
    }
}
