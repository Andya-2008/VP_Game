using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System;
using System.Threading.Tasks;
using System.Text;
using System.IO;
using UnityEngine.Networking;

public class HighScore
{
    public string Name { get; set; }
    public Decimal Score { get; set; }
    public int LeaderBoardId { get; set; }
}

public class HSController : MonoBehaviour
{
    [SerializeField] string API_KEY;
    [SerializeField] int leaderBoardId;
    public static HSController instance;
    static HttpClient client = new HttpClient();
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
        if (instance == null)
        {
            instance = this;
            if (instance == null)
            {
                instance = new HSController();
            }

        }
        else if (instance != null)
        {
            Destroy(gameObject);
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    public IEnumerator AddScore(decimal score, string username)
    {
        Debug.Log("AddScore");
        string domain = "http://highscores.frogcoo.com/";
        string path = "api/HighScore/addscore";
        Debug.Log(username + " : " + score + " : " + leaderBoardId + " : " + API_KEY);

        WWWForm form = new WWWForm();
        form.AddField("LeaderboardId", leaderBoardId);
        form.AddField("apiKey", API_KEY);
        form.AddField("Name", username);
        form.AddField("Score", score.ToString());

        using (UnityWebRequest www = UnityWebRequest.Post(domain + path, form))
        {
            yield return www.SendWebRequest();

            if (www.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("Success: High Score Added!");
            }
        }
        /*


        client.BaseAddress = new Uri("http://highscores.frogcoo.com/");
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));

        string domain = "http://highscores.frogcoo.com/";
        string path = "api/HighScore/addscore";
        Debug.Log(username + " : " + score + " : " + leaderBoardId + " : " + API_KEY);
        
        try
        {
            string postBody = "";
            
            postBody += "{\"LeaderboardId\":" + leaderBoardId + ",";
            postBody += "\"apiKey\":\"" + API_KEY + "\",";
            postBody += "\"Name\":\"" + username + "\",";
            postBody += "\"score\":" + score + "}";
            Debug.Log(postBody);
            HttpContent c = new StringContent(postBody, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await client.PostAsync(domain + path, c);
            if (response.IsSuccessStatusCode)
            {
                Debug.Log("Success: High Score Added");
            }


        }
        catch (Exception ex) {
            Debug.LogError(ex.Message);
        }
        */
    }

    public void testHello()
    {
        Debug.Log("Hello");
    }

    public IEnumerator GetScore(Action<string> callback = null)
    {

        string domain = "http://highscores.frogcoo.com/";
        string path = "api/highscore/getscores?id=4&asc=0";
        string uri = domain + path;
        string data = "";
        using (UnityWebRequest webRequest = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = uri.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    break;
                case UnityWebRequest.Result.Success:
                    data = webRequest.downloadHandler.text;
                    break;
            }

            if (callback != null)
            {
                callback(data);
            }

        }
        /*
         client.BaseAddress = new Uri("http://highscores.frogcoo.com/");
         client.DefaultRequestHeaders.Accept.Clear();
         client.DefaultRequestHeaders.Accept.Add(
             new MediaTypeWithQualityHeaderValue("application/json"));

         string domain = "http://highscores.frogcoo.com/";
         string path = "api/HighScore/GetScores";

         try
         {
             HttpResponseMessage response = await client.GetAsync(domain + path + "?LeaderBoardId=" + leaderBoardId);
             string responseBody = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
             responseBody = responseBody.TrimStart('"').TrimEnd('"').Replace("\\", "");

             Debug.Log(responseBody);

             return responseBody;
         }
         catch (Exception ex) {
             Debug.LogError(ex.Message);
             return "";
         }

         */
    }

}
