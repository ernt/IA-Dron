using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAutomatico : MonoBehaviour {

	private Sensores sensor;
	private Actuadores actuador;
	public int grados = 0;
	public bool rotar = false;
	public string estado;
	private bool activo;
	void Start(){
		sensor = GetComponent<Sensores>();
		actuador = GetComponent<Actuadores>();
	
	}

	void FixedUpdate () {
		if(sensor.Bateria() <= 0) {
			return;
		}
		actuador.Flotar();
        if (rotar)
        {
			girar();
        }
		if (sensor.FrenteAPared() && sensor.CercaDePared()) {
			actuador.Detener();
			actuador.GirarAleatorio();
			//rotar = true;
		} else {
			actuador.Adelante();
		}

	}
	 void girar()
    {
		grados++;
        if (grados == 90)
        {
			rotar = false;
			grados = 0;
        }
        else
        {
			actuador.GirarDerecha();
        }
    }

	void OnTriggerEnter(Collider other)
	{

		if (other.gameObject.CompareTag("CultivoA"))
		{
			if (other.GetComponent<Renderer>().material.color == Color.black)
			{
				other.GetComponent<Renderer>().material.color = Color.green;
			}
			

		}
	}







}
