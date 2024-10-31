using System.Collections;
using UnityEngine;
using TMPro;

public class Trigger_4 : MonoBehaviour
{
    public GameObject gerenciadorDeImagem; // Para gerenciar as imagens do diário
    public GameObject textoDaNarrativa; // Para exibir o texto da narrativa
    public string meuTexto; // Texto da narrativa
    public GameObject diarioCanvas; // Canvas que contém a imagem do diário

    private bool diarioAberto = false; // Para controlar o estado do diário

    void Start()
    {
        // Esconder o Canvas do diário no início
        diarioCanvas.SetActive(false);
    }

    private void Update()
    {
        // Verifica se o diário está aberto e se a tecla de espaço foi pressionada
        if (diarioAberto && Input.GetKeyDown(KeyCode.Space))
        {
            FecharDiario();
        }
        // Verifica se o jogador está perto e se a tecla de espaço foi pressionada para abrir o diário
        else if (!diarioAberto && textoDaNarrativa.activeSelf && Input.GetKeyDown(KeyCode.Space))
        {
            AbrirDiario();
        }
    }

    private void AbrirDiario()
    {
        textoDaNarrativa.SetActive(false); // Esconder texto da narrativa
        diarioCanvas.SetActive(true); // Mostrar o Canvas do diário
        diarioAberto = true; // Atualizar estado do diário
    }

    private void FecharDiario()
    {
        diarioCanvas.SetActive(false); // Esconder o Canvas do diário
        diarioAberto = false; // Atualizar estado do diário
        StartCoroutine(ativaProximopasso()); // Avançar para o próximo passo
    }

    private IEnumerator ativaProximopasso()
    {
        yield return new WaitForSeconds(3f);
        // Aqui você pode adicionar a lógica para avançar no estado da narrativa ou qualquer outra ação necessária
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameObject.GetComponent<BoxCollider>().enabled = false; // Desativa o collider para não repetir a ativação
            textoDaNarrativa.GetComponent<TextMeshProUGUI>().text = meuTexto; // Atualiza o texto da narrativa
            textoDaNarrativa.SetActive(true); // Ativa o texto da narrativa
        }
    }
}
