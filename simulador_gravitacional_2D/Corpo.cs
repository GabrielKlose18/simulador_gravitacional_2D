using System;
namespace simulador_gravitacional_2D{
	public class Corpo:CorpoAb{
        private string nome;
        private double massa;
        private double densidade;
        private double posX;
        private double posY;
        private double velX;
        private double velY;
        private double forcaX;
        private double forcaY;

        public Corpo(){
            nome = "";
            massa = 0;
            densidade = 0;
            posX = 0;
            posY = 0;
            velX = 0;
            velY = 0;
            forcaX = 0;
            forcaY = 0;
        }

        public override double getMassa(){
            return massa;
        }
        public void setMassa( double m ){
            massa = m;
        }

        // get set velocidadeX
        public string getNome(){
            return nome;
        }
        public void setNome( string n){
            nome = n;
        }

        // get set velocidadeX
        public override double getVelocidadeX(){
            return velX;
        }
        public override void setVelocidadeX( double vx ){
            velX = vx;
        }

        // get set velocidadeY
        public override double getVelocidadeY(){
            return velY;
        }
        public override void setVelocidadeY(double vy){
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
        public override double getPosX(){
            return posX;
        }
        public override void setPosX( double px ){
            posX = px;
        }

        // get set posY
        public override double getPosY(){
            return posY;
        }
        public override void setPosY(double py){
            posY = py;
        }

        // get set densidade
        public override double getDensidade(){
            return densidade;
        }
        public override void setDensidade(double d){
            densidade = d;
        }

        // get set forcaX
        public override double getForcaX(){
            return forcaX;
        }
        public override void setForcaX( double fx ){
            forcaX = fx;
        }

        // get set forcaY
        public override double getForcaY(){
            return forcaY;
        }
        public override void setForcaY(double fy){
            forcaY = fy;
        }

        public double getVolume(){
            return massa / densidade;
        }

        public static Corpo operator +(Corpo corpo1, Corpo corpo2){
            Corpo corpoResultante = new Corpo();
            corpoResultante.setNome(corpo1.getNome() + corpo2.getNome());
            corpoResultante.setMassa(corpo1.getMassa() + corpo2.getMassa());
            corpoResultante.setVelocidadeX(corpo1.getVelocidadeX() + corpo2.getVelocidadeX());
            corpoResultante.setVelocidadeY(corpo1.getVelocidadeY() + corpo2.getVelocidadeY());

            return corpoResultante;
        }   
    }
}

