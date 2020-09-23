using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Creacion : MonoBehaviour
{
    public float maxSize = 100;
    public Transform nextPoint, nextPointPlataformas;
    public GameObject suelo1, suelo2, plataforma1, plataforma2, pointSuelo, pointPlataforma;

    // Start is called before the first frame update
    void Start()
    {
        //Sincronizamos la referencia del punto inical del suelo y pasarelas donde vamos a hacer el aleatorio
        nextPoint = pointSuelo.transform;
        nextPointPlataformas = pointPlataforma.transform;
        GenerarSuelo();
        GenerarPlataformas();
        //GenerarEnemigos();
    }

    private void GenerarSuelo()
    {
        //Controlamos que pare de generar al superar el límite del escenario
        while (nextPoint.position.x < maxSize)
        {
            int al = Random.Range(0, 2);
            switch (al)
            {
                case 0:
                    InstanciarObjeto(suelo1, pointSuelo.transform);  
                    pointSuelo.transform.position = new Vector3(pointSuelo.transform.position.x + 10f, -7f, 1);
                    nextPoint.position = pointSuelo.transform.position;
                    break;
                case 1:
                    InstanciarObjeto(suelo2, pointSuelo.transform);
                    pointSuelo.transform.position = new Vector3(pointSuelo.transform.position.x + 2f, -7f, 1);
                    nextPoint.position = pointSuelo.transform.position;
                    break;
                case 2:
                    pointSuelo.transform.position = new Vector3(pointSuelo.transform.position.x + 2f, -7f, 1);
                    nextPoint.position = pointSuelo.transform.position;
                    //No se instancia nada para que quede el hueco vacío
                    break;
            }
        }
    }

    private void GenerarPlataformas()
    {
        //Controlamos que pare de generar al superar el límite del escenario
        while (nextPointPlataformas.position.x < maxSize)
        {
            int al = Random.Range(0, 5);
            switch (al)
            {
                case 0:
                    InstanciarPlataformas(plataforma1, pointPlataforma.transform);
                    pointPlataforma.transform.position = new Vector3(pointPlataforma.transform.position.x + 4f, -2f, 1);
                    nextPointPlataformas.position = pointPlataforma.transform.position;
                    break;
                case 1:
                    InstanciarPlataformas(plataforma2, pointPlataforma.transform);
                    pointPlataforma.transform.position = new Vector3(pointPlataforma.transform.position.x + 2f, -2f, 1);
                    nextPointPlataformas.position = pointPlataforma.transform.position;
                    break;
                case 2:
                case 3:
                case 4:
                    pointPlataforma.transform.position = new Vector3(pointPlataforma.transform.position.x + 2f, -2f, 1);
                    nextPointPlataformas.position = pointPlataforma.transform.position;
                    //No se instancia nada para que quede el hueco vacío
                    break;
            }
        }
    }

    private void GenerarEnemigos()
    {
        //TODO igual se generan directamente cuando creemos la plataforma o suelo, se puede generar en el medio de la instancia y con el tamaño/2 para saber el rango de movimiento del enemigo
        throw new NotImplementedException();
    }

    //Instanciador suelo
    private void InstanciarObjeto(GameObject prefab, Transform posicion)
    {
        GameObject go = Instantiate(prefab, posicion.position, Quaternion.identity);
        //Metemos el objeto instanciado en la carpeta de la jerarquía
        go.transform.parent = GameObject.Find("Suelo").transform;
    }
    //Instanciador plataformas
    private void InstanciarPlataformas(GameObject prefab, Transform posicion)
    {
        GameObject go = Instantiate(prefab, posicion.position, Quaternion.identity);
        go.transform.parent = GameObject.Find("Plataformas").transform;
    }
}
