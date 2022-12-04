using System;
using System.IO;
using simulador_gravitacional_2D;


namespace simulador_gravitacional_2D{
    class Program{
        static void Main(string[] args){
          try{
            StreamReader sr = new StreamReader("./../../../Files/entrada.txt");
            string linha = sr.ReadLine() ?? "";
            string[] cabecalho = linha.Split(";");
            if(int.Parse(cabecalho[0]) > 200)
              throw new Exception("Número máximo de corpos excedito! (max: 200)");
            Universo universo = new Universo();
            universo.setTempo(double.Parse(cabecalho[2]));

            Corpo[] Corpos = new Corpo[int.Parse(cabecalho[0])];

            int count = 0;
            while(!sr.EndOfStream){
                linha = sr.ReadLine();
                string[] parametros = linha.Split(";");
                Corpos[count] = new Corpo();

                if(double.Parse(parametros[1]) > 500 || double.Parse(parametros[1]) < 1)
                    throw new Exception("A Massa do Corpo deve estar em 1 e 500! (min: 1 ; max 500)");
                Corpos[count].setNome(parametros[0]);
                Corpos[count].setMassa(double.Parse(parametros[1]));
                Corpos[count].setDensidade(double.Parse(parametros[2]));
                Corpos[count].setPosX(double.Parse(parametros[3]));
                Corpos[count].setPosY(double.Parse(parametros[4]));
                Corpos[count].setVelocidadeX(double.Parse(parametros[5]));
                Corpos[count].setVelocidadeY(double.Parse(parametros[6]));
                count++;
            }
            sr.Close();
            
            StreamWriter sw = new StreamWriter("./../../../Files/saida.txt");
            for (int i = 0; i < int.Parse(cabecalho[1])+1; i++){
                sw.WriteLine($"--- Iteração {i} ---");
                universo.CalcularIteracaoGravitacional(Corpos);
                universo.CalculaColisao(Corpos, sw);
                sw.WriteLine(universo.LogIteracao(Corpos));
            }
            sw.Close();
          }
          catch(Exception ex){
            Console.WriteLine(ex.Message);
          }
        }
    }
}
