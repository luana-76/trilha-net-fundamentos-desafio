using System;
using System.Text.RegularExpressions;

namespace DesafioFundamentos.Models
{
    public class Estacionamento
    {
        private decimal precoInicial = 0;
        private decimal precoPorHora = 0;
        private List<string> veiculos = new List<string>();

        public bool ValidarPlaca(string placa)
        {
            
            //Aceita apenas sem o -, sem espaços e com letras maiúscula
            string padrao = @"^[A-Z]{3}\d{4}[A-Z]?$";

            // Criar um objeto Regex com o padrão
            Regex regex = new Regex(padrao);
            
            // Verificar se a placa corresponde ao padrão
            bool validacao = regex.IsMatch(placa);

            //Verificando se é válido ou não
            if(validacao){

               veiculos.Add(placa);

            }else{

                Console.WriteLine("Placa inválida.");

            }

            return validacao;

        }

        public Estacionamento(decimal precoInicial, decimal precoPorHora)
        {
            this.precoInicial = precoInicial;
            this.precoPorHora = precoPorHora;
        }

        public void AdicionarVeiculo()
        {
 
            Console.WriteLine("Digite a placa do veículo para estacionar:");

            ValidarPlaca(Console.ReadLine());

        }

        public void RemoverVeiculo()
        {
            Console.WriteLine("Digite a placa do veículo para remover:");
            
            string placa = Console.ReadLine();

            // Verifica se o veículo existe
            if (veiculos.Any(x => x.ToUpper() == placa.ToUpper()))
            {
                Console.WriteLine("Digite a quantidade de horas que o veículo permaneceu estacionado:");

                int horas = Convert.ToInt32(Console.ReadLine());
                decimal valorTotal = precoInicial * precoPorHora + horas;

                veiculos.Remove(placa);
                Console.WriteLine($"O veículo {placa} foi removido e o preço total foi de: R$ {valorTotal}");
            }
            else
            {
                Console.WriteLine("Desculpe, esse veículo não está estacionado aqui. Confira se digitou a placa corretamente");
            }
        }

        public void ListarVeiculos()
        {
            // Verifica se há veículos no estacionamento
            if (veiculos.Any())
            {
                Console.WriteLine("Os veículos estacionados são:");
          
                foreach(string veiculo in veiculos){

                    Console.WriteLine(veiculo);

                }

            }
            else
            {
                Console.WriteLine("Não há veículos estacionados.");
            }
        }
    }
}
