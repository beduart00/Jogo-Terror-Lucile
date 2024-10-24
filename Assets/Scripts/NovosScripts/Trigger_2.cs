using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Trigger_2 : MonoBehaviour
{
  
private void OnTriggerEnter(Collider other)
 {   
  if(other.tag=="Player"){
 
 
 StartCoroutine(ativaProximopasso());
 
 
 
  }

 }


public IEnumerator ativaProximopasso(){

//ETAPA1: Depois do teleport as animacoes de vinheta e das particulas saindo comecam
//ETAPA2: Trigger de narracao da personagem principal
//ETAPA3: Quick time event apos colidir com privada 
//ETAPA4: Animacao da camera voltando ao normal e particulas parando de sair



   yield return new WaitForSeconds(3f);
  // gerenciadorDeNarrativas.GetComponent<Gerenciadordenarrativa>().narrativeState=1;
//textoDaNarrativa.SetActive(false);

}








}