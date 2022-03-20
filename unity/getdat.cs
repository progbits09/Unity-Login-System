using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.Networking;
public class getdat : MonoBehaviour {
	public Button loginbutton;
    public InputField UsernameInput;
    public InputField PasswordInput; 
	// Use this for initialization
	void Start () {
		//starts function when button is clicked
        loginbutton.onClick.AddListener(()=>{

		StartCoroutine(getdata(UsernameInput.text, PasswordInput.text));
        });
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public IEnumerator getdata(string username, string password)
    {

       
        
        WWWForm form = new WWWForm();
        form.AddField("loginUser", username);
        form.AddField("loginPass", password);
      

        using (UnityWebRequest www = UnityWebRequest.Post("https://example.000webhostapp.com/getdata.php", form))//web requests and sends data as _POST to php script
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)// check for errors
            {
                Debug.Log(www.error);
                
            }
            else
            {
               string money = (www.downloadHandler.text); //the echoed data
               
               Debug.Log("money = " + money);//displays the amount of money

               
          
 
              
            }
        }
  
    }
}
