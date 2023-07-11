using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TestManager : MonoBehaviour
{
    [SerializeField] List<GameObject> texts = new List<GameObject>();
    // [SerializeField] List<GameObject> keyboardKey = new List<GameObject>();

    [SerializeField] int currentLayOutIndex;
    [SerializeField] int indexUpTo = 4;


    [SerializeField] string combineWord;
    [SerializeField] string correctWord;



    void Start()
    {

        //access the text feild of the InputArea;
        for (int i = 0; i < texts.Count; i++)
        {
            string str = "";
            texts[i].GetComponentInChildren<TMP_Text>().text = str;

        }
        currentLayOutIndex = 0;
    }





    public void KeyBoard(string key)
    {
        if (currentLayOutIndex <= indexUpTo)
        {
            texts[currentLayOutIndex].GetComponentInChildren<TMP_Text>().text = key;
            currentLayOutIndex++;

        }

    }

    public void DeleteLastKey()
    {
        currentLayOutIndex--;
        texts[currentLayOutIndex].GetComponentInChildren<TMP_Text>().text = "";


    }


    public void EnterClicked()
    {
        if (currentLayOutIndex == indexUpTo + 1)
        {
            combineWord = "";

            //Getting User Words
            GetUserWord();

            // Wining Condition
            if (combineWord.ToLower() == correctWord)
            {
                Debug.LogWarning("WINNNNNNNNNNNNN");
                WinEffect();
            }
            else
            {
                //IncreaseUpTo();
                RemoveElement();

            }

            //IncreaseUpTo();//put inside else Part;
        }
    }


    void RemoveElement()
    {
        for (int i = 0; i < 5; i++)
        {
            texts.RemoveAt(i);
        }

    }

    void GetUserWord()
    {
        for (int i = indexUpTo - 4; i < currentLayOutIndex; i++)
        {
            string str = texts[i].GetComponentInChildren<TMP_Text>().text;
            combineWord += str;

        }


        //Color Change Rule
        ChangeColor();
    }

    void ChangeColor()
    {
        //word to wordArray
        //check if it present and index
        //string[] wordArray = new string[combineWord.Length];
        for (int i = indexUpTo - 4; i < combineWord.Length; i++)
        {
            char temp = combineWord[i];
            // wordArray[i] = temp.ToString();
            if (correctWord.Contains(temp.ToString().ToLower()))
            {
                Debug.Log("MatchFound");


                if (texts[i].GetComponentInChildren<TMP_Text>().text.ToLower() ==
                        correctWord[indexUpTo - 4].ToString())
                {
                    texts[i].GetComponent<RawImage>().color = Color.green;
                }
                else
                {
                    texts[i].GetComponent<RawImage>().color = Color.yellow;
                }
            }
            else
            {
                texts[i].GetComponent<RawImage>().color = Color.gray;
            }

        }


    }

    //oneRow++++++++++++++++++++++++++++++++++++++++++++++++++++

    void WinEffect()
    {
        //WinningAnimation
    }

    void LooseEffect()
    {
        //TODO LooseEffect
    }


    void IncreaseUpTo()
    {
        //Loos Condition
        if (indexUpTo >= 19)
        {
            Debug.LogWarning("Lose");
            LooseEffect();
        }
        else
        {
            indexUpTo += 5;
        }

    }


    //GET The Wordal reponse word
    public void GETAnswer(string answer)
    {
        correctWord = answer;
    }
}
