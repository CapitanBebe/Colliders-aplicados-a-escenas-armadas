using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pared : MonoBehaviour
{

    float portUse = 2f;
    float portStart = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            portStart += Time.deltaTime;
            if (portStart > portUse)
            {
                portStart = 0;
                transform.position = new Vector3(0, 6, 0);
                transform.Rotate= new Vector3(90, 90, 90);
            }
        }
    }
}
