using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuFade : MonoBehaviour
{
    #region Variables
    private CanvasGroup beginPanel;
    private CanvasGroup endPanel;
    private bool isFading;
    #endregion
    private void Update()
    {
        //if the panels are fading
        if(isFading)
        {
            //the starting panel fades out and the end panel fades in
            beginPanel.alpha -= Time.unscaledDeltaTime;
            endPanel.alpha += Time.unscaledDeltaTime;
            //once the start panel is fully transparent and the end panel is fully opaque
            if(beginPanel.alpha == 0 && endPanel.alpha == 1)
            {
                //set fading to false and disable the starting panel
                isFading = false;
                beginPanel.gameObject.SetActive(false);
            }
        }
    }
    //these two functions ensure that the fading always starts with the start panel at alpha = 1 and the end panel at alpha = 0
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
