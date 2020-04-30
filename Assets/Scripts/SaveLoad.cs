using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public GameObject player;
    public void Save()
    {
        PlayerPrefs.SetFloat("xPosition", player.transform.position.x);
        PlayerPrefs.SetFloat("yPosition", player.transform.position.y);
        PlayerPrefs.Save();
    }
    public void Load()
    {
        
        player.transform.position = new Vector2(PlayerPrefs.GetFloat("xPosition"), PlayerPrefs.GetFloat("yPosition"));
    }
    public void NewGame()
    {
        PlayerPrefs.SetFloat("xPosition", 1);
        PlayerPrefs.SetFloat("yPosition", 1);
        PlayerPrefs.Save();
        Load();
    }
}