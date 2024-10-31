using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class Trigger_3 : MonoBehaviour
{

//ativar
//public GameObject Trigger_3;

//public GameObject gerenciadorDeNarrativas;
public GameObject textoDaNarrativa;
public string meuTexto;
public GameObject trigger_4;
public GameObject trigger_5_diario;

  
//public float meuTempo;

void Start(){

//gerenciadorDeNarrativas = GameObject.Find("Gerenciador de narrativas");

}


public IEnumerator ativaProximopasso(){

   yield return new WaitForSeconds(3f);
  // gerenciadorDeNarrativas.GetComponent<Gerenciadordenarrativa>().narrativeState=3;
textoDaNarrativa.SetActive(false);
trigger_4.SetActive(true);
trigger_5_diario.SetActive(true);


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
