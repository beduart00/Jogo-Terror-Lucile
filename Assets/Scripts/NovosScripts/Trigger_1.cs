using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Rendering;
using Unity.VisualScripting;

public class Trigger_1 : MonoBehaviour
{

//ativar
//public GameObject Trigger_2;

public GameObject gerenciadorDeNarrativas;
public GameObject textoDaNarrativa;
public string meuTexto;
  
//public float meuTempo;

public GameObject proximoTriggerAtivado;

void Start(){

gerenciadorDeNarrativas = GameObject.Find("Gerenciador de narrativas");

}


public IEnumerator ativaProximopasso(){

   yield return new WaitForSeconds(3f);
 //  gerenciadorDeNarrativas.GetComponent<Gerenciadordenarrativa>().narrativeState=1;
 proximoTriggerAtivado.SetActive(true);
 
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
