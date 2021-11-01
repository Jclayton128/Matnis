using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class QuestionPanel_UI : UI_Driver
{
    [SerializeField] TextMeshProUGUI topTMP = null;
    [SerializeField] TextMeshProUGUI bottomTMP = null;
    [SerializeField] TextMeshProUGUI operatorTMP = null;
    [SerializeField] Image[] _panelImages = null;

    public override void ShowHideAllUIElements(bool shouldBeShown)
    {
        topTMP.enabled = shouldBeShown;
        bottomTMP.enabled = shouldBeShown;
        operatorTMP.enabled = shouldBeShown;
        foreach (var image in _panelImages)
        {
            image.enabled = shouldBeShown;
        }
    }

    public void UpdateProblem(Problem incomingProblem)
    {
        topTMP.text = incomingProblem.TopNumber.ToString();
        bottomTMP.text = incomingProblem.BottomNumber.ToString();
        operatorTMP.text = $"{incomingProblem.OpChar}";

        RescaleTextSizes();
    }

    private void RescaleTextSizes()
    {
        float topSize = topTMP.fontSize;
        float bottomSize = bottomTMP.fontSize;
        if (topSize > bottomSize)
        {
            topTMP.fontSize = bottomTMP.fontSize;
            topTMP.ForceMeshUpdate();
            operatorTMP.fontSize = bottomTMP.fontSize;
            operatorTMP.ForceMeshUpdate();
        }
        else
        {
            bottomTMP.fontSize = topTMP.fontSize;
            bottomTMP.ForceMeshUpdate();
            operatorTMP.fontSize = topTMP.fontSize;
            operatorTMP.ForceMeshUpdate();
        }
    }
}
