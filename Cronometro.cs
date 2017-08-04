using System;
using System.Globalization;
using System.Windows.Forms;

namespace Dominio_Lector
{
    
    public class Cronometro
    {
        //private Timer Tiempo { get; set; }
        Timer Tiempo = new Timer();
        public Double Result { get; set; }

        public Cronometro()
        {
            Tiempo.Enabled = true;
            Tiempo.Tick += new EventHandler(Tiempo_Tick);
            Tiempo.Interval = 100;
            //Tiempo.Start();
        }

        void Tiempo_Tick(object sender, EventArgs e)
        {
            Result++;
        }
        //private static void TimerEventProcessor(object sender, EventArgs e)
        // 
            // Result++;
            //Tiempo.Stop();
        //}

        public void Start()
        {
            Tiempo.Start();
        }

        public void Pause()
        {
            //
        }

        public void Stop()
        {
            Tiempo.Stop();
        }

        public override string ToString()
        {
            return string.Format(
                CultureInfo.CurrentCulture,
                "{0} ms",
                Result);

        }
    }

}
