using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Trigger_4 : MonoBehaviour
{

    
//public GameObject gerenciadorDeNarrativas;
public GameObject textoDaNarrativa;
public string meuTexto;
  
//public float meuTempo;

void Start(){

//gerenciadorDeNarrativas = GameObject.Find("Gerenciador de narrativas");

}


public IEnumerator ativaProximopasso(){

   yield return new WaitForSeconds(3f);
 //  gerenciadorDeNarrativas.GetComponent<Gerenciadordenarrativa>().narrativeState=1;
textoDaNarrativa.SetActive(false);



}


 private void OnTriggerEnter(Collider other)
 {   
  if(other.tag=="Player"){
gameObject.GetComponent<BoxCollider>().enabled=false;
textoDaNarrativa.GetComponent<TextMeshProUGUI>().text = meuTexto;
textoDaNarrativa.SetActive(true);
StartCoroutine(ativaProximopasso());


   

   }
    
}
}
