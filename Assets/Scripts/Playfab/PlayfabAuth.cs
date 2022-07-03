using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayfabAuth : MonoBehaviour
{
    public InputField Username;
    public InputField Password;
    public string LevelToLoad;
    public void Login()
    {
        LoginWithPlayFabRequest request = new LoginWithPlayFabRequest();
        request.Username = Username.text;
        request.Password = Password.text;

        PlayFabClientAPI.LoginWithPlayFab(request, result => {
            Alerts a = new Alerts();
            StartCoroutine(a.CreateNewAlert(Username.text + " Giriþ Yaptýnýz"));
            SceneManager.LoadScene(LevelToLoad);
        }, error => {
            Alerts a = new Alerts();
            StartCoroutine(a.CreateNewAlert(error.ErrorMessage));
        });
    }

}
