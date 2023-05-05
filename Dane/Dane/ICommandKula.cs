using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dane
{
    public interface ICommandKula
    {
        double XPosition { get; set; }
        double YPosition { get; set; }
        int Radius { get; set; }
        int Mass { get; }
        double XSpeed { get; set; }
        double YSpeed { get; set; }
        int[] BaseColor { get; set; }
        int[] CurrentColor { get; set; }
    }
}
