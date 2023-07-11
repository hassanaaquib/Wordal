using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterAndDelete : MonoBehaviour
{

    Manager manager;


    private void Start()
    {
        manager = FindAnyObjectByType<Manager>();
            
    }
    public void EnterButtonClicked()
    {
        //TODO
        manager.EnterClicked();

    }

    public void DeleteButtonClicked()
    {
        manager.DeleteLastKey();
    }
}
