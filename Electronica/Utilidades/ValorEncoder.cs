using System;

namespace Electronica.Utilidades
{
    public class ValorEncoder
    {
        #region Propiedades
        private int valor;
        public int Valor
        {
            get
            {
                return valor;
            }
            set
            {
                valor = value;
            }
        }

        private int valorMaximo;
        public int ValorMaximo
        {
            get
            {
                return valorMaximo;
            }
            set
            {
                if (value < ValorMinimo)
                {
                    valorMaximo = valorMinimo;
                }
                else
                {
                    valorMaximo = value;
                }
            }
        }

        private int valorMinimo;
        public int ValorMinimo
        {
            get
            {
                return valorMinimo;
            }
            set
            {
                if (value > ValorMaximo)
                {
                    valorMinimo = ValorMaximo;
                }
                else
                {
                    valorMinimo = value;
                }
            }
        }

        public int ValorIncremento { get; set; }
        public Boolean RotarValor { get; set; }
        #endregion Propiedades

        public ValorEncoder(int valor)
        {
            this.valor = valor;
        }

        public ValorEncoder(int minimo, int maximo, int incremento, bool rotar)
        {
            this.ValorMaximo = maximo;
            this.ValorMinimo = minimo;
            this.ValorIncremento = incremento;
            this.RotarValor = rotar;
            this.valor = ValorMinimo;
        }

        public void Incrementar()
        {
            valor += ValorIncremento;
            if (valor > ValorMaximo)
            {
                if (RotarValor)
                {
                    valor = ValorMinimo;
                }
                else
                {
                    valor = ValorMaximo;
                }
            }
        }

        public void Decrementar()
        {
            valor -= ValorIncremento;
            if (valor < ValorMinimo)
            {
                if (RotarValor)
                {
                    valor = ValorMaximo;
                }
                else
                {
                    valor = valorMinimo;
                }
            }
        }

        public int CargarPasos(int pasos)
        {
            if (pasos > 0)
            {
                for (int i = 0; i < pasos; i++)
                {
                    Incrementar();
                }
            }
            else if (pasos < 0)
            {
                for (int i = pasos; i < 0; i++)
                {
                    Decrementar();
                }
            }
            return valor;
        }

        public int CargarPasos(int pasos1, int pasos2)
        {
            if (pasos1 > 0)
            {
                for (int i = 0; i < pasos1; i++)
                {
                    Incrementar();
                }
            }
            else if (pasos1 < 0)
            {
                for (int i = pasos1; i < 0; i++)
                {
                    Decrementar();
                }
            }

            if (pasos2 > 0)
            {
                for (int i = 0; i < pasos2; i++)
                {
                    Incrementar();
                }
            }
            else if (pasos2 < 0)
            {
                for (int i = pasos2; i < 0; i++)
                {
                    Decrementar();
                }
            }
            return valor;
        }
    }
}
