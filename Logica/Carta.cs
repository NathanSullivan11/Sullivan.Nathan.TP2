using System;

namespace Entidades
{
    public class Carta
    {
        private int numero;
        private int valorJerarquico;
        private EPalo palo;

        public Carta(int numero, EPalo palo)
        {
            this.numero = numero;
            this.palo = palo;
            Carta.CalcularValorJerarquico(this);
        }

        public int Numero { get => numero; }
        public EPalo Palo { get => palo; }
        public int ValorJerarquico { get => valorJerarquico; }

        private static void CalcularValorJerarquico(Carta carta)
        { 
            switch (carta.numero)
            {
                case 1:
                    if (carta.Palo == EPalo.Espada)
                    {
                        carta.valorJerarquico  = 1;
                    }
                    else if (carta.Palo == EPalo.Basto)
                    {
                        carta.valorJerarquico  = 2;
                    }
                    else
                    {
                        carta.valorJerarquico  = 7;
                    }
                    break;
                case 2:
                    carta.valorJerarquico  = 6;
                    break;
                case 3:
                    carta.valorJerarquico  = 5;
                    break;
                case 4:
                    carta.valorJerarquico  = 14;
                    break;
                case 5:
                    carta.valorJerarquico  = 13;
                    break;
                case 6:
                    carta.valorJerarquico  = 12;
                    break;
                case 7:
                    if (carta.Palo == EPalo.Espada)
                    {
                        carta.valorJerarquico  = 3;
                    }
                    else if (carta.Palo == EPalo.Oro)
                    {
                        carta.valorJerarquico  = 4;
                    }
                    else
                    {
                        carta.valorJerarquico  = 11;
                    }
                    break;
                case 10:
                    carta.valorJerarquico  = 10;
                    break;
                case 11:
                    carta.valorJerarquico  = 9;
                    break;
                case 12:
                    carta.valorJerarquico  = 8;
                    break;
            }
    
        }

        public bool EsFigura()
        {
            return this.Numero >= 10;
        }
     
        public override string ToString()
        {
            return $"{this.numero} {this.palo.ToString()} ";
        }

        public override bool Equals(object obj)
        {
            if(obj is Carta item)
            {
                return this.numero == item.numero && this.palo == item.palo;
            }
            else
            {
                return false;
            }            
        }
    }
}
