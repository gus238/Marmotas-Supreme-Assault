using UnityEngine;

public class M4 : MonoBehaviour, IWeapon
{
    [Header("Propiedades del Arma")]
    public int da�o = 20;
    public float fireRate = 0.1f;
    public float rango = 50f;
    public float tiempoRecarga = 2.5f;
    public float tiempoEntreRafaga = 0.1f;
    public int tama�oCargador = 30;
    public int tama�oRafaga = 3;
    public bool mantenerApretado = true;

    [Header("Estado de Munici�n")]
    [SerializeField] private int balasRestantes;
    private int balasDisparadas;

    [Header("Control de Disparo")]
    private bool disparando;
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
        disparando = mantenerApretado ? Input.GetKey(KeyCode.Mouse0) : Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && balasRestantes < tama�oCargador && !recargando)
            Recargar();

        if (listoParaDisparar && disparando && !recargando && balasRestantes > 0)
        {
            balasDisparadas = tama�oRafaga;
            Disparar();
        }
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
        balasDisparadas--;

        Invoke(nameof(ResetDisparo), fireRate);

        if (balasDisparadas > 0 && balasRestantes > 0)
            Invoke(nameof(Disparar), tiempoEntreRafaga);
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
