using System;

namespace src
{
    public class Feriados
    {
        private int[] feriados;

        public Feriados()
        {
            this.feriados = [1, 11, 15, 25];
        }

        public int[] GetFeriados()
        {
            return feriados;
        }
    }
}