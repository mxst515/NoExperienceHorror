using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_ToyChaseScript : MonoBehaviour
{
    [SerializeField] GameObject Toy;
    [SerializeField] Transform startPos;
    [SerializeField] Transform chP1;
    [SerializeField] Transform chP2;
    [SerializeField] Transform chP3;
    [SerializeField] GameObject ToyTrigger;
    [SerializeField] AudioSource SaudioIn;
    [SerializeField] AudioClip SaudioInClip;
    [SerializeField] float speed = 7f;

    void OnEnable()
    {
        Toy.SetActive(true);
        ToyTrigger.SetActive(true);
        Toy.transform.position = startPos.position;
    }

    public IEnumerator ChaseCoroutine(){
        Toy.transform.position = startPos.position;
        ToyTrigger.SetActive(false);
        SaudioIn.PlayOneShot(SaudioInClip);

        while(Vector3.Distance(Toy.transform.position, chP1.position) > 0.1f){
            Toy.transform.position = Vector3.MoveTowards(Toy.transform.position, chP1.position, speed * Time.deltaTime);
            yield return null;
        }

        while(Vector3.Distance(Toy.transform.position, chP2.position) > 0.1f){
            Toy.transform.position = Vector3.MoveTowards(Toy.transform.position, chP2.position, speed * Time.deltaTime);
            yield return null;
        }

        while(Vector3.Distance(Toy.transform.position, chP3.position) > 0.1f){
            Toy.transform.position = Vector3.MoveTowards(Toy.transform.position, chP3.position, speed * Time.deltaTime);
            yield return null;
        }

        yield return new WaitForSeconds(1.2f);

        while(Vector3.Distance(Toy.transform.position, chP2.position) > 0.1f){
            Toy.transform.position = Vector3.MoveTowards(Toy.transform.position, chP2.position, speed * Time.deltaTime);
            yield return null;
        }

        while(Vector3.Distance(Toy.transform.position, chP1.position) > 0.1f){
            Toy.transform.position = Vector3.MoveTowards(Toy.transform.position, chP1.position, speed * Time.deltaTime);
            yield return null;
        }

        while(Vector3.Distance(Toy.transform.position, startPos.position) > 0.1f){
            Toy.transform.position = Vector3.MoveTowards(Toy.transform.position, startPos.position, speed * Time.deltaTime);
            yield return null;
        }
        
        yield return null;
        Toy.SetActive(false);
    }

}
