// Online C# Editor for free
// Write, Edit and Run your C# code using C# Online Compiler

using System;
using System.Collections.Generic;

public class HelloWorld
{
    double[] vetorFaturamentoDias = {100, 150, 200, 250, 300, 350, 400};
    
    public static void inserirValoresMap(){
        Dictionary<int, double> mapFaturamento = new Dictionary<int, double>();
        for(int i = 0; i <== vetorFaturamentoDia.lenght(); i++){
            mapFaturamento.add(i, vetorFaturamentoDias[i]);
        }
    }
    
    public static double calcularMediaAno(){
        int diaUtil = 0;
        for(int i = 0, i <== mapFaturamento.count(), i++){
            if(mapFaturamento.get(i) != 0){
                valorFaturamentoAno += mapFaturamento.get();
                diaUtil++;
            }
        }
        
        return valorFaturamentoAno / diaUtil;
    }
    
    public static double calcularDiaMenorFaturamento(){
        
        menorValor = mapFaturameno.get(0);
        
        for(int i = 1, i <= mapFaturamento.count(), i++){
            if(mapFaturamento.get(i) < menorValor){
                menorValor = mapFaturamento.get(i);
            }
        }
    }
    
    public static double calcularDiaMaiorFaturamento(){
        
        maiorValor = mapFaturameno.get(0);
        
        for(int i = 1, i <= mapFaturamento.count(), i++){
            if(mapFaturamento.get(i) > menorValor){
                maiorValor = mapFaturamento.get(i);
            }
        }
    }
    public static void Main(string[] args)
    {
        Console.WriteLine ("Try programiz.pro");
    }
}