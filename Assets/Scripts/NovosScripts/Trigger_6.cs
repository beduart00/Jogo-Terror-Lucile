using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Trigger_6: MonoBehaviour

{


public GameObject textoDaNarrativa;
public string meuTexto;



public IEnumerator ativaProximopasso(){

yield return new WaitForSeconds(3f);

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
