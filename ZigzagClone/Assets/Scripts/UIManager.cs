using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text curScoreTxt;
    public Text maxScoreTxt;

    private int maxScore = 0;

    private void Awake()
    {
        curScoreTxt.text = "0";
    }

    private void Update()
    {
        curScoreTxt.text = GameScenes.globalCharacterController.getCrystalCount.ToString();

        if( maxScore > GameScenes.globalCharacterController.getCrystalCount)
        {
            maxScore = GameScenes.globalCharacterController.getCrystalCount;
            maxScoreTxt.text = maxScore.ToString();
        }
    }
}
