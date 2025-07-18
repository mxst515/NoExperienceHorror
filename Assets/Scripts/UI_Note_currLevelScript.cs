using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Note_currLevelScript : MonoBehaviour
{
    [SerializeField] GameManagerScript gm;

    [SerializeField] TextMeshProUGUI currLevelText;

    void Update()
    {
        currLevelText.text = gm.GetCurrentLevel().ToString();
    }
}
