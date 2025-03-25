using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu_Controller : MonoBehaviour
{
    public GameObject rules;
    // Este método se llamará cuando se haga clic en el botón
    public void OnButtonClick()
    {
        StartCoroutine(Rules());
    }
    public IEnumerator Rules()
    {
        // Cargar la escena llamada "Rules"
        rules.SetActive(true);
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene(1);

    }
    public void Exitor()
    {
        Application.Quit();
    }
}
