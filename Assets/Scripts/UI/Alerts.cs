using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Alerts : MonoBehaviour
{
    public IEnumerator CreateNewAlert(string msg)
    {
        
        yield return SceneManager.LoadSceneAsync("Alerts", LoadSceneMode.Additive);
        GameObject.FindObjectOfType<AlertObjects>().AlertText.text = msg;
    }

    //public IEnumerator UpdateText(string msg)
    //{
        
    //    yield return new WaitForSeconds(.3f);
    //    GameObject.FindGameObjectWithTag("AlertMsg").GetComponent<AlertObjects>().AlertText.text = msg;
    //}

}
