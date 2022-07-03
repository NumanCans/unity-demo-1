using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine.UI;

public class Register : MonoBehaviour
{
    public InputField Username;
    public InputField Password;
    public InputField ConfPassswordAgain;
    public InputField Email;
   public void CreateAccount()
    {
        if(Password.text == ConfPassswordAgain.text)
        {
            RegisterPlayFabUserRequest request = new RegisterPlayFabUserRequest();
            request.Username = Username.text;
            request.Password = ConfPassswordAgain.text;
            request.Email = Email.text;
            request.DisplayName = Username.text;

            PlayFabClientAPI.RegisterPlayFabUser(request, resultCallback => {
                Alerts a = new Alerts();
                StartCoroutine(a.CreateNewAlert(resultCallback.Username + " uye olusturuldu"));
            }, error => {
                Alerts a = new Alerts();
                StartCoroutine(a.CreateNewAlert(error.ErrorMessage));
            });
        }
    }
}
