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
	private int contador = 0;
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
		if (sensor.FrenteAPared()) {
			actuador.Detener();
			actuador.GirarAleatorio();
			
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
			actuador.GirarAleatorio();
        }
    }

	void OnTriggerEnter(Collider other)
	{
		
		
		if (other.gameObject.CompareTag("CultivoA")){

			if(contador >= 0 && contador <= 90){
				if (other.GetComponent<Renderer>().material.color == Color.black)
				{
					other.GetComponent<Renderer>().material.color = Color.green;
					contador ++;
				}
			}	
		}else if (other.gameObject.CompareTag("CultivoB")){
			
			if(contador >= 90 && contador <= 180){
				if (other.GetComponent<Renderer>().material.color == Color.black)
				{
					other.GetComponent<Renderer>().material.color = Color.green;
					contador ++;
				}
			}	
		}else if (other.gameObject.CompareTag("CultivoC")){
			
			if(contador >= 180 && contador <= 270){
				if (other.GetComponent<Renderer>().material.color == Color.black)
				{
					other.GetComponent<Renderer>().material.color = Color.green;
					contador ++;
				}
			}	
		}else if (other.gameObject.CompareTag("CultivoD")){
			
			if(contador >= 270 && contador <= 360){
				if (other.GetComponent<Renderer>().material.color == Color.black)
				{
					other.GetComponent<Renderer>().material.color = Color.green;
					contador ++;
				}
			}	
		}			
	
	}




}
