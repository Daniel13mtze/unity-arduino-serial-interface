using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
using System.IO.Ports;
using System.Threading;

public class PlayerMovement : MonoBehaviour

{
    bool alive = true;
    public float speed = 10;
    public float ac = 100;
    public float de = 1 / 100;
    public Rigidbody rb;
    float horizontalInput;
    public float horizontalMultiplier;
    public static PlayerMovement inst;
    public TextMeshProUGUI vel;

    SerialPort serialPort;
    public string portName = "COM10"; // Reemplaza con el nombre de tu puerto
    public int baudRate = 115200;
    private bool isSerialConnected = false;

    void Start()
    {
        panelOpciones = GameObject.FindGameObjectWithTag("Opciones").GetComponent<Controlador>();
        serialPort = new SerialPort(portName, baudRate);
        serialPort.ReadTimeout = 50;
        try
        {
            serialPort.Open();
            isSerialConnected = true;
            Debug.Log("Arduino conectado con éxito en el puerto " + portName);
        }
        catch (System.Exception e)
        {
            isSerialConnected = false;
            Debug.LogWarning("Arduino no detectado. Activando Modo Simulación (Teclado). Detalles: " + e.Message);
        }
    }
    public void incrementvel()
    {
        speed++;
        vel.text = "Velocidad: " + speed;
    }
    public void decrementvel()
    {
        if (speed > 2)
        {
            speed--;
            vel.text = "Velocidad: " + speed;
        }
    }

    private void Awake()
    {
        inst = this;
    }
    private void Update()
    {
        if (!alive) return;

        float hardwareHorizontalInput = 0;

        if (isSerialConnected && serialPort != null && serialPort.IsOpen)
        {
            try
            {
                string data = serialPort.ReadLine();
                Debug.Log("Data received: " + data);

                if (data == "Derecha")
                {
                    hardwareHorizontalInput = 1f;
                }
                else if (data == "Izquierda")
                {
                    hardwareHorizontalInput = -1f;
                }
            }
            catch (System.TimeoutException)
            {

            }
            catch (System.Exception e)
            {
                Debug.LogError("Error leyendo el puerto serial: " + e.Message);
            }
        }

        float keyboardInput = Input.GetAxis("Horizontal");

        if (Mathf.Abs(keyboardInput) > 0.01f)
        {
            horizontalInput = keyboardInput;
        }
        else
        {
            horizontalInput = hardwareHorizontalInput;
        }

        if (transform.position.y < -5)
        {
            Die();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MostrarOpciones();
        }

        Vector3 forwardMove = transform.forward * speed * Time.deltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.deltaTime * horizontalMultiplier;

        rb.MovePosition(rb.position + forwardMove + horizontalMove);

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            forwardMove = transform.forward * speed * ac * Time.deltaTime;
            incrementvel();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            forwardMove = transform.forward * speed * de * Time.deltaTime;
            decrementvel();
        }
    }
    public void Die()
    {
        alive = false; Invoke("Restart", 0);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public Controlador panelOpciones;
    public void MostrarOpciones()
    {
        speed = 0; SceneManager.UnloadSceneAsync("Jugador");
        panelOpciones.pantallaOpciones.SetActive(true);
    }
    public void EscenaGame()
    {
        SceneManager.LoadScene("Jugador"); speed = 5;

    }
    void OnApplicationQuit()
    {
        if (isSerialConnected && serialPort != null && serialPort.IsOpen)
        {
            serialPort.Close();
        }
    }
}
