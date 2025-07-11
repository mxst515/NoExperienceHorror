using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashlightOffsetScript : MonoBehaviour
{
    private Vector3 vectOffset;
    [SerializeField] private GameObject goFollow;

    [SerializeField] private float followSpeed = 3.0f;

    void Start()
    {
        // goFollow = Camera.main.gameObject;
        vectOffset = transform.position - goFollow.transform.position;

    }

    void Update()
    {
        transform.position = goFollow.transform.position + vectOffset;
        transform.rotation = Quaternion.Slerp(transform.rotation, goFollow.transform.rotation, followSpeed * Time.deltaTime);
    }

}
