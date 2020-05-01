using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class KeyBinds : MonoBehaviour
{
    #region Variables
    public static Dictionary<string, KeyCode> keys = new Dictionary<string, KeyCode>();
    public Text left, right, jump, fall;
    public GameObject currentKey;
    [Header("Colours")]
    public Color32 changed = new Color32(40, 250, 103, 255);
    public Color32 selected = new Color32(179, 36, 240, 255);
    #endregion
    void Start()
    {
        //I was having a weird error with the left key, this fixed it
        if (!keys.ContainsKey("Left"))
        {
            //Adds the keys for left, right, jump, and fall to the dictionary
            keys.Add("Left", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Left", "A")));
            keys.Add("Right", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Right", "D")));
            keys.Add("Jump", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Jump", "Space")));
            keys.Add("Fall", (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString("Fall", "S")));
            //Converts those keys to text
            left.text = keys["Left"].ToString();
            right.text = keys["Right"].ToString();
            jump.text = keys["Jump"].ToString();
            fall.text = keys["Fall"].ToString();
        }
    }
    private void OnGUI()
    {
        //if the current key has a value
        if (currentKey != null)
        {
            //start process of selecting desired key
            string newKey = "";
            Event e = Event.current;
            if (e.isKey)
            {
                //convert the value of the selected key to a string
                newKey = e.keyCode.ToString();
            }
            //leftshift and rightshift are exceptions
            if (Input.GetKey(KeyCode.LeftShift))
            {
                newKey = "LeftShift";
            }
            if (Input.GetKey(KeyCode.RightShift))
            {
                newKey = "RightShift";
            }
            //if newkey has value
            if (newKey != "")
            {
                //change the button text to the value of the new key
                keys[currentKey.name] = (KeyCode)System.Enum.Parse(typeof(KeyCode), newKey);
                currentKey.GetComponentInChildren<Text>().text = newKey;
                currentKey.GetComponent<Image>().color = changed;
                currentKey = null;
            }
        }

    }
    public void ChangeKey(GameObject clicked)
    {
        //when the selected key is clicked
        currentKey = clicked;
        //if it has a value
        if (currentKey != null)
        {
            //change the colour of the button
            currentKey.GetComponent<Image>().color = selected;
        }
    }
    public void SaveKeys()
    {
        //for each key in the keys dictionary
        foreach (var key in keys)
        {
            //save the key value to playerprefs
            PlayerPrefs.SetString(key.Key, key.Value.ToString());
        }
        //save the playerprefs
        PlayerPrefs.Save();
    }
}
