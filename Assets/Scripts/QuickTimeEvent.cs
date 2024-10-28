using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvent : MonoBehaviour
{
    public Image actionImage; // UI Image para mostrar a ação
    public float responseTime = 2f; // Tempo limite para a resposta
    public Sprite[] actionSprites; // Array de imagens correspondentes às ações
    private string[] actions = { "Espaço", "Seta Cima", "Seta Baixo", "Seta Esquerda", "Seta Direita" };
    private string currentAction;
    private int correctCount = 0;
    private int totalActions = 5; // Número de ações que o jogador precisa acertar
    private bool gameActive = true;
    public GameObject meujogador;
    public GameObject trigger2;



    IEnumerator quickTimeAcerto()
    {
       GameObject.Find("Gerenciador de narrativas").GetComponent<Gerenciadordenarrativa>().narrativeState=2;
        trigger2.SetActive(false);
        yield return new WaitForSeconds(2f);
        meujogador.GetComponent<FPSController>().enabled = true;
        gameActive = false; // Para garantir que o QTE não continue
    }

    IEnumerator quickTimeErrou()
    {
      
        trigger2.SetActive(false);
        meujogador.transform.position = new Vector3(-4.6f, 1.48f, -1.39f);
        yield return new WaitForSeconds(2f);
        meujogador.GetComponent<FPSController>().enabled = true;
        ResetQTE();
        trigger2.SetActive(true);
    }

    private void ResetQTE()
    {
        correctCount = 0;
        gameActive = true;
    }

    public IEnumerator QTESequence()
    {
        while (gameActive && correctCount < totalActions)
        {
            SortAction();
            float timer = responseTime;

            while (timer > 0 && gameActive)
            {
                timer -= Time.deltaTime;

                if (InputMatchesAction())
                {
                    correctCount++;
                    Debug.Log("Acertou! Ações corretas: " + correctCount);
                    actionImage.gameObject.SetActive(false);
                    break; // Sai do loop, sorteia nova ação
                }

                yield return null; // Espera o próximo frame
            }

            if (timer <= 0)
            {
                gameActive = false; // Fim do jogo
                Debug.Log("Você perdeu! Tempo esgotado!");
                actionImage.gameObject.SetActive(false);
                StartCoroutine(quickTimeErrou());
            }
        }

        if (correctCount >= totalActions)
        {
            Debug.Log("Você venceu!");
            actionImage.gameObject.SetActive(false);
            StartCoroutine(quickTimeAcerto());
        }
    }

    void SortAction()
    {
        int randomIndex = Random.Range(0, actions.Length);
        currentAction = actions[randomIndex];
        UpdateUI(randomIndex);
    }

    void UpdateUI(int index)
    {
        actionImage.sprite = actionSprites[index];
        actionImage.gameObject.SetActive(true);
    }

    bool InputMatchesAction()
    {
        switch (currentAction)
        {
            case "Espaço":
                return Input.GetKeyDown(KeyCode.Space);
            case "Seta Cima":
                return Input.GetKeyDown(KeyCode.UpArrow);
            case "Seta Baixo":
                return Input.GetKeyDown(KeyCode.DownArrow);
            case "Seta Esquerda":
                return Input.GetKeyDown(KeyCode.LeftArrow);
            case "Seta Direita":
                return Input.GetKeyDown(KeyCode.RightArrow);
            default:
                return false;
        }
    }
}
