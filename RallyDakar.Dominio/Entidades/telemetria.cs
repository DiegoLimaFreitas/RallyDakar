using System;
using System.Collections.Generic;
using System.Text;

namespace RallyDakar.Dominio.Entidades
{
   public class telemetria
    {

        public int Id { get; set; }

        public int Temporadaid { get; set; }

        public int PilotoId { get; set; }

        public DateTime Data { get; set; }

        public TimeSpan Hora { get; set; }

        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

        public decimal PercentualCombustivel { get; set; }

        public double Velocidade { get; set; }

        public double RPM { get; set; }

        public int TemperaturaExterna { get; set; }

        public int TemperaturaMotor { get; set; }

        public double AltitudeNiveMar { get; set; }
        //Ele está com o pé no acelerador?
        public bool PedalAcelerador  { get; set; }
        //Ele está com o pé no freio?
        public bool PedalFreio { get; set; }

    }

}
