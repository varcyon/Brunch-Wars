using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CountdownTimerUI : MonoBehaviour
{
    BrawlGameManager brawlGameManager;
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        // if (brawlGameManager == null)
        // {
        //     brawlGameManager = GameObject.FindObjectOfType<BrawlGameManager>();
        //     if (brawlGameManager == null)
        //     {
        //         return;
        //     }
        // }
        // text.text = brawlGameManager.TimeLeft.ToString("#.00");
    }
}
