using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TeleportScriptYes : MonoBehaviour
{
    public GameManagerScript gm;

    [SerializeField]
    public GameObject playerPrefab;
    [SerializeField]
    private Transform spawnPos, playerPos;

    [SerializeField] private TeleportFadeScriptYes tpFade;

    void OnTriggerEnter(Collider other)
    {
        // Debug.Log("trigger" + other.tag);
        if(other.tag == "Player"){

            playerPrefab.SetActive(false);
            float d = transform.position.z - playerPos.position.z;
            float movePosZ = spawnPos.position.z - d;
            playerPos.position = new Vector3(spawnPos.position.x, playerPos.position.y, movePosZ);
            playerPrefab.SetActive(true);

            tpFade.SetFullBlackInstant();
            tpFade.StartCoroutine(tpFade.fadeCoroutineYes());


            if(gm.GetIsAnomaly()){
                // Debug.Log("IsAnBad");
                gm.RestartCurrentLevel();
            }
            else{
                // Debug.Log("IsAnGood");
                if(gm.GetCurrentLevel() < 8){
                    gm.IncreaseCurrentLevel();
                }
                else if (gm.GetCurrentLevel() >= 8){
                    SceneManager.LoadScene(2);
                }
            }

            gm.UnsetAllAnomalies();
            // gm.SetAnomaly(gm.GenerateAnomaly());
            gm.SetAnomaly(gm.SmartGenerateAnomaly());
        }
    }

}
