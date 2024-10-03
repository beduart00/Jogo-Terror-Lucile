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

void Start(){
//spawnPoint = GameObject.Find("Player").GetComponent<Transform>();

}

 private void OnTriggerEnter(Collider other)
 {   
   if(other.CompareTag("Player")){

estaColidindo=true;

   

   }
    
 }

 private void OnTriggerExit(Collider other)
 {   
   if(other.CompareTag("Player")){

estaColidindo=false;
btnFeedback.SetActive(true);
   

   }
    
 }

void Update(){

if(Input.GetKey(KeyCode.Space)){}

if(estaColidindo==true){

player.position = spawnPoint.position;
btnFeedback.SetActive(false);

}


}


}
