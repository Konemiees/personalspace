#pragma strict

var getURL = "http://192.168.1.37/:3000/highscore";
var postURL = "http://192.168.1.37/:3000/score";

var highscore : Score;


//var button : UnityEngine.UI.Button;

function Start() {

	//button.GetComponent(UI.Button).onClick.AddListener(ButtonClicked);
}

function ButtonClicked(){
	var name = "No-name";
	name = GameObject.Find("highscore").GetComponent(UI.InputField).text;
	
	var score = highscore.highscore;

	UploadHighscore(name, score);
}

function UploadHighscore(name, score){
	var form = new WWWForm();
	form.AddField("name", name.ToString());
	form.AddField("score", score.ToString());

	var w = WWW(postURL, form);
	yield w;

	if(!String.IsNullOrEmpty(w.error)){
		print(w.error);
	}else{
		print("Finished uploading highscore");
	};
}

function DownloadHighscore(){
	var highscore = new WWW(getURL);
	/*Wait for data to download before releasing contact*/
	yield highscore;
	if(highscore.error == null){
		Debug.Log("Download completed.");
	}else{
		Debug.Log("www-error: " + highscore.error);
	}
	Debug.Log( highscore.text);
}