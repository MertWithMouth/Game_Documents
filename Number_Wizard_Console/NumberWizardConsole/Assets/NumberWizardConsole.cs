using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberWizardConsole : MonoBehaviour
{


	int max ;
	int min ;
	int guess;
	// Start is called before the first frame update
	void Start()
    {


		StartGame();
			
			
		

        
    }

    void StartGame()
    {


		int max = 1000;
		int min = 1;
		int guess = 500;

		Debug.Log("Welcome to Number Wizard, yo");
		Debug.Log("Pick a number and don't tell me bitch");
		Debug.Log("Highest number you can pick is: " + max);
		Debug.Log("Lowest number is: " + min);
		Debug.Log("Tell me if your number is higher or lower than 500");
		Debug.Log("Push up = higher, push down = lower, Push Enter = correct");
		max = max + 1;





	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.UpArrow))
		{
			min = guess;
			NextGuess();


		}

		else if (Input.GetKeyDown(KeyCode.DownArrow))
		{

			max = guess;
			NextGuess();


		}
		else if (Input.GetKeyDown(KeyCode.Return))
		{
			Debug.Log("I am a genius!");
			StartGame();

		}

		void NextGuess()
        {

			guess = (max + min) / 2;
			Debug.Log("Is it higher or lower than " + guess);




		}


	}
}
