using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastFollow : MonoBehaviour
{
    [SerializeField] private GameObject goFollow;

    void Update()
    {
        transform.position = goFollow.transform.position;
        transform.rotation = Quaternion.Slerp(transform.rotation, goFollow.transform.rotation, 1);
    }
}
