using System;
namespace simulador_gravitacional_2D{
	public class Corpo:CorpoAb{
        private string nome;
        private float massa;
        private float densidade;
        private float posX;
        private float posY;
        private float velX;
        private float velY;

        public Corpo(){
            nome = "";
            massa = 0;
            densidade = 0;
            posX = 0;
            posY = 0;
            velX = 0;
            velY = 0;
        }

        public override float getMassa(){
            return massa;
        }

        // get set velocidadeX
        public override float getVelocidadeX(){
            return velX;
        }
        public override void setVelocidadeX( float vx ){
            velX = vx;
        }

        // get set velocidadeY
        public override float getVelocidadeY(){
            return velY;
        }
        public override void setVelocidadeY(float vy){
            velY = vy;
        }

        // get Raio
        /*
        * formula original: v = (4/3)πrˆ2
        * formula manipulada para descobrir o raio: ((V/π)(3/4))ˆ1/3 = r 
        * consideraremos pi = 3,14
        */
        public override double getRaio(){
            return Math.Pow(((this.getVolume() / 3.14) * (3/4)),1/3);
        }

        // get set posX
        public override float getPosX(){
            return posX;
        }
        public override void setPosX( float px ){
            posX = px;
        }

        // get set posY
        public override float getPosY(){
            return posY;
        }
        public override void setPosY(float py){
            posY = py;
        }

        // get set densidade
        public override float getDensidade(){
            return densidade;
        }
        public override void setDensidade(float d){
            densidade = d;
        }

        // get set forcaX
        public override float getForcaX(){
            return 0;
        }
        public override void setForcaX( float fx ){
            float forcaX = fx;
        }

        // get set forcaY
        public override float getForcaY(){
            return 0;
        }
        public override void setForcaY(float fy){
            float forcaY = fy;
        }

        public float getVolume(){
            return massa / densidade;
        }
    }
}

