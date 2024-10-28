using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gerenciadordenarrativa : MonoBehaviour
{


public int narrativeState;

public GameObject trigger_1; // vo falando bosta 1
public GameObject trigger_2; //quick time event da privada
public GameObject trigger_3; // vo falando bosta 2 - corredor pos banheiro
public GameObject trigger_4; // página 1 diário


    // Update is called once per frame
    void Update()
    {
        
        //start do jogo
if(narrativeState==0)
{

trigger_1.SetActive(true);



}
//finald a vo 1
if(narrativeState==1)
{

trigger_1.SetActive(false);
trigger_2.SetActive(true);


}


//final do quick time event 1
if(narrativeState==2)
{

trigger_2.SetActive(false);
trigger_3.SetActive(true);


} // final quick time event corredor
if(narrativeState==3)
{

trigger_3.SetActive(false);
trigger_4.SetActive(true);

}


    }
}
