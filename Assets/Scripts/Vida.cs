using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Vida : MonoBehaviour{
    private float vida; // Esta cifra es equivalente a los segundos activos de la batería
    public float vidaMaxima; // Indica la capacidad máxima de la batería
    public float vidaCrecimiento; // Escalar para multiplicar la velocidad de carga de la batería

    public void Update(){
        if(vida > 0) // esto evita que la batería sea negativa
            vida -= Time.deltaTime;
    }

    // ========================================
    // Métodos públicos que podrán ser utilizados por otros componentes (scripts):
    public void actualizaVida(){
        if(vida < vidaMaxima)
            vida += Time.deltaTime * vidaCrecimiento;
    }

    public float getVida(){
        return vida;
    }

    public void setVida(float nivel){
        vida = nivel;
    }
}
