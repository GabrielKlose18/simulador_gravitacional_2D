using System;
namespace simulador_gravitacional_2D{
    public class Universo:UniversoAb{
        private double tempo;
        // get set tempo
        public double getTempo(){
            return tempo;
        }
        public void setTempo(double t){
            tempo = t;
        }

        public override void CalcularIteracaoGravitacional(Corpo[] Corpos){
            for (int i = 0; i < Corpos.Length; i++){
                for (int j = 0; j < Corpos.Length; j++){
                    if (i != j){
                        if (Corpos[i] != null && Corpos[j] != null){
                            CalcularForcaGravitacional(Corpos[i], Corpos[j]);
                        }
                    }
                }
            }
            foreach (Corpo corpo in Corpos){
                if (corpo != null){
                    CalcularPosicao(corpo);
                    CalcularVelocidade(corpo);
                    corpo.setForcaX(0);
                    corpo.setForcaY(0);
                }
            }

        }
        public override double CalcularDistancia(Corpo corpo1, Corpo corpo2){
            double d = 0;
            double x2 = Math.Pow((corpo1.getPosX() - corpo2.getPosX()), 2);
            double y2 = Math.Pow((corpo1.getPosY() - corpo2.getPosY()), 2);
            d = Math.Sqrt(x2 + y2);
            return d; //572.7704601321545
        }
        public override void CalcularForcaGravitacional(Corpo corpo1, Corpo corpo2){
            double G = 6.674184 * Math.Pow(10, -11);
            double Forca = 0;
            double distancia = CalcularDistancia(corpo1, corpo2); //572.7704601321545
            Forca = G * (corpo1.getMassa() * corpo2.getMassa()) / Math.Pow(distancia, 2); //0.000010001

            corpo1.setForcaX(corpo1.getForcaX() + (Forca * (corpo2.getPosX() - corpo1.getPosX()) / distancia)); //-0.996911498
            corpo1.setForcaY(corpo1.getForcaY() + (Forca * (corpo2.getPosY() - corpo1.getPosY()) / distancia)); //4.772112942693402E-07
        }
        public void CalcularPosicao(Corpo corpo){
            double ax = (corpo.getForcaX() * corpo.getMassa());
            double posx = (corpo.getVelocidadeX() * tempo) + (((corpo.getForcaX() / corpo.getMassa()) / 2) * (tempo * tempo)); //109.67+ (-1.62149) * 100
            double posy = (corpo.getVelocidadeY() * tempo) + (((corpo.getForcaY() / corpo.getMassa()) / 2) * (tempo * tempo));

            corpo.setPosX(corpo.getPosX() + posx); //1264.39165689528285
            corpo.setPosY(corpo.getPosY() + posy); //391.2458414005469
        }
        public void CalcularVelocidade(Corpo corpo){
            corpo.setVelocidadeX(corpo.getVelocidadeX() + (corpo.getForcaX() * corpo.getMassa()));
            corpo.setVelocidadeY(corpo.getVelocidadeY() + (corpo.getForcaY() * corpo.getMassa()));
        }

        public string LogIteracao(Corpo[] Corpos){
            string log = string.Empty;

            foreach (Corpo corpo in Corpos){
                if (corpo != null){
                    log += Convert.ToString(corpo.getNome()) + ";" +
                        Convert.ToString(Math.Round(corpo.getMassa(), 2)) + ";" +
                        Convert.ToString(Math.Round(corpo.getRaio(), 2)) + ";" +
                        Convert.ToString(Math.Round(corpo.getPosX(), 2)) + ";" +
                        Convert.ToString(Math.Round(corpo.getPosY(), 2)) + ";" +
                        Convert.ToString(Math.Round(corpo.getVelocidadeX(), 2)) + ";" +
                        Convert.ToString(Math.Round(corpo.getVelocidadeY(), 2));
                }
            }

            return log;
        }
        public void CalculaColisao(Corpo[] corpos, StreamWriter sw){
            for (int i = 0; i < corpos.Length; i++){
                for (int j = 0; j < corpos.Length; j++){
                    if (i != j){
                        if (corpos[i] != null && corpos[j] != null){
                            if (CalcularDistancia(corpos[i], corpos[j]) < (corpos[i].getRaio() + corpos[j].getRaio())){
                                sw.WriteLine(LogIteracao(corpos));
                                corpos[j] = corpos[j] + corpos[i];
                                corpos[i] = null;
                            }
                        }
                    }
                }
            }
        }
    }
}

