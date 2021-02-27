using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float speed = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);   
    }

    private void OnTriggerEnter(Collider other)
    {
        if(CompareTag("Playe"))
        {
            Debug.Log("impacto conel jugador");
            Destroy(this.gameObject);

        }
    }

}
