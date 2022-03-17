using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAutomatico : MonoBehaviour {

	private Sensores sensor;
	private Actuadores actuador;
	public int grados = 0;
	public bool rotar = false;
	public string estado;	
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

	void OnTriggerEnter(Collider other){

		if (other.gameObject.CompareTag("Cultivo")){
			if(other.GetComponent<Renderer>().material.color == Color.black){
				estado = "NUEVA";
				vidaPlanta(other);
			}else if(other.GetComponent<Renderer>().material.color == Color.yellow){
				estado = "CASI_SECA";
				vidaPlanta(other);
			}else if(other.GetComponent<Renderer>().material.color == Color.red){
				estado = "SECA";
				vidaPlanta(other);
        	}else{
        		estado = "BUENA";
        		vidaPlanta(other);
        	}

		}
	}


    void vidaPlanta(Collider other){
    	if(estado == "SECA"){
            other.GetComponent<Renderer>().material.color = Color.yellow;
            estado = "CASI_SECA";
            
        }else if (estado == "NUEVA"){
        	other.GetComponent<Renderer>().material.color = Color.red;
        	estado = "SECA";
        	
            
        }else if(estado == "CASI_SECA"){
        	other.GetComponent<Renderer>().material.color = Color.green;
        	estado = "BUENA";
        }else{
        	estado = "BUENA";
        	other.GetComponent<Renderer>().material.color = Color.green;
        }
    }
        
    
}
