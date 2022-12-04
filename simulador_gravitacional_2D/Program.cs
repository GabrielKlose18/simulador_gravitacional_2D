using System;
using System.IO;
using simulador_gravitacional_2D;


namespace simulador_gravitacional_2D{
    class Program{
        static void Main(string[] args){
            StreamReader sr = new StreamReader("./../../../Files/entrada.txt");
            string linha = sr.ReadLine() ?? "";
            string[] cabecalho = linha.Split(";");

            Universo universo = new Universo();
            universo.setTempo(double.Parse(cabecalho[2]));

            Corpo[] Corpos = new Corpo[int.Parse(cabecalho[0])];

            int count = 0;
            while(!sr.EndOfStream){
                linha = sr.ReadLine();
                string[] parametros = linha.Split(";");
                Corpos[count] = new Corpo();
                
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
    }
}
