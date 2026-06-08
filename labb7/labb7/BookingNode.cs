using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class BookingNode
{
    public string Time { get; set; }
    public string PatientName { get; set; }
    public BookingNode Left { get; set; }
    public BookingNode Right { get; set; }

    public BookingNode(string time, string patientName)
    {
        Time = time;
        PatientName = patientName;
        Left = null;
        Right = null;
    }
}
