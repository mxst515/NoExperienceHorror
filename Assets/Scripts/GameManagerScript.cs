using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{
    public static bool IsAnomaly;
    [Header("ANOMALIES")]
    [SerializeField] private GameObject ANO_None;
    [SerializeField] private GameObject ANO_Paintings;
    [SerializeField] private GameObject ANO_Television;
    [SerializeField] private GameObject ANO_RedLight;
    [SerializeField] private GameObject ANO_LeanMonster;
    [SerializeField] private GameObject ANO_NoLights;
    [SerializeField] private GameObject ANO_NoCarpets;
    [SerializeField] private GameObject ANO_CarpetTrail;

    public List<GameObject> ListAnomalies;

    [Header("DEBUG")]
    [SerializeField] private int _DEBUG_anomIndex;
    [SerializeField] private bool _DEBUG_isAnom;
    [SerializeField] private string _DEBUG_anomName;
    [SerializeField] private int _DEBUG_firstAnom;

    void Start()
    {
        ListAnomalies.Add(ANO_None);
        ListAnomalies.Add(ANO_Paintings);
        ListAnomalies.Add(ANO_Television);
        ListAnomalies.Add(ANO_RedLight);
        ListAnomalies.Add(ANO_LeanMonster);
        ListAnomalies.Add(ANO_NoLights);
        ListAnomalies.Add(ANO_NoCarpets);
        ListAnomalies.Add(ANO_CarpetTrail);

        foreach(GameObject anom in ListAnomalies){
            // Debug.Log(anom.name);
        }

        UnsetAllAnomalies();
        SetAnomaly(_DEBUG_firstAnom);
    }

    void Update()
    {
        Debug.Log(IsAnomaly);
    }

    public void UnsetAllAnomalies(){
        foreach(GameObject anom in ListAnomalies){
            anom.SetActive(false);
        }
    }

    public int GenerateAnomaly(){
        int maxIndex = GetListAnomaliesLength();
        int gen = Random.Range(0, maxIndex);
        // Debug.Log(gen);
        _DEBUG_anomIndex = gen;
        return gen;
    }

    public void SetAnomaly(int index){
        ListAnomalies[index].SetActive(true);
        if(ListAnomalies[index].name == "ANO_None"){
            IsAnomaly = false;
        }
        else{
            IsAnomaly = true;
        }
        _DEBUG_anomName = ListAnomalies[index].name;
    }

    public int GetListAnomaliesLength(){
        return ListAnomalies.Count;
    }

    public bool GetIsAnomaly(){
        return IsAnomaly;
    }


}
