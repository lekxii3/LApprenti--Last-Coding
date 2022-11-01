using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemeSolaire : MonoBehaviour
{
    // Références vers les composants Transform de la terre, de la lune et du soleil
    public Transform sun;
    public Transform earth;
    public Transform moon;

    // Distance terre - lune
    public float moonDistance = 5f;
    
    // Distance terre - soleil
    public Vector3 EarthDistance = new Vector3(0,0,5);
    
    // Distance terre - lune
    public Vector3 luneDistance = new Vector3(0,0,0.3f);

    // Axe de rotation de la terre autour du soleil
    public Vector3 sunRotationAxis = new Vector3(0.2f, 1f, 0.2f);

    // Angle de rotation de la terre autour du soleil
    private float sunCumulatedAngle = 0;

    // Valeur ajoutée à l'angle de rotation de la terre autour du soleil
    public float sunAngleIncrement = 0.02f;


    void FixedUpdate()
    {
        // Faire tourner la terre autour du soleil 
        Quaternion rotation = Quaternion.Euler(0, sunAngleIncrement++ * 1, 0);
        earth.position = rotation * EarthDistance + sun.position;

        // Faire tourner la terre sur elle même, 365 fois en un tour de soleil


        // Faire tourner la lune autour de la terre
        // La lune doit tourner 27 fois autour de la terre, lorsque celle-ci fait un tour du soleil
        Quaternion rotation1 = Quaternion.Euler(0, sunAngleIncrement++ * 3, 0);
        moon.position = rotation1 * luneDistance + earth.position;


        // La lune doit toujours regarder la terre avec la même face
        //moon.
        moon.rotation = Quaternion.LookRotation(earth.position-transform.position);

        // On incrémente l'angle de la terre autour du soleil
        //sunCumulatedAngle += sunAngleIncrement;
    }
}
