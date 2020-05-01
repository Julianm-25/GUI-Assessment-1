using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressAnyKey : MonoBehaviour
{
    #region Variables
    public GameObject pressAnyKeyPanel;
    public GameObject menuPanel;
    #endregion
    void Update()
    {
        //if you input anything on the pressanykey screen
        if(Input.anyKey)
        {
            //enable the main menu and disable the pressanykey panel
            menuPanel.SetActive(true);
            pressAnyKeyPanel.SetActive(false);
        }
    }
}
