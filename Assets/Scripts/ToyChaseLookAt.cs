using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToyChaseLookAt : MonoBehaviour
{
    [SerializeField] GameObject player;

    void Update()
    {
        transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
    }
}
