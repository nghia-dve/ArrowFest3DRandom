using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateMove : MonoBehaviour
{
    float x = 1.5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        Vector3 move = transform.right * x * Time.deltaTime;
        transform.Translate(move);


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "wall1")
        {
            x *= (-1);
        }
        if (other.tag == "wall2")
        {
            x *= (-1);
        }
    }
}
