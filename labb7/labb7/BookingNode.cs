using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// BookingNode representerar en nod i det binära sökträdet (Uppgift 2)
// Används för att lagra och sortera tidbokningar
public class BookingNode
{
    // Tiden för bokningen, t.ex. "10:30"
    public string Time { get; set; }

    // Patientens namn
    public string PatientName { get; set; }

    // Pekar på nod med tidigare tid (vänster i BST)
    public BookingNode Left { get; set; }

    // Pekar på nod med senare tid (höger i BST)
    public BookingNode Right { get; set; }

    // Konstruktor – skapar en ny bokning med tid och patientnamn
    public BookingNode(string time, string patientName)
    {
        Time = time;
        PatientName = patientName;
        Left = null;
        Right = null;
    }
}
