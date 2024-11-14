using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;


public class triggerPai : MonoBehaviour

{

  public GameObject meujogador;
    
  
void Start(){

    meujogador = GameObject.Find("Player");

}  
private void OnTriggerEnter(Collider other)
 {   
  if(other.tag=="Player"){
 
 StartCoroutine(ativaProximopasso());
 

  }

 }


public IEnumerator ativaProximopasso(){

// pausa o player
     meujogador.GetComponent<FPSController>().enabled=false;

// animacoes em looping


//lucile fala umas groselha

   yield return new WaitForSeconds(2f);

//roda a funcao de quick time
    StartCoroutine(GameObject.Find("QuickTimeEvent_1").GetComponent<QuickTimeEvent2>().QTESequence());

/*
     if (timer <= 0)
            {

                //voltar para o quarto
                //ativar o box collider do trigger2(privada)novamente
                //ativar o jogador poder andar
                gameaction = false;
                Debug.Log("Você perdeu! Tempo esgotado!");
                actionImage.gameObject.SetActive(false);

// despausa o player
  

  */

}








}