using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ANO_2BiggerScript : MonoBehaviour
{
    [SerializeField] GameObject _main_Bed;
    [SerializeField] GameObject _main_sofa_small;
    [SerializeField] GameObject _main_tea_table;
    [SerializeField] GameObject _main_light_desk;
    [SerializeField] GameObject _main_Cabinet;
    [SerializeField] GameObject _main_sofa_big;
    [SerializeField] GameObject _main_clock_wall;

    // Start is called before the first frame update
    void OnEnable()
    {
        _main_Bed.SetActive(false);
        _main_sofa_small.SetActive(false);
        _main_tea_table.SetActive(false);
        _main_light_desk.SetActive(false);
        _main_Cabinet.SetActive(false);
        _main_sofa_big.SetActive(false);
        _main_clock_wall.SetActive(false);
    }

    void OnDisable()
    {
        _main_Bed.SetActive(true);
        _main_sofa_small.SetActive(true);
        _main_tea_table.SetActive(true);
        _main_light_desk.SetActive(true);
        _main_Cabinet.SetActive(true);
        _main_sofa_big.SetActive(true);
        _main_clock_wall.SetActive(true);
    }

}
