using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

public string nomeDaFaseParaCarregar;
   public GameObject FadeCanvas;

public void click(){

    StartCoroutine(fadeCarregaFase());
}

public IEnumerator fadeCarregaFase(){

FadeCanvas.GetComponent<Animator>().Play("FadeIn");
 

yield return new WaitForSeconds(2f);
   SceneManager.LoadScene(nomeDaFaseParaCarregar);

}
 

    // Método para carregar a cena

}