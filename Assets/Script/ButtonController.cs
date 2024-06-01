using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ButtonController : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI text1;
    [SerializeField] private TextMeshProUGUI text2;
    [SerializeField] private TextMeshProUGUI text3;
    [SerializeField] private TextMeshProUGUI text4;
    [SerializeField] private TextMeshProUGUI text5;
    [SerializeField] private GameObject check;
    [SerializeField] private GameObject check1;
    [SerializeField] private GameObject check2;
    [SerializeField] private GameObject check3;
    [SerializeField] private GameObject checkDelete;
    [SerializeField] private GameObject checkDelete1;
    [SerializeField] private GameObject checkDelete2;
    [SerializeField] private GameObject checkDelete3;
    [SerializeField] private TextMeshProUGUI totalText;

    private float totalPercentageCPU = 0f; // Variable to store the total CPU percentage
    private float totalPercentageRAM = 0f;
    private float totalPercentageHDD = 0f;
    private bool finished = false; // Variable to control if the process has finished
    

    public void ButtonPress()
    {
        // Add percentages for CPU, RAM, and HDD
        AddPercentage(20f, 10f, 5f);
        text1.text = "Word      20%   10%  5% ";
        Debug.Log("Imprimio Word");
            
    }

    public void ButtonPress2()
    {
        AddPercentage(30f, 10f, 10f);
        text2.text = "Excel      30%   10%  10% ";
        Debug.Log("Imprimio Excel");
    }

    public void ButtonPress3()
    {
        AddPercentage(5f, 1f, 10f);
        text3.text = "Recortes   5%   1%  10% ";
        Debug.Log("Imprimio Recortes");
    }

    public void ButtonPress4()
    {
        AddPercentage(3f, 1f, 5f);
        text4.text = "Reloj      3%   1%  5% ";
        Debug.Log("Imprimio Reloj");
    }

    public void CheckBox()
        {
            // Ensure that the check object is active
            check.gameObject.SetActive(true);
            checkDelete.gameObject.SetActive(true);
        }

    public void CheckBox1()
        {
            check1.gameObject.SetActive(true);
            checkDelete1.gameObject.SetActive(true);
            
        }

     public void CheckBox2()
        {
            check2.gameObject.SetActive(true);
            checkDelete2.gameObject.SetActive(true);
        }
     public void CheckBox3()
        {
            check3.gameObject.SetActive(true);
            checkDelete3.gameObject.SetActive(true);
        }

    public void ButtonRemoveWord()
    {
        text1.text = "";
        SubtractPercentage(20f, 10f, 5f);
        check.SetActive(false);
        checkDelete.SetActive(false);

        Debug.Log("Se ha eliminado el contenido de Word");
    }

    public void ButtonRemoveExcel()
    {
        text2.text = "";
        SubtractPercentage(30f, 10f, 10f);
        check1.SetActive(false);
        checkDelete1.SetActive(false);

        Debug.Log("Se ha eliminado el contenido de Excel");
    }

    public void ButtonRemoveCurt()
    {
        text3.text = "";
        SubtractPercentage(5f, 1f, 10f);
        check2.SetActive(false);
        checkDelete2.SetActive(false);

        Debug.Log("Se ha eliminado el contenido de Recorte");
    }

    public void ButtonRemoveClock()
    {
        text4.text = "";
        SubtractPercentage(3f, 1f, 5f);
        check3.SetActive(false);
        checkDelete3.SetActive(false);

        Debug.Log("Se ha eliminado el contenido de Reloj");
    }

    public void ButtonRemove()
    {
        // Subtract percentages for CPU, RAM, and HDD
        SubtractPercentage(totalPercentageCPU, totalPercentageRAM, totalPercentageHDD);
       
        // Reset the total percentage variables to 0
        totalPercentageCPU = 0f;
        totalPercentageRAM = 0f;
        totalPercentageHDD = 0f;

        // Clear the text for text fields
        text1.text = "";
        text2.text = "";
        text3.text = "";
        text4.text = "";
        text5.text = "";
        finished = true;

        // Deactivate all checkboxs
        check.SetActive(false);
        check1.SetActive(false);
        check2.SetActive(false);
        check3.SetActive(false);
        checkDelete.SetActive(false);
        checkDelete1.SetActive(false);
        checkDelete2.SetActive(false);
        checkDelete3.SetActive(false);
    }

    private void AddPercentage(float cpuPercentage, float ramPercentage, float hddPercentage)
    {
       
    // Check if adding CPU percentage exceeds 100%
    if (totalPercentageCPU + cpuPercentage > 100f)
    {
        text5.text = "CPU esta llegando al 100%";
        Debug.Log("No se puede anadir mas porcentaje al CPU. Ya ha alcanzado el 100%");
        return;
    }

    // Check if adding RAM percentage exceeds 100%
    if (totalPercentageRAM + ramPercentage > 100f)
    {
        text5.text = "RAM esta llegando al 100%";
        Debug.Log("No se puede añadir más porcentaje a la RAM. Ya ha alcanzado el 100%");
        return;
    }

    // Check if adding HDD percentage exceeds 100%
    if (totalPercentageHDD + hddPercentage > 100f)
    {
        text5.text = "HDD esta llegando al 100%";
        Debug.Log("No se puede añadir más porcentaje al HDD. Ya ha alcanzado el 100%");
        return;
    }

    // Add the percentages if none of them exceed 100%
    totalPercentageCPU += cpuPercentage;
    totalPercentageRAM += ramPercentage;
    totalPercentageHDD += hddPercentage;
    UpdateTotalText();
    }

    void SubtractPercentage(float cpuPercentage, float ramPercentage, float hddPercentage)
    {
        totalPercentageCPU -= cpuPercentage;
        totalPercentageRAM -= ramPercentage;
        totalPercentageHDD -= hddPercentage;
        UpdateTotalText();
    }

    private void UpdateTotalText()
    {
        // Actualiza el texto de los porcentajes
        totalText.text = "CPU: " + totalPercentageCPU.ToString() + "%\n";
        totalText.text += "RAM: " + totalPercentageRAM.ToString() + "%\n";
        totalText.text += "HDD: " + totalPercentageHDD.ToString() + "%";
    }
}
