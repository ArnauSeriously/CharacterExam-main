using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoSimple : MonoBehaviour
{
    public float velocidad = 5f; 
    public float sensibilidadRaton = 15f; 
    public float fuerzaSalto = 10f; 
    private bool enSuelo;

    void Update()
    {
        
        Movimiento();

      
        RotacionConRaton();

       
        if (Input.GetButtonDown("Jump") && enSuelo)
        {
            Saltar();
        }
    }

    void Movimiento()
    {
       
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

       
        float horizontalWASD = Input.GetKey("d") ? 1f : (Input.GetKey("a") ? -1f : 0f);
        float verticalWASD = Input.GetKey("w") ? 1f : (Input.GetKey("s") ? -1f : 0f);

        
        float movimientoHorizontalTotal = movimientoHorizontal + horizontalWASD;
        float movimientoVerticalTotal = movimientoVertical + verticalWASD;

       
        Vector3 direccion = new Vector3(movimientoHorizontalTotal, 0f, movimientoVerticalTotal).normalized;

       
        Vector3 desplazamiento = direccion * velocidad * Time.deltaTime;

       
        transform.Translate(desplazamiento);
    }

    void RotacionConRaton()
    {
       
        float rotacionX = Input.GetAxis("Mouse X") * sensibilidadRaton;

       
        transform.Rotate(Vector3.up, rotacionX);
    }

    void Saltar()
    {
       
        GetComponent<Rigidbody>().AddForce(Vector3.up * fuerzaSalto, ForceMode.Impulse);
        enSuelo = false; 
    }

    void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.CompareTag("Suelo"))
        {
            enSuelo = true;
        }
    }
}