using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportScriptYes : MonoBehaviour
{
    public GameManagerScript gm;

    [SerializeField]
    public GameObject playerPrefab;
    [SerializeField]
    private Transform spawnPos, playerPos;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger" + other.tag);
        playerPrefab.SetActive(false);
        float d = transform.position.z - playerPos.position.z;
        float movePosZ = spawnPos.position.z - d;
        playerPos.position = new Vector3(spawnPos.position.x, playerPos.position.y, movePosZ);
        playerPrefab.SetActive(true);

        if(gm.GetIsAnomaly()){
            Debug.Log("IsAnBad");
        }
        else{
            Debug.Log("IsAnGood");
        }

        gm.UnsetAllAnomalies();
        // gm.SetAnomaly(gm.GenerateAnomaly());
        gm.SetAnomaly(gm.SmartGenerateAnomaly());

    }

}
