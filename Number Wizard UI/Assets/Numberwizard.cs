using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Numberwizard : MonoBehaviour
{


	[SerializeField] int max;
	[SerializeField] int min;
	[SerializeField] TextMeshProUGUI guessText;

	int guess;
	// Start is called before the first frame update
	void Start()
	{


		StartGame();





	}

	void StartGame()
	{



		NextGuess();
		





	}

	void Quit()
	{
		
			Application.Quit();
		
	}


	public void onPressHigher()
    {
        if(min<max)
        {

			min = guess + 1;
			NextGuess();

		}
         else
        {

			min = guess;
			NextGuess();
		}
		


	}

	public void onPressLower()
	{

        max = guess;
			NextGuess();



	}

	void NextGuess()
    {
      
			guess = Random.Range(min, max);


        
		guessText.text = guess.ToString();
	}


}

