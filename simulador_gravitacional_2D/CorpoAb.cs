using System;
namespace simulador_gravitacional_2D{
    // Classe corpo abstrada que sera utilizada como base para classe Corpo
	public abstract class CorpoAb{
        public abstract float getMassa();
        public abstract float getVelocidadeX();
        public abstract void setVelocidadeX(float vx);
        public abstract float getVelocidadeY();
        public abstract void setVelocidadeY(float vy);
        public abstract double getRaio();
        public abstract float getPosX();
        public abstract void setPosX( float px);
        public abstract float getPosY();
        public abstract void setPosY( float py);
        public abstract float getDensidade();
        public abstract void setDensidade( float d);
        public abstract float getForcaX();
        public abstract void setForcaX( float fx );
        public abstract float getForcaY();
        public abstract void setForcaY( float fy );
    }
}

