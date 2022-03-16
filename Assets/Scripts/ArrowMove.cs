using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMove : MonoBehaviour
{

    public float speedArrow = 2.5f;
    float x = 2f;
    private Vector3 velocity;
    float playGame = 0;
    [HideInInspector]
    public bool checkFinish = false;
    [SerializeField]
    GameManager gameManager;
    [SerializeField]
    ArrowControl arrowControl;

    BoxCollider boxCollider;
    [SerializeField]
    CameraControl cameraControl;

    // Start is called before the first frame update
    void Start()
    {
        boxCollider = gameObject.GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0) && checkFinish == false)
        {

            if (Input.GetAxis("Mouse X") < 0)
            {
                Vector3 move = transform.right * -x * Time.deltaTime;
                transform.Translate(move);
            }
            if (Input.GetAxis("Mouse X") > 0)
            {
                Vector3 move = transform.right * x * Time.deltaTime;
                transform.Translate(move);
            }





        }
        // if (playGame == 1)
        playGame = 1;
        velocity = transform.forward * -speedArrow * Time.deltaTime;
        transform.Translate(velocity);
        if (checkFinish)
        {
            transform.SetPositionAndRotation(new Vector3(0, transform.position.y, transform.position.z), Quaternion.identity);
        }


    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "finishline")
        {
            checkFinish = true;
            //gameManager.coin += arrowControl.listArrow.Count + 1;*/
            boxCollider.size = new Vector3(2, boxCollider.size.y, boxCollider.size.z);
            //cameraControl.TransitionSpeed = 0.5f;
            cameraControl.Offset = new Vector3(cameraControl.Offset.x, 1f, -3.5f);
        }
    }

}
