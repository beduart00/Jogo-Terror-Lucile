using UnityEngine;
using UnityEngine.UI;  // Necessário para acessar a Image do UI
using System.Collections;

public class QTEVinhetaController : MonoBehaviour
{
    public Image vinhetaImage;          // A imagem que será a vinheta
    public float tempoVinheta = 2f;     // Tempo para a vinheta aparecer (gradualmente)
    public float tempoDesvanecerVinheta = 1f; // Tempo para a vinheta desaparecer (gradualmente)
    public QuickTimeEvent qteController; // Referência ao script QTEController (pode ser arrastado no Inspector)

    private Coroutine corRotinaAtivar;   // Para armazenar a Coroutine de ativação da vinheta
    private Coroutine corRotinaDesvanecer; // Para armazenar a Coroutine de desvanecimento da vinheta

    void Start()
    {
        // Inicializa a vinheta invisível
        if (vinhetaImage != null)
        {
            vinhetaImage.color = new Color(0, 0, 0, 0);  // Preto e transparente
        }
    }

    void Update()
    {
        // Verifica se o QTE está ativo e se a vinheta não está visível
        if (vinhetaImage != null && !vinhetaImage.enabled)
        {
            // Se a vinheta não estiver visível, inicia a coroutine de ativação
            if (vinhetaImage != null && !vinhetaImage.enabled)
            {
                if (corRotinaAtivar != null) StopCoroutine(corRotinaAtivar); // Para a rotina anterior caso exista
                corRotinaAtivar = StartCoroutine(AtivarVinheta());
            }
        }
        else
        {
            // Se o QTE não está ativo e a vinheta está visível, começa a desvanecer
            if (vinhetaImage != null && vinhetaImage.enabled)
            {
                if (corRotinaDesvanecer != null) StopCoroutine(corRotinaDesvanecer); // Para a rotina anterior caso exista
                corRotinaDesvanecer = StartCoroutine(DesvanecerVinheta());
            }
        }
    }

    // Coroutine para ativar a vinheta (aumentando a opacidade de 0 a 1)
    private IEnumerator AtivarVinheta()
    {
        vinhetaImage.enabled = true;  // Certifique-se de que a imagem está visível
        float tempo = 0;

        // Gradualmente aumenta a opacidade da vinheta
        while (tempo < tempoVinheta)
        {
            tempo += Time.deltaTime;
            float alpha = Mathf.Lerp(0, 1, tempo / tempoVinheta);
            vinhetaImage.color = new Color(0, 0, 0, alpha); // Aumenta a opacidade da vinheta
            yield return null;
        }
    }

    // Coroutine para desvanecer a vinheta (diminuindo a opacidade de 1 a 0)
    private IEnumerator DesvanecerVinheta()
    {
        float tempo = 0;

        // Gradualmente diminui a opacidade da vinheta
        while (tempo < tempoDesvanecerVinheta)
        {
            tempo += Time.deltaTime;
            float alpha = Mathf.Lerp(1, 0, tempo / tempoDesvanecerVinheta);
            vinhetaImage.color = new Color(0, 0, 0, alpha); // Diminui a opacidade da vinheta
            yield return null;
        }
        vinhetaImage.enabled = false;  // Desabilita a imagem após o fade-out
    }
}
