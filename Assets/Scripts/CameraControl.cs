using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public float TransitionSpeed;

    public Transform PlayerFollow;
    [SerializeField]
    public Vector3 Offset;

    private void Awake()
    {
        Offset = transform.position - PlayerFollow.transform.position;
    }

    private void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,
        PlayerFollow.position + Offset, Time.deltaTime * TransitionSpeed);
    }

}
