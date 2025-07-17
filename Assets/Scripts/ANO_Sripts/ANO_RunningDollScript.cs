using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_RunningDollScript : MonoBehaviour
{
    [SerializeField] GameObject doll;
    [SerializeField] GameObject dollTrigger;
    [SerializeField] GameObject dollStart;
    [SerializeField] GameObject dollEnd;
    [SerializeField] AudioSource dollLaught;
    [SerializeField] AudioClip dollLaught_clip;

    [SerializeField] float speed = 10f;

    void OnEnable()
    {
        dollTrigger.SetActive(true);
        doll.SetActive(true);
        doll.transform.position = dollStart.transform.position;
    }

    public IEnumerator runCouroutine(){
        dollTrigger.SetActive(false);
        doll.transform.position = dollStart.transform.position;

        dollLaught.PlayOneShot(dollLaught_clip);
        while(Vector3.Distance(doll.transform.position, dollEnd.transform.position) > 0.1f){
            doll.transform.position = Vector3.MoveTowards(doll.transform.position, dollEnd.transform.position, speed * Time.deltaTime);
        
            yield return null;
        }

        yield return new WaitForSeconds(dollLaught_clip.length - 1.2f);
        doll.SetActive(false);
    }
}
