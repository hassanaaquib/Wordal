using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;
public class OnKeyBoardClick : EventTrigger
{
    [SerializeField] Manager manager;

    public string key;
    private void Start()
    {
        manager = FindAnyObjectByType<Manager>();
        Debug.Log("gfsbhdskm");
    }

  

    public override void OnPointerClick(PointerEventData data)
    {
        Debug.Log(gameObject.GetComponentInChildren<TMP_Text>().text);
        key = gameObject.GetComponentInChildren<TMP_Text>().text;
        manager.KeyBoard(key);
    }


}
