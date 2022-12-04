using System;
namespace simulador_gravitacional_2D{
  // Classe Universo abstrada que sera utilizada como base para classe Universo
	public abstract class UniversoAb{
        public abstract void CalcularForcaGravitacional(Corpo corpo1 , Corpo corpo2);
        public abstract void CalcularIteracaoGravitacional(Corpo[] corpos );
        public abstract double CalcularDistancia(Corpo corpo1, Corpo corpo2);
    }
}

