using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    //set to the rules canvas
    public GameObject rules;
    
    //set to the Main canvas with the question mark
    public GameObject mainUI;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    //Scrapped idea from when we initially set up a main menu that was also scrapped
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    //Function set to the question mark button to be able to set the rules canvas as shown and the Main canvas as hidden
    public void Rules()
    {
        rules.SetActive(true);
        mainUI.SetActive(false);
    }
    
    //Function set to X button to set the rules as a hidden canvas and the main canvas back to being the actively shown one
    public void Main()
    {
        rules.SetActive(false);
        mainUI.SetActive(true);
    }
}
