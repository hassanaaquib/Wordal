using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Manager : MonoBehaviour
{

    [SerializeField] List<GameObject> texts = new List<GameObject>();
   // [SerializeField] List<GameObject> keyboardKey = new List<GameObject>();

    [SerializeField] int currentLayOutIndex;
    [SerializeField] int indexUpTo = 4;


    [SerializeField] string combineWord;
    [SerializeField] string correctWord;

    [SerializeField] int turnLeft = 4;
    [SerializeField] TMP_Text correctWordText;
    [SerializeField] TMP_Text turnLeftText;
    [SerializeField] GameObject playAgainButton;
    [SerializeField] GameObject winUI;
    [SerializeField] GameObject loosUI;



    void Start()
    {
        turnLeftText.text = "Turn Left " + turnLeft;
        currentLayOutIndex = 0;


        //access the text feild of the InputArea;
        for (int i = 0; i < texts.Count; i++)
        {
            string str = "";
            texts[i].GetComponentInChildren<TMP_Text>().text = str;

        }
        
    }

    //GET The Wordal reponse word
    public void GETAnswer(string answer)
    {
        correctWord = answer;
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
        if (currentLayOutIndex == indexUpTo +1)
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
                turnLeft--;
                turnLeftText.text = "Turn Left " + turnLeft;
                if(turnLeft == 0)
                {
                    LooseEffect();
                }

                
            }

            //IncreaseUpTo();//put inside else Part;
        }
    }


    void RemoveElement()
    {
        for(int i = 0; i < 5; i++)
        {
            texts.RemoveAt(0);
        }
        currentLayOutIndex = 0;
        
    }

    void GetUserWord()
    {
        for (int i = 0; i < currentLayOutIndex; i++)
        {
            string str = texts[i].GetComponentInChildren<TMP_Text>().text;
            combineWord += str;

        }


        //Color Change Rule
        ChangeColor();
    }

    void ChangeColor()
    {
        
        for (int i = 0; i < combineWord.Length; i++)
        {
            char temp = combineWord[i];
          
            if (correctWord.Contains(temp.ToString().ToLower()))
            {
                Debug.Log("MatchFound");


                if(texts[i].GetComponentInChildren<TMP_Text>().text.ToLower() == 
                        correctWord[i].ToString())
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

   

    void WinEffect()
    {
        winUI.SetActive(true);
        playAgainButton.SetActive(true);
        //WinningAnimation
    }

    void LooseEffect()
    {
        loosUI.SetActive(true);
        playAgainButton.SetActive(true);
        correctWordText.text = correctWord.ToUpper();
        //TODO LooseEffect
    }


    void IncreaseUpTo()
    {
        //Loos Condition
        if(indexUpTo >= 19)
        {
            Debug.LogWarning("Lose");
            LooseEffect();     
        }
        else
        {
            indexUpTo += 5;
        }

    }


   
}
