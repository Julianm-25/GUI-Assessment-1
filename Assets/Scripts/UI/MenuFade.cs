using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFade : MonoBehaviour
{
    private CanvasGroup beginPanel;
    private CanvasGroup endPanel;
    private bool isFading;
    private void Update()
    {
        if(isFading)
        {
            beginPanel.alpha -= Time.unscaledDeltaTime;
            endPanel.alpha += Time.unscaledDeltaTime;
            if(beginPanel.alpha == 0 && endPanel.alpha == 1)
            {
                isFading = false;
                beginPanel.gameObject.SetActive(false);
            }
        }
    }
    public void FadeOut(CanvasGroup panelFrom)
    {
        if(beginPanel)
        {
            beginPanel.alpha = 0;
        }
        beginPanel = panelFrom;
        beginPanel.alpha = 1;
        isFading = true;
    }
    public void FadeIn(CanvasGroup panelTo)
    {
        if (endPanel)
        {
            endPanel.alpha = 1;
        }
        endPanel = panelTo;
        endPanel.alpha = 0;
        panelTo.gameObject.SetActive(true);
    }
}
