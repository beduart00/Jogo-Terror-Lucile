using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Teleport : MonoBehaviour
{

public Transform player;

public Transform spawnPoint;
private bool estaColidindo;

public GameObject btnFeedback;

public Animator Fade;
public bool teleporting;

void Start(){
//spawnPoint = GameObject.Find("Player").GetComponent<Transform>();

}

 private void OnTriggerEnter(Collider other)
 {   
   if(other.tag=="Player"){

estaColidindo=true;
btnFeedback.SetActive(true);
Debug.Log("Entrou");

   

   }
    
 }

 private void OnTriggerExit(Collider other)
 {   
  if(other.tag=="Player"){

estaColidindo=false;
btnFeedback.SetActive(false);
Debug.Log("Saiu");
   

   }
    
 }

IEnumerator teleportingAction(){

teleporting=true;

Fade.Play("FadeIn");
player.GetComponent<FPSController>().enabled=false;

 btnFeedback.SetActive(false);

yield return new WaitForSeconds(2f);

 player.position = spawnPoint.position;
teleporting=false;
Fade.Play("FadeOut");
player.GetComponent<FPSController>().enabled=true;
}


void Update(){

  //Debug.Log(estaColidindo);

if(Input.GetKey(KeyCode.Space)){

if(estaColidindo==true&&teleporting==false){

StartCoroutine(teleportingAction());
}

// Debug.Log("Teleportei");

// player.position = spawnPoint.position;
// btnFeedback.SetActive(false);

}


}


}
