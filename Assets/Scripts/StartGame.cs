using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void BatDau()
    {
        SceneManager.LoadScene("Man1");
    }

    public void Map2()
    {
        SceneManager.LoadScene("Man2");
    }
    public void reloadMan()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;

    }
}
   
