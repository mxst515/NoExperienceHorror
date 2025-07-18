using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LevelSystemScript : MonoBehaviour
{
    [SerializeField] private TextMeshPro levelNumber;
    public GameManagerScript gm;

    void Update()
    {
        levelNumber.text = gm.GetCurrentLevel().ToString();
    }

}
