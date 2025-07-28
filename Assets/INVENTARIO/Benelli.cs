using UnityEngine;

public class Benelli : MonoBehaviour, IWeapon
{
    [Header("Propiedades del Arma")]
    public int da�o = 50;
    public float fireRate = 1f;
    public float rango = 25f;
    public float tiempoRecarga = 3f;
    public int tama�oCargador = 5;

    [Header("Estado de Munici�n")]
    [SerializeField] private int balasRestantes;

    [Header("Control de Disparo")]
    private bool listoParaDisparar = true;
    private bool recargando;

    [Header("Referencias")]
    public Camera fpsCam;
    public LayerMask capaEnemigo;
    public AudioSource audioSource;
    public AudioClip disparoSonido;
    public AudioClip recargaSonido;

    public int BalasRestantes => balasRestantes;
    public int TamanoCargador => tama�oCargador;

    private void OnEnable()
    {
        balasRestantes = tama�oCargador;
        AmmoHUD.Instance.SetArmaActual(this);
    }

    private void Update()
    {
        MiInput();
        AmmoHUD.Instance.ActualizarHUD();
    }

    private void MiInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && listoParaDisparar && !recargando && balasRestantes > 0)
            Disparar();

        if (Input.GetKeyDown(KeyCode.R) && balasRestantes < tama�oCargador && !recargando)
            Recargar();
    }

    private void Disparar()
    {
        listoParaDisparar = false;
        if (audioSource && disparoSonido) audioSource.PlayOneShot(disparoSonido);

        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out RaycastHit rayHit, rango, capaEnemigo))
        {
            var vida = rayHit.collider.GetComponentInParent<VidaEnemigo>();
            if (vida != null) vida.TakeDamage(da�o);
        }

        balasRestantes--;
        Invoke(nameof(ResetDisparo), fireRate);
    }

    private void ResetDisparo() => listoParaDisparar = true;

    public void Recargar()
    {
        recargando = true;
        if (audioSource && recargaSonido) audioSource.PlayOneShot(recargaSonido);
        Invoke(nameof(RecargaTerminada), tiempoRecarga);
    }

    private void RecargaTerminada()
    {
        balasRestantes = tama�oCargador;
        recargando = false;
        AmmoHUD.Instance.ActualizarHUD();
    }
}

