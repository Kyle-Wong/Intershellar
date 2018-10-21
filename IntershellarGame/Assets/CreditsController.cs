using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CreditsController : MonoBehaviour {

    // Use this for initialization
    public UIRevealer[] names;
    public UIRevealer[] roles;
    public float initialDelay;
    public float repeatDelay;

	void Start () {
        StartCoroutine(doCredits());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private IEnumerator doCredits()
    {
        yield return new WaitForSeconds(initialDelay);
        for(int i = 0; i < names.Length; i++)
        {
            names[i].revealUI();
            roles[i].revealUI();
            yield return new WaitForSeconds(repeatDelay);
        }
    }
    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
