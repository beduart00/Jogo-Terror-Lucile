using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvent : MonoBehaviour
{
    public Text actionText; // Text UI para mostrar a ação
    public float timeBetweenActions = 2f; // Tempo entre as ações
    private string[] actions = { "Espaço", "Seta Cima", "Seta Baixo", "Seta Esquerda", "Seta Direita" };
    private string currentAction;
    private int correctCount = 0;
    private int totalActions = 5; // Número de ações que o jogador precisa acertar
    private bool gameActive = true;

    void Start()
    {
        StartCoroutine(QTESequence());
    }

    IEnumerator QTESequence()
    {
        while (gameActive && correctCount < totalActions)
        {
            SortAction();
            yield return new WaitForSeconds(timeBetweenActions); // Espera o tempo antes da próxima ação

            if (InputMatchesAction())
            {
                correctCount++;
                Debug.Log("Acertou! Ações corretas: " + correctCount);
            }
            else
            {
                gameActive = false;
                Debug.Log("Você perdeu!");
                actionText.text = "Você perdeu!";
            }

            if (correctCount >= totalActions)
            {
                gameActive = false;
                Debug.Log("Você venceu!");
                actionText.text = "Você venceu!";
            }
        }
    }

    // Função para sortear uma ação
    void SortAction()
    {
        int randomIndex = Random.Range(0, actions.Length);
        currentAction = actions[randomIndex];
        UpdateUI(currentAction); // Atualiza a UI com a nova ação
    }

    // Atualiza a UI com a ação sorteada
    void UpdateUI(string action)
    {
        actionText.text = "Pressione: " + action;
    }

    // Verifica se a entrada do jogador corresponde à ação sorteada
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
