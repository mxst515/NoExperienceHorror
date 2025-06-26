using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScriptNo : MonoBehaviour
{
    [SerializeField]
    public GameObject playerPrefab;
    [SerializeField]
    private Transform spawnPos, playerPos;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger" + other.tag);
        playerPrefab.SetActive(false);
        float d = playerPos.position.z - spawnPos.position.z;
        float movePosZ = playerPos.position.z - (2 * d);
        playerPos.position = new Vector3(spawnPos.position.x, playerPos.position.y, movePosZ);
        playerPos.Rotate(0f, 180, 0f); 
        playerPrefab.SetActive(true);

    }
}
