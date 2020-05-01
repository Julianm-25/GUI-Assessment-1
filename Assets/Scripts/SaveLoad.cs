using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    #region Variables
    public GameObject player;
    #endregion
    //function that saves the x and y position of the player to playerprefs
    public void Save()
    {
        PlayerPrefs.SetFloat("xPosition", player.transform.position.x);
        PlayerPrefs.SetFloat("yPosition", player.transform.position.y);
        PlayerPrefs.Save();
    }
    //function that sets the player's x and y position to the saved values
    public void Load()
    {
        
        player.transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
    }
    //function that clears the previously saved data
    public void NewGame()
    {
        PlayerPrefs.SetFloat("xPosition", 1);
        PlayerPrefs.SetFloat("yPosition", 1);
        PlayerPrefs.Save();
        Load();
    }
}