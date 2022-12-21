using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SimpleJSON;
using UnityEngine.UI;
using UnityEngine.Networking;

public class LoginSystem : MonoBehaviour
{
    [SerializeField]
    InputField username;
    [SerializeField]
    InputField password;
    [SerializeField]
    string url = "";
    public void Log_in()
    {
        StartCoroutine(Verif_log_in());
    }
    public IEnumerator Verif_log_in()
    {
        string newurl = url + "?usersname=" + UnityWebRequest.EscapeURL(username.text) + "&pass=" + UnityWebRequest.EscapeURL(password.text);
        //creer une url qui va appeller login.php
        UnityWebRequest data =  UnityWebRequest.Get(newurl);
        yield return data.SendWebRequest();
        if (data.error != null)
            Debug.Log("Error");
        else if (data.downloadHandler.text != "")
        {
            //Parse le resultat , autrement dit c'est 'decouper' la reponse envoyer 

            var parsedata = JSON.Parse(data.downloadHandler.text);
            //si le resultat est null alors la requete a retourner aucun resultat avec le nom de compte et le mdp assossier donc une erreur;
            if (parsedata[0] != null)
            {
                print("Login_correct");

                //login correcte j'active mon menu , tu fais ce que tu veux quand le login est ok 
            }
            else
            {
                print("erreur");
            }

        }
    }
}