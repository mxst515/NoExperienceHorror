using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterAudio : MonoBehaviour
{
    [SerializeField] AudioSource audioSourceWarning;
    [SerializeField] AudioSource audioSourceDead;
    [SerializeField] AudioClip deadClip;

    [SerializeField] GameObject DeadUI;
    [SerializeField] RawImage DeadImage;

    [SerializeField] GameObject player;
    [SerializeField] CharacterController playerController;
    [SerializeField] private Transform spawnPos, playerPos;

    [SerializeField] SetupLoaderScript setupLoader;
    [SerializeField] GameManagerScript gm;

    void OnEnable()
    {
        audioSourceWarning.enabled = true;
        audioSourceWarning.spatialBlend = 1f;
        audioSourceWarning.volume = 0.2f;

        DeadUI.SetActive(false);
    }

    public void Change3dSound(){
        audioSourceWarning.spatialBlend = 0f;
        audioSourceWarning.volume = 0.1f;
    }

    public IEnumerator DeadCoroutine(){
        DeadUI.SetActive(true);
        SetAlphaDead(1f, DeadImage);

        audioSourceWarning.enabled = false;
        audioSourceDead.PlayOneShot(deadClip);

        playerController.enabled = false;
        yield return new WaitForSeconds(3f);

        TpPlayerDead();
        StartCoroutine(setupLoader.fadeCoroutineStart(DeadImage));
        yield return new WaitForSeconds(1.5f);
        RestarPlayerDead();
        playerController.enabled = true;
    }

    public void TpPlayerDead(){
        player.SetActive(false);
        playerPos.position = new Vector3(spawnPos.position.x, playerPos.position.y, spawnPos.position.z);
        player.SetActive(true);
    }

    public void RestarPlayerDead(){
        gm.RestartCurrentLevel();
        gm.UnsetAllAnomalies();
        gm.SetAnomaly(gm.SmartGenerateAnomaly());
    }

    private void SetAlphaDead(float alpha, RawImage image)
    {
        Color color = image.color;
        color.a = alpha;
        image.color = color;
    }

}
