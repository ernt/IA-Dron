using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComportamientoAutomatico : MonoBehaviour {

	private Sensores sensor;
	private Actuadores actuador;
	public int grados = 0;
	public bool rotando = false;
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
		if (rotando) {
			rotar();
		} else if (sensor.FrenteAPared()) {
			actuador.Detener();
		
			rotando=true;
		}else{
			actuador.Adelante();
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


	void rotar (){
		grados++;
		if (grados==90)
		{
			rotando=false;
			grados=0;
		}else{
		actuador.GirarDerecha();

		}
	}
		bool randomDir() {
		return (Random.value > 0.5f);
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

