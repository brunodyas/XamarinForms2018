using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_cosultarCEP.Servico.Modelo;
using App01_cosultarCEP.Servico;

namespace App01_cosultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args) {
            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {

                    Endereco end = viaCepServico.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        RESULTADO.Text = string.Format("Endereco: {0}, {1}, {2}, {3}", end.logradouro, end.bairro, end.localidade, end.uf);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "O endereço não foi encontrado para o CEP Informado: " + cep, "OK");
                    }
                }catch(Exception e)
                { DisplayAlert("ERRO CRÍTICO", e.Message, "OK");
                }
            }
            
        }
        private bool isValidCEP(string cep)
        {
            bool valido = true;

           /* if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP inválido! O CEP deve conter 8 caracteres!", "OK");
                valido = false;
            }*/
            int NovoCEP = 0;
            if(!int.TryParse(cep, out NovoCEP))
                {
                DisplayAlert("Erro", "CEP inválido! O CEP deve ser composto apenas por numeros!", "OK");
                valido = false;
            }
            return valido;
        }
    }
}
