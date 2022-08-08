using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Propiedades
    public float speed = 2f;
    public float rotationSpeed = 500f;
    bool alreadyEntered = false;
    float sizeCooldown = 1f;
    float sizeStart = 0;

    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        sizeStart += Time.deltaTime;
        movement();
    }
    void MovePlayer(Vector3 direction)
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    void movement()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MovePlayer(Vector3.forward);
        }
        if (Input.GetKey(KeyCode.S))
        {
            MovePlayer(Vector3.back);
        }
        float h = Time.deltaTime * rotationSpeed * Input.GetAxis("Horizontal");
        transform.Rotate(0, h, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Portal") & sizeStart > sizeCooldown & alreadyEntered == false)
        {
            sizeStart = 0;
            transform.localScale = new Vector3(1, 1, 1);
            alreadyEntered = true;
        }
        if (other.gameObject.CompareTag("Portal") & sizeStart > sizeCooldown & alreadyEntered == true)
        {
            transform.localScale = new Vector3(2, 2, 2);
            alreadyEntered = false;
        }
    }

    
}
