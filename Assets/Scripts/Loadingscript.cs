using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Loadingscript : MonoBehaviour
{
    public TextMeshProUGUI LoadingTXT;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadingText());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator LoadingText()
    {
        LoadingTXT.text = "Loading";
        yield return new WaitForSeconds(0.8f);
        LoadingTXT.text = "Loading.";
        yield return new WaitForSeconds(0.8f);
        LoadingTXT.text = "Loading..";
        yield return new WaitForSeconds(0.8f);
        LoadingTXT.text = "Loading...";
        yield return new WaitForSeconds(0.8f);
        StartCoroutine(LoadingText());

    }
}
