using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
    public GameObject rules;
    public GameObject mainUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Rules()
    {
        rules.SetActive(true);
        mainUI.SetActive(false);
    }
    public void Main()
    {
        rules.SetActive(false);
        mainUI.SetActive(true);
    }
}
