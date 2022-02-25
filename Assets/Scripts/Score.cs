using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] private TMP_Text stickmanText2;
    [SerializeField] private TMP_Text gemCountText2;
    [SerializeField] private TMP_Text totalGem;

    private float totalGemCount;
    private float gems = 0;
    private void Start()
    {

        
    }
    private void Update()
    {
        totalGem.text = "" + PlayerMovement.PM.totalScore;
        stickmanText2.text = "" + PlayerMovement.PM.stickmanCount;
        gemCountText2.text = "" + PlayerMovement.PM.gemCount;
    }

    public void HoldScore()
    {
        /*totalGemCount = PlayerPrefs.GetFloat("TotalScore");
        totalGemCount += PlayerMovement.PM.totalScore;
        PlayerPrefs.SetFloat("TotalScore", totalGemCount);
        */
        Debug.Log("Hello");
    }


}
