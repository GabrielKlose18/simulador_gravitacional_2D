using System;
namespace simulador_gravitacional_2D{
    // Classe corpo abstrada que sera utilizada como base para classe Corpo
	public abstract class CorpoAb{
        public abstract double getMassa();
        public abstract double getVelocidadeX();
        public abstract void setVelocidadeX(double vx);
        public abstract double getVelocidadeY();
        public abstract void setVelocidadeY(double vy);
        public abstract double getRaio();
        public abstract double getPosX();
        public abstract void setPosX( double px);
        public abstract double getPosY();
        public abstract void setPosY( double py);
        public abstract double getDensidade();
        public abstract void setDensidade( double d);
        public abstract double getForcaX();
        public abstract void setForcaX( double fx );
        public abstract double getForcaY();
        public abstract void setForcaY( double fy );
    }
}

