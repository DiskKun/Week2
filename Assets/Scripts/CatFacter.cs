using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using System.Collections;


class Fact
{
    public string fact;
    public int length;
    public Fact(string fact, int length)
    { 
        this.fact = fact;
        this.length = length;
    }
}

public class CatFacter : MonoBehaviour
{
    public TextMeshProUGUI factTextMesh;
    string json;
    Fact fact;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        NewFact();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NewFact()
    {
        StartCoroutine(GetWebRequest());

    }


    IEnumerator GetWebRequest()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://catfact.ninja/fact"))
        {
            yield return webRequest.SendWebRequest();

            if (webRequest.result == UnityWebRequest.Result.Success)
            {
                json = webRequest.downloadHandler.text;
                Debug.Log(webRequest.downloadHandler.text);

                fact = JsonUtility.FromJson<Fact>(json);

                DisplayFact(fact);
            }
        }
    }

    void DisplayFact(Fact f)
    {
        factTextMesh.text = f.fact;
    }

    
}
