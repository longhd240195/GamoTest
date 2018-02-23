using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Net;
using System.IO;

public class PnlGameOver : MonoBehaviour
{
	[SerializeField] string url = "http://GamoTest";
	public Text txtCurrentScore;
	public Text txtHighestScore;

	void OnEnable ()
	{
		txtCurrentScore.text = GameMaster.gm.currentScore.ToString ();
		txtHighestScore.text = GameMaster.gm.highScore.ToString ();
	}

	public void btn_SendScore ()
	{
		var httpWebRequest = (HttpWebRequest)WebRequest.Create (url);
		httpWebRequest.ContentType = "/leaderboard";
		httpWebRequest.Method = "POST";

		using (var streamWriter = new StreamWriter (httpWebRequest.GetRequestStream ())) {
			string json = "{ \"userName\": \"some-user-name\"," +
			              "\"score\":" + GameMaster.gm.currentScore.ToString () + "} ";

			streamWriter.Write (json);
			streamWriter.Flush ();
			streamWriter.Close ();
		}

		var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse ();
		string result = "405";
		using (var streamReader = new StreamReader (httpResponse.GetResponseStream ())) {
			result = streamReader.ReadToEnd ();
		}

		switch (result) {
		case "404":
			//TODO: User name not found message
			break;
		case "405":
			//TODO: User name invalid message
			break;
		case "200":
			//TODO: Success message
			break;
		default:
			break;
		}
	}
}
