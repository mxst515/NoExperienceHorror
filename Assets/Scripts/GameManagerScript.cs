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
    [SerializeField] private GameObject ANO_ToyOnBed;
    [SerializeField] private GameObject ANO_PaintsOnFloor;
    [SerializeField] private GameObject ANO_SittingMonster;
    [SerializeField] private GameObject ANO_Fire;
    [SerializeField] private GameObject ANO_GlowEyes;
    [SerializeField] private GameObject ANO_SamePosters;
    [SerializeField] private GameObject ANO_ModernCameras;
    [SerializeField] private GameObject ANO_FullLights;

    public List<GameObject> ListAnomalies;

    [SerializeField] private List<GameObject> availableAnomalies = new List<GameObject>();

    [Header("DEBUG")]
    [Range(0f, 1f)]
    [SerializeField] private float anomalySpawnChance = 0.5f;

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
        ListAnomalies.Add(ANO_ToyOnBed);
        ListAnomalies.Add(ANO_PaintsOnFloor);
        ListAnomalies.Add(ANO_SittingMonster);
        ListAnomalies.Add(ANO_Fire);
        ListAnomalies.Add(ANO_GlowEyes);
        ListAnomalies.Add(ANO_SamePosters);
        ListAnomalies.Add(ANO_ModernCameras);
        ListAnomalies.Add(ANO_FullLights);

        foreach(GameObject anom in ListAnomalies){
            // Debug.Log(anom.name);
        }

        UnsetAllAnomalies();
        InitAnomalyPool();
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

    public void InitAnomalyPool(){
        availableAnomalies.Clear();

        for (int i = 1; i<ListAnomalies.Count; i++){
            availableAnomalies.Add(ListAnomalies[i]);
        }
    }

    public int GenerateAnomaly(){
        int maxIndex = GetListAnomaliesLength();
        int gen = Random.Range(0, maxIndex);
        // Debug.Log(gen);
        _DEBUG_anomIndex = gen;
        return gen;
    }

    public int SmartGenerateAnomaly(){
        if(Random.value > anomalySpawnChance){
            return 0; // NONE anomaly
        }

        if(availableAnomalies.Count == 0){
            InitAnomalyPool();
        }

        int randIndex = Random.Range(0, availableAnomalies.Count);

        GameObject chosenAnomaly = availableAnomalies[randIndex];
        availableAnomalies.RemoveAt(randIndex);

        return ListAnomalies.IndexOf(chosenAnomaly);

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
