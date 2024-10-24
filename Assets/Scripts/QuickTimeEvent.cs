using System.Collections;
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

    void Start()
    {
    //   StartCoroutine(QTESequence()); 
    }

    public IEnumerator QTESequence()
    {
        while (gameActive && correctCount < totalActions)
        {
            SortAction();
            float timer = responseTime;

            // Aguarda a resposta do jogador ou o tempo limite
            while (timer > 0 && gameActive)
            {
                timer -= Time.deltaTime;

                if (InputMatchesAction())
                {
                    correctCount++;
                    Debug.Log("Acertou! Ações corretas: " + correctCount);
                    actionImage.gameObject.SetActive(false); // Oculta a imagem após o acerto
                    break; // Sai do loop, sorteia nova ação
                }

                yield return null; // Espera o próximo frame
            }

            // Se o timer chegar a zero, o jogador perdeu
            if (timer <= 0)
            {

                //voltar para o quarto
                //ativar o box collider do trigger2(privada)novamente
                //ativar o jogador poder andar
                gameActive = false;
                Debug.Log("Você perdeu! Tempo esgotado!");
                actionImage.gameObject.SetActive(false);
            }
        }

        // Verifica se o jogador venceu
        if (correctCount >= totalActions)
        {

            //ativar o jogador poder andar
            Debug.Log("Você venceu!");
            actionImage.gameObject.SetActive(false);
        }
    }

    // Função para sortear uma ação
    void SortAction()
    {
        int randomIndex = Random.Range(0, actions.Length);
        currentAction = actions[randomIndex];
        UpdateUI(randomIndex); // Atualiza a UI com a nova ação
    }

    // Atualiza a UI com a ação sorteada
    void UpdateUI(int index)
    {
        actionImage.sprite = actionSprites[index]; // Define a imagem correspondente à ação
        actionImage.gameObject.SetActive(true); // Garante que a imagem esteja visível
    }

    // Verifica se a entrada do jogador corresponde à ação sorteada
    bool InputMatchesAction()
    {
        bool matched = false;
        switch (currentAction)
        {
            case "Espaço":
                matched = Input.GetKeyDown(KeyCode.Space);
                break;
            case "Seta Cima":
                matched = Input.GetKeyDown(KeyCode.UpArrow);
                break;
            case "Seta Baixo":
                matched = Input.GetKeyDown(KeyCode.DownArrow);
                break;
            case "Seta Esquerda":
                matched = Input.GetKeyDown(KeyCode.LeftArrow);
                break;
            case "Seta Direita":
                matched = Input.GetKeyDown(KeyCode.RightArrow);
                break;
        }

        return matched;
    }
}
