using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    // Propiedades Movimiento
    float speed = 10f;
    float rotationSpeed = 300f;
    // Propiedades Portal
    bool alreadyEntered = false;
    float sizeCooldown = 2f;
    float sizeStart = 0;
    // Propiedades Pared
    public GameObject pared;
    float portUse = 2f;
    float portStart = 0;
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
    // ---------------------------------------------- Movimiento ---------------------------------------------------------------
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
    // ----------------------------------------- Choque con portal -------------------------------------------------------------
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
            sizeStart = 0;
            transform.localScale = new Vector3(2, 2, 2);
            alreadyEntered = false;
        }
    }
    // ------------------------------------------ Choque con pared ------------------------------------------------------------
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Respawn"))
        {
            portStart += Time.deltaTime;
            if (portStart > portUse)
            {
                portStart = 0;
                pared.transform.position = new Vector3(Random.Range(0, 10), Random.Range(0, 10), Random.Range(0, 10));
                pared.transform.rotation = Quaternion.Euler(Random.Range(0, 90), Random.Range(0, 90), Random.Range(0, 90));
            }
        }
    }

}
