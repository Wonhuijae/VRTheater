using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectAvatar : MonoBehaviour
{
    public List<GameObject> charList;

    Dictionary<GameObject, string> charNames = new Dictionary<GameObject, string>();

    string selection;
    GameObject selctedImage;

    private void Start()
    {
        for (int i = 0; i < charList.Count; i++) 
        {
            charNames.Add(charList[i], "Player_" + (i + 1).ToString());
            Debug.Log(charNames[charList[i]]);
        }
    }

    public void OnClickAvatar(GameObject _gameObject)
    {
        if (selctedImage == _gameObject) return;
        if(selctedImage != null) selctedImage.GetComponent<Outline>().enabled = false;

        selctedImage = _gameObject;
        selection = charNames[selctedImage];
        Debug.Log(selection);
    }
}
